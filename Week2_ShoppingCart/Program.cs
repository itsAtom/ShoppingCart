using IdentityServer4.Services;
using IdentityServer4.Validation;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Week2_ShoppingCart.Models;
using Week2_ShoppingCart.Security.Authentication;
using Week2_ShoppingCart.Security.OAuth;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("Connection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ShoppingCartContext>(options =>
options.UseSqlServer(connectionString));

/*builder.Services.AddDbContext<ShoppingCartContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Connection")));*/


//builder.Services.AddAuthentication("Basic")
//  .AddScheme<BasicAuthenticationOption, BasicAuthenticationHandler>("Basic", null);
//builder.Services.AddTransient<IAuthenticationHandler, BasicAuthenticationHandler>();


builder.Services.AddIdentityServer()
    .AddInMemoryApiResources(config.GetApiResources())
    .AddInMemoryClients(config.GetClients())
    .AddProfileService<ProfileServices>()
    .AddDeveloperSigningCredential();

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme =
                               JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme =
                               JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(o =>
{
    o.Authority = "http://localhost:5092";
    o.Audience = "ShoppingCart.ReadAccess";
    o.RequireHttpsMetadata = false;
});

builder.Services.AddTransient<IResourceOwnerPasswordValidator, ResourcePasswordValidator>();
builder.Services.AddTransient<IProfileService, ProfileServices>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseStaticFiles();
app.UseIdentityServer();

app.UseAuthorization();

app.MapControllers();

app.Run();


