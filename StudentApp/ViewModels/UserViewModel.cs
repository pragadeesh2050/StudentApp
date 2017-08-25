using StudentApp.DAL;
using StudentApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentApp.ViewModels
{
    public class UserViewModel
    {
        public UserViewModel()
        {
            RolesWithoutBusiness = new List<string> { "EDM Adminstrator", "Leader", "Search and View" };
            OtherRolesWithBusiness = new List<string> { "DSE", "DQCE", "FLU-CF-Admin" };
        }

        [HiddenInput]
        public int ID { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        [StringLength(50, MinimumLength = 1)]
        public string LastName { get; set; }
        [Required]
        [Display(Name = "First Name")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "First Name cannot be more than 50 chars")]
        public string FirstName { get; set; }

        public IList<string> RolesWithoutBusiness { get; set; }
        public IList<string> OtherRolesWithBusiness { get; set; }


        public IList<BusinessRoleViewModel> UserRolesWithBusiness { get; set; }
        public IList<BusinessRoleViewModel> UserRolesWithoutBusiness { get; set; }

    }

    public class BusinessRoleViewModel
    {
        private SchoolContext db = new SchoolContext();
        public BusinessRoleViewModel()        {

            Businesses = new SelectList(db.Businesses, "ID", "Name");
        }

        [Key]
        public int? ID { get; set; }
        public SelectList Businesses { get; set; }
        public string Role { get; set; }
    }
}