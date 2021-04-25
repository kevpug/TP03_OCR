using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP3_OCR_WPF.BLL;

namespace TP3_OCR_WPF.DAL
{
    public interface IGestionFichiers
    {
        List<CoordDessin> ChargerCoordonnees(string fichier);
        int SauvegarderCoordonnees(string fichier, CoordDessin Coordo);
        IList<CoordDessin> ObtenirCoordonnees();
        void MelangerEchantillon(List<CoordDessin> lstCoord);
    }
}
