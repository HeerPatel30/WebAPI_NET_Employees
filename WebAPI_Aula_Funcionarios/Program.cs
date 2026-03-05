using Microsoft.EntityFrameworkCore;
using WebAPI_Aula_Funcionarios.DataContext;
using WebAPI_Aula_Funcionarios.Service.FuncionarioService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IFuncionarioInterface, FuncionarioService>();

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

// CORS configuration
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
        policy =>
        {
            policy.WithOrigins("http://localhost:4200")
                  .AllowAnyMethod()
                  .AllowAnyHeader();
        });
});

// Database connection
builder.Services.AddDbContext<AplicationDBContext>(options =>
{
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection"));
});

var app = builder.Build();

// Configure HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(MyAllowSpecificOrigins);

app.UseAuthorization();

app.MapControllers();


// ✅ Health Check Endpoint for CI/CD pipeline
app.MapGet("/status", () =>
{
    return Results.Ok("Status OK");
});

app.Run();