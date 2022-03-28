﻿using System.ComponentModel.DataAnnotations;
using TicketManagement.Web.ModelsDTO;

namespace TicketManagement.Web.Models.Areas
{
    /// <summary>
    /// Area view model.
    /// </summary>
    public class AreaViewModel
    {
        /// <summary>
        /// Gets or sets id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets layout's id.
        /// </summary>
        [Required(ErrorMessage = "FieldRequired")]
        [Display(Name = "LayoutId")]
        public int LayoutId { get; set; }

        /// <summary>
        /// Gets or sets description.
        /// </summary>
        [Required(ErrorMessage = "FieldRequired")]
        [Display(Name = "Description")]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets X coordinate in layout.
        /// </summary>
        [Required(ErrorMessage = "FieldRequired")]
        [Display(Name = "CoordXInLayout")]
        public int CoordX { get; set; }

        /// <summary>
        /// Gets or sets Y coordinate in layout.
        /// </summary>
        [Required(ErrorMessage = "FieldRequired")]
        [Display(Name = "CoordYInLayout")]
        public int CoordY { get; set; }

        /// <summary>
        /// Gets or sets base price for area.
        /// </summary>
        [Required(ErrorMessage = "FieldRequired")]
        [Display(Name = "Price")]
        public double BasePrice { get; set; }
    }
}