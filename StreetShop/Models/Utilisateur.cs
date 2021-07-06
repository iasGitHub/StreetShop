using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace GestionStock.Models
{
    public class Utilisateur
    {
        [Key]
        public int Id { get; set; }

        [Display(Name ="Nom de l'utilisateur"), MaxLength(80), Required(ErrorMessage ="*")]
        public string Nom { get; set; }

        [Display(Name = "Prénom de l'utilisateur"), MaxLength(100), Required(ErrorMessage = "*")]
        public string Prenom { get; set; }

        [Display(Name = "l'Email de l'utilisateur"), MaxLength(80), Required(ErrorMessage = "*"), DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        
        public string Idprofil { get; set; }
    }
}