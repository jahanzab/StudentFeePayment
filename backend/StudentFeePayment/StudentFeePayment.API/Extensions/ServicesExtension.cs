using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using StudentFeePayment.Entities;
using StudentPayment.Contracts;
using StudentPayment.Repository;

namespace StudentFeePayment.API.Extensions
{
    public static class ServicesExtension
    {
        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(name: "DefaultPolicy",
                    policy =>
                    {
                        policy.AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                        //.WithMethods("PUT", "DELETE", "GET", "POST");
                    });
            });
        }

        public static void Configureservices(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddControllers();
            services.AddHttpContextAccessor();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("ConnectionString"),
                    x => x.MigrationsAssembly("StudentFeePayment.Entities"));
            });

            // auto mapper for models and dto's
            services.AddAutoMapper(typeof(Program));


            //Add services
            services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();


        }
    }
}
