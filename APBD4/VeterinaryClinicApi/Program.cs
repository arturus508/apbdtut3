using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var appBuilder = WebApplication.CreateBuilder(args);

                // Register services ,  configureing DI 
appBuilder.Services.AddControllers();
            // Adding CORS 
appBuilder.Services.AddCors(options =>
{
    options.AddPolicy("CustomCorsPolicy", policy =>
    {
        policy.AllowAnyOrigin()             //  Adjust this for the  production
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

var app = appBuilder.Build();


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/error");
}


app.UseHttpsRedirection();


app.UseCors("CustomCorsPolicy");


app.UseAuthorization();


app.MapControllers();

app.Run();

