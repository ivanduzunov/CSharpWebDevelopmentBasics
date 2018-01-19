namespace ExamApp.Web.Controllers
{
    using ExamApp.Service;
    using ExamApp.Service.Implementations;
    using ExamApp.Service.Models;
    using SimpleMvc.Framework.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class FlightsController : BaseController
    {
        private readonly IFlightService flights;

        public FlightsController()
        {
            this.flights = new FlightService();
        }

        public IActionResult Details(int id)
        {
            if (!User.IsAuthenticated)
            {
                this.RedirectToLogin();
            }

            var flightDetails = this.flights.Details(id);

            this.ViewModel["imageUrl"] = flightDetails.ImageUrl;
            this.ViewModel["origin"] = flightDetails.Origin;
            this.ViewModel["destination"] = flightDetails.Destination;
            this.ViewModel["dateAndTime"] = $"{flightDetails.Date.Date} {flightDetails.Date.Month} {flightDetails.Date.TimeOfDay}";
            this.ViewModel["destination"] = flightDetails.Destination;
            this.ViewModel["UserName"] = User.Name;
            this.ViewModel["title"] = $"Flight to {flightDetails.Destination} details";


            return this.View();
        }

        public string ToHtml(IEnumerable<FlightListingServiceModel> flights, string condition)
        {
            var sb = new StringBuilder();

            if (condition == "admin")
            {
                foreach (var flight in flights)
                {
                    sb.AppendLine($@"<a class=""added-flight"">");
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
