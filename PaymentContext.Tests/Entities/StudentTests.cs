using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Tests.Entities
{
    [TestClass]
    class StudentTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var student = new Student(new Name("Rodrigo", "Bento"), new Document("12345678912", Domain.Enums.EDocumentType.CPF), 
                "rodrigo@gmail.com");
        }

    }
}
