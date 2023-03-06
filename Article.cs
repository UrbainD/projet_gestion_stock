using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionStock
{
    
    public class Article
    {
            public int Reference { get; set; }
            public string Nom { get; set; }
            public double Prix { get; set; }
            public int Quantite { get; set; }

            public Article(int reference, string nom, double prix, int quantite)
            {
                Reference = reference;
                Nom = nom;
                Prix = prix;
                Quantite = quantite;
            }

            public override string ToString()
            {
                return $"{Reference} - {Nom} - {Prix} - {Quantite}";
            }
        
    }
    
}
