using Fendahl_API_Profile.Models;
using Microsoft.AspNetCore.Mvc;

namespace Fendahl_API_Profile.Services
{
    public interface IProfileServices
    {
        Task<Profile> GetProfileById(int id);
        Task<IEnumerable<Profile>> GetAllProfiles();
        Task<Profile> CreateProfile(Profile profile);
        Task<bool> UpdateProfileById(int id,Profile profile);
        Task<bool> DeleteProfile(int id);
    }
}
