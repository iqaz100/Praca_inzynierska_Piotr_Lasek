using Brutus_RestApi.Managers.Classes;
using Brutus_RestApi.Managers.Interfaces;
using Brutus_RestApi.Models;
using Brutus_RestApi.Repositories.Classes;
using Brutus_RestApi.Repositories.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using System;
using AutoMapper;

namespace Brutus_RestApi
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

            services.AddCors(options =>
            {
                options.AddPolicy("AllowOrigin",
                    builder => builder.AllowAnyOrigin());
            });

            services.AddMvc();

            services.AddAutoMapper(typeof(Startup));
            services.AddEntityFrameworkMySql();
            services.AddDbContext<mydbContext>( // replace "YourDbContext" with the class name of your DbContext
                options => options.UseMySql("Server=localhost;Database=mydb;User=root;Password=13jaro13;TreatTinyAsBoolean=true;", // replace with your Connection String
                    mySqlOptions =>
                    {
                        mySqlOptions.ServerVersion(new Version(5, 7, 17), ServerType.MySql); // replace with your Server Version and Type
                    }
            ));
            
            services.AddControllers();
            services.AddScoped<IStudentRepository, StudentRepository>();
            services.AddScoped<IStudentManager, StudentManager>();
            services.AddScoped<IGradeRepository, GradeRepository>();
            services.AddScoped<IGradesManager, GradesManager>();
            services.AddScoped<IAbsenceRepository, AbsenceRepository>();
            services.AddScoped<IAbsenceManager, AbsenceManager>();
            services.AddScoped<ILoginRepository, LoginRepository>();
            services.AddScoped<ILoginManager, LoginManager>();
            services.AddScoped<IBehaviorRepository, BehaviorRepository>();
            services.AddScoped<IBehaviorManager, BehaviorManager>();
            services.AddScoped<ISubjectRepository, SubjectRepository>();
            services.AddScoped<ISubjectManager, SubjectManager>();
            services.AddScoped<IClassRepository, ClassRepository>();
            services.AddScoped<IClassManager, ClassManager>();
            services.AddScoped<IPersonRepository, PersonRepository>();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                c.RoutePrefix = string.Empty;
            });

            app.UseRouting();

            app.UseCors();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
