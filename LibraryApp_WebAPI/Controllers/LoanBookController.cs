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
    public class LoanBookController : ControllerBase
    {
        [HttpPost]
        public ActionResult Post(LoanBook loanBook)
        {

            LoanBookRepository.AddLoanBook(loanBook);
            return Ok();
        }

        [HttpGet("byInvNum")]
        public ActionResult<Member> GetLoanBookByInvNum(string invnum)
        {
            var member = LoanBookRepository.GetLoanBookByInvNum(invnum);
            return Ok(member);
        }

        [HttpGet("byLoanBook")]
        public ActionResult<Member> GetMemberByLoanBook(string invnum)
        {
            var member = LoanBookRepository.GetMemberIdByLoanBook(invnum);
            return Ok(member);
        }


        [HttpDelete("{invNum}")]
        public ActionResult Delete(string invNum)
        {
            var success = LoanBookRepository.DeleteLoanBook(invNum);
            if (success)
            {
                return Ok();
            }
            return NotFound();
        }
    }
}
