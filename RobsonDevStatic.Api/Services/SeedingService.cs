using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using RobsonDevStatic.Api.Data;
using RobsonDevStatic.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RobsonDevStatic.Api.Services
{
    public static class SeedingService
    {
        public static async Task PeoplesSeedingStart(this IApplicationBuilder appBuilder)
        {
            using (var serviceScope = appBuilder.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                await Task.Factory.StartNew(() =>
                {
                    var context = serviceScope.ServiceProvider.GetService<ContextData>();

                    context.People = context.People ?? new People { 
                        Nickname = "Robson Alves", 
                        Name = "Robson", 
                        Birthday = new DateTime(1980, 8, 29), 
                        Country = "Brasil", 
                        State = "Paraná", 
                        Email = "robson.curitibapr@gmail.com" 
                    };

                    context.SocialMedia = context.SocialMedia ?? new SocialMedia
                    {
                        LinkedIn = @"https://www.linkedin.com/in/robson-curitiba/",
                        Github = @"https://github.com/robsondesenvolvimento",
                        Discord = @"https://discord.gg/gpbe9gv7mC",
                        Email = @"robson.curitibapr@gmail.com"
                    };

                });
            }
        }
    }
}
