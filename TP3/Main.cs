using Robert_Alexandre_TP2;
using SpaceInvadersArmory;
using System.Configuration;
using System.Xml;

namespace Robert_Alexandre_TP3
{
    internal class Main2
    {
        static void Main(string[] args)
        {
            string cheminNomArmes;
            string cheminListeNoireNomArmes;
            
            //demander s'il veut entrer les chemins des fichiers
            Console.WriteLine("Voulez-vous entrer des chemins spécifiques des fichiers? (O/N)");
            string choix = Console.ReadLine();
            
            if (choix == "O")
            {
                Console.WriteLine("Entrez le chemin du fichier contenant les noms des armes:");
                cheminNomArmes = Console.ReadLine();
                Console.WriteLine("Entrez le chemin du fichier contenant la liste noire des armes:");
                cheminListeNoireNomArmes = Console.ReadLine();
            }
            else if (choix == "N")
            {
                string cheminApp = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
                cheminNomArmes = cheminApp + "\\NomArmes.txt";
                cheminListeNoireNomArmes = cheminApp + "\\ListeNoireNomArmes.txt";
                Console.WriteLine("Les chemins par défaut vont être appliqués");
                Thread.Sleep(1000);
            }
            else
            {
                Console.WriteLine("Choix invalide");
                return;
            }


            Armory armory = new Armory();
            ArmeImporteur import = new ArmeImporteur();

            try
            {
                import.ImportArmesDepuisFichier(cheminNomArmes, 3, cheminListeNoireNomArmes, armory);
                armory.ViewArmoryDetail();
                armory.ViewTop5();
                armory.ViewTop5Min();
            }
            catch (Exception e)
            {
                Console.WriteLine("Erreur: " + e.Message);
            }
        }
    }
}
