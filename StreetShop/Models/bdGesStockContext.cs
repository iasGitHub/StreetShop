using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;//il faut l'installer grâce au package Nuget : install -Package EntityFramework

namespace GestionStock.Models
{
    public class bdGesStockContext : DbContext
    {
        public bdGesStockContext() : base("cnxGesStock")
        { }

        public DbSet <Produit> produits { get; set; }
        public DbSet<Profil> profils { get; set; }
        public DbSet<Utilisateur> utilisateurs { get; set; }

    }
}