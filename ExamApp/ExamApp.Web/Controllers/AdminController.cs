namespace ExamApp.Web.Controllers
{
    using ExamApp.Service;
    using ExamApp.Service.Implementations;
    using ExamApp.Web.Models.Admin;
    using SimpleMvc.Framework.Attributes.Methods;
    using SimpleMvc.Framework.Contracts;

    public class AdminController : BaseController
    {
        private readonly IFlightService flights;

        public AdminController()
        {
            this.flights = new FlightService();
        }

        public IActionResult CreateFlight()
        {
            if (!IsAdmin)
            {
                return RedirectToHome();
            }

            this.ViewModel["title"] = "Create Flight";

            return this.View();
        }

        [HttpPost]
        public IActionResult CreateFlight(CreateFlightModel model)
        {
            if (!IsValidModel(model) || !IsAdmin)
            {
                this.ShowError("Function only for Admins!");
                return RedirectToHome();
            }

          var success =   this.flights.Create
                (model.Destination, model.Origin,
                model.Date, model.ImageUrl);

            if (!success)
            {
                this.ShowError("Not valid Flight data!");
                return this.View();
            }

            this.ShowSuccess("Flight added successfully!");

            return this.RedirectToHome();
        }
    }
}
