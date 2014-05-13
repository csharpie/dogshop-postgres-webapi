using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using DogShop.Models;

namespace DogShop.Controllers
{
    public class DogController : ApiController
    {
        private readonly DogShopContext _db = new DogShopContext();

        // GET api/Dog
        public IQueryable<Dog> GetDogs()
        {
            return _db.Dogs;
        }

        // GET api/Dog/5
        [ResponseType(typeof(Dog))]
        public IHttpActionResult GetDog(int id)
        {
            Dog dog = _db.Dogs.Find(id);
            if (dog == null)
            {
                return NotFound();
            }

            return Ok(dog);
        }

        // PUT api/Dog/5
        public IHttpActionResult PutDog(int id, Dog dog)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != dog.Id)
            {
                return BadRequest();
            }

            _db.Entry(dog).State = EntityState.Modified;

            try
            {
                _db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DogExists(id))
                {
                    return NotFound();
                }
                throw;
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST api/Dog
        [ResponseType(typeof(Dog))]
        public IHttpActionResult PostDog(Dog dog)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _db.Dogs.Add(dog);
            _db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = dog.Id }, dog);
        }

        // DELETE api/Dog/5
        [ResponseType(typeof(Dog))]
        public IHttpActionResult DeleteDog(int id)
        {
            Dog dog = _db.Dogs.Find(id);
            if (dog == null)
            {
                return NotFound();
            }

            _db.Dogs.Remove(dog);
            _db.SaveChanges();

            return Ok(dog);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DogExists(int id)
        {
            return _db.Dogs.Count(e => e.Id == id) > 0;
        }
    }
}