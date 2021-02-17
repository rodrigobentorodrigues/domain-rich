using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.Queries;
using PaymentContext.Domain.ValueObjects;
using System.Collections.Generic;
using System.Linq;

namespace PaymentContext.Tests.Queries
{
    [TestClass]
    public class StudentQueriesTests
    {

        private IList<Student> _students;

        public StudentQueriesTests()
        {
            this._students = new List<Student>();
            for (int i = 0; i <= 10; i++)
            {
                _students.Add(new Student(new Name("Aluno", i.ToString()),
                    new Document("1111111111" + i.ToString(), EDocumentType.CPF),
                    new Email("rocklee@gmail.com")));
            }
        }

        [TestMethod]
        public void ShouldReturnErrorWhenDocumentNotExists()
        {
            var expression = StudentQueries.GetStudentInfo("11111122233");
            var student = _students.AsQueryable().Where(expression).FirstOrDefault();

            Assert.AreEqual(null, student);
        }

        [TestMethod]
        public void ShouldReturnErrorWhenDocumentExists()
        {
            var expression = StudentQueries.GetStudentInfo("11111111111");
            var student = _students.AsQueryable().Where(expression).FirstOrDefault();

            Assert.AreNotEqual(null, student);
        }

    }
}
