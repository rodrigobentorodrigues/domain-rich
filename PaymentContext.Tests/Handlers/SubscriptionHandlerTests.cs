using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Commands;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.Handlers;
using PaymentContext.Tests.Mocks;
using System;

namespace PaymentContext.Tests.Handlers
{
    [TestClass]
    public class SubscriptionHandlerTests
    {
        [TestMethod]
        public void ShouldReturnErrorWhenDocumentExists()
        {
            var handler = new SubscriptionHandler(new FakeStudentRepository());
            var command = new CreateBoletoSubscriptionCommand();
            command.BarCode = "123123123";
            command.FirstName = "Rock";
            command.LastName = "Lee";
            command.Document = "123123123123";
            command.Email = "leerock@gmail.com";
            command.BoletoNumber = "123456789";
            command.PaymentNumber = "0";
            command.PaidDate = DateTime.Now;
            command.ExpireDate = DateTime.Now.AddMonths(1);
            command.Total = 60;
            command.TotalPaid = 60;
            command.Payer = "Might Guy";
            command.PayerDocument = "123456789";
            command.PayerDocumentType = EDocumentType.CPF;
            command.PayerEmail = "leerock@gmail.com";
            command.Street = "adsad";
            command.Number = "adasd";
            command.Neighborhood = "adsasd";
            command.City = "asdsas";
            command.State = "asfasf";
            command.Country = "asflks";
            command.ZipCode = "asfasf";

            handler.Handle(command);
            Assert.AreEqual(true, handler.Invalid);
        }
    }
}
