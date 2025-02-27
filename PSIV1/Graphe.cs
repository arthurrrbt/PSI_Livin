using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSIV1
{
    class Graphe
    {
        // Liste des nœuds du graphe
        public List<Noeud> Noeuds { get; set; }

        // Liste des liaisons entre les nœuds
        public List<Lien> Liens { get; set; }
        public List<Lien> LiensParcourus { get; set; } // Liens visités en BFS

        /// <summary>
        /// Constructeur de la classe Graphe
        /// Initialise les listes de nœuds et de liaisons
        /// </summary>
        public Graphe()
        {
            Noeuds = new List<Noeud>();
            Liens = new List<Lien>();
            LiensParcourus = new List<Lien>();
        }

        /// <summary>
        /// Ajoute une liaison entre deux nœuds du graphe
        /// </summary>
        /// <param name="idSource">Identifiant du nœud source</param>
        /// <param name="idCible">Identifiant du nœud cible</param>
        public void AjouterLien(int idSource, int idCible)
        {
            // Recherche du nœud source dans la liste des nœuds
            Noeud source = Noeuds.FirstOrDefault(n => n.Id == idSource);

            // Recherche du nœud cible dans la liste des nœuds
            Noeud cible = Noeuds.FirstOrDefault(n => n.Id == idCible);

            // Vérifie si les deux nœuds existent avant d'ajouter la liaison
            if (source != null && cible != null)
            {
                Liens.Add(new Lien(source, cible));
            }
        }
        /// <summary>
        /// Trouve le chemin le plus court entre deux nœuds en utilisant DFS.
        /// </summary>
        /// <param name="idDepart">Identifiant du nœud de départ.</param>
        /// <param name="idArrivee">Identifiant du nœud d'arrivée.</param>
        /// <returns>Liste des identifiants des nœuds formant le chemin le plus court.</returns>
        public List<int> ListeDFS(int idDepart, int idArrivee)
        {
            Noeud depart = Noeuds.FirstOrDefault(n => n.Id == idDepart);
            Noeud arrivee = Noeuds.FirstOrDefault(n => n.Id == idArrivee);

            if (depart == null || arrivee == null)
                return new List<int>(); // Retourne une liste vide si les nœuds n'existent pas

            List<int> cheminActuel = new List<int>();
            List<int> cheminPlusCourt = null;

            // Appel récursif pour explorer les chemins
            DFS(depart, arrivee, cheminActuel, ref cheminPlusCourt);

            return cheminPlusCourt ?? new List<int>(); // Retourne le chemin le plus court trouvé
        }

        /// <summary>
        /// Fonction récursive qui explore les chemins en profondeur.
        /// </summary>
        private void DFS(Noeud courant, Noeud cible, List<int> cheminActuel, ref List<int> cheminPlusCourt)
        {
            cheminActuel.Add(courant.Id); // Ajouter le nœud au chemin actuel

            // Vérifier si nous avons atteint la cible
            if (courant.Id == cible.Id)
            {
                // Vérifier si c'est le chemin le plus court trouvé jusqu'à présent
                if (cheminPlusCourt == null || cheminActuel.Count < cheminPlusCourt.Count)
                {
                    cheminPlusCourt = new List<int>(cheminActuel); // Copier le chemin
                }
            }
            else
            {
                // Explorer tous les voisins du nœud actuel
                foreach (Lien lien in Liens)
                {
                    Noeud voisin = null;

                    // Trouver le nœud voisin
                    if (lien.Source.Id == courant.Id)
                        voisin = lien.Cible;
                    else if (lien.Cible.Id == courant.Id)
                        voisin = lien.Source;

                    // Vérifier que le voisin n'est pas déjà dans le chemin actuel (évite les boucles)
                    if (voisin != null && !cheminActuel.Contains(voisin.Id))
                    {
                        DFS(voisin, cible, cheminActuel, ref cheminPlusCourt);
                    }
                }
            }

            // Retour en arrière (backtracking)
            cheminActuel.RemoveAt(cheminActuel.Count - 1);
        }
        public List<int> ListeBFS(int idDepart, int idArrivee)
        {
            Noeud depart = Noeuds.FirstOrDefault(n => n.Id == idDepart);
            Noeud arrivee = Noeuds.FirstOrDefault(n => n.Id == idArrivee);
            if (depart == null || arrivee == null)
                return new List<int>();

            Queue<List<int>> file = new Queue<List<int>>();
            HashSet<int> visites = new HashSet<int>();
            file.Enqueue(new List<int> { idDepart });
            visites.Add(idDepart);

            while (file.Count > 0)
            {
                List<int> cheminActuel = file.Dequeue();
                int dernierNoeud = cheminActuel.Last();

                if (dernierNoeud == idArrivee)
                    return cheminActuel;

                foreach (Lien lien in Liens)
                {
                    Noeud voisin = (lien.Source.Id == dernierNoeud) ? lien.Cible : (lien.Cible.Id == dernierNoeud ? lien.Source : null);
                    if (voisin != null && !visites.Contains(voisin.Id))
                    {
                        List<int> nouveauChemin = new List<int>(cheminActuel) { voisin.Id };
                        file.Enqueue(nouveauChemin);
                        visites.Add(voisin.Id);
                    }
                }
            }
            return new List<int>();
        }
    }
}
