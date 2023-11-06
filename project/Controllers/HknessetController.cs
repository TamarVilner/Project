﻿using Microsoft.AspNetCore.Mvc;
using project.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HknessetController : ControllerBase
    {
        // GET: api/<HknessetController>
        public List<Hknesset> hknessets = new List<Hknesset> {  new Hknesset { Id = 1, PartyName = "הליכוד", Type = 1 }, new Hknesset { Id = 2, PartyName = "ג", Type = 1 }, new Hknesset { Id = 3, PartyName = "רעמ", Type = 2 }, new Hknesset { Id = 4, PartyName = "יש עתיד", Type = 2 } };

        [HttpGet]
        public IEnumerable<Hknesset> Get()
        {
            return hknessets;
        }

        // GET api/<HknessetController>/5
        [HttpGet("{id}")]
        public ActionResult<Hknesset> Get(int id)
        {
            var h = hknessets.Find(x => x.Id == id);
            if (h == null)
                return NotFound();
            return h;
        }

        // POST api/<HknessetController>
        [HttpPost]
        public void Post([FromBody] Hknesset h)
        {
            hknessets.Add(h);
            //אם יעשה בעיות אז השורה הזו
            //
            //hknessets.Add(new Hknesset { Id = h.Id, PartyName = h.PartyName, Type = h.Type };
        }

        // PUT api/<HknessetController>/5
        [HttpPut("{id}")]
        public ActionResult Put( [FromBody] Hknesset hknesset)
        {
            var h = hknessets.Find(x => x.Id == hknesset.Id);
            if (h == null)
                return NotFound();
            h.Id = hknesset.Id;
            h.PartyName= hknesset.PartyName;
            h.Type = hknesset.Type;
            return Ok();  
            
        }

        // DELETE api/<HknessetController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var h = hknessets.Find(x => x.Id == id);
            if (h == null)
                return NotFound();
            hknessets.Remove(h);
            return Ok();
        }
    }
}