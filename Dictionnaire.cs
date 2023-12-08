using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Runtime.CompilerServices;

namespace Projet_v2
{
    internal class Dictionnaire
    {
        string langue;
        SortedList<char, List<string>> liste;

        public string Langue
        { get { return langue; } }

        public SortedList<char, List<string>> Liste
        { get { return liste; } }
        public Dictionnaire(string langue)
        {
            liste = new SortedList<char, List<string>>();
            this.langue = langue;
            #region Création des listes correspondant à chaque lettre
            List<string> A = new List<string>();
            List<string> B = new List<string>();
            List<string> C = new List<string>();
            List<string> D = new List<string>();
            List<string> E = new List<string>();
            List<string> F = new List<string>();
            List<string> G = new List<string>();
            List<string> H = new List<string>();
            List<string> I = new List<string>();
            List<string> J = new List<string>();
            List<string> K = new List<string>();
            List<string> L = new List<string>();
            List<string> M = new List<string>();
            List<string> N = new List<string>();
            List<string> O = new List<string>();
            List<string> P = new List<string>();
            List<string> Q = new List<string>();
            List<string> R = new List<string>();
            List<string> S = new List<string>();
            List<string> T = new List<string>();
            List<string> U = new List<string>();
            List<string> V = new List<string>();
            List<string> W = new List<string>();
            List<string> X = new List<string>();
            List<string> Y = new List<string>();
            List<string> Z = new List<string>();
            #endregion
            StreamReader sReader = null;
            try
            {
                sReader = new StreamReader("Mots_Français.txt");
                string line;
                while ((line = sReader.ReadLine()) != null)
                {
                    string[] tab = line.Split(' ');
                    foreach (string mot in tab)
                        switch (Convert.ToChar(mot.Substring(0, 1)))
                        #region Verifie la première lettre de chaque et mot et l'associe au tableau correspondant
                        {
                            case 'A':
                                A.Add(mot);
                                break;
                            case 'B':
                                B.Add(mot);
                                break;
                            case 'C':
                                C.Add(mot);
                                break;
                            case 'D':
                                D.Add(mot);
                                break;
                            case 'E':
                                E.Add(mot);
                                break;
                            case 'F':
                                F.Add(mot);
                                break;
                            case 'G':
                                G.Add(mot);
                                break;
                            case 'H':
                                H.Add(mot);
                                break;
                            case 'I':
                                I.Add(mot);
                                break;
                            case 'J':
                                J.Add(mot);
                                break;
                            case 'K':
                                K.Add(mot);
                                break;
                            case 'L':
                                L.Add(mot);
                                break;
                            case 'M':
                                M.Add(mot);
                                break;
                            case 'N':
                                N.Add(mot);
                                break;
                            case 'O':
                                O.Add(mot);
                                break;
                            case 'P':
                                P.Add(mot);
                                break;
                            case 'Q':
                                Q.Add(mot);
                                break;
                            case 'R':
                                R.Add(mot);
                                break;
                            case 'S':
                                S.Add(mot);
                                break;
                            case 'T':
                                T.Add(mot);
                                break;
                            case 'U':
                                U.Add(mot);
                                break;
                            case 'V':
                                V.Add(mot);
                                break;
                            case 'W':
                                W.Add(mot);
                                break;
                            case 'X':
                                X.Add(mot);
                                break;
                            case 'Y':
                                Y.Add(mot);
                                break;
                            case 'Z':
                                Z.Add(mot);
                                break;
                                #endregion
                        }
                }
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            #region Attibue des clés au tableau correspondant selon la première lettre des mots
            liste.Add('A', A);
            liste.Add('B', B);
            liste.Add('C', C);
            liste.Add('D', D);
            liste.Add('E', E);
            liste.Add('F', F);
            liste.Add('G', G);
            liste.Add('H', H);
            liste.Add('I', I);
            liste.Add('J', J);
            liste.Add('K', K);
            liste.Add('L', L);
            liste.Add('M', M);
            liste.Add('N', N);
            liste.Add('O', O);
            liste.Add('P', P);
            liste.Add('Q', Q);
            liste.Add('R', R);
            liste.Add('S', S);
            liste.Add('T', T);
            liste.Add('U', U);
            liste.Add('V', V);
            liste.Add('W', W);
            liste.Add('X', X);
            liste.Add('Y', Y);
            liste.Add('Z', Z);
            #endregion
            this.liste = liste;
        }


        public string toString()
        {
            List<char> listeDesCles = liste.Keys.ToList<char>();
            string s = "";
            foreach (char c in listeDesCles)
            {
                s = s + "Nombre mots commençant par " + c + ": " + liste[c].Count() + ".\r\n";
            }
            return "Langue: " + langue + "\r\n" + s;

        }

        public bool RechDicoReccursif(string mot, int g, int d)
        {

            mot = mot.ToUpper();
            char c = Convert.ToChar(mot.Substring(0, 1));

            if (g <= d)
            {
                // Utilise une formule robuste pour calculer mid
                int mid = (d + g) / 2;

                // Vérifie si la cible est présente au milieu
                if (liste[c][mid] == mot)
                {
                    return true;
                }

                // Si la cible est plus petite, recherche dans la moitié gauche
                if (String.Compare(liste[c][mid], mot) > 0)
                {
                    return RechDicoReccursif(mot, g, mid - 1);
                }

                // Si la cible est plus grande, recherche dans la moitié droite
                return RechDicoReccursif(mot, mid + 1, d);
            }

            // La cible n'est pas présente dans la liste
            return false;
        }
        private void QuickSort(List<string> liste, int debut, int fin)
        {
            if (debut < fin)
            {
                int pivotIndex = Partition(liste, debut, fin);

                // Tri des sous-tableaux autour du pivot
                QuickSort(liste, debut, pivotIndex - 1);
                QuickSort(liste, pivotIndex + 1, fin);
            }
        }

        private int Partition(List<string> liste, int debut, int fin)
        {
            string pivot = liste[fin];
            int i = debut - 1;

            for (int j = debut; j < fin; j++)
            {
                if (String.Compare(liste[j], pivot) < 0)
                {
                    i++;
                    // Échanger liste[i] et liste[j]
                    string temp = liste[i];
                    liste[i] = liste[j];
                    liste[j] = temp;
                }
            }

            // Échanger liste[i + 1] et liste[fin] (le pivot)
            string tempPivot = liste[i + 1];
            liste[i + 1] = liste[fin];
            liste[fin] = tempPivot;

            return i + 1;
        }
        public void QuickSortAll(SortedList<char, List<string>> liste)
        {
            foreach (char c in liste.Keys)
            {
                QuickSort(liste[c], 0, liste[c].Count - 1);
            }
        }
    }
}
