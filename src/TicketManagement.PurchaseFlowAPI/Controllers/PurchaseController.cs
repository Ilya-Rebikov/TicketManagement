﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TicketManagement.PurchaseFlowAPI.Interfaces;
using TicketManagement.PurchaseFlowAPI.Models;

namespace TicketManagement.PurchaseFlowAPI.Controllers
{
    /// <summary>
    /// Controller for purchase flow.
    /// </summary>
    [ApiController]
    [Authorize(Roles = "admin, user, event manager, venue manager")]
    public class PurchaseController : ControllerBase
    {
        /// <summary>
        /// Key for authorization header.
        /// </summary>
        private const string AuthorizationKey = "Authorization";

        /// <summary>
        /// IPurchaseService object.
        /// </summary>
        private readonly IPurchaseService _service;

        /// <summary>
        /// Initializes a new instance of the <see cref="PurchaseController"/> class.
        /// </summary>
        /// <param name="service">IPurchaseService object.</param>
        public PurchaseController(IPurchaseService service)
        {
            _service = service;
        }

        /// <summary>
        /// Get account view model for personal account.
        /// </summary>
        /// <param name="token">Jwt token.</param>
        /// <returns>Account view model.</returns>
        [HttpGet("account/personalaccount")]
        public async Task<IActionResult> GetAccountViewModelForPersonalAccount([FromHeader(Name = AuthorizationKey)] string token)
        {
            return Ok(await _service.GetAccountViewModelForPersonalAccount(token));
        }

        /// <summary>
        /// Get ticket view model for buy method.
        /// </summary>
        /// <param name="token">Jwt token.</param>
        /// <param name="dictionary">Dictionary with event seat id and price for it.</param>
        /// <returns>Ticket view model.</returns>
        [HttpGet("events/buy")]
        public async Task<IActionResult> GetTicketViewModelForBuy([FromHeader(Name = AuthorizationKey)] string token, [FromBody] Dictionary<int, double> dictionary)
        {
            return Ok(await _service.GetTicketViewModelForBuyAsync(dictionary.Keys.First(), dictionary.Values.First(), token));
        }

        /// <summary>
        /// Update event seat state to occupied after buying ticket.
        /// </summary>
        /// <param name="token">Jwt token.</param>
        /// <param name="ticketVm">Ticket view model.</param>
        /// <returns>True if state was changed and false if not because of low balance.</returns>
        [HttpPut("events/buy")]
        public async Task<IActionResult> UpdateEventSeatStateAfterBuyingTicket([FromHeader(Name = AuthorizationKey)] string token, [FromBody] TicketModel ticketVm)
        {
            return await _service.UpdateEventSeatStateAfterBuyingTicket(token, ticketVm) ? Ok() : BadRequest();
        }
    }
}