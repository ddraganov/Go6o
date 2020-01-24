using Go6o.AbTesting;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System.Reflection;

namespace Go6o.QueueProcessor.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddABTestEventHandlers(this IServiceCollection services, Assembly assembly)
        {
            var classTypes = assembly.ExportedTypes.Select(t => t.GetTypeInfo()).Where(t => t.IsClass && !t.IsAbstract);

            foreach (var type in classTypes)
            {
                var interfaces = type.ImplementedInterfaces.Select(i => i.GetTypeInfo());

                foreach (var handlerType in interfaces.Where(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IABTestEventHandler<>)))
                {
                    services.AddTransient(handlerType.AsType(), type.AsType());
                }
            }

            return services;
        }
    }
}
