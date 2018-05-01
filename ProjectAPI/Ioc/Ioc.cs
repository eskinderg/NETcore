using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Project.Data;
using Project.Services;
using Microsoft.Extensions.DependencyInjection;

namespace ProjectAPI.Ioc
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // ASP.NET HttpContext dependency
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            // Domain Bus (Mediator)
            // services.AddScoped<IMediatorHandler, InMemoryBus>();

            // ASP.NET Authorization Polices
            // services.AddSingleton<IAuthorizationHandler, ClaimsRequirementHandler>(); ;

            // Application
            services.AddSingleton(Mapper.Configuration);
            services.AddScoped<IMapper>(sp => new Mapper(sp.GetRequiredService<IConfigurationProvider>(), sp.GetService));
            // services.AddScoped<ICustomerAppService, CustomerAppService>();

            // Domain - Events
            // services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();
            // services.AddScoped<INotificationHandler<CustomerRegisteredEvent>, CustomerEventHandler>();
            // services.AddScoped<INotificationHandler<CustomerUpdatedEvent>, CustomerEventHandler>();
            // services.AddScoped<INotificationHandler<CustomerRemovedEvent>, CustomerEventHandler>();

            // Domain - Commands
            // services.AddScoped<INotificationHandler<RegisterNewCustomerCommand>, CustomerCommandHandler>();
            // services.AddScoped<INotificationHandler<UpdateCustomerCommand>, CustomerCommandHandler>();
            // services.AddScoped<INotificationHandler<RemoveCustomerCommand>, CustomerCommandHandler>();

            // Infra - Data
            // services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddSingleton(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IDbContext, ProjectDbContext>();
            services.AddScoped<IContentService, ContentService>();
            services.AddScoped<IFolderService, FolderService>();

            // services.AddScoped<IUnitOfWork, UnitOfWork>();
            // services.AddScoped<EquinoxContext>();

            // Infra - Data EventSourcing
            // services.AddScoped<IEventStoreRepository, EventStoreSQLRepository>();
            // services.AddScoped<IEventStore, SqlEventStore>();
            // services.AddScoped<EventStoreSQLContext>();

            // Infra - Identity Services
            // services.AddTransient<IEmailSender, AuthEmailMessageSender>();
            // services.AddTransient<ISmsSender, AuthSMSMessageSender>();

            // Infra - Identity
            // services.AddScoped<IUser, AspNetUser>();
        }
    }
}