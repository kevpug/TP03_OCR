using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP3_OCR_WPF.BLL
{
    public class GestionMainWindow : IGestionMainWindow
    {
        GestionClassesPerceptrons _gestionClassesPerceptrons = new GestionClassesPerceptrons();
        public void ChargementInitialDonnees(string sNomFichier)
        {
            _gestionClassesPerceptrons.ChargerCoordonnees(sNomFichier);
        }

        public string Entrainement(CoordDessin coordo, string reponse)
        {
            coordo.Reponse = reponse;
            _gestionClassesPerceptrons.SauvegarderCoordonnees(CstApplication.NOM_FICHIER_ENTRAIMENT, coordo);

            return _gestionClassesPerceptrons.Entrainement(coordo, reponse);
        }
    }
}
