using Flunt.Notifications;
using PaymentContext.Domain.Commands;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.Repositories;
using PaymentContext.Domain.ValueObjects;
using PaymentContext.Shared.Commands;
using PaymentContext.Shared.Handlers;
using System;

namespace PaymentContext.Domain.Handlers
{
    public class SubscriptionHandler : Notifiable, 
        IHandler<CreateBoletoSubscriptionCommand>, 
        IHandler<CreateCreditCardSubscriptionCommand>, 
        IHandler<CreatePayPalSubscriptionCommand>
    {

        private readonly IStudentRepository _repository;

        public SubscriptionHandler(IStudentRepository repo)
        {
            this._repository = repo;
        }

        public ICommandResult Handle(CreateBoletoSubscriptionCommand command)
        {
            command.Validate();
            if (command.Invalid)
            {
                AddNotifications(command);
                return new CommandResult(false, "Não foi possível realizar sua assinatura!");
            }

            if (_repository.DocumentExists(command.Document))
                AddNotification("Document", "Este CPF já está em uso");

            if (_repository.EmailExists(command.Email))
                AddNotification("Document", "Este email já está em uso");

            var name = new Name(command.FirstName, command.LastName);
            var document = new Document(command.Document, EDocumentType.CPF);
            var email = new Email(command.Email);
            var address = new Address(command.Street, command.Number, command.Neighborhood, command.City, 
                command.State, command.Country, command.ZipCode);
            
            var student = new Student(name, document, email);
            var subscription = new Subscription(DateTime.Now.AddMonths(1));
            var payment = new BoletoPayment(command.BarCode, command.BoletoNumber, command.PaidDate, 
                command.ExpireDate, command.Total, command.TotalPaid, command.Payer, 
                new Document(command.PayerDocument, command.PayerDocumentType), address, email);

            subscription.AddPayment(payment);
            student.AddSubscription(subscription);

            AddNotifications(name, document, email, address, student, subscription, payment);

            _repository.CreateSubscription(student);

            return new CommandResult(true, "Assinatura realizada com sucesso!");
        }

        public ICommandResult Handle(CreateCreditCardSubscriptionCommand command)
        {
            command.Validate();
            if (command.Invalid)
            {
                AddNotifications(command);
                return new CommandResult(false, "Não foi possível realizar sua assinatura!");
            }

            if (_repository.DocumentExists(command.Document))
                AddNotification("Document", "Este CPF já está em uso");

            if (_repository.EmailExists(command.Email))
                AddNotification("Document", "Este email já está em uso");

            var name = new Name(command.FirstName, command.LastName);
            var document = new Document(command.Document, EDocumentType.CPF);
            var email = new Email(command.Email);
            var address = new Address(command.Street, command.Number, command.Neighborhood, command.City,
                command.State, command.Country, command.ZipCode);

            var student = new Student(name, document, email);
            var subscription = new Subscription(DateTime.Now.AddMonths(1));
            var payment = new CreditCardPayment(command.CardHolderName, command.CardNumber, command.LastTransactionNumber,
                command.PaidDate, command.ExpireDate, command.Total, command.TotalPaid, command.Payer,
                new Document(command.PayerDocument, command.PayerDocumentType), address, email);

            subscription.AddPayment(payment);
            student.AddSubscription(subscription);

            AddNotifications(name, document, email, address, student, subscription, payment);

            _repository.CreateSubscription(student);

            return new CommandResult(true, "Assinatura realizada com sucesso!");
        }

        public ICommandResult Handle(CreatePayPalSubscriptionCommand command)
        {
            command.Validate();
            if (command.Invalid)
            {
                AddNotifications(command);
                return new CommandResult(false, "Não foi possível realizar sua assinatura!");
            }

            if (_repository.DocumentExists(command.Document))
                AddNotification("Document", "Este CPF já está em uso");

            if (_repository.EmailExists(command.Email))
                AddNotification("Document", "Este email já está em uso");

            var name = new Name(command.FirstName, command.LastName);
            var document = new Document(command.Document, EDocumentType.CPF);
            var email = new Email(command.Email);
            var address = new Address(command.Street, command.Number, command.Neighborhood, command.City,
                command.State, command.Country, command.ZipCode);

            var student = new Student(name, document, email);
            var subscription = new Subscription(DateTime.Now.AddMonths(1));
            var payment = new PayPalPayment(command.TransactionCode, command.PaidDate,
                command.ExpireDate, command.Total, command.TotalPaid, command.Payer,
                new Document(command.PayerDocument, command.PayerDocumentType), address, email);

            subscription.AddPayment(payment);
            student.AddSubscription(subscription);

            AddNotifications(name, document, email, address, student, subscription, payment);

            _repository.CreateSubscription(student);

            return new CommandResult(true, "Assinatura realizada com sucesso!");
        }
    }
}
