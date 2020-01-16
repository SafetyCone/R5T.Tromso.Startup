using System;

using R5T.Richmond;


namespace R5T.Tromso.Startup
{
    public static class IServiceBuilderExtensions
    {
        /// <summary>
        /// Links an <see cref="IStartup"/> instance to an <see cref="IServiceBuilder"/>.
        /// </summary>
        public static IServiceBuilder UseStartup(this IServiceBuilder serviceBuilder, IStartup startup)
        {
            serviceBuilder.AddConfigureConfiguration(startup.ConfigureConfiguration);

            serviceBuilder.AddConfigureServices(startup.ConfigureServices);

            serviceBuilder.AddConfigure(startup.Configure);

            return serviceBuilder;
        }
    }
}
