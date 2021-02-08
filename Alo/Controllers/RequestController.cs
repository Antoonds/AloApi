using Alo.DTOs;
using Alo.Entities;
using Alo.Extensions;
using Alo.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace Alo.Controllers
{
    [Authorize]
    public class RequestController : BaseApiController
    {
        private readonly IRequestRepository _requestRepository;
        private readonly IUserRepository _userRepository;
        public RequestController(IRequestRepository requestRepository, IUserRepository userRepository)
        {
            _requestRepository = requestRepository;
            _userRepository = userRepository;
        }

        [HttpGet("get-requests")]
        public async Task<ActionResult<IEnumerable<RequestDto>>> GetRequests()
        {
            var requests = await _requestRepository.GetRequestsAsync();

            return Ok(requests);
        }

        [HttpGet("get-request/{id}")]
        public async Task<ActionResult<RequestDto>> GetRequest(int id)
        {
            var request = await _requestRepository.GetRequestByIdAsync(id);


            return Ok(request);
        }

        [HttpPost("add-request")]
        public async Task<ActionResult> AddRequest([FromBody] Request request)
        {
            var id = User.GetUserId();
            request.RequesterId = id;
            request.Requester = await _userRepository.GetUserByIdAsync(id);

            _requestRepository.AddRequest(request);

            if (await _requestRepository.SaveAllAsync()) return Ok();

            return BadRequest("failed");

        }

    }
}
