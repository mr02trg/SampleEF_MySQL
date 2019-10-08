using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SampleEFCore.Model;

namespace SampleEFCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private BaseContext _context;
        public ValuesController(BaseContext context)
        {
            _context = context;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return _context.MyValues.Select(x => x.Name).ToList();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            var record = _context.MyValues.First(x => x.Id == id);
            return record.Name;
        }

        // POST api/values
        [HttpPost]
        public void Post(MyValueRequest request)
        {
            var newValue = new MyValue { Name = request.Name };
            _context.MyValues.Add(newValue);
            _context.SaveChanges();
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] MyValueRequest request)
        {
            var record = _context.MyValues.First(x => x.Id == id);
            record.Name = request.Name;
            _context.SaveChanges();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var record = _context.MyValues.First(x => x.Id == id);
            _context.MyValues.Remove(record);
            _context.SaveChanges();
        }
    }
}
