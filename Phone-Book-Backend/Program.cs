using Microsoft.EntityFrameworkCore;
using Phone_Book_Backend.ExceptionConfigurations;
using PhoneBook.Repository;
using PhoneBook.Repository.IRepository;
using PhoneBook.Repository.Repository;
using PhoneBook.Repository.RepositoryImp;
using PhoneBook.Service.ContactService;
using PhoneBook.Service.IService;
using PhoneBook.Service.ServiceImp;
using Serilog;

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .WriteTo.Console()
    .WriteTo.File("logs/contactInfo", rollingInterval: RollingInterval.Day).CreateLogger();

var builder = WebApplication.CreateBuilder(args);
// builder.Logging.AddConsole();
builder.Host.UseSerilog();
// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// To Use in memory data bases
builder.Services.AddDbContext<PhoneBookContext>(optins => optins.UseInMemoryDatabase("ContactsDb"));


builder.Services.AddTransient<IContactService, ContactServiceImp>();
builder.Services.AddTransient<IContactRepository, ContactRepository>();
builder.Services.AddTransient<ICategoryService, CategoryService>();
builder.Services.AddTransient<ICategoryRepository, CategoryRepository>();

builder.Services.AddCors(p => p.AddPolicy("corsapp", builder =>
{
    builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("corsapp");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.AddGlobalErrorHandler();

app.Run();
