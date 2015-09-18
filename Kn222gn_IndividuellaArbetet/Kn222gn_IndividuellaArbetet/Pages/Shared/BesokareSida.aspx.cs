using Kn222gn_IndividuellaArbetet.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Kn222gn_IndividuellaArbetet.BLL;

namespace Kn222gn_IndividuellaArbetet.Pages.Shared
{
    public partial class BesokareSida : System.Web.UI.Page
    {

        /*
        private Service _service;
        private Service Service
        {
            get { return _service ?? (_service = new Service()); }
        }
         * */
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["confirmtab"] != null)
            {
                confirmholder.Visible = true;
                confirmText.Text = Session["confirmtab"] as string;
                Session.Remove("confirmtab");
            }

        }


        public IEnumerable<Kn222gn_IndividuellaArbetet.BLL.Besokare> BesokarListView_GetData()
        {
            return Service.GetBesokare();
        }

        public void BesokarListView_InsertItem(Besokare besokare)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Service.SaveBesokare(besokare);
                    Session["confirmtab"] = String.Format("En besökare har skapats");
                    Response.Redirect(Request.RawUrl);
                }

                catch
                {
                    ModelState.AddModelError(string.Empty, "Ett fel vid Insertmetoden har uppstått!");
                }
            }
        }
        //När ändringar sker i besökarbasen...
        public void BesokarListView_UpdateItem(int besokarID)
        {
            try
            {
                var besokaren = Service.GetBesokare(besokarID);
                if (besokaren == null)
                {
                    ModelState.AddModelError(String.Empty, String.Format("The biljett with the ID {0} was not found", besokaren.BesokarID));
                    return;
                }
                //TryUpdateModel(besokare);
                if (ModelState.IsValid)
                {
                    Service.SaveBesokare(besokaren);
                    Session["confirmtab"] = "du har uppdaterat Biljetten";
                    Response.Redirect(Request.RawUrl);
                }
            }
            catch (Exception)
            {
                ModelState.AddModelError(String.Empty, "Ett oväntat fel inträffade då Personuppgiften skulle uppdateras.");
            }

        }
    }
}