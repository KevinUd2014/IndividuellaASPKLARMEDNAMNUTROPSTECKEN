using Kn222gn_IndividuellaArbetet.App_Validation;
using Kn222gn_IndividuellaArbetet.BLL;
using Kn222gn_IndividuellaArbetet.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Kn222gn_IndividuellaArbetet.Model
{
    public static class Service
    {
        private static BesokareDAL _besokareDAL;
        private static BiljettDAL _biljettDAL;
        private static PrivilegieDAL _privilegieDAL;

        private static BesokareDAL BesokareDAL
        {
            get
            {
                return _besokareDAL ?? (_besokareDAL = new BesokareDAL());
            }
        }
        private static BiljettDAL BiljettDAL
        {
            get
            {
                return _biljettDAL ?? (_biljettDAL = new BiljettDAL());
            }
        }
        private static PrivilegieDAL PrivilegieDAL
        {
            get
            {
                return _privilegieDAL ?? (_privilegieDAL = new PrivilegieDAL());
            }
        }

        public static IEnumerable<Besokare> GetBesokare()// denna ska hämta besökare!
        {
            return BesokareDAL.GetBesokare();
        }
        public static Besokare GetBesokare(int BesokareID)
        {
            return BesokareDAL.GetSpecifikBesokare(BesokareID);
        }

        //public Biljett GetSpecifikBiljett(int BiljettID)
        //{
        //    return BiljettDAL.GetSpecifikBiljett(BiljettID);
        //}
        //public Biljett GetBiljett(int BiljettID)
        //{
        //    return BiljettDAL.GetSpecifikBiljett(BiljettID);
        //}

        public static Privilegie GetPrivilegie(int PrivilegieID)
        {
            return PrivilegieDAL.GetSpecifikPrivilegie(PrivilegieID);
        }
        public static IEnumerable<Biljett> GetBiljett() // denna ska hämta biljett!
        {
            return BiljettDAL.GetBiljett();
        }
        public static IEnumerable<Privilegie> GetPrivilegie() // denna ska hämta från privilegier!
        {
            return PrivilegieDAL.GetPrivilegie();
        }
        public static Biljett GetNewBiljett(int biljettId)  // denna skickar in en parameter till denna klassen i Biljett!
        {
            return BiljettDAL.GetBiljettById(biljettId);
        }

        public static void SaveBesokare(Besokare besokare)  // denna kommer spara besökaren!!
        {
            ICollection<ValidationResult> validatonResults = new List<ValidationResult>();

            if (besokare.Validate(out validatonResults))
            {
                if (besokare.BesokarID == 0)
                {
                    BesokareDAL.CreateBesokare(besokare);
                }
                else
                {
                    BesokareDAL.UpdateBesokare(besokare);
                }
            }
            else
            {
                var ex = new ApplicationException("Ett fel uppstod när du skulle spara Besökaren!");
                ex.Data.Add("ValidationResult", validatonResults);
                throw ex;
            }
        }

        public static void SaveBiljett(Biljett biljett)  // denna kommer spara biljetten!
        {
            ICollection<ValidationResult> validatonResults = new List<ValidationResult>();

            if (biljett.Validate(out validatonResults))
            {
                if (biljett.BiljettID == 0)
                {
                     BiljettDAL.CreateBiljett(biljett);
                }
                else
                {
                     BiljettDAL.UpdateBiljett(biljett);
                }
            }
            else
            {
                var ex = new ApplicationException("Ett fel uppstod när du skulle spara biljetten!");
                ex.Data.Add("ValidationResult", validatonResults);
                throw ex;
            }
        }
        public static void SavePrivilegie(Privilegie privilegie)  // denna kommer spara privilegiet!
        {
            ICollection<ValidationResult> validatonResults = new List<ValidationResult>();

            if (privilegie.Validate(out validatonResults))
            {
                if (privilegie.PrivilegieID == 0)
                {
                    PrivilegieDAL.InsertPrivilegie(privilegie);
                }
                else
                {
                    PrivilegieDAL.UpdatePrivilegie(privilegie);
                }
            }
            else
            {
                var ex = new ApplicationException("Ett fel uppstod när du skulle spara privilegiet!");
                ex.Data.Add("ValidationResult", validatonResults);
                throw ex;
            }
        }
        public static Privilegie GetPrivilegieId(int privilegieID)
        {
            return PrivilegieDAL.GetPrivilegieId(privilegieID);
        }

        public static void DeletePrivilegie(int privilegieID)  // denna tar bort privilegie
        {
            PrivilegieDAL.DeletePrivilegie(privilegieID);
        }
        public static void DeleteBiljett(int biljettID)  // denna tar bort biljett!
        {
            BiljettDAL.DeleteBiljett(biljettID);
        }
    }
}