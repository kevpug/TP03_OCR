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
            List<CoordDessin> lstInter = (List<CoordDessin>)lstCoord.Where(r => r.Reponse == _reponse);
            string resultat = "";

            double dSum = 0;
            int iNbErreur = 0;
            int iNbIteration = 0;
            int iResultatEstime = 0;
            int iErreurLocal = 0;
            int NbAttributs = lstCoord[0].BitArrayDessin.Length;
            string sResultat = "";

            Random rdn = new Random();
            int NbElements = lstInter.Count(); // Calcule le nombre d'element dans le fichier ayant la meme lettre que le perceptron

            _poidsSyn = new double[NbAttributs];
            int[] Resultats = new int[NbElements];
            double[,] Elements = new double[NbElements, NbAttributs];


            //Initialise les poids synaptiques à des valeurs aléatoire
            for (int i = 0; i < _poidsSyn.Length; i++)
                _poidsSyn[i] = rdn.NextDouble();

            do
            {
                iNbErreur = 0;
                foreach(var lettre in lstInter)
                {
                    //Évaluer une observation et de faire une prédiction.
                    dSum = _poidsSyn[0];
                    for (int j = 1; j < _poidsSyn.Length; j++)
                    {
                        dSum += _poidsSyn[j] * (lettre.BitArrayDessin[j]? 1:-1);
                    }
                    iResultatEstime = (dSum >= 0) ? 1 : 0;
                    //ValeurEstime(_poidsSyn, lettre.BitArrayDessin);
                    //iErreurLocal = bd.Resultats[i] - iResultatEstime;

                    //Vérifier s'il y a eu une erreur avec l'observation
                    if (iErreurLocal != 0)
                    {
                        //Si on s'est trompé, alors mettre à jour les poids 
                        //synaptiques avec la méthode de descente en gradient.
                        _poidsSyn[0] += _cstApprentissage * iErreurLocal;
                        for (int j = 1; j < _poidsSyn.Length; j++)
                        {
                            _poidsSyn[j] += _cstApprentissage * iErreurLocal * (lettre.BitArrayDessin[j] ? 1:-1);
                        }
                        iNbErreur++;
                    }
                }
                sResultat += string.Format("\r\nIteration {0} \t Erreur {1}", iNbIteration, iNbErreur);
                sResultat += string.Format("\r\nLe taux de succès est {0} %",
                                            ((double)(NbElements - iNbErreur) / (double)(NbElements)) * 100.00);

                iNbIteration++;
            }
            while (iNbErreur > 0 && iNbIteration < 10000);

            return sResultat;
            return resultat;
        }

        /// <summary>
        /// Calcul la valeur(vrai ou faux) pour un les coordonnées d'un caractère. Permet au perceptron d'évaluer la valeur de vérité.
        /// </summary>
        /// <param name="vecteurSyn">Les poids synaptiques du perceptron</param>
        /// <param name="entree">Le vecteur de bit correspondant aux couleurs du caractère</param>
        /// <returns>Vrai ou faux</returns>
        public int ValeurEstime(double[] vecteurSyn, BitArray entree)
        {
            //À COMPLÉTER
            return CstApplication.VRAI;
        }

        /// <summary>
        /// Interroge la neuronnes pour un ensembles des coordonnées(d'un caractère).
        /// </summary>
        /// <param name="coord"></param>
        /// <returns></returns>
        public bool TesterNeurone(CoordDessin coord)
        {
            //À COMPLÉTER
            return CstApplication.VRAI == CstApplication.VRAI ? true : false;
        }

    }
}
