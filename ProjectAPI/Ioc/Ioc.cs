using Project.Infra;
using ProjectAPI.Services;
using Project.Data;
using Project.Services;
using ProjectAPI.Authorization;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace ProjectAPI.Ioc
{
  public class NativeInjectorBootStrapper
  {
    public static void RegisterServices(IServiceCollection services)
    {

      // ASP.NET HttpContext dependency
      services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
      services.AddSingleton<System.Net.Http.HttpClient, System.Net.Http.HttpClient>();

      // Domain Bus (Mediator)
      // services.AddScoped<IMediatorHandler, InMemoryBus>();

      // ASP.NET Authorization Polices
      /* services.AddSingleton<IAuthorizationHandler, ClaimsRequirementHandler>(); */
      services.AddSingleton<IAuthorizationHandler, RoleClaimRequirmentHandler>(); ;

      AutoMapper.IConfigurationProvider config = new MapperConfiguration(
          cfg => { cfg.AddMaps(Assembly.GetExecutingAssembly()); }
          );

      services.AddSingleton(config);
      services.AddScoped<IMapper, Mapper>();

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
      services.AddScoped<AppDbContext>();
      services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
      services.AddScoped<IContentService, ContentService>();
      services.AddScoped<IMovieService, MovieService>();
      services.AddScoped<IFolderService, FolderService>();
      services.AddScoped<IEventService, EventService>();
      services.AddScoped<INoteService, NoteService>();
      services.AddScoped<ICategoryService, CategoryService>();
      services.AddScoped<IUnitOfWork, UnitOfWork>();

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
