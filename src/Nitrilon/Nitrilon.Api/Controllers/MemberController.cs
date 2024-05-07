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
        public void AddMember(Member member)
        {
            MemberRepository memberRepo = new MemberRepository();

            try
            {
                memberRepo.AddMember(member);
            }
            catch (Exception e)
            {

                StatusCode(500);
            }

        }

        [HttpPut]
        public void UpdateMember(Member member)
        {
            MemberRepository memberRepo = new MemberRepository();

            try
            {
                memberRepo.UpdateMember(member);
            }
            catch (Exception e)
            {

                StatusCode(500);
            }

        }

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

        [HttpGet("{id}")]
        public Member GetMemberById(int id)
        {
            Member member = null;
            MemberRepository memberRepo = new();

            member = memberRepo.GetMemberBy(id);

            return member;
        }

    }
}
