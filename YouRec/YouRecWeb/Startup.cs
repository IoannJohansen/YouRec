using AutoMapper;
using BLL.Core.Auth.Jwt;
using BLL.Interfaces;
using BLL.Services;
using CloudinaryDotNet;
using DAL.Data;
using DAL.Infrastructure.Interfaces;
using DAL.Infrastructure.UnitOfWork;
using DAL.Model;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Linq;
using YouRecWeb.Core.Mapper;

namespace YouRecWeb
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        readonly string AllowedOrigins = "allowedOrigins";

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(name: AllowedOrigins,
                builder =>
                {
                    builder.WithOrigins("localhost:3000")
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowAnyOrigin();
                });
            });

            services.AddEasyQuery();

            var cloudName = Configuration["CloudinarySettings:CloudName"];
            var apiKey = Configuration["CloudinarySettings:ApiKey"];
            var apiSecret = Configuration["CloudinarySettings:ApiSecret"];

            if (new[] { cloudName, apiKey, apiSecret }.Any(string.IsNullOrWhiteSpace))
            {
                throw new ArgumentException("Please specify Cloudinary account details!");
            }
            services.AddSingleton(new Cloudinary(new Account(cloudName, apiKey, apiSecret)));

            services.AddControllers();

            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(Configuration["ConnectionString:DefaultConnection"]);
            });

            var mapperConfig = new MapperConfiguration(config =>
            {
                config.AddProfile(new MappingProfile());
            });
            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);

            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IAuthService, AuthService>();
            services.AddTransient<ITagService, TagService>();
            services.AddTransient<IRecommendService, RecommendService>();
            services.AddTransient<ILikeService, LikeService>();
            services.AddTransient<ICommentService, CommentService>();
            services.AddTransient<IRatingService, RatingService>();
            services.AddTransient<IGroupService, GroupService>();
            services.AddTransient<IImageService, ImageService>();
            services.AddTransient<IRecommendTagService, RecommendTagService>(); 
            services.AddTransient<IUserService, UserService>();

            services.AddSingleton(Configuration);

            services.AddAuthentication(options =>
            {
                options.DefaultSignInScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultSignInScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
            {
                options.SaveToken = true;
                options.RequireHttpsMetadata = true;
                options.TokenValidationParameters = JwtOptions.GetTokenValidationParameters();
            });

            services.AddIdentity<AppUser, IdentityRole>(options =>
            {
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireDigit = true;
                options.Password.RequireUppercase = false;
                options.User.RequireUniqueEmail = true;
                options.User.AllowedUserNameCharacters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyzÀÁÂÃÄÅ¨ÆÇÈÉÊËÌÍÎÏĞÑÒÓÔÕÖ×ØÙÚÛÜİŞßàáâãäå¸æçèéêëìíîïğñòóôõö÷øùúûüışÿ1234567890_- ";
            }).AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseCors(AllowedOrigins);

            app.UseAuthentication();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}