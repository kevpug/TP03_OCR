﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TP3_OCR_WPF.BLL;

namespace TP3_OCR_WPF.DAL
{
    /// <summary>
    /// Cette classe gère l'accès aux disques pour le fichiers d'apprentissages. 
    /// Permet de charger ou décharger dans la matrice d'apprentissage.
    /// </summary>
    public class GestionFichiersSorties : IGestionFichiers
    {
        private List<CoordDessin> _lstCoord;
        /// <summary>
        /// Permet d'extraire un fichier texte dans une matrice pour l'apprentissage automatique.
        /// </summary>
        /// <param name="fichier">Fichier où extraire les données</param>
        public List<CoordDessin> ChargerCoordonnees(string fichier)
        {

            if (!File.Exists(fichier))
            {
                return null;
            }
            else
            {
                _lstCoord = new List<CoordDessin>();
                StreamReader sr = new StreamReader(fichier);
                string sLigne = "";

                while (!sr.EndOfStream)
                {
                    sLigne = sr.ReadLine();
                    var sSplit = sLigne.Split(':');
                    var Coordonnees = sSplit[1].Split(' ');
                    CoordDessin Coord = new CoordDessin(CstApplication.TAILLEDESSINX, CstApplication.TAILLEDESSINY);
                    Coord.Reponse = sSplit[0];
                    for (int i = 0; i < Coord.BitArrayDessin.Length; i++)
                        Coord.BitArrayDessin[i] = int.Parse(Coordonnees[i]) == 1 ? true: false;

                    _lstCoord.Add(Coord);
                }

            }

            return _lstCoord;
        }

        /// <summary>
        /// Permet de sauvegarder dans fichier texte, une matrice pour l'apprentissage automatique
        /// </summary>
        /// <param name="fichier">Fichier où extraire les données</param>
        public int SauvegarderCoordonnees(string fichier, List<CoordDessin> lstCoord)
        {
            File.WriteAllText(fichier, String.Empty);

            StreamWriter strm = new StreamWriter(fichier);
            

            foreach (var item in lstCoord)
            {
                strm.Write(item.Reponse + ":");

                foreach (var coord in item.BitArrayDessin)
                {
                    if (coord.ToString() == "False")
                    {
                        strm.Write("-1 ");
                    }
                    else
                    {
                        strm.Write("1 ");
                    }
                    //strm.Write(coord.ToString() + " ");
                }
                strm.WriteLine();
            }
            strm.Flush();
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
        public void MelangerEchantillon(List<CoordDessin> lstCoord)
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
