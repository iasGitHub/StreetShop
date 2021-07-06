using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionStock.Models
{
    public class Produit
    {    

        [Key]//DataAnnotations
        public int IdProduit { get; set; }

        [Display(Name ="Désignation"), MaxLength(200), Required(ErrorMessage = "La désignation du produit est obligatoire")]
        public string Designation { get; set; }

        [Display(Name = "Quantité en stock"), Required(ErrorMessage = "La quantité du produit est obligatoire")]
        public double QteStock { get; set; }

        [Display(Name = "Quantité minimale"), Required(ErrorMessage = "La quantité minimale du produit est obligatoire")]
        public double QteMin { get; set; }

        [DataType(DataType.Date), Required(ErrorMessage = "La date est obligatoire")]
        public DateTime DatePeremption { get; set; }

    }
}