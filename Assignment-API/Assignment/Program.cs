using Assignment.DataLayer;
using Assignment.DataLayer.Repositories.Contracts;
using Assignment.DataLayer.Repositories.Implementations;
using Assignment.Services.Services.Contracts;
using Assignment.Services.Services.Implementations;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
var configuration = new ConfigurationBuilder()
	.SetBasePath(Directory.GetCurrentDirectory())
	.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
	.AddEnvironmentVariables()
	.Build();

// Add services to the container.
builder.Services.AddCors(options =>
{
	options.AddPolicy("ProductStoreCorsPolicy", policy =>
	{
		policy.WithOrigins("http://localhost:4200")
		.AllowAnyHeader()
		.AllowAnyOrigin();
	});
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ProductDBContext>(option => option.UseSqlServer(configuration["ConnectionStrings:ProductStore"]));

//Adding JWT authentication we can create separate extension methods of these to make program.cs more clean
builder.Services.AddAuthentication(opt => {
	opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
	opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options => {
	options.TokenValidationParameters = new TokenValidationParameters
	{
		ValidateIssuer = true,
		ValidateAudience = true,
		ValidateLifetime = true,
		ValidateIssuerSigningKey = true,
		ValidIssuer = "http://localhost:5199",
		ValidAudience = "http://localhost:5199",
		IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("productstoresecret"))
	};
});

builder.Services.AddTransient(typeof(IBaseRepository<,>), typeof(BaseRepository<,>));
builder.Services.AddTransient<IProductService, ProductService>();
builder.Services.AddTransient<IProductRepository, ProductRepository>();

var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
	var dbContext = scope.ServiceProvider.GetRequiredService<ProductDBContext>();
	dbContext.Database.EnsureCreated();
	// use context
}
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseAuthorization();
app.UseCors("ProductStoreCorsPolicy");
app.MapControllers();

app.Run();
