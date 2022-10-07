using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Formes
{
    public class Graphe
    {
        public int nbnodes;
        public char[,] matrix = new char[100, 100];
        // on s’autorise 100 nœuds maximum
        // Méthode appelée pour créer la matrice d’adjacence
        // Le paramètre Myfile est typiquement le chemin complet du fichier texte à lire
        // Vous pouvez cependant vous contenter du nom du fichier si vous placez le fichier à lire
        // dans le même dossier que l’exécutable (le .exe se trouve dans bin)
        public Graphe(string myfile)
        {
            // Si le fichier n'existe pas, on ne va pas plus loin !
            if (File.Exists(myfile) == false) return;
            // Création d'une instance de StreamReader pour permettre la
            // lecture dans le fichier toto. A vous de donner le nom approprié
            // Notez que le dossier par défaut est celui de /bin/debug
            StreamReader monStreamReader = new StreamReader(myfile);
            string ligne = monStreamReader.ReadLine();
            nbnodes = Convert.ToInt32(ligne); // Nombre de nœuds du graphe
            for (int i = 0; i < nbnodes; i++)
                for (int j = 0; j < nbnodes; j++)
                    matrix[i, j] = '0'; // On initialise à « 0 »
            ligne = monStreamReader.ReadLine();
            while (ligne != null) // Tant qu’il reste une ligne dans le fichier
            {
                int x = Convert.ToInt32(ligne);
                ligne = monStreamReader.ReadLine();
                int y = Convert.ToInt32(ligne);
                ligne = monStreamReader.ReadLine();
                matrix[x, y] = ligne[0];// C’est « d » ou « b » normalement
                ligne = monStreamReader.ReadLine();
            }
            // Fermeture du StreamReader (obligatoire)
            monStreamReader.Close();
        }
        private bool EstuneextremiteBasse(int n)
        {
            int cptbSortant = 0;
            int cptbEntrant = 0;
            int cptdSortant = 0;
            int cptdEntrant = 0;
            for (int i = 0; i < nbnodes; i++)
            {
                if (matrix[n, i] == 'b')
                {
                    cptbSortant++;
                }
                if (matrix[n, i] == 'd')
                {
                    cptdSortant++;
                }
                if (matrix[i, n] == 'b')
                {
                    cptbEntrant++;
                }
                if (matrix[i, n] == 'd')
                {
                    cptdEntrant++;
                }
            }
            return (cptbSortant == 0) && (cptbEntrant == 1) && (cptdEntrant == 0) && (cptdSortant == 0);
        }
        private bool EstuneextremiteHaute(int n)
        {
            int cptbSortant = 0;
            int cptbEntrant = 0;
            int cptdSortant = 0;
            int cptdEntrant = 0;
            for (int i = 0; i < nbnodes; i++)
            {
                if (matrix[n, i] == 'b')
                {
                    cptbSortant++;
                }
                if (matrix[n, i] == 'd')
                {
                    cptdSortant++;
                }
                if (matrix[i, n] == 'b')
                {
                    cptbEntrant++;
                }
                if (matrix[i, n] == 'd')
                {
                    cptdEntrant++;
                }
            }
            return (cptbSortant == 1) && (cptbEntrant == 0) && (cptdEntrant == 0) && (cptdSortant == 0);
        }
        private bool EstuneextremiteDroite(int n)
        {
            int cptbSortant = 0;
            int cptbEntrant = 0;
            int cptdSortant = 0;
            int cptdEntrant = 0;
            for (int i = 0; i < nbnodes; i++)
            {
                if (matrix[n, i] == 'b')
                {
                    cptbSortant++;
                }
                if (matrix[n, i] == 'd')
                {
                    cptdSortant++;
                }
                if (matrix[i, n] == 'b')
                {
                    cptbEntrant++;
                }
                if (matrix[i, n] == 'd')
                {
                    cptdEntrant++;
                }
            }
            return (cptbSortant == 0) && (cptbEntrant == 0) && (cptdEntrant == 1) && (cptdSortant == 0);
        }
        private bool EstuneextremiteGauche(int n)
        {
            int cptbSortant = 0;
            int cptbEntrant = 0;
            int cptdSortant = 0;
            int cptdEntrant = 0;
            for (int i = 0; i < nbnodes; i++)
            {
                if (matrix[n, i] == 'b')
                {
                    cptbSortant++;
                }
                if (matrix[n, i] == 'd')
                {
                    cptdSortant++;
                }
                if (matrix[i, n] == 'b')
                {
                    cptbEntrant++;
                }
                if (matrix[i, n] == 'd')
                {
                    cptdEntrant++;
                }
            }
            return (cptbSortant == 0) && (cptbEntrant == 0) && (cptdEntrant == 0) && (cptdSortant == 1);

        }
        public int NbextremiteBasse()
        {
            int nb = 0;
            for (int i = 0; i < nbnodes; i++)
            {
                if (EstuneextremiteBasse(i))
                {
                    nb++;
                }
            }
            return nb;
        }
        public int NbextremiteGauche()
        {
            int nb = 0;
            for (int i = 0; i < nbnodes; i++)
            {
                if (EstuneextremiteGauche(n: i))
                {
                    nb++;
                }
            }
            return nb;
        }
        public int NbextremiteDroite()
        {
            int nb = 0;
            for (int i = 0; i < nbnodes; i++)
            {
                if (EstuneextremiteDroite(i))
                {
                    nb++;
                };
            }
            return nb;
        }
        public int NbextremiteHaute()
        {
            int nb = 0;
            for (int i = 0; i < nbnodes; i++)
            {
                if (EstuneextremiteHaute(i))
                {
                    nb++;
                }
            }
            return nb;
        }
        public string Estnombre()
        {
            if ((this.NbextremiteBasse() == 1) && (this.EstuneextremiteHaute() == 1) && (this.NbextremiteDroite() == 0) && (this.EstuneextremiteGauche() == 0))
            {
                return "Mes conaissances disent que c'est un 1";
            }
            else
            {
                Console.WriteLine("Lol ça marche pas");
            }
        }
    }
}
