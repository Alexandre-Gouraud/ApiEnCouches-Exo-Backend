namespace ApiEnCouches.Controllers.User.AdminController
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Authorization;

    [Authorize(Roles = "Admin")]
    [ApiController]
    [Route("api/[controller]")]
    public class AdminController : ControllerBase
    {
        [HttpGet("stats")]
        public IActionResult GetStats()
        {
            return Ok("Accès Admin validé.");
        }
    }
}