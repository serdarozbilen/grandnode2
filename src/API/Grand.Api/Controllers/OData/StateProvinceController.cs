﻿using Grand.Api.DTOs.Common;
using Grand.Api.Queries.Models.Common;
using Grand.Business.Common.Interfaces.Security;
using Grand.Business.Common.Services.Security;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

namespace Grand.Api.Controllers.OData
{
    public partial class StateProvinceController : BaseODataController
    {
        private readonly IMediator _mediator;
        private readonly IPermissionService _permissionService;

        public StateProvinceController(IMediator mediator, IPermissionService permissionService)
        {
            _mediator = mediator;
            _permissionService = permissionService;
        }

        [SwaggerOperation(summary: "Get entity from StateProvince by key", OperationId = "GetStateProvinceById")]
        [HttpGet("{key}")]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Get(string key)
        {
            if (!await _permissionService.Authorize(PermissionSystemName.Countries))
                return Forbid();

            var states = await _mediator.Send(new GetQuery<StateProvinceDto>() { Id = key });
            if (!states.Any())
                return NotFound();

            return Ok(states);
        }

        [SwaggerOperation(summary: "Get entities from StateProvince", OperationId = "GetStateProvinces")]
        [HttpGet]
        [EnableQuery(HandleNullPropagation = HandleNullPropagationOption.False)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> Get()
        {
            if (!await _permissionService.Authorize(PermissionSystemName.Countries))
                return Forbid();

            return Ok(await _mediator.Send(new GetQuery<StateProvinceDto>()));
        }
    }
}
