using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Repositories;
using System;

namespace PaymentContext.Tests.Mocks
{
    public class FakeStudentRepository : IStudentRepository
    {

        public void CreateSubscription(Student student)
        {
            throw new NotImplementedException();
        }

        public bool DocumentExists(string document)
        {
            if (document == "123123123123")
                return true;

            return false;
        }

        public bool EmailExists(string email)
        {
            if (email == "rocklee@gmail.com")
                return true;

            return false;
        }

    }
}
