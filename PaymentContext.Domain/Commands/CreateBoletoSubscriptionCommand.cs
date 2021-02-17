using Flunt.Notifications;
using Flunt.Validations;
using PaymentContext.Domain.Enums;
using PaymentContext.Shared.Commands;
using System;

namespace PaymentContext.Domain.Commands
{
    public class CreateBoletoSubscriptionCommand : Notifiable, ICommand
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Document { get; set; }
        public string Email { get; set; }
        public string BarCode { get; set; }
        public string BoletoNumber { get; set; }
        public string PaymentNumber { get; set; }
        public DateTime PaidDate { get; set; }
        public DateTime ExpireDate { get; set; }
        public decimal Total { get; set; }
        public decimal TotalPaid { get; set; }
        public string Payer { get; set; }
        public string PayerDocument { get; set; }
        public EDocumentType PayerDocumentType { get; set; }
        public string PayerEmail { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string Neighborhood { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }

        public void Validate()
        {
            AddNotifications(new Contract()
                .Requires()
                .HasMinLen(FirstName, 3, "Name.FirstName", "Nome deve conter pelo menos 3 caracteres")
                .HasMinLen(LastName, 3, "Name.LastName", "Sobrenome deve conter pelo menos 3 caracteres")
                .HasMaxLen(FirstName, 30, "Name.FirstName", "Nome deve conter até 30 caracteres")
                .IsLowerOrEqualsThan(0, Total, "Payment.Total", "O total não pode ser zero")
                .IsGreaterOrEqualsThan(Total, TotalPaid, "Payment.TotalPaid", "O valor pago é menor que o valor do pagamento")
                .HasMinLen(Street, 3, "Address.Street", "Rua deve conter pelo menos 3 caracteres")
                .HasMinLen(Number, 1, "Address.Number", "Sobrenome deve conter pelo menos 1 caracteres")
                .HasMinLen(Neighborhood, 3, "Address.Neighborhood", "Bairro deve conter pelo menos 3 caracteres")
                .HasMinLen(City, 3, "Address.City", "Cidade deve conter pelo menos 3 caracteres")
                .HasMinLen(State, 2, "Address.State", "Estado deve conter pelo menos 2 caracteres")
                .HasMinLen(Country, 3, "Address.Country", "País deve conter pelo menos 3 caracteres")
                .HasMinLen(ZipCode, 5, "Address.ZipCode", "Código Postal deve conter pelo menos 1 caracteres")
            );
        }
    }
}
