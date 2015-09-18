using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Kn222gn_IndividuellaArbetet.BLL
{
    public class Besokare
    {
        public int BesokarID { get; set; }


        [Required(ErrorMessage = "Lägg till ett Förnamn", AllowEmptyStrings = false)]
        [StringLength(20, ErrorMessage = "Ledsen vi stödjer inte ditt namn :O det är för långt...")]
        public string Fornamn { get; set; }
        
        [Required(ErrorMessage = "Lägg till ett Efternamn", AllowEmptyStrings = false)]
        [StringLength(20, ErrorMessage = "Ledsen vi stödjer inte ditt namn :O det är för långt...")]
        public string Efternamn { get; set; }

        [Required(ErrorMessage = "Du måste lägga till ett telefonnummer.")]
        [StringLength(10, ErrorMessage = "Numret måste vara korrekt.")]
        [RegularExpression("^[0]{1}[7]{1}[0-9]{8}$", ErrorMessage = "Inget korrekt telefonnummer")]
        public string TelefonNR { get; set; }

        [Required(ErrorMessage = "Lägg till en plats")]
        [StringLength(10, ErrorMessage = "Felaktigt när en plats lades till försök igen!")]
        public string Kop { get; set; }

        [Required(ErrorMessage = "Ett startdatum måste finnas.")]
        [DataType(DataType.Date, ErrorMessage = "Skriv ett giltigt datum.")]
        public DateTime Bokning { get; set; }

        [Required(ErrorMessage = "Ett slutdatum måste finnas.")]
        [DataType(DataType.Date, ErrorMessage = "Skriv in ett giltigt slutdatum!")]
        public DateTime BokningUpphor { get; set; }
    }
}