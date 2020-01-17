using System;

using R5T.Richmond;
using R5T.Tromso.Types;


namespace R5T.Tromso.Startup
{
    public static class IBuildableServiceExtensions
    {
        public static void UseStartup<TStartup>(this IBuildableService buildableService, IServiceProvider configurationServiceProvider)
            where TStartup : class, IStartup
        {
            var serviceBuilder = buildableService.GetServiceBuilder();

            serviceBuilder.UseStartup<TStartup>();

            serviceBuilder.Build(configurationServiceProvider);
        }
    }
}
