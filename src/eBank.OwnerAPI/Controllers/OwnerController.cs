using eBank.Business.Interfaces;
using eBank.Business.DTO.DTO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using System.Net;

namespace eBank.OwnerAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]

    public class OwnerController : ControllerBase
    {
        private readonly IBusinessServiceManagementOwner _businessServiceManagementOwner;

        public OwnerController(IBusinessServiceManagementOwner businessServiceManagementOwner)
        {
            _businessServiceManagementOwner = businessServiceManagementOwner;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            try
            {
                var result = await _businessServiceManagementOwner.GetAll();
                if (result == null)
                    return NotFound();

                return Ok(result);
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            try
            {
                var result = await _businessServiceManagementOwner.GetById(id);
                if (result == null)
                    return NotFound();

                return Ok(result);
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] OwnerDTO Owner)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = await _businessServiceManagementOwner.Add(Owner);
                    if (result == false)
                        return BadRequest();

                    return StatusCode((int)HttpStatusCode.Created, result);
                }
                else
                    return StatusCode((int)HttpStatusCode.BadRequest, ModelState);
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var result = await _businessServiceManagementOwner.Remove(id);
                if (result == false)
                    return BadRequest();

                return Ok(result);
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<ActionResult> Update(int? id, [FromBody] OwnerDTO Owner)
        {
            try
            {
                if (!ModelState.IsValid || !id.HasValue || id == 0)
                    return BadRequest(ModelState);

                var result = await _businessServiceManagementOwner.Update((int)id, Owner);
                if (result == false)
                    return BadRequest();

                return Ok(result);
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
