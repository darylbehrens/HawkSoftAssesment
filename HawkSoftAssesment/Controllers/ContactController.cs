using HawkSoftAssesment.Models;
using HawkSoftAssesment.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HawkSoftAssesment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly ContactStore ContactStore;
        public ContactController(ContactStore contactStore) 
        {
            ContactStore = contactStore;
        }

        // GET api/<ContactController>/5
        [HttpGet("{id}")]
        public async Task<IEnumerable<Contact>> Get(int id)
        {
            return await ContactStore.GetBy(id);
        }

        // POST api/<ContactController>
        [HttpPost]
        public async Task<int> Post([FromBody] Contact contact)
        {
            return await ContactStore.Insert(contact);
        }

        // PUT api/<ContactController>/5
        [HttpPut]
        public async Task Put([FromBody] Contact contact)
        {
            await ContactStore.Update(contact);
        }

        // DELETE api/<ContactController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await ContactStore.Delete(id);
        }
    }
}
