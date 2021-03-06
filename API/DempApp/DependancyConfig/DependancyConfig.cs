using DA.Domain.Interfaces;
using DA.Infrastructure.SQL.Data;
using DA.Infrastructure.SQL.Repositories;
using DA.ServicesInterfaces;
using DM.ApplicationServices;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PK.BuildingBlocks.Infrastructure;
using PK.BuildingBlocks.Repository;
//using PK.BuildingBlocks.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DempApp.DependancyConfig
{
    public class DependancyConfig
    {
        private IServiceCollection _services;
        private IConfiguration _configuration;

        public DependancyConfig(IServiceCollection services, IConfiguration configuration)
        {
            _services = services;
            _configuration = configuration;

        }

        public void ConfigureServices()
        {
            AddDependencyRepository();
            AddDependencyService();
            AddDependencyValidator();
            AddEmailClient();
            AddBizTalkEMailClient();
        }

        /// <summary>
        /// AddDependencyValidator
        /// </summary>
        private void AddDependencyValidator()
        {
            #region Commented Codes
            //_services.AddScoped<IValidator<GroupsRequest>, GroupsRequestValidator>();
            //_services.AddScoped<IValidator<CompanyRequest>, CompanyRequestValidator>();

            #endregion

        }
        /// <summary>
        /// AddDependencyRepository
        /// </summary>
        private void AddDependencyRepository()
        {
            _services.AddScoped(typeof(IRepository<>), typeof(RepositoryEF<>));

            _services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));

            _services.AddScoped<ICustomerOrdersRequestRepos, CustomerOrdersRequestRepository>();
            _services.AddScoped<ICustomersRequestRepos, CustomersRequestRepository>();
            _services.AddScoped<IOrdersRequestRepos, OrdersRequestRepository>();
            _services.AddScoped<IProductsRequestRepos, ProductsRequestRepository>();
            _services.AddScoped<IProductTypeRequestRepos, ProductTypeRequestRepository>();
        }

        /// <summary>
        /// AddDependencyService
        /// </summary>
        private void AddDependencyService()
        {
            _services.AddScoped<ICustomerService, CustomerService>();
            _services.AddScoped<IProductsService, ProductService>();



        }

        public void AddEmailClient()
        {
            #region commented Codes
            //    if (_configuration["SMTP:SMTPEnabled"] == "true")
            //        _services.Configure<SmtpOptions>(_configuration.GetSection("SMTP"));
            //    _services.AddSingleton<ISmtpEmailClient, SmtpEmailClient>();
            #endregion
        }

        public void AddBizTalkEMailClient()
        {
            #region commented Codes
            //var baseUrl = _configuration["BiztalkEmailClient:EmailBase"];
            //var apiMethod = _configuration["BiztalkEmailClient:ApiMethod"];
            //var proxy = _configuration["BiztalkEmailClient:Proxy"];
            //_services.AddScoped<IEmailClient>(x =>
            //{
            //    return new BizTalkEMailClient
            //    {
            //        BaseUrl = baseUrl,
            //        ApiMethod = apiMethod,
            //        Proxy = proxy
            //    };
            //});
            #endregion
        }

        private void AddDependencyBus()
        {
            #region commented codes
            //_services.AddSingleton(configuration =>
            //{
            //    /// Add MassTransit Service Bus
            //    var massTransitConfig = _configuration.GetSection(string.Format("{0}:MassTransit", _configuration["Api:Default"]));
            //    var _rabbitMQHost = massTransitConfig["ClusterUrl"];
            //    var _rabbitMQUserName = massTransitConfig["UserName"];
            //    var _rabbitMQPassword = massTransitConfig["Password"];
            //    var nodes = massTransitConfig.GetSection("Nodes").Get<string[]>();

            //    var bus = Bus.Factory.CreateUsingRabbitMq(sbc =>
            //    {
            //        var host = sbc.Host(new Uri($"rabbitmq://{_rabbitMQHost}"), h =>
            //        {
            //            h.Username(_rabbitMQUserName);
            //            h.Password(_rabbitMQPassword);
            //            if (nodes != null && nodes.Any())
            //                h.UseCluster(e =>
            //                {
            //                    foreach (var node in nodes)
            //                    {
            //                        e.Node(node);
            //                    }
            //                });
            //        });

            //        sbc.UseConcurrencyLimit(1);

            //        #region "Message Senders"
            //        sbc.Publish<EmailTemplateDTO>(e => { e.ExchangeType = ExchangeType.Topic; });
            //        sbc.Send<EmailTemplateDTO>(e => e.UseRoutingKeyFormatter(x => $"IdentityManagement.{x.Message.Source}.{x.Message.RequestType}"));
            //        #endregion

            //        #region "Consumers"
            //        sbc.ReceiveEndpoint(host, "IDM.EmailNotification.NOT", e =>
            //        {
            //            e.BindMessageExchanges = false;
            //            e.Bind("MG.Identity.Event:ForgotPasswordEmailRequested", config =>
            //            {
            //                config.RoutingKey = "*.*";
            //                config.ExchangeType = ExchangeType.Topic;
            //                config.Durable = true;
            //            });
            //            e.Consumer(() => new ForgotPasswordEmailEvent());
            //        });
            //        #endregion
            //    });
            //    return bus;
            //});

            ////start the service bus
            //var sp = _services.BuildServiceProvider();
            //var busControl = sp.GetService<IBusControl>();
            //if (busControl != null)
            //    busControl.Start();
            #endregion
        }
    }
}
