﻿using TicketManagement.DataAccess.Interfaces;

namespace TicketManagement.DataAccess.Models
{
    /// <summary>
    /// Represent area's model.
    /// </summary>
    public class Ticket : IEntity
    {
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets event seat's id.
        /// </summary>
        public int EventSeatId { get; set; }

        /// <summary>
        /// Gets or sets user's id.
        /// </summary>
        public int UserId { get; set; }
    }
}
