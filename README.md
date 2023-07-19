# NetCore31Api
--Create project dotnet core 3.1

dotnet new webapi -o EFCoreMySQL -f netcoreapp3.1

--Add Swagger in dotnet core 3.1

dotnet add package Swashbuckle.AspNetCore --version 6.5.0

dotnet add package Microsoft.VisualStudio.Web.CodeGeneration.Design --version 3.1.0-preview3.19558.8

dotnet add package Microsoft.EntityFrameworkCore.Design --version 5.0.0

==========================> add into startup.cs file under void of "ConfigureServices"<==============================

using Microsoft.OpenApi.Models;

// Register the Swagger Generator service. This service is responsible for genrating Swagger Documents.
// Note: Add this service at the end after AddMvc() or AddMvcCore().
services.AddSwaggerGen(c =>
{
	c.SwaggerDoc("v1", new OpenApiInfo { 
		Title = "Modtanoi API", 
		Version = "v1",
		Description ="Description for the API goes here.",
		Contact = new OpenApiContact
		{
			Name = "Ankush Jain",
			Email = string.Empty,
			Url = new Uri("https://coderjony.com/"),
		},
	});
});


==========================> add into startup.cs file under void of "Configure"<==============================


// Enable middleware to serve generated Swagger as a JSON endpoint.
app.UseSwagger();

// Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
// specifying the Swagger JSON endpoint.
app.UseSwaggerUI(c =>
{
	c.SwaggerEndpoint("/swagger/v1/swagger.json", "Zomato API V1");

	// To serve SwaggerUI at application's root page, set the RoutePrefix property to an empty string.
	c.RoutePrefix = string.Empty;
});


------------------------------------------------------------------------> Add package Entity and pamelo mysql

dotnet add package Microsoft.EntityFrameworkCore --version 5.0.0
dotnet add package Microsoft.EntityFrameworkCore.Tools --version 5.0.0
dotnet add package Pomelo.EntityFrameworkCore.MySql --version 5.0.0-alpha.2


------------------------------------------------------------------------> migrate database

dotnet ef migrations add FirstMigration

dotnet ef database update
