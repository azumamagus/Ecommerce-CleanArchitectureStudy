using Ecommerce.Application;
using Ecommerce.Application.Dtos;
using Ecommerce.Application.Interfaces;
using Ecommerce.Application.Mappers;
using Ecommerce.Application.Mappers.Interfaces;

namespace Ecommerce.Infrastructure.CrossCuting.Extensions.Ioc;

public static class ServicesCollectionsExtensions
{
    public static IServiceCollection AddRavenDB(this IServiceCollection serviceCoollection)
    {
        serviceCoollection.TryAddSingleton<IDocumentStore>(ctx =>
       {
           var ravenDbSettings = ctx.GetRequiredService<IOptions<RavenDbSettings>>().Value;

           var store = new DocumentStore
           {
               Urls = new[] { ravenDbSettings.Url },
               Database = ravenDbSettings.DataBaseName,
           };

           store.Initialize();

           return store;
       });
        return serviceCoollection;
    }

    public static IServiceCollection AddRepositories(this IServiceCollection serviceCollection)
    {
        serviceCollection.TryAddSingleton<ICustomerRepository, CustomerRepository>();
        return serviceCollection;
    }

    public static IServiceCollection AddDomainServices(this IServiceCollection serviceCollection)
    {
        serviceCollection.TryAddScoped<ICustomerService, CustomerService>();
        return serviceCollection;
    }

    public static IServiceCollection AddMappers(this IServiceCollection serviceCollection)
    {
        serviceCollection.TryAddScoped<IMapper<Customer, CustomerDto>, CustomerMapper>();
        serviceCollection.TryAddScoped<IMapper<CustomerDto, Customer>, CustomerMapper>();
        return serviceCollection;
    }

    public static IServiceCollection AddApplicationServices(this IServiceCollection serviceCollection)
    {
        serviceCollection.TryAddScoped<ICustomerApplicationService, CustomerApplicationService>();
        return serviceCollection;
    }
}
