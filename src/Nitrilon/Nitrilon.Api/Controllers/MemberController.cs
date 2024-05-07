using Microsoft.AspNetCore.Mvc;
using Nitrilon.DataAccess;
using Nitrilon.Entities;

namespace Nitrilon.Api.Controllers
{
    [Route("api/[controller]")] // Part of the URL the client calls
    [ApiController]
    public class MemberController : ControllerBase
    {
        [HttpPost]
        public ActionResult<int> AddMember(Member member)
        {
            MemberRepository memberRepo = new MemberRepository();

            try
            {
                int id = memberRepo.AddMember(member);
                return Ok(id);
            }
            catch (Exception e)
            {
                return StatusCode(500);
            }
        }

        [HttpPut]
        public IActionResult UpdateMember(Member member)
        {
            MemberRepository memberRepo = new MemberRepository();

            try
            {
                memberRepo.UpdateMember(member);
            }
            catch (Exception e)
            {

                return StatusCode(500);
            }

            return Ok();

        }

        [HttpGet]
        public IActionResult GetAllMembers()
        {
            List<Member> members = new();
            MemberRepository memberRepo = new();

            try
            {
                members = memberRepo.GetMembers();
            }
            catch (Exception e)
            {
                return StatusCode(500);
            }

            return Ok(members);
        }

        [HttpGet("{id}")]
        public ActionResult<Member> GetMemberById(int id)
        {
            Member member = null;
            MemberRepository memberRepo = new();

            try
            {
                member = memberRepo.GetMemberBy(id);
                return Ok(member);
            }
            catch (Exception e)
            {
                return StatusCode(500);
            }
        }

        [HttpDelete]
        public IActionResult DeleteMemberById(int id)
        {
            MemberRepository memberRepo = new();

            try
            {
                memberRepo.RemoveMemberBy(id);
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(500);
            }
        }

    }
}
