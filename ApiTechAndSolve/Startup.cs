using Application.Interface;
using Application.Main;
using AutoMapper;
using Domain.Core;
using Domain.Interface;
using Infrastructure.Data;
using Infrastructure.Interface;
using Infrastructure.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json.Serialization;
using Transversal.common;
using Transversal.Mapper;

namespace ApiTechAndSolve
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        readonly string myPolicy = "policyApiEcommerce";
        public IConfiguration Configuration { get; }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void ConfigureServices(IServiceCollection services)
        {
            //configura componenes para hacer el mapeo
            services.AddAutoMapper(x => x.AddProfile(new MappingProfile()), typeof(Startup));
            //permitir cors
            services.AddCors(options => options.AddPolicy(myPolicy, builder => builder.WithOrigins(Configuration["Config:OriginCors"])
                                                                                   .AllowAnyHeader()
                                                                                   .AllowAnyMethod()));
            services.AddControllers().AddNewtonsoftJson(options => {
                options.SerializerSettings.ContractResolver = new DefaultContractResolver();
            });

            services.AddMvc().AddJsonOptions(o =>
            {
                o.JsonSerializerOptions.PropertyNamingPolicy = null;
                o.JsonSerializerOptions.DictionaryKeyPolicy = null;
            });

            services.AddSingleton(Configuration);
            services.AddScoped<IDataProcessApplication, DataProcessApplication>();
            services.AddScoped<IDataProcessDomain, DataProcessDomain>();
            services.AddScoped<IDataProcessRepository, DataProcessRepository>();
            // se conecta una sola vez a la base de datos por eso el singelton y se reutiliza
            services.AddSingleton<IconectionFactory, ConnectionFactory>();

        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {

                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();
            app.UseCors(myPolicy);

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
