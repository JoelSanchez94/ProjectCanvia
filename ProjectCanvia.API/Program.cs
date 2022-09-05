using ProjectCanvia.API.Data.Configuration;
using ProjectCanvia.API.Data.Implementation;
using ProjectCanvia.API.Data.Interface;
using ProjectCanvia.API.Logic.Implementation;
using ProjectCanvia.API.Logic.Interfaz;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<ConfigurationConexion>(builder.Configuration.GetSection("ConnectionStrings"));

builder.Services.AddCors(options => options.AddPolicy("allowWebApp",
			builder => builder.AllowAnyOrigin()
								.AllowAnyHeader()
								.AllowAnyMethod()));

builder.Services.AddScoped<IEmployeesLogic, EmployeesLogic>();
builder.Services.AddScoped<IEmployeesData, EmployeesData>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();

	app.UseSwaggerUI(c => {
		c.RoutePrefix = "";
		c.SwaggerEndpoint("/swagger/v1/swagger.json","v1");
	});
}

app.UseHttpsRedirection();

app.UseCors("allowWebApp");

app.UseAuthorization();

app.MapControllers();

app.Run();
