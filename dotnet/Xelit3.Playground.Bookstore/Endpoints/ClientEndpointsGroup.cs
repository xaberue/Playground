using Xelit3.Playground.Bookstore.Endpoints.Models;
using Xelit3.Playground.Bookstore.Services;

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


    private static async Task<IResult> GetClientById(IClientService clientService, int id)
    {
        var client = await clientService.GetSingleAsync(id);

        if (client is not null)
            return TypedResults.Ok(client);
        else
            return TypedResults.NotFound();
    }

    private static async Task<IResult> CreateClient(ClientCreationDto clientCreationDto, IClientService clientService)
    {
        var client = clientService.CreateAsync(clientCreationDto);

        return TypedResults.Created($"{client.Id}", client);
    }

}
