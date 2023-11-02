namespace Robert_Alexandre_TP1
{
    public class SpaceInvaders
    {
        //création liste joueurs
        private List<Player> ListePlayer { get; set; }

        //constructeur vide
        public SpaceInvaders() 
        {
        }

        //initialisation joueurs
        private void Init()
        {
            ListePlayer = new List<Player>();
            ListePlayer.Add(new Player("tzUyU", "chou", "FreshKiwi"));
            ListePlayer.Add(new Player("mOmo", "HiRai", "Peach_88"));
            ListePlayer.Add(new Player("nayeon", "im", "bunnie.Unnie"));
        }

        //--------------------MAIN--------------------// 
        static void Main()
        {
            SpaceInvaders jeu = new SpaceInvaders();
            jeu.Init();                                     //création liste joueurs

            Armory armory = new Armory();                   //création armurerie + ajout des armes (Init() dans le constructeur)
            armory.ViewArmory();                            //affichage de l'armurerie

            //affiche les joueur
            Console.WriteLine("Liste des joueurs : \n");    //affichage liste joueur
            foreach (Player player in jeu.ListePlayer)
            {
                Console.WriteLine(player.ToString());
            }
            Console.WriteLine("\n");

            //ajout d'arme au vaisseau d'un joueur (choix arme entre 0, 1 et 2)
            Console.WriteLine("Ajout des armes aux vaisseau...");
            jeu.ListePlayer[0].PlayerSpaceship.addWeaponFromArmory(armory.ListeWeapons[0]); //mitrailleuses
            jeu.ListePlayer[0].PlayerSpaceship.addWeaponFromArmory(armory.ListeWeapons[1]); //missiles
            jeu.ListePlayer[0].PlayerSpaceship.addWeaponFromArmory(armory.ListeWeapons[2]); //lasers
            jeu.ListePlayer[0].PlayerSpaceship.ViewArmory();                                //toutes les armes du vaisseau
            Console.WriteLine("Retrait des mitrailleuses");                                  
            jeu.ListePlayer[0].PlayerSpaceship.RemoveWeapon(armory.ListeWeapons[0]);        //retrait de mitrailleuses
            jeu.ListePlayer[0].PlayerSpaceship.ViewArmory();                                //toutes les armes du vaisseau
                                                                                          
            //affichage vaisseau d'un joueur
            Console.WriteLine(jeu.ListePlayer[0].ViewShip()); //infos du vaisseau du joueur 0
        }

    }
}

  