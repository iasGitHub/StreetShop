using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestionStock.Models
{
    public class ListeDesProduits
    {
        public int? id { get; set; }
        public string Designation { get; set; }
        public string QteStock { get; set; }
        public string QteMin { get; set; }
        public DateTime? DatePeremption { get; set; }

    }
}