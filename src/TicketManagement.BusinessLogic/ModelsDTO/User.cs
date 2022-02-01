﻿using Microsoft.AspNetCore.Identity;

namespace TicketManagement.BusinessLogic.ModelsDTO
{
    /// <summary>
    /// Represent user's dto model.
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
        public double Balance { get; set; }
    }
}
