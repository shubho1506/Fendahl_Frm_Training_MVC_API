using Fendahl_API_Profile.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace Fendahl_API_Profile.Services
{
    public class ProfileServices : IProfileServices
    {
        private ApplicationDBContext _context;
        public ProfileServices(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<Profile> CreateProfile(Profile profile)
        {
             _context.Profiles.Add(profile);
             _context.SaveChanges();
             return profile;
        }

        public async Task<bool> DeleteProfile(int id)
        {
            var profile = _context.Profiles.Find(id);
            if (profile == null)
            {
                return false;
            }
            _context.Profiles.Remove(profile);
            _context.SaveChanges();
            return true;
        }

        public async Task<IEnumerable<Profile>> GetAllProfiles()
        {
            return _context.Profiles.ToList();
        }

        public async Task<Profile> GetProfileById(int id)
        {
            return _context.Profiles.Find(id);
        }

        public async Task<bool> UpdateProfileById(int id,Profile profile)
        {
            if (id != profile.Id)
            {
                return false;
            }
            _context.Profiles.Update(profile);
            _context.SaveChanges(true);
            return true;
        }
    }
}
