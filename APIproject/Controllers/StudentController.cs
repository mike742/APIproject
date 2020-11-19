using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIproject.Data;
using APIproject.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APIproject.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly StudentDbContext _dbc = new StudentDbContext();

        // GET: api/<StudentController>
        [HttpGet]
        public IEnumerable<Student> Get()
        {
            return _dbc.Students.ToList();
        }

        // GET api/<StudentController>/5
        [HttpGet("{id}")]
        public Student Get(int id)
        {
            return _dbc.Students.Find(id);
        }

        // POST api/<StudentController>
        [HttpPost]
        public void Post([FromBody] Student value)
        {
            _dbc.Students.Add(value);
            _dbc.SaveChanges();
        }

        // PUT api/<StudentController>/5
        [HttpPut]
        public void Put([FromBody] Student value)
        {
            Student st = _dbc.Students.Where(s => s.Id == value.Id)
                                        .FirstOrDefault();

            if (st != null)
            {
                st.Name = value.Name;
                st.Email = value.Email;

                _dbc.SaveChanges();
            }
        }

        // DELETE <StudentController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Student st = _dbc.Students.Find(id);
            _dbc.Students.Remove(st);
            _dbc.SaveChanges();
        }
    }
}
