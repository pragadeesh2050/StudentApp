using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentApp.Models
{
    public class UserRole
    {
        public int ID { get; set; }
        public string Role { get; set; }

        public int CreatedBy { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public virtual User User { get; set; }
        public virtual Business Business { get; set; }
    }
}