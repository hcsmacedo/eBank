using AutoMapper;
using eBank.Business.Interfaces;
using eBank.Business.DTO.DTO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;

namespace eBank.BankAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]

    public class BankController : ControllerBase
    {
        private readonly IBusinessServiceManagementBank _businessServiceManagementBank;

        public BankController(IBusinessServiceManagementBank businessServiceManagementBank)
        {
            _businessServiceManagementBank = businessServiceManagementBank;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            try
            {
                var result = await _businessServiceManagementBank.GetAll();
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
                var result = await _businessServiceManagementBank.GetById(id);
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
        public async Task<ActionResult> Post([FromBody] BankDTO Bank)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = await _businessServiceManagementBank.Add(Bank);
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

                var result = await _businessServiceManagementBank.Remove(id);
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
        public async Task<ActionResult> Update(int? id,[FromBody] BankDTO Bank)
        {
            try
            {
                if (!ModelState.IsValid || !id.HasValue || id == 0)
                    return BadRequest(ModelState);

                var result = await _businessServiceManagementBank.Update((int)id, Bank);
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
