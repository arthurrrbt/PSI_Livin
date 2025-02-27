using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Windows.Forms;

namespace PSIV1
{
    /// <summary>
    /// Classe permettant d'afficher un graphe dans un composant Panel
    /// </summary>
    class AffichageGraphe : Panel
    {
        private Graphe graphe; /// <summary>Référence au graphe à afficher</summary>
        private List<int> cheminLePlusCourt = new List<int>(); /// <summary>Liste des nœuds du chemin le plus court (DFS)</summary>
        private List<int> cheminBFS = new List<int>(); /// <summary>Liste des nœuds du chemin trouvé par BFS</summary>

        /// <summary>
        /// Constructeur prenant un graphe en paramètre et associant l'événement Paint
        /// </summary>
        /// <param name="g">Graphe à afficher</param>
        public AffichageGraphe(Graphe g)
        {
            graphe = g;
            this.Paint += new PaintEventHandler(DessinerGraphe); /// <summary>Attache la méthode de dessin au rafraîchissement du composant</summary>
        }

        /// <summary>
        /// Méthode pour dessiner le graphe dans le Panel
        /// </summary>
        private void DessinerGraphe(object envoyeur, PaintEventArgs e)
        {
            Graphics dessin = e.Graphics;
            Pen styloLiaison = new Pen(Color.Black, 2); /// <summary>Stylo utilisé pour dessiner les arêtes</summary>
            Brush pinceauNoeud = Brushes.LightBlue; /// <summary>Couleur de remplissage des nœuds</summary>
            Font police = new Font("Arial", 12); /// <summary>Police pour les labels des nœuds</summary>

            /// <summary>Dessiner les arêtes normales</summary>
            foreach (var liaison in graphe.Liens)
            {
                dessin.DrawLine(styloLiaison, liaison.Source.Position, liaison.Cible.Position);
            }

            /// <summary>Dessiner les arêtes du chemin le plus court (DFS) en rouge</summary>
            foreach (var lien in graphe.Liens)
            {
                Pen couleurArete = new Pen(Color.Black, 2);
                if (cheminLePlusCourt.Contains(lien.Source.Id) && cheminLePlusCourt.Contains(lien.Cible.Id))
                {
                    couleurArete = new Pen(Color.Red, 4); /// <summary>Arêtes du chemin DFS en rouge plus épais</summary>
                }
                dessin.DrawLine(couleurArete, lien.Source.Position, lien.Cible.Position);
            }

            /// <summary>Dessiner les arêtes du chemin BFS en bleu</summary>
            foreach (var lien in graphe.Liens)
            {
                Pen couleurBFS = new Pen(Color.Blue, 3);
                if (cheminBFS.Contains(lien.Source.Id) && cheminBFS.Contains(lien.Cible.Id))
                {
                    dessin.DrawLine(couleurBFS, lien.Source.Position, lien.Cible.Position);
                }
            }

            /// <summary>Dessiner les nœuds</summary>
            foreach (var noeud in graphe.Noeuds)
            {
                int rayon = 15; /// <summary>Rayon du cercle (30 / 2)</summary>
                dessin.FillEllipse(pinceauNoeud, noeud.Position.X - rayon, noeud.Position.Y - rayon, 30, 30);
                dessin.DrawEllipse(Pens.Black, noeud.Position.X - rayon, noeud.Position.Y - rayon, 30, 30);

                /// <summary>Centrer le texte dans le cercle</summary>
                string texte = noeud.Id.ToString();
                SizeF tailleTexte = dessin.MeasureString(texte, police);
                float textX = noeud.Position.X - (tailleTexte.Width / 2);
                float textY = noeud.Position.Y - (tailleTexte.Height / 2);
                dessin.DrawString(texte, police, Brushes.Black, textX, textY);
            }
        }

        /// <summary>
        /// Met à jour et redessine le chemin DFS
        /// </summary>
        /// <param name="chemin">Liste des nœuds du chemin DFS</param>
        public void MettreAJourCheminDFS(List<int> chemin)
        {
            cheminLePlusCourt = chemin;
            this.Invalidate(); /// <summary>Force le rafraîchissement du dessin</summary>
        }

        /// <summary>
        /// Met à jour et redessine le chemin BFS
        /// </summary>
        /// <param name="chemin">Liste des nœuds du chemin BFS</param>
        public void MettreAJourCheminBFS(List<int> chemin)
        {
            cheminBFS = chemin;
            this.Invalidate(); /// <summary>Force le rafraîchissement du dessin</summary>
        }
    }
}
