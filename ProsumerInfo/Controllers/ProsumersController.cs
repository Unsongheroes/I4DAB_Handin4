using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProsumerInfo.Data;
using ProsumerInfo.Interfaces;
using ProsumerInfo.Models;
using ProsumerInfo.Models.Dtos;

namespace ProsumerInfo.Controllers
{
    [Produces("application/json")]
    [Route("api/Prosumers")]
    public class ProsumersController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDtoFactory _dtoFactory;

        public ProsumersController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _dtoFactory = new DtoFactory();
        }

        // GET: api/Prosumers
        [HttpGet]
        public async Task<IEnumerable<ProsumerDto>> GetProsumer()
        {
            var result = await _unitOfWork.Prosumers.GetAllAsync();
            return result.Select(prosumer => _dtoFactory.CreateDto(prosumer));
        }

        // GET: api/Prosumers/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProsumer([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            var prosumer = await _unitOfWork.Prosumers.GetAsync(id);

            if (prosumer == null)
            {
                return NotFound();
            }

            return Ok(_dtoFactory.CreateFullDto(prosumer));
        }

        // PUT: api/Prosumers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProsumer([FromRoute] int id, [FromBody] ProsumerFullDto prosumerDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != prosumerDto.Id)
            {
                return BadRequest();
            }

            var prosumer = DtoToProsumer.GetProsumer(prosumerDto);

            if (_unitOfWork.Prosumers.Update(prosumer, id) == null)
            {
                return NotFound();
            }

            await _unitOfWork.CommitAsync();

            return NoContent();
        }

        // POST: api/Prosumers
        [HttpPost]
        public async Task<IActionResult> PostProsumer([FromBody] ProsumerFullDto prosumerDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var prosumer = DtoToProsumer.GetProsumer(prosumerDto);

            _unitOfWork.Prosumers.Add(prosumer);

            try
            {
                await _unitOfWork.CommitAsync();
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }

            return CreatedAtAction("GetProsumer", new { id = prosumer.Id }, _dtoFactory.CreateFullDto(prosumer));
        }

        // DELETE: api/Prosumers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProsumer([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var prosumer = _unitOfWork.Prosumers.Remove(id);
            if (prosumer == null)
            {
                return NotFound();
            }

            await _unitOfWork.CommitAsync();

            return Ok(_dtoFactory.CreateDto(prosumer));
        }
    }

    internal static class DtoToProsumer
    {
        public static Prosumer GetProsumer(ProsumerFullDto dto)
        {
            var type = dto.Type == "Company" ? Prosumer.ProsumerType.Company : Prosumer.ProsumerType.Private; 
            var prosumer = new Prosumer(dto.PublicKey, type,
                    new SmartMeter(dto.SmartMeter.GeneratedPower, dto.SmartMeter.UsedPower))
            { Id = dto.Id };
            return prosumer;
        }
    }
}