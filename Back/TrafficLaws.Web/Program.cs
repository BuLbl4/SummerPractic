using Microsoft.Extensions.FileProviders;
using TrafficLaws.Application.Extensions;
using TrafficLaws.Infrastructure.Extensions;
using TrafficLaws.Persistence.Extensions;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.WithOrigins("http://localhost:3000")
            .AllowCredentials()
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

builder.Services.AddApplicationLayer();
builder.Services.AddPersistenceLayer(builder.Configuration);
builder.Services.AddInfrastructureLayer(builder.Configuration);
builder.Services.ConfigureApplicationCookie(options =>
{
    options.Cookie.Name = "Identity";
    options.ExpireTimeSpan = TimeSpan.FromMinutes(60);
});
var app = builder.Build();
app.UseCors();

app.UseFileServer(new FileServerOptions  
{  
    FileProvider = new PhysicalFileProvider(  
        Path.Combine(Directory.GetCurrentDirectory(), "wwwroot")),  
    RequestPath = "/static",  
    EnableDefaultFiles = true  
});
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseStaticFiles();
app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();

