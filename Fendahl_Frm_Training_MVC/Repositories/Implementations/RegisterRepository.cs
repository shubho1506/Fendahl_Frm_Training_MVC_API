using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using Fendahl_Frm_Training_MVC.Models;

namespace Fendahl_Frm_Training_MVC.Repositories
{
    public class RegisterRepository : IRegisterRepository
    {
        private readonly FENDAHL_EXAMINATION_Context _context;

        public RegisterRepository()
        {
            _context = new FENDAHL_EXAMINATION_Context();
        }

        public bool AddAsync(REGISTRATION registration)
        {
            _context.REGISTRATION.Add(registration);
            if (_context.SaveChanges() > 0)
            {
                return true;
            }
            return false;
        }

        //public bool DeleteAsync(int id)
        //{
        //    var person = _context.REGISTRATION.FirstOrDefault(r => r.ID == id);
        //    _context.REGISTRATION.Remove(person);
        //    if (_context.SaveChanges() > 0)
        //    {
        //        return true;
        //    }
        //    return false;
        //}

        public bool DeleteAsync(int id)
        {
            var person = _context.REGISTRATION.FirstOrDefault(r => r.ID == id);
            if (person == null)
                return false;

            _context.REGISTRATION.Remove(person);
            return _context.SaveChanges() > 0;
        }


        public List<REGISTRATION> GetAllAsync()
        {
            var registrations = _context.REGISTRATION.ToList();
            return registrations;
        }

        public REGISTRATION GetByIdAsync(int id)
        {
            var registration = _context.REGISTRATION.Find(id);
            if ((registration) == null)
            {
                return null;
            }
            return registration; ;
        }

        //public REGISTRATION GetByValueAsync(string name, string mobile)
        //{
        //    var persons = _context.REGISTRATION.ToList();
        //    var person = persons.Find(a => a.NAME == name && a.MOBILE_NUMBER==mobile);
        //    return person;
        //}

        public REGISTRATION GetByValueAsync(string name, string mobile)
        {
            return _context.REGISTRATION.FirstOrDefault(a => a.NAME == name && a.MOBILE_NUMBER == mobile);
        }


        public bool UpdateAsync(REGISTRATION registration)
        {
            _context.REGISTRATION.AddOrUpdate(registration);
            if (_context.SaveChanges() > 0)
            {
                return true;
            }
            return false;
        }
    }
}