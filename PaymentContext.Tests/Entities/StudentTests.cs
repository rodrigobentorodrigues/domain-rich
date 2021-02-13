using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Entities;

namespace PaymentContext.Tests.Entities
{
    [TestClass]
    class StudentTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var student = new Student("Rodrigo", "Bento", "12345678912", "rodrigo@gmail.com");
        }

    }
}
