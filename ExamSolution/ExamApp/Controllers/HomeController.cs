using System;
using System.Collections.Generic;
using System.Text;

namespace ExamApp.Controllers
{

    using Services;
    using Services.Contracts;
    using SimpleMvc.Framework.Attributes.Methods;
    using SimpleMvc.Framework.Contracts;
    using Models.User;

    public class HomeController : BaseController
    {
        public IActionResult Index()
        {
            if (User.IsAuthenticated)
            {
                this.ViewModel["usersName"] = this.Profile.FullName;
            }

            return this.View();
        }

    }
}
