using Ordering.Application.Orders.Queries.GetOrdersByName;

namespace Ordering.API.Endpoints;

//- Accepts a name parameter
//- Constructs a GetOrderByNameQuery
//- Retrieves and returns matching orders

// public record GetOrdersByNameRequest(string Name);

public record GetOrderByNameResponse(IEnumerable<OrderDto> Orders);

public class GetOrdersByName : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/orders/{orderName}", async (string orderName, ISender sender) =>
            {
                var result = await sender.Send(new GetOrdersByNameQuery(orderName));

                var response = result.Adapt<GetOrderByNameResponse>();

                return Results.Ok(response);
            })
            .WithName("GetOrdersByName")
            .Produces<GetOrderByNameResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status404NotFound)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Get Orders By Name")
            .WithDescription("Get Orders by Name");
    }
}