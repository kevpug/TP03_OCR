using System.Collections.Generic;
using TP3_OCR_WPF.BLL;

namespace TP3_OCR_WPF.DAL
{
    public interface IGestionFichiers
    {

        /// <summary>
        /// Permet d'extraire un fichier texte dans une matrice pour l'apprentissage automatique.
        /// </summary>
        /// <param name="fichier">Fichier où extraire les données</param>
        List<CoordDessin> ChargerCoordonnees(string fichier);

        /// <summary>
        /// Permet de sauvegarder dans fichier texte, une matrice pour l'apprentissage automatique
        /// </summary>
        /// <param name="fichier">Fichier où extraire les données</param>
        int SauvegarderCoordonnees(string fichier, CoordDessin Coordo);

        /// <summary>
        /// Permet de mélanger aléatoirement les échantillons d'apprentissages(coordonnées) dans le but d'améliorer l'apprentissage.
        /// </summary>
        /// <param name="lstCoord">Les coordonnées à mélanger</param>
        void MelangerEchantillon(List<CoordDessin> lstCoord);
    }
}
