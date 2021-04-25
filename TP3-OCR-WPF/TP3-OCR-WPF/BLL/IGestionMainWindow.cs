using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        /// Entraine les perceptrons avec un nouveau caractère
        /// </summary>
        /// <param name="coordo">Les nouvelles coordonnées</param>
        /// <param name="reponse">La réponse associé(caractère) aux coordonnées</param>
        /// <returns>Le résultat de la console</returns>
        string Entrainement(CoordDessin coordo, string reponse);
        void ChargementInitialDonnees(string sNomFichier);

    }
}
