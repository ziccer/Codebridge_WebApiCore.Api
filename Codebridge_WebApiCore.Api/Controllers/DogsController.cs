using Codebridge_WebApiCore.Data.Context;
using Codebridge_WebApiCore.Data.Models;
using Codebridge_WebApiCore.Data.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Codebridge_WebApiCore.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DogsController : ControllerBase
    {   
        public IRepository<Dog> contextDogs;
        public DogsController(IRepository<Dog> contextDogs)
        {
            this.contextDogs = contextDogs;
        }
        /// <summary>
        /// Get all Dogs
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Dog>>> Get()
        {
            List<Dog> result = null;
            try
            {
                result = (List<Dog>)await contextDogs.AllAsync();
                if (result.Count == 0 )
                {
                    return NotFound();
                }
            }
            catch (Exception)
            {

                return BadRequest();
            }
            return Ok(result);
        }
        /// <summary>
        /// Get dog by name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpGet("{name}")]
        public async Task<ActionResult<Dog>> GetDogByName(string name)
        {
            var ch = CheckDataAsync(name);
            if (ch.Result)
            {
                return await contextDogs.FindById(name);
            }

            return NotFound();
        }
        /// <summary>
        /// Add or Update Dog 
        /// </summary>
        /// <param name="value"></param>
        /// <returns> </returns>

        
        [HttpPost]
        public async Task<ActionResult<Dog>> Post([FromQuery] Dog value)
        {
            if (CheckDataAsync(value.Name).Result)
            {
                await contextDogs.Update(value);
                return Ok( "Updated succesfully");
                
            }
            if (value.Tail_Length > 0 && value.Weight > 0)
            {
                await contextDogs.Add(value);
                return Ok("Added succesfully");
            }
            return BadRequest("Tail_Length or Weight cannot be negative");
        }
        private async Task<bool> CheckDataAsync(string name)
        {   
            List<Dog> result = (List<Dog>)await contextDogs.AllAsync();
            var isExists = result.Exists(x => x.Name == name);

            return isExists;
        }
        /// <summary>
        /// Delete dog by name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpDelete("{name}")]
        public async Task<ActionResult<Dog>> Delete(string name)
        {
            if (CheckDataAsync(name).Result)
            {
                var entity = contextDogs.FindById(name);
                await contextDogs.Delete(entity.Result);
                return Ok("Deleted succesfully ");
            }
            return NotFound();
        }
    }

}
