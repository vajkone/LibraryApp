using LibraryApp_Common.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LibraryApp.Tests
{
    [TestClass]
    public class MemberTest
    {
        [TestMethod]
        public void CreateMemberWithWhitespace_ShouldThrowArgumentException()
        {
            
            Assert.ThrowsException<System.ArgumentException>(() => new Member("TestWrong","     "));
            
        }

        [TestMethod]
        public void CreateMemberWithMoreWhitespace_ShouldThrowArgumentException()
        {

            Assert.ThrowsException<System.ArgumentException>(() => new Member("       ", "     "));

        }
    }
}
