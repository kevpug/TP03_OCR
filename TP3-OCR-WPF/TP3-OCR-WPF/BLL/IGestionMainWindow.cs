namespace TP3_OCR_WPF.BLL
{
    /// <summary>
    /// Auteur:         Kévin Pugliese, Arnaud Labrecque
    /// Description:    Gère l'interaction du MainWindow
    /// Date:           2021-04-07
    /// </summary>
    public interface IGestionMainWindow
    {
        /// <summary>
        /// S'occupe de retourner à l'interface visuelle l'entraînement de GestionClassePerceptron
        /// </summary>
        /// <param name="coordo"></param>
        /// <param name="reponse"></param>
        /// <returns></returns>
        string Entrainement(CoordDessin coordo, string reponse);

        /// <summary>
        /// Charge le fichier afin de fournir à l'application les données initiales
        /// </summary>
        /// <param name="sNomFichier"></param>
        void ChargementInitialDonnees(string sNomFichier);
        /// <summary>
        /// S'occupe de retourner à l'interface visuelle de retourner le résultat des tests des perceptrons 
        /// </summary>
        /// <param name="coordo"></param>
        /// <returns></returns>
        string Tester(CoordDessin coordo);

    }
}
