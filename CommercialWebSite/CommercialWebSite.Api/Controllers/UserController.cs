using CommercialWebSite.DataRepositoryInterface;
using CommercialWebSite.ShareDTO.Auth;
using CommercialWebSite.ShareDTO.Business;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CommercialWebSite.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller
    {
        private readonly IUserAccountRepository _userRepository;

        public UserController(IUserAccountRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        [Authorize(Roles = UserRoles.Admin)]
        [Route("")]
        public async Task<IActionResult> GetAllAsync()
        {
            List<UserAccountModel> products = await _userRepository.GetAllAsync();
            return Ok(products);
        }
    }
}
