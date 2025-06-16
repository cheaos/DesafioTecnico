using Api.Data;
using Api.Services;
using Api.Repositories;
using EFCore.NamingConventions;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<ProdutoRepository>();
builder.Services.AddScoped<ProdutoService>();

builder.Services.AddScoped<MovimentacaoRepository>();
builder.Services.AddScoped<MovimentacaoService>();

builder.Services.AddControllers();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))
           .UseSnakeCaseNamingConvention());

var app = builder.Build();

app.UseAuthorization();
app.MapControllers();

app.Run();
