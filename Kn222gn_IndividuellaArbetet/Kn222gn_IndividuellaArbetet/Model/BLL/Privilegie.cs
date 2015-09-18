using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Kn222gn_IndividuellaArbetet.BLL
{
    public class Privilegie
    {

        public int PrivilegieID { get; set; }


        [Required(ErrorMessage = "Lägg till en Privilegie Typ", AllowEmptyStrings = false)]
        [StringLength(20, ErrorMessage = "För långt!")]
        public string PrivilegieTyp { get; set; }


        public int BiljettID { get; set; }


    }
}