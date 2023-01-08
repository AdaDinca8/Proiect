using Proiect.Models;
using System.Security.Policy;

namespace Proiect.Models.ViewModels
{
    public class ComandaIndexData
    {
        public IEnumerable<Comanda> Comenzi { get; set; }
        public IEnumerable<CoffeeShop> CoffeeShops { get; set; }
    }
}
