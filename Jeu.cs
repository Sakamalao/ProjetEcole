using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projet_v2
{
    
    internal class Jeu
    {
        public Jeu()
        {

        }
        public void copieFichier()
        {
            try
            {
                File.Copy(@"Lettre.txt", @"Lettre2.txt", true);
            }
            catch (Exception e)
            {

                MessageBox.Show((e.Message));
            }
            
        }
    }
}
