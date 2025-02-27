using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PSIV1
{
    /// <summary>
    /// Classe principale du programme.
    /// Contient le point d'entr�e de l'application.
    /// </summary>
    public static class Programme
    {
        /// <summary>
        /// Point d'entr�e principal de l'application.
        /// </summary>
        [STAThread] // Indique que l'application utilise un mod�le d'appartement � un seul thread (n�cessaire pour les interfaces graphiques Windows)
        public static void Main()
        {       
            // D�marre l'application en ouvrant la fen�tre principale (MainForm)
            Application.Run(new GrapheForm());
        }
    }
}