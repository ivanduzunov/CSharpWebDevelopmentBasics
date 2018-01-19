namespace ExamApp.Web.Controllers
{
    using ExamApp.Service;
    using ExamApp.Service.Implementations;
    using ExamApp.Service.Models;
    using SimpleMvc.Framework.Contracts;
    using System.Collections.Generic;
    using System.Text;

    public class HomeController : BaseController
    {
        private readonly IFlightService flights;

        public HomeController()
        {
            this.flights = new FlightService();
        }

        public IActionResult Index()
        {
            if (User.IsAuthenticated)
            {
                this.ViewModel["userName"] = this.Profile.Name;
            }

            if (IsAdmin)
            {
                this.ViewModel["adminDisplay"] = "flex";
            }
            else
            {
                this.ViewModel["adminDisplay"] = "none";
            }

            if (IsAdmin)
            {
                var flights = this.flights.All("admin");

                string flightsToHtml = ToHtml(flights, "admin");

                this.ViewModel["flights"] = flightsToHtml;

                this.ViewModel["addFlightButton"] = $@"<a href=""/admin/CreateFlight"" class=""add-flight"" >Add Flight +</a>";
            }

            else
            {
                var flights = this.flights.All("user");

                string flightsToHtml = ToHtml(flights, "admin");

                this.ViewModel["flights"] = flightsToHtml;

                this.ViewModel["addFlightButton"] = "";
            }

            this.ViewModel["userName"] = User.Name;

            this.ViewModel["title"] = "Home";

            return this.View();
        }

        public string ToHtml(IEnumerable<FlightListingServiceModel> flights, string condition)
        {
            var sb = new StringBuilder();

            if (condition == "admin")
            {
                foreach (var flight in flights)
                {
                    sb.AppendLine($@"<a href=""/flights/details?id={flight.Id}"" class=""added-flight"">");
                    sb.AppendLine($@"<img src=""{flight.ImageUrl}"" alt="""" class=""picture-added-flight"">");
                    sb.AppendLine($@"<h3>{flight.Destination}</h3>");
                    sb.AppendLine($@"<span>from {flight.Origin}</span><span>{flight.Date.Date} {flight.Date.Month}</span>");
                    sb.AppendLine("</a>");

                }

                return sb.ToString();
            }

            foreach (var flight in flights)
            {
                sb.AppendLine($@"<a class=""added- flight"">");
                sb.AppendLine($@"<img src=""{flight.ImageUrl}"" alt="""" class=""picture-added-flight"">");
                sb.AppendLine($@"<h3>{flight.Destination}</h3>");
                sb.AppendLine($@"<span>from {flight.Origin}</span><span>{flight.Date.Date} {flight.Date.Month}</span>");
                sb.AppendLine("</a>");

            }
            return sb.ToString();
        }
    }
}
