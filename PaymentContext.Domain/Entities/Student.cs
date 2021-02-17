using Flunt.Validations;
using PaymentContext.Domain.ValueObjects;
using PaymentContext.Shared.Entities;
using System.Collections.Generic;
using System.Linq;

namespace PaymentContext.Domain.Entities
{
    public class Student : Entity
    {
        public Student(Name name, Document document, Email email)
        {
            Name = name;
            Document = document;
            Email = email;
            _subscriptions = new List<Subscription>();

            AddNotifications(name, document, email);
        }

        public Name Name { get; set; }
        public Document Document { get; private set; }
        public Email Email { get; private set; }
        public Address Address { get; private set; }
        public IReadOnlyCollection<Subscription> Subscriptions { get { return _subscriptions.ToArray(); } }
        private IList<Subscription> _subscriptions;

        public void AddSubscription(Subscription subscription)
        {
            var hasSubscriptionActive = false;
            foreach (var sub in Subscriptions)
            {
                if (sub.Active)
                    hasSubscriptionActive = true;
            }

            var hasPayments = subscription.Payments.Count > 0 ? true : false;
            if (hasSubscriptionActive)
                AddNotification("Student.Subscriptions", "Você já tem uma assinatura válida");

            if (!hasPayments)
                AddNotification("Student.Subcription.Payments", "Essa assinatura não possui pagamentos");

            _subscriptions.Add(subscription);
        }

    }
}
