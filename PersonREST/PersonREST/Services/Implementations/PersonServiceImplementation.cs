﻿using Microsoft.AspNetCore.Http.HttpResults;
using PersonREST.Model;
using PersonREST.Model.Context;
using System;

namespace PersonREST.Services.Implementations
{
    public class PersonServiceImplementation : IPersonService
    {
        private MySQLContext _context;

        public PersonServiceImplementation(MySQLContext context)
        {
            _context= context;
        }

        public Person Create(Person person)
        {
            try
            {
                _context.Add(person);
                _context.SaveChanges();
            }
            catch(Exception ex)
            { 
                throw ex;
            }
            return person;
        }

        public void Delete(long id)
        {
            var result = _context.Persons.SingleOrDefault(p => p.Id.Equals(id));

            if (result == null)
                throw new Exception("Person does not exist in the Database.");
            
             try
             {
                 _context.Persons.Remove(result);
                 _context.SaveChanges();
             }
             catch (Exception ex)
             {
                 throw ex;
             }
        }

        public List<Person> FindAll()
        {

            return _context.Persons.ToList();
        }

        public Person FindByID(long id)
        {
            return _context.Persons.SingleOrDefault(p => p.Id.Equals(id));
        }

        public Person Update(Person person)
        {
            var result = _context.Persons.Find(person.Id);

            if (result == null)
                throw new Exception("Person does not exist in the Database.");
            try
            {
                _context.Entry(result).CurrentValues.SetValues(person);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error updating person: {ex.Message}");
            }
            return person;
        }
    }
}
