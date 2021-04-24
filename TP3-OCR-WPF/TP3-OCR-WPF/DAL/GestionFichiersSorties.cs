﻿using System;
using System.Collections.Generic;
using System.IO;
using TP3_OCR_WPF.BLL;

namespace TP3_OCR_WPF.DAL
{
    /// <summary>
    /// Cette classe gère l'accès aux disques pour le fichiers d'apprentissages. 
    /// Permet de charger ou décharger dans la matrice d'apprentissage.
    /// </summary>
    public class GestionFichiersSorties
    {
        private List<CoordDessin> _lstCoord;
        /// <summary>
        /// Permet d'extraire un fichier texte dans une matrice pour l'apprentissage automatique.
        /// </summary>
        /// <param name="fichier">Fichier où extraire les données</param>
        public List<CoordDessin> ChargerCoordonnees(string fichier)
        {
            _lstCoord = new List<CoordDessin>();

            StreamReader lecteur = new StreamReader(fichier);
            string sLigne = "";
            string[] sTabElements = null;
            //BD = new BDApprentissageAuto();
            //if (!lecteur.EndOfStream)
            //{
            //    sLigne = lecteur.ReadLine();
            //    BD.NBElements = Convert.ToInt32(sLigne);
            //    sLigne = lecteur.ReadLine();
            //    BD.NBAttributs = Convert.ToInt32(sLigne);
            //    BD.Elements = new double[BD.NBElements, BD.NBAttributs - 1];
            //    BD.Resultats = new int[BD.NBElements];
            //    for (int i = 0; i < BD.NBElements; i++)
            //    {
            //        sLigne = lecteur.ReadLine();
            //        sTabElements = sLigne.Split('\t');
            //        for (int j = 0; j < sTabElements.Length - 1; j++)
            //            BD.Elements[i, j] = Convert.ToDouble(sTabElements[j]);
            //        BD.Resultats[i] = Convert.ToInt32(sTabElements[sTabElements.Length - 1]);
            //    }
            //}


            //À COMPLÉTER
            return _lstCoord;
        }

        /// <summary>
        /// Permet de sauvegarder dans fichier texte dans une matrice pour l'apprentissage automatique
        /// </summary>
        /// <param name="fichier">Fichier où extraire les données</param>
        public int SauvegarderCoordonnees(string fichier, List<CoordDessin> lstCoord)
        {
            //À COMPLÉTER
            return CstApplication.OK;
        }

        /// <summary>
        /// Permet d'extraire un fichier texte dans une matrice pour l'apprentissage automatique.
        /// </summary>
        public IList<CoordDessin> ObtenirCoordonnees()
        {


            return _lstCoord;
        }


        /// <summary>
        /// Permet de mélanger aléatoirement les échantillons d'apprentissages(coordonnées) dans le but d'améliorer l'apprentissage.
        /// </summary>
        /// <param name="lstCoord">Les coordonnées à mélanger</param>
        private void MelangerEchantillon(List<CoordDessin> lstCoord)
        {
            Random r1 = new Random();
            Random r2 = new Random();
            int index1;
            int index2;
            CoordDessin coordTemp;

            for (int i = 0; i < CstApplication.MAXITERATION; i++)
            {
                index1 = r1.Next(lstCoord.Count);
                index2 = r2.Next(lstCoord.Count);

                coordTemp = lstCoord[index1];
                lstCoord[index1] = lstCoord[index2];
                lstCoord[index2] = coordTemp;
            }
        }

    }

}
