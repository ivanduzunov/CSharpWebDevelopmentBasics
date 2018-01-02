namespace ExamApp.Web.Controllers
{
    using SimpleMvc.Framework.Contracts;

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
