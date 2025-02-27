using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSIV1
{

    /// <summary>
    /// Représente une liaison entre deux nœuds dans un graphe.
    /// </summary>
    class Lien
    {
        /// <summary>
        /// Nœud source de la liaison.
        /// </summary>
        public Noeud Source { get; set; }

        /// <summary>
        /// Nœud cible de la liaison.
        /// </summary>
        public Noeud Cible { get; set; }

        /// <summary>
        /// Constructeur de la classe Lien.
        /// Initialise une liaison entre deux nœuds.
        /// </summary>
        /// <param name="source">Le nœud source.</param>
        /// <param name="cible">Le nœud cible.</param>
        public Lien(Noeud source, Noeud cible)
        {
            Source = source;
            Cible = cible;
        }
    }
}
