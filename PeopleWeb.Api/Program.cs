using Microsoft.EntityFrameworkCore;
using PeopleWeb.Api.Source.Domain.Interfaces;
using PeopleWeb.Api.Source.Infra.Data;
using PeopleWeb.Api.Source.Infra.Repositories;
using PeopleWeb.Api.Source.Services;
using PeopleWeb.Api.Source.Web.Middlewares;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(options =>
    options.Filters.Add<ModelStateCheckMiddleware>()).ConfigureApiBehaviorOptions(options =>
    options.SuppressModelStateInvalidFilter = true
    );

builder.Services.AddDbContext<AppDbContext>(options => 
    options.UseSqlite("Data Source=peopleWeb.sqlite"));

builder.Services.AddScoped<IPersonRepository, PersonRepository>();
builder.Services.AddScoped<IPersonService, PersonService>();
builder.Services.AddSingleton<IDocumentService, DocumentService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.Migrate();
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionMiddleware>();

app.Use(async (context, next) =>
{
    if (context.Request.Path == "/")
    {
        context.Response.Redirect("/swagger");
        return;
    }
    await next();
});

app.UseHttpsRedirection();
app.MapControllers();

app.Run();