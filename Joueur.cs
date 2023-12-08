using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_v2
{
    internal class Joueur
    {
        string nom;
        int score = 0;
        List<string> motsTrouves = new List<string>();

        public Joueur(string nom)
        {
            this.nom = nom;
        }

        public string Nom
        {
            get { return nom; }
            set { nom = value; }
        }
        public int Score
        {
            get { return score; }
            set { score = value; }
        }

        public List<string> MotsTrouves
        {
            get { return motsTrouves; }
            set { motsTrouves = value; }
        }
        public string toString()
        {
            string s = "Nom : " + this.nom + "\r\nScore : " + this.score + "\r\nMots trouves : ";
            foreach (string mot in motsTrouves)
            {
                s += mot + "\n";
            }
            return s;
        }

        public void Add_Mot(string mot)
        {
            if (Contient(mot) == false)
            {
                motsTrouves.Add(mot);
            }
            else
            {
                Console.WriteLine("ERREUR ce mot a déjà été trouvé !!!");
            }
        }

        public void Add_Score(int val)
        {
            string mot = motsTrouves[motsTrouves.Count() - 1];
            string[,] m = new string[26, 3];
            for (int i = 0; i < mot.Length; i++)
            {
                StreamReader sReader = null;
                try
                {
                    string[] lines = File.ReadAllLines("Lettre.txt");

                    for (int j = 0; j < 26; j++)
                    {
                        string[] l = lines[j].Split(',');
                        for (int h = 0; h < 3; h++)
                        {
                            m[j, h] = Convert.ToString(l[h]);
                        }
                    }
                    score += Convert.ToInt32(m[char.ToUpper(mot[i]) - 65, 2]); //par definition A vaut 65 dans le code ASCII...
                }
                catch (IOException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                finally
                {
                    if (sReader != null) { sReader.Close(); }
                }
            }
            if (mot.Length == 4) { score += 2; }
            if (mot.Length == 5) { score += 4; }
            if (mot.Length == 6) { score += 6; }
            if (mot.Length >= 7) { score += 10; }
        }

        public bool Contient(string mot)
        {
            bool b = false;
            for (int i = 0; i < motsTrouves.Count(); i++)
            {
                if (motsTrouves[i] == mot)
                {
                    b = true;
                }
            }
            return b;
        }
    }
}
