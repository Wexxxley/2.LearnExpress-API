using LearnExpress.Application.Interfaces;
using LearnExpress.Application.Mapping;
using LearnExpress.Application.Services;
using LearnExpress.Infra.Data.Repositories;
using LearnExpress.Domain.Interfaces;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LearnExpress.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace LearnExpress.Infra.Ioc
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfraestructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<LearnExpressContext>(options =>
              options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

            services.AddAutoMapper(typeof(ToDTOMappingProfile));

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            //Curso
            services.AddScoped<ICursoService, CursoService>();
            services.AddScoped<ICursoRepository, CursoRepository>();
            //Category
            services.AddScoped<ICategoryService, CategoryService>();
            //Usuario
            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            //Progresso
            services.AddScoped<IProgressoService, ProgressoService>();
            services.AddScoped<IProgressoRepository, ProgressoRepository>();
            //Pedido
            services.AddScoped<IPedidoRepository, PedidoRepository>();
            services.AddScoped<IPedidoService, PedidoService>();
            //Aula
            services.AddScoped<IAulaRepository, AulaRepository>();
            services.AddScoped<IAulaService, AulaService>();

            return services;
        }
    }
}
