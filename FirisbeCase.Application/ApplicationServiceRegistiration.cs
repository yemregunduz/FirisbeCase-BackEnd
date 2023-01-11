using FirisbeCase.Application.Features.Authors.DependencyAggregate;
using FirisbeCase.Application.Features.Authors.Rules;
using FirisbeCase.Application.Features.Books.DependencyAggregate;
using FirisbeCase.Application.Features.Books.Rules;
using FirisbeCase.Application.Features.Categories.DependencyAggregate;
using FirisbeCase.Application.Features.Categories.Rules;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FirisbeCase.Application
{
    public static class ApplicationServiceRegistiration
    {
        public static IServiceCollection AddAplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());
            #region AggregateDependencyAddIOC
            services.AddScoped<IBookDependencyAggregate,BookDependencyAggregate>();
            services.AddScoped<ICategoryDependencyAggregate,CategoryDependencyAggregate>();
            services.AddScoped<IAuthorDependencyAggregate,AuthorDependencyAggregate>();
            #endregion
            #region BusinessRulesAddIOC
            services.AddScoped<BookBusinessRules>();
            services.AddScoped<CategoryBusinessRules>();
            services.AddScoped<AuthorBusinessRules>();
            #endregion

            return services;
        }
    }
}
