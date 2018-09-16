﻿using GraphQL;
using GraphQL.DataLoader;
using GraphQL.Http;
using GraphQL.Types;
using GraphQLDotNet.Data;
using GraphQLDotNet.Middleware;
using GraphQLDotNet.Store;
using GraphQLDotNet.Types;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GraphQLDotNet
{
    public class Startup
    {
        public IConfigurationRoot Configuration { get; set; }

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

            /*if(env.IsDevelopment())
            {
                builder.AddUserSecrets<Startup>();
            }*/

            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddEntityFrameworkNpgsql()
                .AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(Configuration["DefaultConnection"]));

            services.AddScoped<IDependencyResolver>(s => new FuncDependencyResolver(s.GetRequiredService));

            services.AddSingleton<IDocumentWriter, DocumentWriter>();
            services.AddSingleton<IDocumentExecuter, DocumentExecuter>();
            services.AddSingleton<IDataLoaderContextAccessor, DataLoaderContextAccessor>();
            services.AddSingleton<DataLoaderDocumentListener>();

            services.AddScoped<IDataStore, DataStore>();

            services.AddScoped<InventoryQuery>();
            services.AddScoped<InventoryMutation>();
            services.AddScoped<ISchema, InventorySchema>();

            services.AddScoped<ItemType>();
            services.AddScoped<ItemInputType>();
            services.AddScoped<CustomerType>();
            services.AddScoped<CustomerInputType>();
            services.AddScoped<OrderType>();
            services.AddScoped<OrderInputType>();
            services.AddScoped<OrderItemType>();
            services.AddScoped<OrderItemInputType>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.UseMiddleware<GraphQLMiddleware>();
        }
    }
}
