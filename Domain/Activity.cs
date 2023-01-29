using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Activity
    {
        public Guid Id { get; set; }

        [MaxLength(50)]
        public string Title { get; set; }
        public DateTime Date { get; set; }

        [MaxLength(150)]
        public string Description { get; set; }

        [MaxLength(100)]
        public string Category { get; set; }

        [MaxLength(120)]
        public string City { get; set; }

        [MaxLength(200)]
        public string Venue { get; set; }
    }
}