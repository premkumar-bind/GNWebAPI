using GNWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace GNWebAPI.Controllers
{
    public class ContactController : ApiController
    {

        private CustomerEntities db = new CustomerEntities();
        // GET: api/Customers
        public IQueryable<tblContact> GetContacts()
        {


            return db.tblContacts;
        }

        // GET: api/Customers/5
        [ResponseType(typeof(tblContact))]
        public IHttpActionResult GetCustomer(int id)
         {
            tblContact Cont = db.tblContacts.Find(id);
            if (Cont == null)
            {
                return NotFound();
            }

            return Ok(Cont);
        }

        // PUT: api/Customers/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCustomer(int id, tblContact Cont)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != Cont.ContactId)
            {
                return BadRequest();
            }

            db.Entry(Cont).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Customers
        [ResponseType(typeof(tblContact))]
        public IHttpActionResult PostCustomer(tblContact cont)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tblContacts.Add(cont);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = cont.ContactId }, cont);
        }

        // DELETE: api/Customers/5
        [ResponseType(typeof(tblContact))]
        public IHttpActionResult DeleteCustomer(int id)
        {
            tblContact customer = db.tblContacts.Find(id);
            if (customer == null)
            {
                return NotFound();
            }

            db.tblContacts.Remove(customer);
            db.SaveChanges();

            return Ok(customer);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CustomerExists(int id)
        {
            return db.tblContacts.Count(e => e.ContactId == id) > 0;
        }
    }
}