using PaperCave.Infrastructure.Clients;
using PaperCave.Infrastructure.Data;
using PaperCave.Infrastructure.Utils;
using PaperCave.Models.Settings;
using PaperCave.Services.BookService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.Configure<CosmosSettings>(builder.Configuration.GetSection("CosmosSettings"));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<ICosmosClientBuilder, CosmosClientBuilder>();
builder.Services.AddSingleton<IBookService, BookService>();
builder.Services.AddSingleton<IBookRepository, BookRepository>();
builder.Services.AddSingleton<FeedIteratorUtil>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

await app.RunAsync();