namespace ExamApp.Service.Implementations
{
    using ExamApp.Data;
    using ExamApp.Data.Models;
    using System;
    using ExamApp.Service.Models;
    using System.Collections.Generic;
    using System.Linq;

    public class FlightService : IFlightService
    {
        private readonly ExamAppDbContext db;

        public FlightService()
        {
            this.db = new ExamAppDbContext();
        }

        public IEnumerable<FlightListingServiceModel> All(string condition)
        {
            if (condition == "admin")
            {
                return this.db.Flights
                        .Select(f => new FlightListingServiceModel
                        {
                            Id = f.Id,
                            Origin = f.Origin,
                            Destination = f.Destination,
                            Date = f.Date,
                            ImageUrl = f.ImageUrl
                        });
            }


            return this.db.Flights
                    .Where(f => f.IsPublic)
                    .Select(f => new FlightListingServiceModel
                    {
                        Id = f.Id,
                        Origin = f.Origin,
                        Destination = f.Destination,
                        Date = f.Date,
                        ImageUrl = f.ImageUrl
                    });

        }

        public bool Create(string destination, string origin, DateTime date, string imageUrl)
        {
            if (destination == null || origin == null || imageUrl == null)
            {
                return false;
            }

            var flight = new Flight
            {
                Origin = origin,
                Destination = destination,
                Date = date,
                ImageUrl = imageUrl
            };

            this.db.Add(flight);

            this.db.SaveChanges();

            return true;
        }

        public FlightDetailsServiceModel Details(int id)
       => this.db.Flights
            .Where(f => f.Id == id)
            .Select(f => new FlightDetailsServiceModel
            {
                Id = f.Id,
                Origin = f.Origin,
                Destination = f.Destination,
                Date = f.Date,
                ImageUrl = f.ImageUrl
            })
            .FirstOrDefault();
    }
}
