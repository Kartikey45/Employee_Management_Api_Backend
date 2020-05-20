using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CommonLayer.Model
{
    // class having get set method
    public class EmployeesTableDetails
    {
        // Employee's User id
        [Required]
        public int UserId { get; set; }

        // Employee's first name
        [Required]
        [RegularExpression(@"^[A-Z][a-zA-Z]*$")]
        public string FirstName { get; set; }

        // Employee's last name
        [Required]
        [RegularExpression(@"^[A-Z][a-zA-Z]*$")]
        public string LastName { get; set; }

        //Employee's Gender
        [Required]
        [RegularExpression(@"^male$|^female$")]
        public string Gender { get; set; }

        //Employee's Email
        [Required]
        [EmailAddress]
        [StringLength(50)]
        public string Email { get; set; }

        //Employee's address
        [Required]
        public string Address { get; set; }

        //Employee's designation
        [Required]
        public string Designation { get; set; }

        // Employee's salary
        [Required]
        public double Salary { get; set; }

        //Employee's Mobile number
        [Required]
        [Phone]
        public string MobileNumber { get; set; }

        //Employee's Password
        [Required]
        [DataType(DataType.Password)]
        [StringLength(50, MinimumLength = 6)]
        public string Password { get; set; }
    }
}
