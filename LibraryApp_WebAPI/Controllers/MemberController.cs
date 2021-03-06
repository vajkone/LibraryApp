﻿
using LibraryApp_Common.Models;
using LibraryApp_WebAPI.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryApp_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberController : ControllerBase
    {

        [HttpGet]
        public ActionResult<IEnumerable<Member>> Get()
        {
            var members = MemberRepository.GetMembers();
            return Ok(members);
        }

        [HttpGet("{id}")]
        public ActionResult<Member> Get(long id)
        {
            var member = MemberRepository.GetMember(id);


            if (member != null)
            {
                return Ok(member);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet("byName")]
        public ActionResult<IList<Member>> GetMembersByName(string name)
        {
            var members = MemberRepository.GetMembersByName(name);
            return Ok(members);
        }

        [HttpGet("byFullName")]
        public ActionResult<Member> GetMemberByFullName(string name)
        {
            var member = MemberRepository.GetMemberByFullName(name);
            return Ok(member);
        }

        [HttpGet("byInvNum")]
        public ActionResult<IList<Member>> GetLoaningMember(string invNum)
        {
            var member = MemberRepository.GetLoaningMember(invNum);
            return Ok(member);
        }






        [HttpPost]
        public ActionResult Post(Member member)
        {

            MemberRepository.AddMember(member);
            return Ok();
        }

        [HttpPut("{id}")]
        public ActionResult Put(Member member, long id)
        {
            var dbMember = MemberRepository.GetMember(id);
            if (dbMember != null)
            {
                MemberRepository.UpdateMember(member);
                return Ok();
            }
            return NotFound();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(long id)
        {
            var success = MemberRepository.DeleteMember(id);
            if (success)
            {
                return Ok();
            }
            return NotFound();
        }
    }
}
