using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebAPI2._0.DatabaseContext;
using WebAPI2._0.Impl;
using WebAPI2._0.Model;

namespace WebAPI2._0.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ToyController : ControllerBase
    {
        private KinderGartenContext kinderGartenContext = new KinderGartenContext();
        
        private IList<Toy> toys = new List<Toy>();

        private SqliteService _sqliteService;

        public ToyController()
        {
            _sqliteService = new SqliteService(kinderGartenContext);
        }
        
        [HttpPost]
        [Route("{Id:int}")]
        public async Task<ActionResult<Toy>> AddToy([FromBody] Toy toy, [FromRoute] int Id)
        {
            try
            {
                Toy add = await _sqliteService.addToy(toy);

                return Created($"https://localhost:5005/Toy/{Id}", add);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet]
        public async Task<ActionResult<IList<Toy>>> GetToys()
        {
            try
            {
                IList<Toy> toys = await _sqliteService.GetToy();

                return Ok(toys);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);

                return StatusCode(500, e.Message);
            }
        }

        [HttpDelete]
        [Route("{Id:int}")]
        public async Task<ActionResult<Toy>> RemoveToy([FromRoute] int Id)
        {
            try
            {
                await _sqliteService.RemoveToy(Id);

                return Ok();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);

                return StatusCode(500, e.Message);
            }
        }
    }
}