using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.Extensions.DependencyInjection;
//using Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore;
using MegansMatineeX.Data;
using Microsoft.AspNetCore.Authorization;
using System;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<MegansMatineeXContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MegansMatineeXContext") ??
    throw new InvalidOperationException("Connection string 'Megan\'s Matinee' not found.")));

//builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => 
    options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<MegansMatineeXContext>();

builder.Services.AddAuthentication()
    .AddGitHub(options =>
    {
        
        options.Scope.Add("read:user");
    });

builder.Services.AddAuthorization(options =>
{
    options.FallbackPolicy = new AuthorizationPolicyBuilder()
        .RequireAuthenticatedUser()
        .Build();
});

builder.Services.AddRazorPages(options =>
{
    options.Conventions.AuthorizeFolder("/LeadActs");
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
/*
else
{
    app.UseDeveloperExceptionPage();
    app.UseMigrationsEndPoint();
}
*/

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var context = services.GetRequiredService<MegansMatineeXContext>();
    //context.Database.EnsureCreated();
    DbInitializer.Initialize(context);
    //CreateRolesAsync(services).Wait();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
