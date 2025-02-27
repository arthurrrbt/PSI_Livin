using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSIV1
{

    /// <summary>
    /// Représente un nœud dans un graphe.
    /// </summary>
    class Noeud
    {
        /// <summary>
        /// Identifiant unique du nœud.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Position du nœud dans l'espace (coordonnées X et Y).
        /// </summary>
        public Point Position { get; set; }

        /// <summary>
        /// Constructeur de la classe Noeud.
        /// Initialise un nœud avec un identifiant et une position donnée.
        /// </summary>
        /// <param name="id">Identifiant du nœud.</param>
        /// <param name="x">Coordonnée X du nœud.</param>
        /// <param name="y">Coordonnée Y du nœud.</param>
        public Noeud(int id, int x, int y)
        {
            Id = id;
            Position = new Point(x, y);
        }
    }
}
