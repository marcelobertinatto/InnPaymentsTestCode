using InCommPayment.Application.Interfaces;
using InCommPayment.Application.Services;
using InCommPayment.Domain.Interfaces;
using InCommPayment.Domain.Interfaces.Repositories;
using InCommPayment.Domain.Interfaces.Services;
using InCommPayment.Domain.Services;
using InCommPayment.Infra.Context;
using InCommPayment.Infra.Repository;
using InCommPayment.Infra.UnitOfWork;
using Microsoft.EntityFrameworkCore;

namespace InCommPaymentWebApiCore
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //Db
            builder.Services.AddDbContext<DBContext>(opt => opt.UseInMemoryDatabase("ProductOrder"));

            //DI mapping

            //application
            builder.Services.AddTransient(typeof(IAppServiceBase<>), typeof(AppServiceBase<>));
            builder.Services.AddTransient(typeof(IAppServiceOrder), typeof(AppServiceOrder));
            builder.Services.AddTransient(typeof(IAppServiceProduct), typeof(AppServiceProduct));

            //domain
            //services
            builder.Services.AddTransient(typeof(IServiceBase<>), typeof(ServiceBase<>));
            builder.Services.AddTransient(typeof(IServiceOrder), typeof(ServiceOrder));
            builder.Services.AddTransient(typeof(IServiceProduct), typeof(ServiceProduct));

            //repository
            builder.Services.AddTransient(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
            builder.Services.AddTransient(typeof(IOrderRepository), typeof(RepositoryOrder));
            builder.Services.AddTransient(typeof(IProductRepository), typeof(RepositoryProduct));

            //infra
            //unitOfWork
            builder.Services.AddTransient(typeof(IUnitOfWork), typeof(UnitOfWork));

            builder.Services.AddControllers();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();


            var app = builder.Build();

            app.MapControllers();

            app.UseSwagger();
            app.UseSwaggerUI();

            app.UseCors(x => x
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());

            app.UseHttpsRedirection();
            //app.UseSwaggerUI(c =>
            //{
            //    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            //    c.RoutePrefix = "";
            //});

            app.Run();
        }
    }
}
