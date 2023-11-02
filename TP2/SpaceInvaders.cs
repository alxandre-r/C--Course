using Models;
using SpaceInvadersArmory;

namespace Robert_Alexandre_TP2
{
    public class SpaceInvaders
    {
        //création joueur, liste ennemis et liste des ennemis vivants
        private List<Player> ListePlayer { get; set; }
        private List<Spaceship> ListeEnnemis { get; set; }
        private List<Spaceship> ListeEnnemisVivants { get; set; }

        //constructeur vide
        public SpaceInvaders() 
        {
        }

        //initialisation joueurs
        private void Init()
        {
            ListePlayer = new List<Player>();
            ListePlayer.Add(new Player("joueur", "1", "Player"));

            ListeEnnemis = new List<Spaceship>();
            ListeEnnemis.Add(new Dart());
            ListeEnnemis.Add(new B_Wings());
            ListeEnnemis.Add(new Rocinante());
            ListeEnnemis.Add(new ViperMKII());
            ListeEnnemis.Add(new Tardis());

            ListeEnnemisVivants = new List<Spaceship>();
            foreach (Spaceship ennemi in ListeEnnemis)
            {
                if (!ennemi.IsDestroyed)
                {
                    ListeEnnemisVivants.Add(ennemi);
                }
            }
        }

        
        //--------------PLAY ROUND -------------//
        
        int tourActuel = 0;
        private void PlayRound()
        {
            tourActuel++;
            Console.WriteLine("------------------------------------");
            Console.WriteLine("               Tour " + tourActuel);
            Console.WriteLine("------------------------------------");
            
            //recharge le shield des vaisseaux ennemis...
            foreach (Spaceship ennemi in ListeEnnemis)
            {
                //si currenthsield < maxshield et si vivant
                if (ennemi.CurrentShield < ennemi.MaxShield && ennemi.IsDestroyed == false)
                {
                    //random entre 0 et 2
                    Random random = new Random();
                    int randomInt = random.Next(0, 3);
                    ennemi.RepairShield(randomInt);
                    Console.WriteLine(ennemi.Name + " + " + randomInt + " points de shield");
                }
            }
            //...et du vaisseau du joueur
            //si currenthsield < maxshield et si vivant
            if (ListePlayer[0].BattleShip.CurrentShield < ListePlayer[0].BattleShip.MaxShield && ListePlayer[0].BattleShip.IsDestroyed == false)
            {
                //random entre 0 et 2
                Random random = new Random();
                int randomInt = random.Next(0, 3);
                ListePlayer[0].BattleShip.RepairShield(randomInt);
                Console.WriteLine(ListePlayer[0].Name + " + " + randomInt + " points de shield");
            }
            Console.WriteLine("Etat de tout les vaisseaux : \n");

            //update de la liste ennemis en vie
            ListeEnnemisVivants.Clear();
            foreach (Spaceship ennemi in ListeEnnemis)
            {
                if (!ennemi.IsDestroyed)
                {
                    ListeEnnemisVivants.Add(ennemi);
                }
            }

            //view ship etat du joueur
            Console.WriteLine(ListePlayer[0].ViewShipEtat());
            //stockage de la structure et shield du vaisseau du joueur pour total damage
            int totalHP = (int)ListePlayer[0].BattleShip.CurrentShield + (int)ListePlayer[0].BattleShip.CurrentStructure;

            //view ship etat de tout les ennemis                                                   
            foreach (Spaceship ennemi in ListeEnnemis)
            {
                Console.WriteLine(ennemi.ViewShipEtat());
            }
            Console.WriteLine("\n");

            // 1/nombre d'ennemis en vie chance de tirer en premier, sinon ennemi
            Random randomPos = new Random();
            int tirerEnPremier = randomPos.Next(1, ListeEnnemisVivants.Count + 1);
            if (tirerEnPremier == 1)
            {
                Console.WriteLine("Vous tirez en premier \n");
                //tire sur un ennemi aléatoire vivant
                Random randomEnnemi = new Random();
                int numEnnemi = randomEnnemi.Next(0, ListeEnnemisVivants.Count);
                ListePlayer[0].BattleShip.ShootTarget(ListeEnnemisVivants[numEnnemi]);

                //update de la liste ennemis en vie
                ListeEnnemisVivants.Clear();
                foreach (Spaceship ennemi in ListeEnnemis)
                {
                    if (!ennemi.IsDestroyed)
                    {
                        ListeEnnemisVivants.Add(ennemi);
                    }
                }
                
                Console.WriteLine("\nAu tour des ennemis \n");
                foreach (Spaceship ennemi in ListeEnnemisVivants)
                {
                    ennemi.ShootTarget(ListePlayer[0].BattleShip);
                    Thread.Sleep(1000);
                }
                // affiche le total des dégats subis par le vaisseau du joueur
                Console.WriteLine("Total des dégats subis : " + (totalHP - (int)ListePlayer[0].BattleShip.CurrentShield - (int)ListePlayer[0].BattleShip.CurrentStructure));
            }
            else //sinon ennemi tir
            {
                Console.WriteLine("L'ennemi tire en premier \n");
                foreach (Spaceship ennemi in ListeEnnemisVivants)
                {
                    ennemi.ShootTarget(ListePlayer[0].BattleShip);
                    Thread.Sleep(1000);
                }
                // affiche le total des dégats subis par le vaisseau du joueur
                Console.WriteLine("Total des dégats subis : " + (totalHP - (int)ListePlayer[0].BattleShip.CurrentShield - (int)ListePlayer[0].BattleShip.CurrentStructure));
                
                Console.WriteLine("\nA votre tour \n");
                //tire sur un ennemi aléatoire vivant
                Random randomEnnemi = new Random();
                int numEnnemi = randomEnnemi.Next(0, ListeEnnemisVivants.Count);
                ListePlayer[0].BattleShip.ShootTarget(ListeEnnemisVivants[numEnnemi]);

            }
        }
        //--------------------MAIN--------------------// 
        static void Main()
        {
            SpaceInvaders jeu = new SpaceInvaders();
            jeu.Init();                                     //création player et ennemis

            Armory armory = new Armory();                   
            //armory.ViewArmory();                            //affichage de l'armurerie

            //affiche le joueur
            jeu.ListePlayer[0].ViewShip();

            //affiche les ennemis
            foreach (Spaceship ennemi in jeu.ListeEnnemis)
            {
                ennemi.ViewShip();
            }

            //affichage avant le début du jeu
            //si c est pressée, clear console
            Console.WriteLine("Appuyez sur Entrée pour commencer le jeu");
            while (Console.ReadKey().Key != ConsoleKey.Enter)
            {
                Console.WriteLine("Appuyez sur Entrée pour commencer le jeu");
            }
            Console.Clear();

            //play round
            //tant que joueur structure > 0 et que il y a des ennemis en vie

            do
            {
                jeu.PlayRound();
                if (jeu.ListePlayer[0].BattleShip.CurrentStructure <= 0)
                {
                    Console.WriteLine("Votre vaisseau à été détruit.. DEFAITE !");
                }
                else if (jeu.ListeEnnemisVivants.Count == 0)
                {
                    Console.WriteLine("Il n'y a plus d'ennemis en vie, VICTOIRE !");
                }
                else
                {
                    Console.WriteLine("\nAppuyez sur Entrée pour passer au tour suivant");
                    while (Console.ReadKey().Key != ConsoleKey.Enter)
                    {
                        Console.WriteLine("\nAppuyez sur Entrée pour passer au tour suivant");
                    }
                    Console.Clear();
                }
            }
            while (jeu.ListePlayer[0].BattleShip.CurrentStructure > 0 && jeu.ListeEnnemisVivants.Count > 0);
        }
    }
}

  