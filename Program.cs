using ControleProdutoEstoque.Data;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;


/* cria e configura o ambiente fundamental da API */
var builder = WebApplication.CreateBuilder(args);

/* essa linha � como se fosse uma etiqueta de um nome que a gente vai usar mais pra frente no processo */
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

/* busca as informa��es de conex�o com o banco e atribui a uma vari�vel 'connectionString' */
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

/* registra "AppDbContext" como um servi�o e o configura para usar o pgadmin com a string de conex�o */
builder.Services.AddDbContext<AppDbContext>(options =>
    {
        options.UseNpgsql(connectionString);
    });
/* adiciona o permiss�o ao CORS para o "http://localhost:5173" para ter permiss�o do Frontend vue.js interagir com a API. */
builder.Services.AddCors(options =>
    {
        options.AddPolicy(name: MyAllowSpecificOrigins, policy => { policy.WithOrigins("http://localhost:5173").AllowAnyHeader().AllowAnyMethod(); });
    });

/* Auxilia na convers�o das informa��es via Json para tratar/lidar com os tipos, principalmente do tipo Enum*/
builder.Services.AddControllers().AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

/* faz rodar s� quando for no ambiente de desenvolvimento, � uma pr�tica de seguran�a */
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