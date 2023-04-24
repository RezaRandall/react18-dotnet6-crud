using Microsoft.EntityFrameworkCore;
using ReactAPI.Demo.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register our CORS 
builder.Services.AddCors(options => {
    options.AddPolicy("ReactJSDomain", 
    policy => policy.WithOrigins("http://localhost:3000")
    .AllowAnyHeader().AllowAnyMethod()
    );
});

builder.Services.AddDbContext<ReactJSDemoContext>(options => {
    options.UseSqlServer(builder.Configuration.GetConnectionString("ReactJSDemoConnection"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("ReactJSDomain");
app.UseAuthorization();

app.MapControllers();

app.Run();
