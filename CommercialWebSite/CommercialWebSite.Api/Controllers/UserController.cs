using CommercialWebSite.DataRepositoryInterface;
using CommercialWebSite.ShareDTO.Business;
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
        [Route("")]
        public async Task<IActionResult> GetByPageAsync(int page)
        {
            List<UserAccountModel> products = await _userRepository.GetAllAsync();
            return Ok(products);
        }
    }
}
