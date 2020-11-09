using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Microsoft.AspNetCore.Identity;

namespace OrderManager.DataAccess.Models
{
    public class User : IdentityUser
    {
        [StringLength(60)]
        [Required]
        public string FirstName { get; set; }

        [StringLength(60)]
        [Required]
        public string LastName { get; set; }

        [StringLength(50)]
        public string Position { get; set; }
        public ICollection<Order> UserTasks { get; set; }
    }
}
