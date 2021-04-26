namespace TP3_OCR_WPF.BLL
{
    public class GestionMainWindow : IGestionMainWindow
    {
        GestionClassesPerceptrons _gestionClassesPerceptrons = new GestionClassesPerceptrons();

        /// <summary>
        /// Charge le fichier afin de fournir à l'application les données initiales
        /// </summary>
        /// <param name="sNomFichier"></param>
        public void ChargementInitialDonnees(string sNomFichier)
        {
            _gestionClassesPerceptrons.ChargerCoordonnees(sNomFichier);
        }

        /// <summary>
        /// S'occupe de retourner à l'interface visuelle l'entraînement de GestionClassePerceptron
        /// </summary>
        /// <param name="coordo"></param>
        /// <param name="reponse"></param>
        /// <returns></returns>
        public string Entrainement(CoordDessin coordo, string reponse)
        {
            coordo.Reponse = reponse;
            _gestionClassesPerceptrons.SauvegarderCoordonnees(CstApplication.NOM_FICHIER_ENTRAIMENT, coordo);

            return _gestionClassesPerceptrons.Entrainement(coordo, reponse);
        }

        /// <summary>
        /// S'occupe de retourner à l'interface visuelle de retourner le résultat des tests des perceptrons 
        /// </summary>
        /// <param name="coordo"></param>
        /// <returns></returns>
        public string Tester(CoordDessin coordo)
        {
            return _gestionClassesPerceptrons.TesterPerceptron(coordo);
        }
    }
}
