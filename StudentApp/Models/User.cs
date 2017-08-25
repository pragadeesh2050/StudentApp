using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace StudentApp.Models
{
    public class User
    {
        public int ID { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        [StringLength(50, MinimumLength = 1)]
        public string LastName { get; set; }
        [Required]
        [Display(Name = "First Name")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "First Name cannot be more than 50 chars")]
        [Column("FirstName")]
        public string FirstName { get; set; }

        public int CreatedBy { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime CreatedAt { get; set;}
        public DateTime UpdatedAt { get; set;}

        public DateTime LastLoginAt { get; set; }

        [Display(Name = "Full Name")]
        public string FullName
        {
            get
            {
                return this.LastName + ", " + this.FirstName;
            }
        }

        public virtual ICollection<UserRole> UserRoles { get; set; }

    }
}