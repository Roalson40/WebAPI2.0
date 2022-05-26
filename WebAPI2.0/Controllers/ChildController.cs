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
    public class ChildController : ControllerBase
    {
        private SqliteService _sqliteService;
        
        private KinderGartenContext kinderGartenContext = new KinderGartenContext();
        
        private IList<Child> children = new List<Child>();

        public ChildController()
        {
            _sqliteService = new SqliteService(kinderGartenContext);
        }

        [HttpPost]
        public async Task<ActionResult<Child>> AddChild([FromBody] Child child)
        {
            
            try
            { 
                Console.WriteLine("ServerChild");

                Child add = await _sqliteService.addChild(child);

                return Created("https://localhost:5005/Child", add);

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                
                return StatusCode(500, e.Message);
            }
        }
        
        [HttpGet]
        public async Task<ActionResult<IList<Child>>> GetChildren()
        {
            try
            {
                IList<Child> children = await _sqliteService.GetChildren();
                
                return Ok(children);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                
                return StatusCode(500, e.Message);
            }
        }
    }
}