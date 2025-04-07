var builder = WebApplication.CreateBuilder(args);

// Adiciona serviços ao contêiner.
builder.Services.AddControllers(); // Se você precisa de Newtonsoft.Json
builder.Services.AddHttpClient(); // Para fazer chamadas HTTP para a Web API
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configurações (opcional, mas comum para ler appsettings.json)
var configuration = builder.Configuration;

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