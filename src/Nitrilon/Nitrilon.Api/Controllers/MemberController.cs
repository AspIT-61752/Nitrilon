using Microsoft.AspNetCore.Mvc;
using Nitrilon.DataAccess;
using Nitrilon.Entities;

namespace Nitrilon.Api.Controllers
{
    [Route("api/[controller]")] // Part of the URL the client calls
    [ApiController]
    public class MemberController : ControllerBase
    {
        [HttpGet]
        public List<Member> GetAllMembers()
        {
            List<Member> members = new();
            MemberRepository memberRepo = new();

            try
            {
                members = memberRepo.GetMembers();
            }
            catch (Exception e)
            {
                StatusCode(500);
            }

            return members;
        }

    }
}
