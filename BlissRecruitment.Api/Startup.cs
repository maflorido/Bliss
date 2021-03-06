using BlissRecruitment.Domain;
using BlissRecruitment.Domain.Questions;
using BlissRecruitment.Domain.Repository;
using BlissRecruitment.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Reflection;

namespace BlissRecruitment.Api
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
            services.AddControllers();
            services.AddDbContext<ApplicationDbContext>(opt =>
            {
                opt.UseNpgsql(Configuration.GetConnectionString("ApiDataBase"),
                    x => x.MigrationsAssembly(Assembly.GetAssembly(typeof(ApplicationDbContext)).FullName));
            });
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<QuestionStorer>();
            services.AddScoped<IUnitOfwork, UnitOfwork>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.Use(async (context, next) => {
                await next.Invoke();

                IUnitOfwork unitOfWork = context.RequestServices.GetService<IUnitOfwork>();
                await unitOfWork.Commit();
            });

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
