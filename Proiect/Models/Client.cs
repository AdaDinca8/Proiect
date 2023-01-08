using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Proiect.Models
{
    public class Client
    {
        public int ID { get; set; }
        [RegularExpression(@"^[A-Z]+[a-z\s]*$", ErrorMessage = "Numele trebuie sa inceapa cu majuscula")]
        [StringLength(30, MinimumLength = 3)]
        public string? Nume { get; set; }
        [RegularExpression(@"^[A-Z]+[a-z\s]*$", ErrorMessage = "Prenumele trebuie sa inceapa cu majuscula")]

        [StringLength(30, MinimumLength = 3)]
        public string? Prenume { get; set; }
        [StringLength(70)]
        public string? Adresa { get; set; }
        public string Email { get; set; }
        [RegularExpression(@"^\(?([0-9]{4})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{3})$", ErrorMessage = "Telefonul trebuie sa fie de forma '0722-123-123' sau '0722.123.123' sau '0722 123 123'")]
        public string? Tel { get; set; }
        [Display(Name = "Full Name")]
        public string? FullName
        {
            get
            {
                return Nume + " " + Prenume;
            }
        }
        public ICollection<Cumpara>? Cumparas { get; set; }

    }
}
