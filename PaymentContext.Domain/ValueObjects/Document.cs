using PaymentContext.Domain.Enums;
using PaymentContext.Shared.ValueObjects;

namespace PaymentContext.Domain.ValueObjects
{
    public class Document : ValueObject
    {

        public Document(string number, EDocumentType eDocumentType)
        {
            Number = number;
            EDocumentType = eDocumentType;
        }

        public string Number { get; private set; }
        public EDocumentType EDocumentType { get; private set; }

    }
}
