using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.IdentityModel.Tokens.Experimental;
using TodoApi.Data;


var builder = WebApplication.CreateBuilder(args);


var jwtsettings=builder.Configuration.GetSection("jwt");
var key=jwtsettings["key"];

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(Options =>
{
    Options.TokenValidationParameters=new TokenValidationParameters
    {
        ValidateIssuer=true,
        ValidateAudience=true,
        ValidateLifetime=true,
        ValidateIssuerSigningKey=true,

        ValidIssuer=jwtsettings["issuer"],
        ValidAudience=jwtsettings["audience"],
        IssuerSigningKey=new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key!))
    };
});

// Add Controllers (required for Web API)
builder.Services.AddControllers();

// Swagger Services (required for Swagger UI)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<TodoDbcontext>
             (options => options.UseSqlite("Data Source=todos.db"));


var app = builder.Build();

// Enable Swagger only in Development mode
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();        
    app.UseSwaggerUI(); 
}


// Redirect HTTP → HTTPS
app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

//Map Controllers (connects your controller routes)
app.MapControllers();

app.Run();
