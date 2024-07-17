using MediatR;
using Xelit3.Playground.Bookstore.Endpoints.Models;

namespace Xelit3.Playground.Bookstore.Endpoints;

public static class ClientEndpointsGroup
{
    public static RouteGroupBuilder MapClientEndpoints(this RouteGroupBuilder group)
    {
        group
            .MapGet("/{id}", GetClientById)
            .WithName("GetClientById");

        group
            .MapPost("/", CreateClient)
            .WithName("CreateClient");
       
        return group;
    }


    private static async Task<IResult> GetClientById(IMediator mediator, int id)
    {
        var request = new GetClientByIdRequest(id);
        var client = await mediator.Send(id);

        if (client is not null)
            return TypedResults.Ok(client);
        else
            return TypedResults.NotFound();
    }

    private static async Task<IResult> CreateClient(IMediator mediator, CreateClientDto clientCreationDto)
    {
        var request = clientCreationDto.ToRequest();
        var client = await mediator.Send(request);

        return TypedResults.Created($"{client.Id}", client);
    }

}
