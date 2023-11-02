using System.Text.RegularExpressions;
using static SpaceInvadersArmory.Weapon;

namespace SpaceInvadersArmory
{
    public class ArmeImporteur
    {
        public Dictionary<string, int> Dictionnaire { get; set; }

        //constructeur
        public ArmeImporteur()
        {
            Dictionnaire = new Dictionary<string, int>();
        }

        //Méthodes

        //lis les fichier, ajoute au dictionnaire les mots et leur nombre d'occurence
        public void ImportArmesDepuisFichier(string cheminFichier, int LongueurMiniDunMot, string cheminListeNoire, Armory armory)
        {
            Console.WriteLine("Import des armes depuis le fichier " + cheminFichier + "...\n");
            Thread.Sleep(1000);
            //lecture du fichier 
            string[] lignes = File.ReadAllLines(cheminFichier);

            //lecture des mots inclu dans la Liste Noire
            string[] ListeNoire = File.ReadAllLines(cheminListeNoire);
           

            foreach (string ligne in lignes)
            {
                //séparation en mots
                string[] mots = ligne.Split(',');

                foreach (string mot in mots)
                {
                    //le met en lowercase et enlève la ponctuation
                    string motSansPonctuation = Regex.Replace(mot.ToLower(), "[^a-zA-Z0-9_.]+", "", RegexOptions.Compiled);

                    if (motSansPonctuation.Length > LongueurMiniDunMot && !ListeNoire.Contains(motSansPonctuation))
                    {
                        //si le mot est déjà dans le dictionnaire
                        if (Dictionnaire.ContainsKey(motSansPonctuation))
                        {
                            //ajoute 1 à la valeur
                            Dictionnaire[motSansPonctuation]++;
                        }
                        else
                        {
                            //Sinon on l'ajoute
                            Dictionnaire.Add(motSansPonctuation, 1);
                        }
                    }
                }
            }
            //importe les armes depuis le dictionnaire et les créer
            ImportArmesDepuisDictionnaire(armory);
        }
        
        public void ImportArmesDepuisDictionnaire(Armory armory)
        {
            foreach (KeyValuePair<string, int> mot in Dictionnaire)
            {
                Console.WriteLine(mot.Key + " apparait " + mot.Value + " fois");
                Weapon arme = CreerArme(mot.Key);
                armory.AjouterArme(arme);
                Console.WriteLine(arme.ToString()+ "\n");
                Thread.Sleep(333);
            }
        }
        
        public Weapon CreerArme(string mot)
        {
            Random rnd = new Random();
            //Création d'une arme    Nom, Dégats Min, Dégats Max, Type Random entre 0 et 2 , Temps de rechargement Random entre 1 et 3
            Weapon arme = new Weapon(mot, mot.Length, mot.Length * Dictionnaire[mot], (EWeaponType)rnd.Next(0, 3), rnd.Next(1, 4));
            return arme;
        }  
    }
}
