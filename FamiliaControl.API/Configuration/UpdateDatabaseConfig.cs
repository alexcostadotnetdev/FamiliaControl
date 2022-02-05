using FamiliaControl.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FamiliaControl.API.Configuration
{
    public static class UpdateDatabaseConfig
    {
        public static IApplicationBuilder UpdateDatabase(this IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                using (var context = serviceScope.ServiceProvider.GetService<FamilyControlDbContext>())
                {
                    context.Database.Migrate();
                }
            }

            return app;
        }
    }
}
