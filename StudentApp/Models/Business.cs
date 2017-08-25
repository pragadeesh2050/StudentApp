using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentApp.Models
{
    public class Business
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public int CreatedBy { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}