using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;

namespace Proiect.Models
{
    public class Cumpara
    {
        public int ID { get; set; }
        public int? ClientID { get; set; }
        public Client? Client { get; set; }
        public int? CoffeeShopID { get; set; }
        public CoffeeShop? CoffeeShop { get; set; }
        [DataType(DataType.Date)]
        public DateTime DataCumparat { get; set; }
    }
}
