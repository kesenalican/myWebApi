using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Serialization;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(c =>
{
    c.AddPolicy("AllowOrigin", options=>options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
} );
builder.Services.AddControllersWithViews().AddNewtonsoftJson(options =>
options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore).AddNewtonsoftJson(
    options => options.SerializerSettings.ContractResolver = new DefaultContractResolver());
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer("Admin", options =>
//{
//    options.TokenValidationParameters = new()
//    {
//        ValidateAudience = true, // olu�turulacak token de�erini kimlerin hangi sitelerin kullan�c�lar� belirledi�imiz de�erdir. istek gelen sunucu bilmemne.com
//        ValidateIssuer = true, // Olu�turulacak token de�erini kimin da��tt���n� ifade edece�imiz lanad�r. kendi alanad�m myapi.com
//        ValidateLifetime = true, // olu�turulan token de�erinin s�resini kontrol edecek olan do�rulamad�r.
//        ValidateIssuerSigningKey = true,// olu�turulan token de�erinin uygulamam�za ait bir de�er oldu�unu ifade eden security key verisinin do�rulanmas�d�r.

//        ValidAudience = builder.Configuration["Token:Audience"],
//        ValidIssuer = builder.Configuration["Token:Issuer"],
//        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Token:SecurityKey"])),
//    };
//});

app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());


app.UseAuthorization();

app.MapControllers();

app.Run();
