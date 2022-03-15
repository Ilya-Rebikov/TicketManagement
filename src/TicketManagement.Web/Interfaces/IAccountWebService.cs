﻿using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using TicketManagement.Web.Models;
using TicketManagement.Web.Models.Account;

namespace TicketManagement.Web.Interfaces
{
    /// <summary>
    /// Web service for account controller.
    /// </summary>
    public interface IAccountWebService
    {
        /// <summary>
        /// Register user in system.
        /// </summary>
        /// <param name="model">RegisterViewModel object.</param>
        /// <param name="httpContext">HttpContext object.</param>
        /// <returns>IdentityResult with success or errors.</returns>
        Task RegisterUser(RegisterViewModel model, HttpContext httpContext);

        /// <summary>
        /// Login for user in system.
        /// </summary>
        /// <param name="model">Login view model.</param>
        /// <param name="httpContext">HttpContext object.</param>
        /// <returns>Task.</returns>
        Task LoginUser(LoginViewModel model, HttpContext httpContext);

        /// <summary>
        /// Logout user from system.
        /// </summary>
        /// <param name="httpContext">HttpContext object.</param>
        /// <returns>Task.</returns>
        Task Logout(HttpContext httpContext);

        /// <summary>
        /// Add balance to user.
        /// </summary>
        /// <param name="model">AddBalanceViewModel object.</param>
        /// <returns>IdentityResult object.</returns>
        Task<IdentityResult> AddBalanceToUser(AddBalanceViewModel model);

        /// <summary>
        /// Get account view model for index method.
        /// </summary>
        /// <param name="user">User.</param>
        /// <returns>Account view model.</returns>
        Task<AccountViewModel> GetAccountViewModelInIndex(User user);

        /// <summary>
        /// Gets edit account view model for edit httpget method.
        /// </summary>
        /// <param name="id">Id of user.</param>
        /// <param name="httpContext">HttpContext object.</param>
        /// <returns>EditAccountViewModel object.</returns>
        Task<EditAccountViewModel> GetEditAccountViewModelForEdit(HttpContext httpContext, string id);

        /// <summary>
        /// Update user in edit httppost method.
        /// </summary>
        /// <param name="model">EditAccountViewModel object.</param>
        /// <param name="httpContext">HttpContext object.</param>
        /// <returns>IdentityResult object.</returns>
        Task<IdentityResult> UpdateUserInEdit(HttpContext httpContext, EditAccountViewModel model);
    }
}
