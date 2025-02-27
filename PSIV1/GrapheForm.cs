using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Windows.Forms;

namespace PSIV1
{
    public class GrapheForm : Form
    {
        public GrapheForm()
        {
            this.Text = "Affichage du Graphe BFS(Bleu) DFS(Rouge) :";
            this.Size = new Size(900, 900);

            Graphe graphe = new Graphe();
            int X = 600, Y = 400, rad = 350;
            double angleStep = 2 * Math.PI / 34;

            // Création des nœuds disposés en cercle
            for (int i = 0; i < 34; i++)
            {
                int x = X + (int)(rad * Math.Cos(i * angleStep));
                int y = Y + (int)(rad * Math.Sin(i * angleStep));
                graphe.Noeuds.Add(new Noeud(i + 1, x, y));
            }

            // Ajout des liens (d'après les données fournies)
            int[,] donnees = {
                {2, 1}, {3, 1}, {4, 1}, {5, 1}, {6, 1}, {7, 1}, {8, 1}, {9, 1}, {11, 1}, {12, 1}, {13, 1}, {14, 1},
                {18, 1}, {20, 1}, {22, 1}, {32, 1}, {3, 2}, {4, 2}, {8, 2}, {14, 2}, {18, 2}, {20, 2}, {22, 2}, {31, 2},
                {4, 3}, {8, 3}, {9, 3}, {10, 3}, {14, 3}, {28, 3}, {29, 3}, {33, 3}, {8, 4}, {13, 4}, {14, 4}, {7, 5},
                {11, 5}, {7, 6}, {11, 6}, {17, 6}, {17, 7}, {31, 9}, {33, 9}, {34, 9}, {34, 10}, {34, 14}, {33, 15},
                {34, 15}, {33, 16}, {34, 16}, {33, 19}, {34, 19}, {34, 20}, {33, 21}, {34, 21}, {33, 23}, {34, 23},
                {26, 24}, {28, 24}, {30, 24}, {33, 24}, {34, 24}, {26, 25}, {28, 25}, {32, 25}, {32, 26}, {30, 27},
                {34, 27}, {34, 28}, {32, 29}, {34, 29}, {33, 30}, {34, 30}, {33, 31}, {34, 31}, {33, 32}, {34, 32},
                {34, 33}
            };

            for (int i = 0; i < donnees.GetLength(0); i++)
            {
                graphe.AjouterLien(donnees[i, 0], donnees[i, 1]);
            }

            AffichageGraphe Affichage = new AffichageGraphe(graphe)
            {
                Dock = DockStyle.Fill
            };
            this.Controls.Add(Affichage);

            // Trouver le chemin le plus court entre les nœuds 1 et 34 en utilisant le parcours DFS
            List<int> cheminDFS = graphe.ListeDFS(22,31);
            Affichage.MettreAJourCheminDFS(cheminDFS);

            // Trouver le chemin en utilisant le parcours BFS
            List<int> cheminBFS = graphe.ListeBFS(20, 30);
            Affichage.MettreAJourCheminBFS(cheminBFS);
        }
    }
}
