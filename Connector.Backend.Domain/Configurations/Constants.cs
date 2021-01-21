using System;
using System.Collections.Generic;
using System.Text;

namespace Connector.Backend.Domain.Configurations
{
    public class Constants
    {
        public const string LocalizationSourceName = "Connector";

        private const string ENVIRONMENT_VARIABLE = "ASPNETCORE_ENVIRONMENT";
        private const string DEV_ENVIRONMENT_VARIABLE = "DEVELOPMENT";

        public static bool IsDevelopment()
        {
            var environmentName = Environment.GetEnvironmentVariable(ENVIRONMENT_VARIABLE);
            if (environmentName.ToUpperInvariant() == DEV_ENVIRONMENT_VARIABLE)
                return true;

            return false;
        }
    }
}
