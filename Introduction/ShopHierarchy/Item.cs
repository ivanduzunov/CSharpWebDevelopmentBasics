using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ShopHierarchy
{
    public class Item
    {
        public int Id { get; set; }

        [Required, MaxLength(50)]
        public string Name { get; set; }

        public double Price { get; set; }

        public List<OrdersItems> Orders { get; set; } = new List<OrdersItems>();

        public List<Review> Reviews { get; set; } = new List<Review>();
    }
}
