using Libralgo.Business.Abstract;
using Libralgo.Business.Concrete;
using Libralgo.Data.Abstract;
using Libralgo.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libralgo.Business.Extensions
{
    public static class ServiceRegistrations
    {
        public static void AddServiceRegistrations(this IServiceCollection services)
        {
            services.AddScoped<IBookDal, BookRepository>();
            services.AddScoped<IBookService, BookService>();

            services.AddScoped<IAuthorDal, AuthorRepository>();
            services.AddScoped<IAuthorService, AuthorService>();

            services.AddScoped<ICategoryDal, CategoryRepository>();
            services.AddScoped<ICategoryService, CategoryService>();

            services.AddScoped<ILibraryDal, LibraryRepository>();
            services.AddScoped<ILibraryService, LibraryService>();

            services.AddScoped<ILibraryMemberDal, LibraryMemberRepository>();
            services.AddScoped<ILibraryMemberService, LibraryMemberService>();

            services.AddScoped<IPublisherDal, PublisherRepository>();
            services.AddScoped<IPublisherService, PublisherService>();

            services.AddScoped<IUserDal, UserRepository>();
            services.AddScoped<IUserService, UserService>();
        }
    }
}
