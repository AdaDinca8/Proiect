using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Policy;
using System.Xml.Linq;

namespace Proiect.Models
{
    public class CoffeeShop
    {
        public int ID { get; set; }

        [Display(Name = "Nume Cafea")]
        public string Coffee { get; set; }
        public string Brand { get; set; }

        [Column(TypeName = "decimal(6, 2)")]
        public decimal Pret { get; set; }
        public int? ComandaID { get; set; }
        [Display(Name = " Status")]
        public Comanda? Comanda { get; set; }
        [Display(Name = " Categorie")]
        public ICollection<CoffeeShopCategorie>? CoffeeShopCategorie { get; set; }
        
        
    }
}
