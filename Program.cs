using ControleProdutoEstoque.Data;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;


/* cria e configura o ambiente fundamental da API */
var builder = WebApplication.CreateBuilder(args);

/* essa linha é como se fosse uma etiqueta de um nome que a gente vai usar mais pra frente no processo */
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

/* busca as informações de conexão com o banco e atribui a uma variável 'connectionString' */
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

/* registra "AppDbContext" como um serviço e o configura para usar o pgadmin com a string de conexão */
builder.Services.AddDbContext<AppDbContext>(options =>
    {
        options.UseNpgsql(connectionString);
    });
/* adiciona o permissão ao CORS para o "http://localhost:5173" para ter permissão do Frontend vue.js interagir com a API. */
builder.Services.AddCors(options =>
    {
        options.AddPolicy(name: MyAllowSpecificOrigins, policy => { policy.WithOrigins("http://localhost:5173").AllowAnyHeader().AllowAnyMethod(); });
    });

/* Auxilia na conversão das informações via Json para tratar/lidar com os tipos, principalmente do tipo Enum*/
builder.Services.AddControllers().AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

/* faz rodar só quando for no ambiente de desenvolvimento, é uma prática de segurança */
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors(MyAllowSpecificOrigins);
app.UseAuthorization();
app.MapControllers();
app.Run();