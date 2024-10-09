using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Something;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/something")]
    [ApiController]
    public class SomethingController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        private readonly ISomethingRepository _somethingRepo;
        public SomethingController(ApplicationDBContext context, ISomethingRepository somethingRepo)
        {
            _context = context;
            _somethingRepo = somethingRepo;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var somethings = await _somethingRepo.GetAllAsync();
            var somethingDto = somethings.Select(a => a.ToSomethingDto());

            return Ok(somethingDto);
            
        }


        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var something = await _somethingRepo.GetByIdAsync(id);

            if (something == null)
            {
                return NotFound();
            }

            return Ok(something.ToSomethingDto());
        }
        
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateSomethingDto somethingDto)
        {
            var somethingModel = somethingDto.ToSomethingFromCreateDto();
            await _somethingRepo.CreateAsync(somethingModel);
            
            return CreatedAtAction(nameof(GetById), new {id = somethingModel.Id}, somethingModel.ToSomethingDto());
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id) 
        {
            var somethingModel = await _somethingRepo.DeleteAsync(id);
            if (somethingModel == null) 
            {
                return NotFound();
            }
            return Ok(somethingModel);
        }
    }
}