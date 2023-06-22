using FluentValidation;
using MediatR;
using System.Reflection;
using TestTaskNS.Backend.Middleware;
using TestTaskNS.BL.Behaviors;
using TestTaskNS.BL.DbConnection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(AppDomain.CurrentDomain.GetAssemblies().Where(t => t.FullName.Contains("BL")).First()));

builder.Services.AddTransient(typeof(IPipelineBehavior<,>),
                typeof(ValidationBehavior<,>));

builder.Services.AddControllers();
builder.Services.AddDbContextsCustom(builder.Configuration);

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

app.UseCustomExceptionHandler();

app.MapControllers();

app.Run();
