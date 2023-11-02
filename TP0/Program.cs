
using Microsoft.VisualBasic;
using System.Drawing;
using System.Threading;
using System.Security.Cryptography.X509Certificates;
using static System.Net.Mime.MediaTypeNames;

internal class Program
{
    private static void Main(string[] args)
    {
        int run = 1;
        while (run == 1)
        {
            //question 1
            Console.WriteLine("Bienvenue sur mon programme, jeune étranger imberbe");

            //question 2
            Console.WriteLine("Quel est ton prénom?");          //le prénom est demandée        
            String prenomUtilisateur = Console.ReadLine();      //le prénom est recupéré
            Console.WriteLine("Quel est ton nom?");             //le nom est demandé
            String nomUtilisateur = Console.ReadLine();

            while (prenomUtilisateur.Any(char.IsDigit) == true
                || nomUtilisateur.Any(char.IsDigit) == true
                || nomUtilisateur == ""
                || prenomUtilisateur == "")
            {
                Console.WriteLine("Ton prénom et nom doivent être écrit en lettre");
                Console.WriteLine("Quel est ton prénom?");
                prenomUtilisateur = Console.ReadLine();
                Console.WriteLine("Quel est ton nom?");
                nomUtilisateur = Console.ReadLine();
            }

            //question 3
            Console.WriteLine(PrenomNOM(prenomUtilisateur, nomUtilisateur));    //utilisation de la fonction PrenomNOM

            //question 4
            Console.WriteLine("Quel est ta taille en cm?");                     //la taille est demandée
            string tailleUtilisateurString = Console.ReadLine();                //la valeur est récupérée
            bool tailleEstNombre = int.TryParse(tailleUtilisateurString, out _);
            while (!tailleEstNombre)
            {
                Console.WriteLine("En centimètres je t'ai dit");                //la taille est demandée
                tailleUtilisateurString = Console.ReadLine();
                if (int.TryParse(tailleUtilisateurString, out _) == true)
                {
                    break;
                }
            }
            float tailleUtilisateur = float.Parse(tailleUtilisateurString);
            Console.WriteLine("T'es serieux ? " + tailleUtilisateur + "cm ?");


            Console.WriteLine("Quel est ton poids en kg?");
            string poidsUtilisateurString = Console.ReadLine();
            bool poidsEstNombre = int.TryParse(poidsUtilisateurString, out _);
            while (!poidsEstNombre)
            {
                Console.WriteLine("En kg je t'ai dit");
                poidsUtilisateurString = Console.ReadLine();
                if (int.TryParse(poidsUtilisateurString, out _) == true)
                {
                    break;
                }
            }
            float poidsUtilisateur = float.Parse(poidsUtilisateurString);
            Console.WriteLine("Tu peux mieux faire que " + poidsUtilisateur + " kg tbh");




            Console.WriteLine("Quel est ton age en années vieux chenapan ?");
            String ageUtilisateurString = Console.ReadLine();
            bool ageEstNombre = int.TryParse(ageUtilisateurString, out _);
            while (!ageEstNombre)
            {
                Console.WriteLine("En années je t'ai dit");     //la taille est demandée
                ageUtilisateurString = Console.ReadLine();
                if (int.TryParse(ageUtilisateurString, out _) == true)
                {
                    break;
                }
            }
            int ageUtilisateur = int.Parse(ageUtilisateurString);

            //question 5
            Console.WriteLine(EstMajeur(ageUtilisateur));
            float imc = IMC(poidsUtilisateur, tailleUtilisateur);
            Console.WriteLine("Ton IMC est de " + imc + ".");

            //question 9
            CommentaireIMC(imc);

            //question 10
            for (int i = 0; ; i++)                                          //boucle
            {
                Console.WriteLine("Ta combien de cheveux ?");
                string nbrCheveuxString = Console.ReadLine();

                if (int.TryParse(nbrCheveuxString, out _) == true)          //si c'est un nombre
                {
                    int nbrCheveuxInt = int.Parse(nbrCheveuxString);        //converti string en int

                    if (nbrCheveuxInt > 99999 && nbrCheveuxInt < 150000)    //conditions
                    {
                        break;
                    }
                    if (nbrCheveuxInt > 0 && nbrCheveuxInt < 100000)
                    {
                        Console.WriteLine("C'est plus");
                    }
                    else if (nbrCheveuxInt > 150000)
                    {
                        Console.WriteLine("C'est moins");
                    }
                    else
                    {
                        Console.WriteLine("Te fous pas de moi");
                    }
                }
                else                                                        //si n'est pas un nombre
                {
                    Console.WriteLine("Faut une valeur numérique");
                }
            }

            //question 11
            Console.WriteLine("Choisissez une option: \n" +
                "1. Quitter le programme (q)\n" +
                "2. Recommencer le programme (r)\n" +
                "3. Compter jusqu’à 10 (c)\n" +
                "4. Téléphoner à Tata Jacqueline (t)\n");
            string option = Console.ReadLine();

            switch (option)
            {
                case "q":
                    Console.WriteLine("Au revoir !");
                    Thread.Sleep(3000);
                    return;


                case "r":
                    Console.WriteLine("On recommence !");
                    break;


                case "c":
                    Console.WriteLine("Compte à rebours avant sortie");
                    for (int i = 10; i > 0; i--)
                    {
                        Console.WriteLine(i);
                        Thread.Sleep(1000);
                    }
                    return;


                case "t":
                    Console.WriteLine("Appel...");
                    for (int i = 3; i > 0; i--)
                    {
                        Console.WriteLine("Beeeeeep");
                        Thread.Sleep(3000);
                    }
                    Console.WriteLine("Jacqueline n'est pas disponible pour le moment");
                    Console.WriteLine("Recommencer le programme (r) ou quitter (q) ?");
                    string choix = Console.ReadLine();
                    if (choix == "r")
                    {
                        Console.WriteLine("On recommence !");
                        break;
                    }
                    else if (choix == "q")
                    {
                        Console.WriteLine("Arrêt du programme");
                        Thread.Sleep(3000);
                        return;
                    }
                    else
                    {
                        Console.WriteLine("l'entrée ne correspond à aucune option");
                        Console.WriteLine("On recommence !");
                        break;
                    }
         

            }

        }

    }


    //question 5
    //fonction qui retourne un message lorsque un nombre en dessous de 18 est spécifié lorsque l'age est demandé
    public static string EstMajeur(int age) => age < 18 ? "En plus de ça t'es mineur !?" : "Parfait.";

    //question 6
    //cette fonction retourne le prénom en minuscule suivi du nom en majuscule
    public static string PrenomNOM(string prenom, string nom)
    {
        return nom.ToUpper() + " " + prenom.ToLower();
    }
    
    //question 7
    // cette fonction retourne l'imc à partir deu poids et de la taille entré en paramètres
    public static float IMC(float poids, float taille)
    {
        float imc = (poids / ((taille / 100) * (taille / 100)));
        //question 8
        string imcString = imc.ToString("0.0");     //limite à 0.0 en le transformant en type string
        imc = float.Parse(imcString);               //modifie le type pour le retourner en float
        return imc;
    }

    //question 9
    //cette fonction permet d'afficher un commentaire différent selon l'IMC
    public static void CommentaireIMC(float val_imc)
    {
        //déclaration des constantes
        const string un = "Attention à l’anorexie!";
        const string deux = "Vous êtes un peu maigrichon !";
        const string trois = "Vous êtes de corpulence normale !";
        const string quatre = "Vous êtes en surpoids !";
        const string cinq = "Obésité modérée !";
        const string six = "Obésité sévère !";
        const string sept = "Obésité morbide !";

        switch (val_imc)
        {
            case < 16.5f:                   //si imc inférieur à 16.5
                Console.WriteLine(un);      //commentaire un
                break;                      //arrêt (ne continue que si supérieur à 16.5)

            case < 18.5f:                   //si imc inférieur à 18.5 (et supérieur à 16.5 donc)
                Console.WriteLine(deux);    //commentaire deux
                break;                      //arrêt (ne continue que si supérieur à 18.5)

            case < 25:
                Console.WriteLine(trois);
                break;

            case < 30:
                Console.WriteLine(quatre);
                break;

            case < 35:
                Console.WriteLine(cinq);
                break;

            case < 40:
                Console.WriteLine(six);
                break;

            case >= 40:
                Console.WriteLine(sept);
                break;
        }

    }

}