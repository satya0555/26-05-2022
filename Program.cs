
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;


var builder=WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
//builder.Services.AddCors();
builder.Services.AddCors(options =>
{
    options.AddPolicy("angular",
                      policy  =>
                      {
                          policy.WithOrigins("https://localhost:4200/",
                                              "http://localhost:4200/");
                      });
});


//builder.Services.AddCors();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<API.Data.StoreContext>(options => options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("angular"); 
app.UseRouting();
 
app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

app.UseAuthorization();
app.MapControllers();
app.Run();
