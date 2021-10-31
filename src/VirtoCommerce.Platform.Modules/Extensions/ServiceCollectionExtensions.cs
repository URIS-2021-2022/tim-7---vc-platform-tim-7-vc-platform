using System;
using System.IO;
using System.Linq;
using System.Reflection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using VirtoCommerce.Platform.Core.Common;
using VirtoCommerce.Platform.Core.Modularity;
using VirtoCommerce.Platform.Modules.External;

namespace VirtoCommerce.Platform.Modules
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddModules(this IServiceCollection services, IConfiguration configuration, bool isDevelopment, Action<Assembly> registerApiControllers = null, Action<LocalStorageModuleCatalogOptions> setupAction = null)
        {
            services.AddOptions<LocalStorageModuleCatalogOptions>().Bind(configuration.GetSection("VirtoCommerce"))
                    .PostConfigure(options =>
                    {
                        options.DiscoveryPath = Path.GetFullPath(options.DiscoveryPath ?? "modules");
                    })
                    .ValidateDataAnnotations();

            services.AddSingleton(services);

            services.AddSingleton<IModuleInitializer, ModuleInitializer>();
            // Cannot inject IHostingEnvironment to LoadContextAssemblyResolver as IsDevelopment() is an extension method (means static) and cannot be mocked by Moq in tests
            services.AddSingleton<IAssemblyResolver, LoadContextAssemblyResolver>(provider =>
                new LoadContextAssemblyResolver(provider.GetService<ILogger<LoadContextAssemblyResolver>>(), isDevelopment));
            services.AddSingleton<IModuleManager, ModuleManager>();
            services.AddSingleton<ILocalModuleCatalog, LocalStorageModuleCatalog>();
            services.AddSingleton<IModuleCatalog>(provider => provider.GetService<ILocalModuleCatalog>());

            if (setupAction != null)
            {
                services.Configure(setupAction);
            }
            var providerSnapshot = services.BuildServiceProvider();

            var manager = providerSnapshot.GetRequiredService<IModuleManager>();
            var moduleCatalog = providerSnapshot.GetRequiredService<ILocalModuleCatalog>();

            manager.Run();

            // Ensure all modules are loaded
            foreach (var module in moduleCatalog.Modules
                .OfType<ManifestModuleInfo>()
                .Where(x => x.State == ModuleState.NotStarted && x.Groups.Contains("platform"))
                .ToArray())
            {
                manager.LoadModule(module.ModuleName);

                // VP-2190: No need to add parts for modules with laoding errors - it could cause an exception
                if (module.Assembly != null && module.Errors.IsNullOrEmpty())
                {
                    // Register API controller from modules
                    registerApiControllers?.Invoke(module.Assembly);
                }
            }

            // Ensure all modules are loaded
            foreach (var module in moduleCatalog.Modules
                .OfType<ManifestModuleInfo>()
                .Where(x => x.State == ModuleState.NotStarted && !x.Groups.Contains("platform"))
                .ToArray())
            {
                manager.LoadModule(module.ModuleName);

                // VP-2190: No need to add parts for modules with laoding errors - it could cause an exception
                if (module.Assembly != null && module.Errors.IsNullOrEmpty())
                {
                    // Register API controller from modules
                    registerApiControllers?.Invoke(module.Assembly);
                }
            }

            services.AddSingleton(moduleCatalog);

            services.AddOptions<ExternalModuleCatalogOptions>().Bind(configuration.GetSection("ExternalModules")).ValidateDataAnnotations();
            services.AddExternalModules();

            return services;
        }

        public static IServiceCollection AddExternalModules(this IServiceCollection services, Action<ExternalModuleCatalogOptions> setupAction = null)
        {
            services.AddSingleton<IExternalModulesClient, ExternalModulesClient>();
            services.AddSingleton<IExternalModuleCatalog, ExternalModuleCatalog>();
            services.AddSingleton<IModuleInstaller, ModuleInstaller>();

            if (setupAction != null)
            {
                services.Configure(setupAction);
            }

            services.AddSingleton<IPlatformRestarter, ProcessPlatformRestarter>();

            return services;
        }
    }
}
