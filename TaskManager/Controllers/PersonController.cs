using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskManager.Models;

namespace TaskManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        // DbContext ile Database baglantisi yapiyoruz
        private readonly PersonDbContext _personDbContext;

        public PersonController(PersonDbContext personDbContext)
        {
            _personDbContext = personDbContext;
        }
        // Crud islemlerini yaziyoruz
        [HttpGet]
        [Route("GetPerson")]
        public async Task<IEnumerable<Person>> GetPersons()
        {
            return await _personDbContext.Person.ToListAsync();
        }
        [HttpPost]
        [Route("AddPerson")]
        public async Task<Person> AddPerson(Person objPerson)
        {
            _personDbContext.Person.Add(objPerson);
            await _personDbContext.SaveChangesAsync();
            return objPerson;
        }
        [HttpPut]
        [Route("UpdatePerson/{id}")]
        public async Task<Person> UpdatePerson(Person objPerson)
        {
            _personDbContext.Entry(objPerson).State = EntityState.Modified;
            await _personDbContext.SaveChangesAsync();
            return objPerson;
        }
        [HttpDelete]
        [Route("DeletePerson/{id}")]
        public bool DeletePerson(int id)
        {
            bool a = false;
            var Person = _personDbContext.Person.Find(id);
            if (Person != null)
            {
                a = true;
                _personDbContext.Entry(Person).State = EntityState.Deleted;
                _personDbContext.SaveChanges();
            }
            else
            {
                a = false;
            }
            return a;
        }
    }
}
