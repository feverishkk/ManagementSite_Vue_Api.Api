using Application.Interfaces;
using Application.Services;
using CommonDatabase.DapperHelperContext.DapperHelper;
using IoC;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddSingleton<CommonDbContext>();
builder.Services.AddSingleton<ApplicationUserDbContext>();
builder.Services.AddSingleton<IAuthRepository, AuthRepository>();
builder.Services.AddHttpContextAccessor();

// Custome middleware
// �������̽�&���� DI
builder.Services.AddRepositoryExtensions();

// ����DI
builder.Services.AddAuthenticationDI(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();
app.UseCors("CorsPolicy");
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
