using System.Collections.Generic;
using TP3_OCR_WPF.DAL;

namespace TP3_OCR_WPF.BLL
{
    /// <summary>
    /// Gère les fonctionnalités de l'application. Entre autre, permet de :
    /// - Charger les échantillons d'apprentissage,
    /// - Sauvegarder les échantillons d'apprentissage,
    /// - Tester le perceptron
    /// - Entrainer le perceptron
    /// </summary>
    public class GestionClassesPerceptrons
    {
        private Dictionary<string, Perceptron> _lstPerceptrons;
        private List<CoordDessin> _lstCoordDessin;
        private IGestionFichiers _gestionSortie;

        /// <summary>
        /// Constructeur
        /// </summary>
        public GestionClassesPerceptrons()
        {
            _lstPerceptrons = new Dictionary<string, Perceptron>();
            _gestionSortie = new GestionFichiersSorties();
            _lstCoordDessin = new List<CoordDessin>();

        }

        /// <summary>
        /// Charge les échantillons d'apprentissage sauvegardé sur le disque.
        /// </summary>
        /// <param name="fichier">Le nom du fichier</param>
        public void ChargerCoordonnees(string fichier)
        {
            _lstCoordDessin = _gestionSortie.ChargerCoordonnees(fichier);
            foreach (var item in _lstCoordDessin)
            {
                if (!_lstPerceptrons.ContainsKey(item.Reponse))
                {
                    _lstPerceptrons.Add(item.Reponse, new Perceptron(item.Reponse));
                }
                _lstPerceptrons[item.Reponse].Entrainement(_lstCoordDessin);
            }
        }

        /// <summary>
        /// Sauvegarde les échantillons d'apprentissage sauvegardé sur le disque.
        /// </summary>
        /// <param name="fichier">Le nom du fichier</param>
        /// <returns>En cas d'erreur retourne le code d'erreur</returns>
        public int SauvegarderCoordonnees(string fichier, CoordDessin coordo)
        {
            int erreur = CstApplication.ERREUR;
            _gestionSortie.SauvegarderCoordonnees(fichier, coordo);

            return erreur;
        }

        /// <summary>
        /// Entraine les perceptrons avec un nouveau caractère
        /// </summary>
        /// <param name="coordo">Les nouvelles coordonnées</param>
        /// <param name="reponse">La réponse associé(caractère) aux coordonnées</param>
        /// <returns>Le résultat de la console</returns>
        public string Entrainement(CoordDessin coordo, string reponse)
        {
            string sConsole = "";
            coordo.Reponse = reponse;
            _lstCoordDessin.Add(coordo);
            if (!_lstPerceptrons.ContainsKey(reponse))
            {
                _lstPerceptrons.Add(reponse, new Perceptron(reponse));
            }
            sConsole = _lstPerceptrons[reponse].Entrainement(_lstCoordDessin);
            return sConsole;
        }


        /// <summary>
        /// Test le perceptron avec de nouvelles coordonnées.
        /// </summary>
        /// <param name="coord">Les nouvelles coordonnées</param>
        /// <returns>Retourne la liste des valeurs possibles du perceptron</returns>
        public string TesterPerceptron(CoordDessin coord)
        {
            string resultat = "";
            foreach (var percep in _lstPerceptrons)
            {
                if (percep.Value.TesterNeurone(coord))
                    resultat += percep.Key + " ";
            }

            if (resultat == "")
                resultat = "?";

            return resultat;
        }

        /// <summary>
        /// Obtient une liste des coordonées.
        /// </summary>
        /// <returns>Une liste des coordonées.</returns>
        public IList<CoordDessin> ObtenirCoordonnees()
        {
            return _gestionSortie.ObtenirCoordonnees();
        }
    }
}
