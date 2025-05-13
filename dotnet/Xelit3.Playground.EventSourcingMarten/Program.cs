using Marten;
using Marten.Events.Projections;
using Weasel.Core;
using Xelit3.Playground.EventSourcingMarten.Models;
using Xelit3.Playground.EventSourcingMarten.Projections;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new ArgumentException("DefaultConnection must be configured"); ;

builder.Services.AddMarten(opt =>
{
    opt.Connection(connectionString);
    opt.UseSystemTextJsonForSerialization();

    opt.Projections.Add<AppointmentProjection>(ProjectionLifecycle.Inline);

    if (builder.Environment.IsDevelopment())
    {
        opt.AutoCreateSchemaObjects = AutoCreate.All;
    }
    else
    {
        opt.AutoCreateSchemaObjects = AutoCreate.None;
    }
});

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

////Apply the AppointmentCreated event to the current appointment. This is done under demand and not through a persisted projection
////It is using the Apply method from the AppointmentProjection class
//app.MapGet("appointment/{id:guid}", async (IQuerySession session, Guid id) => 
//{
//    var appointment = await session.Events.AggregateStreamAsync<Appointment>(id);

//    return appointment is not null ? 
//        Results.Ok(appointment) 
//        : 
//        Results.NotFound();
//});

//Apply the AppointmentCreated event to the current appointment. This is done using the projection class
app.MapGet("appointment/{id:guid}", async (IQuerySession session, Guid id) =>
{
    var appointment = await session.LoadAsync<Appointment>(id);

    return appointment is not null ?
        Results.Ok(appointment)
        :
        Results.NotFound();
});

app.MapGet("appointments", async (IQuerySession session, Guid id) =>
{
    var appointments = await session.Query<Appointment>().ToListAsync();

    return appointments is not null ?
        Results.Ok(appointments)
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

app.MapPatch("appointment", async (IDocumentStore store, AppointmentStatusChanged appointmentStatusChanged) =>
{
    await using var session = store.LightweightSession();

    session.Events.Append(appointmentStatusChanged.Id, appointmentStatusChanged);
    await session.SaveChangesAsync();

    return Results.Ok();
});

app.MapPut("appointment", async (IDocumentStore store, AppointmentUpdated appointmentUpdated) =>
{
    await using var session = store.LightweightSession();

    session.Events.Append(appointmentUpdated.Id, appointmentUpdated);
    await session.SaveChangesAsync();

    return Results.Ok();
});

app.Run();
