﻿using Microsoft.Build.Tasks.Deployment.Bootstrapper;
using System;
using System.Linq.Expressions;
using Tnf.Specifications;

namespace Connector.Backend.Domain.Entities.Specifications
{
    public class ProductShouldHaveDescriptionSpecification : Specification<Product>
    {
        public override string LocalizationSource { get; protected set; } = Constants.LocalizationSourceName;
        public override Enum LocalizationKey { get; protected set; } = Product.Error.ProductShouldHaveDescription;

        public override Expression<Func<Product, bool>> ToExpression()
        {
            return (p) => !string.IsNullOrWhiteSpace(p.Description);
        }
    }
}