using System;
using System.Collections.Generic;
using System.Text;

namespace ModPanel.App.Controllers
{
    using SimpleMvc.Framework.Contracts;

    public class HomeController : BaseController
    {
        
        public IActionResult Index()
        {
            this.ViewModel["guestDisplay"] = "block";
            this.ViewModel["authenticated"] = "none";
            this.ViewModel["admin"] = "none";

            if (this.User.IsAuthenticated)
            {
                this.ViewModel["guestDisplay"] = "none";
                this.ViewModel["authenticated"] = "flex";

                string search = null;
                if (this.Request.UrlParameters.ContainsKey("search"))
                {
                    search = this.Request.UrlParameters["search"];
                }


                if (this.IsAdmin)
                {
                    this.ViewModel["authenticated"] = "none";
                    this.ViewModel["admin"] = "flex";
                }
            }
            return this.View();
        }
    }
}
