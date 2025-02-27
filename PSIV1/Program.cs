using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PSIV1
{
    /// <summary>
    /// Classe principale du programme.
    /// Contient le point d'entrée de l'application.
    /// </summary>
    public static class Programme
    {
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread] // Indique que l'application utilise un modèle d'appartement à un seul thread (nécessaire pour les interfaces graphiques Windows)
        public static void Main()
        {       
            // Démarre l'application en ouvrant la fenêtre principale (MainForm)
            Application.Run(new GrapheForm());
        }
    }
}