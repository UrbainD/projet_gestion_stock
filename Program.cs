// See https://aka.ms/new-console-template for more information
using GestionStock;


public class Program
{
    //fonction qui permet de vérifier l'existence d'un article

    static int Rechercher(List<Article> L, int r)
    {
        int prix = -1;
        for (int i = 0; i < L.Count; i++)
        {
            if (L[i].Reference == r)
            {
                prix = i;
                break;
            }
        }
        return prix;
    }

    static void Main(string[] args)
    {
        int choix, reference, quantite, prix;
        double Prix;
        string nom;
        List<Article> Stock = new List<Article>();
        do
        {
            Console.WriteLine("----------- MENU -----------");
            Console.WriteLine("1-Ajouter un article");
            Console.WriteLine("2-Rechercher un article par référence");
            Console.WriteLine("3-Rechercher un article par nom");
            Console.WriteLine("4-Supprimer un article par référence ");
            Console.WriteLine("5-Modifier un article par référence");
            Console.WriteLine("6-Afficher tous les articles");
            Console.WriteLine("7-Quitter");
            Console.Write("Donner votre choix: ");
            choix = int.Parse(Console.ReadLine());
            switch (choix)
            {

                case 1:

                    Console.WriteLine("Donner la référence de l'article à ajouter: ");
                    reference = int.Parse(Console.ReadLine());
                    prix = Rechercher(Stock, reference);
                    if (prix != -1)
                    {
                        Console.WriteLine("Article existe dèjà");
                    }
                    else
                    {
                        Console.WriteLine("Donner le nom : ");
                        nom = Console.ReadLine();
                        Console.WriteLine("Donner le prix: ");
                        Prix = double.Parse(Console.ReadLine());
                        Console.WriteLine("Donner la quantité: ");
                        quantite = int.Parse(Console.ReadLine());
                        Stock.Add(new Article(reference, nom, prix, quantite));
                        Console.WriteLine("Article Ajouté avec succès");
                    }
                    break;


                case 2:

                    Console.WriteLine("Donner la référence de l'article à rechercher: ");
                    reference = int.Parse(Console.ReadLine());
                    prix = Rechercher(Stock, reference);
                    if (prix == -1)
                    {
                        Console.WriteLine("Article introuvable");
                    }
                    else
                    {
                        Console.WriteLine(Stock[prix]);
                    }
                    break;


                case 3:

                    Console.WriteLine("Donner le nom de l'article à rechercher: ");
                    nom = Console.ReadLine();
                    int comp = 0;
                    for (int i = 0; i < Stock.Count; i++)
                    {
                        if (Stock[i].Nom.ToLower() == nom.ToLower())
                        {
                            Console.WriteLine(Stock[i].ToString());
                            comp++;
                        }
                    }
                    if (comp == 0)
                    {
                        Console.WriteLine("Aucun résultat");
                    }
                    break;


                case 4:

                    Console.WriteLine("Donner la référence de l'article à supprimer:");
                    reference = int.Parse(Console.ReadLine());
                    prix = Rechercher(Stock, reference);
                    if (prix == -1)
                    {
                        Console.WriteLine("Article introuvable");
                    }
                    else
                    {
                        //Stock.Remove(Stock[p]);
                        Stock.RemoveAt(prix);
                        Console.WriteLine("Article supprimé avec succès");
                    }
                    break;


                case 5:

                    Console.WriteLine("Entrer la référence de l'article à modifier: ");
                    reference = int.Parse(Console.In.ReadLine());
                    prix = Rechercher(Stock, reference);
                    if (prix == -1)
                    {
                        Console.WriteLine("Article introuvable");
                    }
                    else
                    {   //Proposer un sous menu pour choisir l'attribut à modifier
                        int c;
                        do
                        {
                            Console.WriteLine("*****Options*****");
                            Console.WriteLine("1-Modifier le nom");
                            Console.WriteLine("2-Modifier le prix");
                            Console.WriteLine("3-Modifier la quantité");
                            Console.WriteLine("4-Terminer");
                            Console.Write("Donner votre choix: ");
                            c = int.Parse(Console.ReadLine());
                            switch (c)
                            {
                                case 1:
                                    Console.WriteLine("Donner le nouveau nom: ");
                                    Stock[prix].Nom = Console.ReadLine();
                                    Console.Out.WriteLine("Nom modifié avec succès");
                                    break;
                                case 2:
                                    Console.WriteLine("Donner le prix: ");
                                    Stock[prix].Prix = double.Parse(Console.In.ReadLine());
                                    Console.WriteLine("Prix modifié avec succès");
                                    break;
                                case 3:
                                    Console.WriteLine("Donner la quantité: ");
                                    Stock[prix].Quantite = int.Parse(Console.In.ReadLine());
                                    Console.WriteLine("Quantité modifiée avec succès");
                                    break;
                                case 4:
                                    Console.WriteLine("Modifications terminées");
                                    break;
                                default:
                                    Console.WriteLine("Choix invalide");
                                    break;
                            }

                        }
                        while (c != 4);
                    }
                    break;


                case 6:
                    foreach (Article a in Stock)
                    {
                        Console.WriteLine(a);
                    }
                    if (Stock.Count == 0)
                    {
                        Console.WriteLine("Aucun résultat");
                    }
                    break;


                case 7:
                    Console.WriteLine("Fin du programme");
                    break;
                default:
                    Console.WriteLine("Choix invalide");
                    break;

            }
        } while (choix != 7);
        Console.ReadKey();

    }
}
