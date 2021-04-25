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
            throw new NotImplementedException();
        }
    }
}
