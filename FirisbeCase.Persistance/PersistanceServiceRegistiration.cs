using FirisbeCase.Application.Repositories;
using FirisbeCase.Persistance.Contexts;
using FirisbeCase.Persistance.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirisbeCase.Persistance
{
    public static class PersistanceServiceRegistiration
    {
        public static IServiceCollection AddPersistanceServices(this IServiceCollection services , IConfiguration configuration)
        {
            services.AddDbContext<FirisbeCaseDbContext>(options => options.UseSqlServer(
                configuration.GetConnectionString("FirisbeCaseDb")));

            #region Repository Dependencies
            services.AddScoped<IAuthorRepository, AuthorRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IBookRepository, BookRepository>();
            return services;
            #endregion
        }
    }
}
