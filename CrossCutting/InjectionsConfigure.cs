using Data.Repositories;
using Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Service.Interface;
using Service.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossCutting.InjectionsConfigure
{
    public static class InjectionsConfigure
    {
        public static void AddDependencyInjectionConfig(this IServiceCollection services)
        {
            //baseEntity
            services.AddScoped(typeof(IBaseService<>), typeof(BaseService<>));
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            //User
            services.AddScoped(typeof(IUserRepository), typeof(UserRepository));
            services.AddScoped(typeof(IUserService), typeof(UserService));
            //Like
            services.AddScoped(typeof(ILikeRepository), typeof(LikeRepository));
            services.AddScoped(typeof(ILikeService), typeof(LikeService));
            //Post
            services.AddScoped(typeof(IPostRepository), typeof(PostRepository));
            services.AddScoped(typeof(IPostService), typeof(PostService));
            //Deslike
            services.AddScoped(typeof(IDeslikeRepository), typeof(DeslikeRepository));
            services.AddScoped(typeof(IDeslikeService), typeof(DeslikeService));
            //Comment
            services.AddScoped(typeof(ICommentRepository), typeof(CommentRepository));
            services.AddScoped(typeof(ICommentService), typeof(CommnetService));

        }
    }
}
