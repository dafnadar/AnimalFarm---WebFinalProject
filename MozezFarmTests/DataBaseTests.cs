using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MozesFarmWebsite.Data;
using System;
using System.Collections.Generic;

namespace MozezFarmTests
{
    [TestClass]
    public class DataBaseTests
    {
        [TestMethod]
        public void IsDbCreated()
        {
            var builder = WebApplication.CreateBuilder();
            builder.Services.AddDbContext<AnimalContext>(options => options.UseSqlServer("Server=(localdb)\\MosesFarmDb;Database=AnimalDbTest;Trusted_Connection=True;"));
            var app = builder.Build();

            using (var scope = app.Services.CreateScope())
            {
                var ctx = scope.ServiceProvider.GetRequiredService<AnimalContext>();
                ctx.Database.EnsureDeleted();
                ctx.Database.EnsureCreated();

                Assert.IsNotNull(ctx.Database);
            }
        }
    }
}
