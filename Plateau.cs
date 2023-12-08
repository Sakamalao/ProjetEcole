using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projet_v2
{
    internal class Plateau
    {
        string[,] plateau = new string[8, 8];
        Stack<Position> positions = new Stack<Position>();
        public Plateau(string file)
        {
            toRead(file);
            this.plateau = plateau;
        }

        public Stack<Position> Positions
        {
            get { return positions; }
        }


        public void toWrite(string filename, string[,] matrice)
        {
            try
            {
                StreamWriter writer = new StreamWriter(filename);
                for (int i = 0; i < matrice.GetLength(0); i++)
                {
                    for (int j = 0; j < matrice.GetLength(1); j++)
                    {
                        writer.Write(plateau[i, j] + ",");
                    }
                    writer.WriteLine();
                }
                writer.Close();
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

        }
        /// <summary>
        ///  On doit generer un tableau aléatoire à partir des lettres disponibles dans lettre.txt
        /// </summary>
        public void plateauAléatoire()
        {
            bool b;
            char c;
            Random r = new Random();
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    do
                    {
                        c = Convert.ToChar(r.Next(0, 26) + 65);
                        b = nombreDeLettre(c);
                    } while (b == false);
                    plateau[i, j] = Convert.ToString(c);
                }
            }
        }
        public bool nombreDeLettre(char c)
        {
            StreamReader sReader = null;
            bool b = true;
            string[,] matrice = new string[26, 3];
            try
            {
                string[] lines = File.ReadAllLines("Lettre2.txt");
                for (int j = 0; j < 26; j++)
                {
                    string[] l = lines[j].Split(',');
                    for (int h = 0; h < 3; h++)
                    {              
                        matrice[j, h] = l[h];
                    }
                }
                int nbL = Convert.ToInt32(matrice[char.ToUpper(c) - 65, 1]); //par definition A vaut 65 dans le code ASCII...
                if (nbL == 0)
                {
                    b = false;                    
                }
                else
                {                    
                    nbL--;
                    matrice[char.ToUpper(c)-65, 1] = Convert.ToString(nbL);
                    toWrite("Lettre2.txt",matrice);
                }
            }
            catch (IOException e)
            {
               MessageBox.Show(e.Message);  
            }
            catch (Exception e)
            {
               MessageBox.Show(e.Message);
            }
            finally
            {
                if (sReader != null) { sReader.Close(); }
            }
            return b;
        }

            public void Maj_Plateau()
        {
            for (int i = 7; i > 0; i--)
            {

                for (int j = 0; j < 8; j++)
                {
                    if (plateau[i, j] == " ")
                    {
                        Switch(i, j);
                    }
                }
            }
            toWrite("NouveauTalbeau.csv", plateau);
        }
        private void Switch(int i, int j)
        {
            int n = i;

            while (n > 0 && plateau[i, j] == " ")
            {
                for (int k = i; k > 0; k--)
                {
                    string a = plateau[k, j];
                    plateau[k, j] = plateau[k - 1, j];
                    plateau[k - 1, j] = a;
                }
                n--;
            }

        }
        public void toRead(string filename)
        {
            try
            {
                string[] lines = File.ReadAllLines(filename);
                for (int i = 0; i < 8; i++)
                {
                    string[] l = lines[i].Split(';'); /// Chaque element de chaque ligne sera associé à un tableau
                    for (int j = 0; j < 8; j++)
                    {
                        plateau[i, j] = Convert.ToString(l[j]);
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
        }
        public string toString()
        {
            string s = "";
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    s = s + plateau[i, j] + " ";
                }
                s = s + "\r\n";  ///Windows a besoin du \r en plus pour sauter une ligne
            }
            return s;
        }
    }
}
