using Autofac;
using Business.Abstract;
using Business.Concrete;
using Core.Utilities.Security.JWT.Abstract;
using Core.Utilities.Security.JWT.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DependencyResolvers.Autofac
{
   public class AutofacBusinessModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            //services.AddTransient<IArticleService, ArticleManager>();
            //services.AddTransient<IArticleDal, ArticleDal>();
            //services.AddTransient<IQuestionService, QuestionManager>();
            //services.AddTransient<IQuestionDal, QuestionDal>();
            //services.AddTransient<IUserService, UserManager>();
            //services.AddTransient<IUserDal, UserDal>();
            //services.AddTransient<IQuestionService, QuestionManager>();
            //services.AddTransient<IQuestionDal, QuestionDal>();
            //services.AddTransient<IQuestionCommentService, QuestionCommentManager>();
            //services.AddTransient<IArticleCommentService, ArticleCommentManager>();
            //services.AddTransient<IArticleCommentDal, ArticleCommentDal>();
            //services.AddTransient<IQuestionCommentDal, QuestionCommentDal>();
            //services.AddTransient<IAuthService, AuthManager>();
            //services.AddTransient<ITokenHelper, JwtHelper>();
            builder.RegisterType<HttpContextAccessor>().As<IHttpContextAccessor>().SingleInstance();
            builder.RegisterType<UserManager>().As<IUserService>().SingleInstance();
            builder.RegisterType<UserDal>().As<IUserDal>().SingleInstance();
            builder.RegisterType<ArticleManager>().As<IArticleService>().SingleInstance();
            builder.RegisterType<ArticleDal>().As<IArticleDal>().SingleInstance();
            builder.RegisterType<QuestionManager>().As<IQuestionService>().SingleInstance();
            builder.RegisterType<QuestionDal>().As<IQuestionDal>().SingleInstance();
          
            
            builder.RegisterType<QuestionCommentManager>().As<IQuestionCommentService>().SingleInstance();
            builder.RegisterType<QuestionCommentDal>().As<IQuestionCommentDal>().SingleInstance();
            builder.RegisterType<ArticleCommentManager>().As<IArticleCommentService>().SingleInstance();
            builder.RegisterType<ArticleCommentDal>().As<IArticleCommentDal>().SingleInstance();
            builder.RegisterType<AuthManager>().As<IAuthService>().SingleInstance();
            builder.RegisterType<JwtHelper>().As<ITokenHelper>().SingleInstance();
           
        }
    }
}
