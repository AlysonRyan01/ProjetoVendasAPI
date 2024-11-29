using ProjetoVendasAPI.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services
    .AddControllers()
    .ConfigureApiBehaviorOptions(options =>
    {
        options.SuppressModelStateInvalidFilter = true; // * DESABILITA O RESULTADO DA VALIDACAO PADRAO DO MODELSTATE *
    });

builder.Services.AddDbContext<VendasDataContext>();

var app = builder.Build();
app.MapControllers();

app.Run();