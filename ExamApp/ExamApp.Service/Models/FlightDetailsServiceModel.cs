using System;
using System.Collections.Generic;
using System.Text;

namespace ExamApp.Service.Models
{
    public class FlightDetailsServiceModel
    {
        public int Id { get; set; }

        public string Origin { get; set; }

        public string Destination { get; set; }

        public DateTime Date { get; set; }

        public string ImageUrl { get; set; }
    }
}
