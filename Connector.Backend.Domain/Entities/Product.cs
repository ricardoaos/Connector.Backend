﻿using System;
using Tnf.Notifications;

namespace Connector.Backend.Domain.Entities
{
    public partial class Product : IEntity
    {
        public Guid Id { get; set; }
        public string Description { get; set; }

        public float Value { get; set; }

        public static Builder Create(INotificationHandler handler)
            => new Builder(handler);

        public static Builder Create(INotificationHandler handler, Product instance)
            => new Builder(handler, instance);
    }
}