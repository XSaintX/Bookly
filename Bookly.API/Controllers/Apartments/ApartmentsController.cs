﻿using Bookly.Application.Apartments.SearchApartments;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bookly.API.Controllers.Apartments
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ApartmentsController : ControllerBase
    {
        private readonly ISender _sender;
        public ApartmentsController(ISender sender)
        {
            _sender = sender;
        }
        [HttpGet]
        public async Task<ActionResult> SearchApartments(DateOnly startDate, DateOnly endDate, CancellationToken cancellationToken)
        {
            var query = new SearchApartmentsQuery(startDate, endDate);
            var result = await _sender.Send(query, cancellationToken);
            return Ok(result.Value);
        }
    }
}
