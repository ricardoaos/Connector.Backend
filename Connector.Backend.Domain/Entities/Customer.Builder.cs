using BasicCrud.Domain.Entities.Specifications;
using System;
using Tnf.Builder;
using Tnf.Notifications;

namespace Connector.Backend.Domain.Entities
{
    public partial class Customer
    {
        public class Builder : Builder<Customer>
        {
            public Builder(INotificationHandler notificationHandler)
                : base(notificationHandler)
            {
            }

            public Builder(INotificationHandler notificationHandler, Customer instance)
                : base(notificationHandler, instance)
            {
            }

            public Builder WithId(long id)
            {
                Instance.Id = id;
                return this;
            }

            public Builder WithName(string name)
            {
                Instance.Name = name;
                return this;
            }

            protected override void Specifications()
            {
                AddSpecification<CustomerShouldHaveNameSpecification>();
            }
        }
    }
}
