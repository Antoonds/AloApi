using Alo.Data;
using Alo.DTOs;
using Alo.Entities;
using Alo.Extensions;
using Alo.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alo.Controllers
{
    public class FillInController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        public FillInController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }
        [Authorize(Roles ="Leiding")]
        [HttpPost("add-request")]
        public async Task<ActionResult> AddRequest([FromBody] FillIn fillIn)
        {
            var id =User.GetUserId();
            fillIn.FillInRequesterId = id;
            fillIn.FillerId = 1;

            _unitOfWork.FillInRepository.AddFillIn(fillIn);

            if (await _unitOfWork.Complete()) return Ok();

            return BadRequest("failed");


        }
        [Authorize(Roles ="Leiding")]
        [HttpGet("get-requests")]
        public async Task<ActionResult<IEnumerable<FillInDto>>> GetRequests()
        {
            var requests = await _unitOfWork.FillInRepository.GetFillInRequestsAsync();
            var requestsDto = requests.Select(r => new FillInDto
            {
                Id = r.Id,
                Vergadering = r.Vergadering,
                StartDate = r.StartDate,
                StopDate = r.StopDate,
                FillInRequesterName = r.FillInRequester.UserName,
                FillInRequesterTak = r.FillInRequester.Tak,
                FillerName = r.Filler.UserName, 
                FillerId = r.FillerId
            }
            );
                

            return Ok(requestsDto);
        }
        [Authorize(Roles = "Leiding,LosseLeden,Bestuur")]
        [HttpPut("add-fillin")]
        public async Task<ActionResult> AddFillIn(FillIn fillIn)
        {

            fillIn.FillerId = User.GetUserId();
            fillIn.Filler = await _unitOfWork.UserRepository.GetUserByIdAsync(User.GetUserId());

            fillIn.Accepted = true;

            _unitOfWork.FillInRepository.Update(fillIn);

            if (await _unitOfWork.Complete()) return Ok();

            return BadRequest("failed");

        }
    }
}
