using Fendahl_API_Profile.Models;
using Fendahl_API_Profile.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Fendahl_API_Profile.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfilesController : ControllerBase
    {
        private IProfileServices _services;
        public ProfilesController(IProfileServices services)
        {
            _services = services;
        }

        [HttpGet]
        public async Task<IEnumerable<Profile>> GetProducts()
        {

            return await _services.GetAllProfiles();
        }

        [HttpPost]
        public IActionResult AddProduct(Profile profile)
        {
            try
            {
                _services.CreateProfile(profile);
                return StatusCode(StatusCodes.Status201Created, profile);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    message = ex.Message,
                    inner = ex.InnerException?.Message,
                    stack = ex.StackTrace
                });
            }
        }

        [HttpGet("{id}")]
        public Task<Profile> GetProductbyID(int id)
        {
            return _services.GetProfileById(id);
        }

        [HttpPut]
        public IActionResult UpdateProduct(int id, Profile profile)
        {
            try
            {
                if (id != profile.Id)
                {
                    return StatusCode(StatusCodes.Status400BadRequest);
                }
                _services.UpdateProfileById(id, profile);
                return StatusCode(StatusCodes.Status200OK);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProductById(int id)
        {
            _services.DeleteProfile(id);
            return Ok(new { message = "Profile deleted successfully." });
        }
    }
}
