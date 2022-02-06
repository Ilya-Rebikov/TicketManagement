﻿using System.ComponentModel.DataAnnotations;

namespace TicketManagement.Web.Models.Users
{
    public class EditUserViewModel
    {
        public string Id { get; set; }

        public string Email { get; set; }

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
