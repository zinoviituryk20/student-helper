using StudentHelper.API.Configuration;
using StudentHelper.API.Services;
using StudentHelper.API.Services.IServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddHttpClient<IUserServices, UserService>();
builder.Services.AddHttpClient<IAuthService, AuthService>();

ApiConfiguration.UserApiBase = builder.Configuration["ServicesUrl:UserAPI"];
ApiConfiguration.AuthApiBase = builder.Configuration["ServicesUrl:AuthService"];

builder.Services.AddScoped<IUserServices,UserService>();
builder.Services.AddScoped<IAuthService,AuthService>();


builder.Services.AddControllers();
builder.Services.AddHttpContextAccessor();
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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
