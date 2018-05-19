using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TraderInfo.Data;
using TraderInfo.Models;

namespace TraderInfo.Controllers
{
    [Produces("application/json")]
    [Route("api/Transaction")]
    public class TransactionController : Controller
    {
        private TransactionRepository _transactionContext = new TransactionRepository();

        // GET: api/Transaction
        [HttpGet(Name = "GetAll")]
        [ProducesResponseType(200, Type = typeof(Transaction))]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetAll()
        {
            var result = await _transactionContext.GetItemsAsync(v => v.TransactionId != null);
            if (result != null)
                return Ok(result);
            else
                return NotFound();
        }

        // GET: api/Transaction/5
        [HttpGet("{id}", Name = "Get")]
        [ProducesResponseType(200, Type = typeof(Transaction))]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Get(string id)
        {
            var result = await _transactionContext.GetItemAsync(id);
            if (result != null)
                return Ok(result);
            else
                return NotFound();
        }
        
        // POST: api/Transaction
        [HttpPost]
        [ProducesResponseType(201, Type = typeof(Transaction))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Post([FromBody] Transaction value)
        {


            var result = await _transactionContext.CreateItemAsync(value);

            if (result != null)
            {
                return CreatedAtRoute(
                    routeName: "Get",
                    routeValues: new {id = result.TransactionId},
                    value: result);
            }
            else
                return BadRequest(ModelState);
        }
        
        // PUT: api/Transaction/5
        [HttpPut("{id}")]
        [ProducesResponseType(201, Type = typeof(Transaction))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Put(string id, [FromBody]Transaction value)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _transactionContext.UpdateItemAsync(id, value);

            if (result != null)
            {
                return CreatedAtRoute(
                    routeName: "Get",
                    routeValues: new { id = result.TransactionId },
                    value: result);
            }
            else
                return BadRequest(ModelState);
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        [ProducesResponseType(200, Type = typeof(Transaction))]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Delete(string id)
        {
            var result = _transactionContext.DeleteItemAsync(id);

            if (result != null)
                return Ok(id);
            else
                return NotFound();
        }
    }
}
