using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Kn222gn_IndividuellaArbetet.BLL;
using Kn222gn_IndividuellaArbetet.Model;

namespace Kn222gn_IndividuellaArbetet.Pages.Shared
{
    public partial class PrivilegieSida : System.Web.UI.Page
    {
        /*
        private Service _service;
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
        public IEnumerable<Privilegie> PrivilegieListView_GetData()
        {
            return Service.GetPrivilegie();
        }
        //Data till Dropdownlisten för besökare...
        public IEnumerable<Biljett> BiljettDropDownList_GetData()
        {
            return Service.GetBiljett();
        }
        //Lägger till en ny biljett...
        public void PrivilegieListView_InsertItem(Privilegie privilegie)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Service.SavePrivilegie(privilegie);
                    Session["confirmtab"] = String.Format("Ett Privilegie har skapats");
                    Response.Redirect(Request.RawUrl);
                }
                catch
                {
                    ModelState.AddModelError(string.Empty, "Kunde inte skapa Privilegie, Har du rätt Biljett ID?");
                }
            }
        }
        //När ändringar sker i biljettbasen...
        public void PrivilegieListView_UpdateItem(int privilegieID)
        {
            try
            {
                var privilegie = Service.GetPrivilegie(privilegieID);
                if (privilegie == null)
                {
                    ModelState.AddModelError(String.Empty, String.Format("Privilegiet med ID {0} hittades inte", privilegie.PrivilegieID));
                    return;
                }
                //TryUpdateModel(privilegie);
                //if (ModelState.IsValid)
                if(TryUpdateModel(privilegie))
                {
                    Service.SavePrivilegie(privilegie);
                    Session["confirmtab"] = " du har uppdaterat privilegiet";
                    Response.Redirect(Request.RawUrl);
                }
            }
            catch (Exception)
            {
                //ModelState.AddModelError(String.Empty, "Ett oväntat fel inträffade då Personuppgiften skulle uppdateras.");
            }
        }
        // Ta bort en Privilegiet
        public void PrivilegieListView_DeleteItem(int PrivilegieID)
        {
            Service.DeletePrivilegie(PrivilegieID);
            Session["confirmtab"] = "du tog bort Privilegiet";
            Response.Redirect(Request.RawUrl);
        }
    }
}