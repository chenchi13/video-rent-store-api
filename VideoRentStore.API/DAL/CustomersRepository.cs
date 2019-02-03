using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VideoRentStore.API.Models;

namespace VideoRentStore.API.DAL
{
    public class CustomersRepository : IRepository<Customer>
    {
        private readonly VideoRentStoreDBContext db;

        public CustomersRepository(VideoRentStoreDBContext context)
        {
            this.db = context;
        }

        public IQueryable<Customer> Query => throw new NotImplementedException();

        public void Add(Customer entity)
        {
            db.Customers.Add(entity);
        }

        public int Delete(Customer entity)
        {
            try
            {
                db.Customers.Remove(entity);
                db.SaveChangesAsync();
                return 1;
            }
            catch
            {
                throw;
            }
        }

        public List<Customer> FetchAll()
        {
            return db.Customers.ToList();
        }

        public Customer Get(int id)
        {
            try
            {
                Customer customer =  db.Customers.Include(k => k.Rents).Include("Rents.Movie").FirstOrDefault(k => k.IdCustomer == id);
                return customer;
            }
            catch
            {
                throw;
            }
        }

        public void Save()
        {
            db.SaveChangesAsync();
        }

        public int Update(Customer entity)
        {
            try
            {
                db.Entry(entity).State = EntityState.Modified;
                db.SaveChanges();
                return 1;
            }
            catch
            {
                throw;
            }
        }
    }
}
