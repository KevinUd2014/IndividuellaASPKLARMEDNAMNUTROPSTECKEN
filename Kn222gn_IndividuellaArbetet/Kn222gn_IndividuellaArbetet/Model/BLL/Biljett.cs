using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Kn222gn_IndividuellaArbetet.BLL
{
    public class Biljett
    {
        public int BiljettID { get; set; }

        [Required(ErrorMessage = "Lägg till ett pris", AllowEmptyStrings = false)]
        public int Pris { get; set; }

        [Required(ErrorMessage = "Lägg till ett antal", AllowEmptyStrings = false)]
        public int Antal { get; set; }

        [Required(ErrorMessage = "Lägg till en Rabatt", AllowEmptyStrings = false)]
        public decimal Rabatt { get; set; }

        [Required(ErrorMessage = "Lägg till en Biljett Typ", AllowEmptyStrings = false)]
        [StringLength(20, ErrorMessage = "För långt!")]
        public string BiljettTyp { get; set; }


        public int BesokarID { get; set; }
        public Besokare Besokare { get; set; }
    }
}