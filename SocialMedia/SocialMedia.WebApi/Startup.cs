using AutoMapper;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SocialMedia.Core.Interfaces;
using SocialMedia.Infrastructure.Data;
using SocialMedia.Infrastructure.Filters;
using SocialMedia.Infrastructure.Repositories;
using System;

namespace SocialMedia.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //Los mapeos los realiza esta libreria una unica vez, esto busca en los compilados de
            //los proyectos, e identifica los profiles
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddControllers().AddNewtonsoftJson(options =>
            {
                //Ignoramos la referencia circular
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            })
            .ConfigureApiBehaviorOptions(options =>
            {
                //Configuramos las opciones de comportamiento de la API va a validar nuestro estado,
                //y esta propiedad la suprimimos, esto si lo queremos validar de forma manual, o
                //si no queremos validarlo
                //Lo comentamos para no suprmir los errores, sino para que el ApiController sea el
                //encargado de los errores
                //options.SuppressModelStateInvalidFilter = true;
            });

            services.AddDbContext<SocialMediaContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("SocialMedia"))
            );

            //Para resolver las dependencias debemos:
            //Se le esta entregando a la clase una instancia de esta
            //implementacion, en este caso seria PostRepository
            //Apuntamos a las abstracciones y no a las
            //implementaciones
            services.AddTransient<IPostRepository, PostRepository>();

            //Con esto le decimos a la aplicacion que haremos un filtro de manera global
            //Ahora haremos las validaciones igual que con el automapper, lo hacemos en
            //el metodo MVC. Aqui mencionamos que queremos hacer nuestras validaciones
            //desde nuestros assemblies. Se puede hacer desde un unico assemblie, pero
            //en nueastro caso lo hacemos de diferentes. En nuestro caso tenemos
            //nuestras validaciones en una capa diferente al de nuestras Api ,pero si
            //estuvieran en la misma capa, le especificariamos que lo saque de los que
            //son clase Startup
            services.AddMvc(options => {
                options.Filters.Add<ValidationFilter>();
            })
            .AddFluentValidation(options =>
            {
                options.RegisterValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
