﻿using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace TicketManagement.Web.Models
{
    /// <summary>
    /// Represent user's model.
    /// </summary>
    public class User : IdentityUser
    {
        /// <summary>
        /// Gets or sets first name.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets surname.
        /// </summary>
        public string Surname { get; set; }

        /// <summary>
        /// Gets or sets balance.
        /// </summary>
        [Range(0, double.MaxValue)]
        public double Balance { get; set; }
    }
}
