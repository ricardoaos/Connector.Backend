﻿using Connector.Backend.Domain.Entities;
using Connector.Backend.Domain.Interfaces.Repositories;
using Connector.Backend.Domain.Interfaces.Services;
using System;
using System.Threading.Tasks;
using Tnf.Domain.Services;
using Tnf.Notifications;

namespace Connector.Backend.Domain.Services
{
    public class ProductDomainService : DomainService, IProductDomainService
    {
        private readonly IProductRepository _repository;

        public ProductDomainService(IProductRepository repository, INotificationHandler notificationHandler)
            : base(notificationHandler)
        {
            _repository = repository;
        }

        public Task DeleteProductAsync(Guid id) => _repository.DeleteProductAsync(id);

        public async Task<Product> InsertProductAsync(Product.Builder builder)
        {
            if (builder == null)
            {
                Notification.RaiseError(Constants.LocalizationSourceName, Error.DomainServiceOnInsertNullBuilderError);
                return default;
            }

            var product = builder.Build();

            if (Notification.HasNotification())
                return default;

            product = await _repository.InsertProductAndGetIdAsync(product);

            return product;
        }

        public async Task<Product> UpdateProductAsync(Product.Builder builder)
        {
            if (builder == null)
            {
                Notification.RaiseError(Constants.LocalizationSourceName, Error.DomainServiceOnUpdateNullBuilderError);
                return default;
            }

            var product = builder.Build();

            if (Notification.HasNotification())
                return default;

            return await _repository.UpdateProductAsync(product);
        }
    }
}
