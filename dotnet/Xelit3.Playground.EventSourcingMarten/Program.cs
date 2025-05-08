using Marten;
using Weasel.Core;
using Xelit3.Playground.EventSourcingMarten.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new ArgumentException("DefaultConnection must be configured"); ;

builder.Services.AddMarten(opt =>
{
    opt.Connection(connectionString);
    opt.UseSystemTextJsonForSerialization();

    if (builder.Environment.IsDevelopment())
    {
        opt.AutoCreateSchemaObjects = AutoCreate.All;
    }
    else
    {
        opt.AutoCreateSchemaObjects = AutoCreate.None;
    }

    //opt.UseOptimisticConcurrency = true;
    //opt.Schema.For<WeatherForecast>().Identity(x => x.Date);
});

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();


app.MapGet("appointment/{id:guid}", async (IQuerySession session, Guid id) => 
{
    var appointment = await session.Events.AggregateStreamAsync<Appointment>(id);

    return appointment is not null ? 
        Results.Ok(appointment) 
        : 
        Results.NotFound();
});

app.MapPost("appointment", async (IDocumentStore store, AppointmentCreationRequest appointmentCreationRequest) =>
{
    var appointmentCreated = new AppointmentCreated
    {
        Title = appointmentCreationRequest.Title,
        Description = appointmentCreationRequest.Description
    };
    await using var session = store.LightweightSession();
    
    session.Events.StartStream<Appointment>(appointmentCreated.Id, appointmentCreated);
    await session.SaveChangesAsync();

    return Results.Created($"/appointment/{appointmentCreated.Id}", appointmentCreationRequest);
});

app.Run();





//var appointment = new Appointment(appointmentCreated.Status, appointmentCreated.Title, appointmentCreated.Description);