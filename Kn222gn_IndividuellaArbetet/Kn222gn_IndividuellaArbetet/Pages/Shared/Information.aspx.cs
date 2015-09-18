using Kn222gn_IndividuellaArbetet.BLL;
using Kn222gn_IndividuellaArbetet.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Kn222gn_IndividuellaArbetet.Pages.Shared
{
    public partial class Information : System.Web.UI.Page
    {
        /*private Service _service;
        private Service Service
        {
            get { return _service ?? (_service = new Service()); }
        }
        */
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["confirmtab"] != null)
            {
                confirmholder.Visible = true;
                confirmText.Text = Session["confirmtab"] as string;
                Session.Remove("confirmtab");
            }
        }
        //Hämtar listan med uthyrningar...
        public IEnumerable<Biljett> BiljettListView_GetData()
        {
            return Service.GetBiljett();
        }

        public IEnumerable<Besokare> BesokarDropDownList_GetData()
        {
            return Service.GetBesokare();
        }

        //Lägger till en ny biljett...
        public void BiljettListView_InsertItem(Biljett Biljett)
        {
            if (ModelState.IsValid)
            {
                try
                {

                    Service.SaveBiljett(Biljett);
                    Session["confirmtab"] = String.Format("En biljett har skapats");
                    Response.Redirect(Request.RawUrl);
                }
                catch
                {
                    ModelState.AddModelError(string.Empty, "Ett fel vid Insertmetoden har uppstått!");
                }
            }
        }
        //När ändringar sker i biljettbasen...
        public void BiljettListView_UpdateItem(int biljettId)
        { 
            //try
            //{
                var biljett = Service.GetNewBiljett(biljettId);
                if (biljett == null)
                {
                    ModelState.AddModelError(String.Empty, String.Format("Biljetten med ID {0} hittades inte!", biljett.BiljettID));
                    return;
                }
                //TryUpdateModel(biljett);
                //if (ModelState.IsValid)
                if (TryUpdateModel(biljett))
                {
                    Service.SaveBiljett(biljett);
                    Session["confirmtab"] = "Du har uppdaterat Biljetten";
                    Response.Redirect(Request.RawUrl);
                }
            }
            //catch (Exception)
            //{
            //    ModelState.AddModelError(String.Empty, "Ett oväntat fel inträffade då Personuppgiften skulle uppdateras.");
            //}
       // }
        // Ta bort en Biljett
        public void BiljettListView_DeleteItem(int BiljettID)
        {
            Service.DeleteBiljett(BiljettID);
            Session["confirmtab"] = " Du tog bort biljetten.";
            Response.Redirect(Request.RawUrl);
        }
    }
}