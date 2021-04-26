using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace TP3_OCR_WPF.BLL
{
    /// <summary>
    /// Classe du perceptron. Permet de faire l'apprentissage automatique sur un échantillon d'apprentissage. 
    /// </summary>
    public class Perceptron
    {
        private double _cstApprentissage;
        private double[] _poidsSyn;
        private string _reponse = "?";

        public string Reponse
        {
            get { return _reponse; }
        }

        /// <summary>
        /// Constructeur de la classe. Crée un perceptron pour une réponse(caractère) qu'on veut identifier le pattern(modèle)
        /// </summary>
        /// <param name="reponse">La classe que défini le perceptron</param>
        public Perceptron(string reponse)
        {
            _cstApprentissage = CstApplication.CONSTANTEAPPRENTISSAGE;
            _reponse = reponse;
        }

        /// <summary>
        /// Faire l'apprentissage sur un ensemble de coordonnées. Ces coordonnées sont les coordonnées de tous les caractères analysés. 
        /// </summary>
        /// <param name="lstCoord">La liste de coordonnées pour les caractères à analysés.</param>
        /// <returns>Les paramètres de la console</returns>
        public string Entrainement(List<CoordDessin> lstCoord)
        {
            string sResultat = "";
            int iNbErreur = 0;
            int iNbIteration = 0;
            int iResultatEstime = 0;
            int iErreurLocal = 0;
            double dPourcentageReussite = 0.00;
            int NbAttributs = lstCoord[0].BitArrayDessin.Length;

            Random rdn = new Random();
            int NbElements = lstCoord.Count();

            _poidsSyn = new double[NbAttributs];

            //Initialise les poids synaptiques à des valeurs aléatoire
            for (int i = 0; i < _poidsSyn.Length; i++)
                _poidsSyn[i] = rdn.NextDouble();

            do
            {
                iNbErreur = 0;
                foreach (var lettre in lstCoord)
                {
                    iResultatEstime = ValeurEstime(_poidsSyn, lettre.BitArrayDessin);
                    iErreurLocal = (lettre.Reponse == _reponse ? CstApplication.VRAI : CstApplication.FAUX) - iResultatEstime;

                    //Vérifier s'il y a eu une erreur avec l'observation
                    if (iErreurLocal != 0)
                    {
                        //Si on s'est trompé, alors mettre à jour les poids 
                        //synaptiques avec la méthode de descente en gradient.
                        _poidsSyn[0] += _cstApprentissage * iErreurLocal;
                        for (int j = 1; j < _poidsSyn.Length; j++)
                        {
                            _poidsSyn[j] += _cstApprentissage * iErreurLocal * (lettre.BitArrayDessin[j] ? 1 : -1);
                        }
                        iNbErreur++;

                    }
                }
                dPourcentageReussite = ((double)(NbElements - iNbErreur) / (double)(NbElements)) * 100d;


                sResultat = string.Format("\r\nPour le Perceptron '{0}' : le pourcentage de réussite est de {1} %", _reponse, dPourcentageReussite.ToString("0.00"));


                iNbIteration++;
            }
            while (dPourcentageReussite < CstApplication.POURCENTCONVERGENCE && iNbIteration < CstApplication.MAXITERATION);

            return sResultat;
        }

        /// <summary>
        /// Calcul la valeur(vrai ou faux) pour un les coordonnées d'un caractère. Permet au perceptron d'évaluer la valeur de vérité.
        /// </summary>
        /// <param name="vecteurSyn">Les poids synaptiques du perceptron</param>
        /// <param name="entree">Le vecteur de bit correspondant aux couleurs du caractère</param>
        /// <returns>Vrai ou faux</returns>
        public int ValeurEstime(double[] vecteurSyn, BitArray entree)
        {
            //Évaluer une observation et de faire une prédiction.
            double dSum = vecteurSyn[0];
            for (int j = 1; j < vecteurSyn.Length; j++)
            {
                dSum += _poidsSyn[j] * (entree[j] ? 1 : -1);
            }
            return (dSum >= 0) ? CstApplication.VRAI : CstApplication.FAUX;
        }

        /// <summary>
        /// Interroge la neuronnes pour un ensembles des coordonnées(d'un caractère).
        /// </summary>
        /// <param name="coord"></param>
        /// <returns></returns>
        public bool TesterNeurone(CoordDessin coord)
        {
            //Évaluer une observation et de faire une prédiction.
            return ValeurEstime(_poidsSyn, coord.BitArrayDessin) == CstApplication.VRAI ? true : false;
        }
    }
}
