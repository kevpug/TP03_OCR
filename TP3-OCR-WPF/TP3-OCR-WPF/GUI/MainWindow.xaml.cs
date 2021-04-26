using System.Windows;
using TP3_OCR_WPF.BLL;

namespace TP3_OCR_WPF.GUI
{
    /// <summary>
    /// Permet d'afficher l'interface pour la reconnaissance de caractères. 
    /// Cet interface fera appel au Perceptron pour identifier le caractère dessiné.
    /// </summary>
    public partial class MainWindow : Window
    {
        // Le gestionnaire des perceptrons.
        private IGestionMainWindow _gestionMainWindows;
        public MainWindow()
        {
            InitializeComponent();
            _gestionMainWindows = new GestionMainWindow();
            _gestionMainWindows.ChargementInitialDonnees(CstApplication.NOM_FICHIER_ENTRAIMENT);

            ucDessin.Width = CstApplication.TAILLEDESSINX + 6;
            ucDessin.Height = CstApplication.TAILLEDESSINY + 6;

        }

        /// <summary>
        /// Efface le caractère dessiné et sa matrice.
        /// </summary>
        /// <param name="sender">L'objet qui à envoyé cet événement.</param>
        /// <param name="e">Les arguments de cet événement.</param>

        private void btnEffacer_Click(object sender, RoutedEventArgs e)
        {
            ucDessin.EffacerDessin();
        }
        /// <summary>
        /// Entraine le bon Perceptron avec la valeur entrée dans le TextBox txtValeurEntrainee et le caractère dessiné.
        /// </summary>
        /// <param name="sender">L'objet qui à envoyé cet événement.</param>
        /// <param name="e">Les arguments de cet événement.</param>
        private void btnEntrainement_Click(object sender, RoutedEventArgs e)
        {
            if (!(string.IsNullOrEmpty(txtValeurEntrainee.Text) && txtValeurEntrainee.Text.Length != 1))
                txtConsole.Text = _gestionMainWindows.Entrainement(ucDessin.Coordonnees, txtValeurEntrainee.Text);
            else
                txtConsole.Text = "Assurez-vous d'avoir entré UNE lettre pour la valeur entrainée";

            txtValeurEntrainee.Text = "";
            ucDessin.EffacerDessin();
        }

        /// <summary>
        /// Appel le perceptron pour vérifier quel neuronne identifie le mieux le caractère dessiné.
        /// </summary>
        /// <param name="sender">L'objet qui à envoyé cet événement.</param>
        /// <param name="e">Les arguments de cet événement.</param>
        private void btnTest_Click(object sender, RoutedEventArgs e)
        {
            string sResultat = _gestionMainWindows.Tester(ucDessin.Coordonnees);
            txtConsole.Text = ""; //Efface ce qui a dans la console au cas
            txtValeurTestee.Text = sResultat;
        }
    }
}
