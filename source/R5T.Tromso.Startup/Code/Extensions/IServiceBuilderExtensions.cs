using System;

using R5T.Dacia;
using R5T.Exeter;
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

        public static TStartup GetStartupInstance<TStartup>(this IServiceBuilder serviceBuilder)
            where TStartup : class, IStartup
        {
            var startup = ServiceProviderHelper.New().GetInstance<TStartup>();
            return startup;
        }

        public static IServiceBuilder UseStartup<TStartup>(this IServiceBuilder serviceBuilder)
            where TStartup: class, IStartup
        {
            // Get the startup instance.
            var startup = serviceBuilder.GetStartupInstance<TStartup>();

            serviceBuilder.UseStartup(startup);

            return serviceBuilder;
        }
    }
}
