using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Formes
{
    public class Graphe
    {
        int nbnodes;
        char[,] matrix = new char[100, 100];
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
    }
}
