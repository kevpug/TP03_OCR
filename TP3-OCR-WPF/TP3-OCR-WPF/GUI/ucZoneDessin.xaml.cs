using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TP3_OCR_WPF.BLL;

namespace TP3_OCR_WPF.GUI
{

    

    /// <summary>
    /// Logique d'interaction pour ucZoneDessin.xaml
    /// </summary>
    public partial class ucZoneDessin : UserControl
    {
        private CoordDessin _coordonnees;
        private Point _pointCourant = new Point();
        public ucZoneDessin()
        {
            InitializeComponent();

            pZoneDessin.Width = CstApplication.TAILLEDESSINX;
            pZoneDessin.Height = CstApplication.TAILLEDESSINX;
            _coordonnees = new CoordDessin(CstApplication.TAILLEDESSINX, CstApplication.TAILLEDESSINY);
        }

        /// <summary>
        /// Ré-initialise le dessin et les composants.
        /// </summary>
        public void EffacerDessin()
        {
            pZoneDessin.Children.Clear();
            _coordonnees = new CoordDessin(CstApplication.TAILLEDESSINX, CstApplication.TAILLEDESSINY);

        }

        /// <summary>
        /// Si l'utilisateur à cliqué, enclenché le processus de dessin pour le MouseMove.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pZoneDessin_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ButtonState == MouseButtonState.Pressed)
                _pointCourant = e.GetPosition(this);
        }

        /// <summary>
        /// Si l'utilisateur a préalablement cliqué, alors dessiner à la position de la souris.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pZoneDessin_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                int coordCorrigeX = (int)e.GetPosition(this).X - ((int)e.GetPosition(this).X % CstApplication.LARGEURTRAIT);
                int coordCorrigeY = (int)e.GetPosition(this).Y - ((int)e.GetPosition(this).Y % CstApplication.LARGEURTRAIT);

                Line line = new Line();
                line.Stroke = SystemColors.WindowFrameBrush;
                line.StrokeThickness = CstApplication.LARGEURTRAIT;
                line.X1 = _pointCourant.X;
                line.Y1 = _pointCourant.Y;
                line.X2 = e.GetPosition(this).X;
                line.Y2 = e.GetPosition(this).Y;
                _pointCourant = e.GetPosition(this);
                pZoneDessin.Children.Add(line);
                _coordonnees.AjouterCoordonnees(coordCorrigeX, coordCorrigeY, CstApplication.LARGEURTRAIT, CstApplication.HAUTEURTRAIT);

            }
        }
    }
}
