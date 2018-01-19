namespace ExamApp.Service
{
    using ExamApp.Service.Models;
    using System;
    using System.Collections.Generic;

    public interface IFlightService
    {
        bool Create(string destination, string origin, DateTime date, string imageUrl);

        IEnumerable<FlightListingServiceModel> All(string condition);

        FlightDetailsServiceModel Details(int id);
    }
}
