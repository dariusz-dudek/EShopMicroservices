using Ordering.Application.Orders.Queries.GetOrdersByCustomer;

namespace Ordering.API.Endpoints;

//- Accepts a customer ID
//- Uses a GetOrderByCustomerQuery to fetch orders
//- Returns the list of orders for that customer

// public record GetOrderByCustomerRequest(Guid CustomerId);

public record GetOrderByCustomerResponse(IEnumerable<OrderDto> Orders);

public class GetOrdersByCustomer : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/orders/customer/{customerId:guid}", async (Guid customerId, ISender sender) =>
        {
            var result = await sender.Send(new GetOrdersByCustomerQuery(customerId));

            var response = result.Adapt<GetOrderByCustomerResponse>();
            
            return Results.Ok(response);
        })
        .WithName("GetOrdersByCustomer")
        .Produces<GetOrderByCustomerResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status404NotFound)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Get Orders By Customer")
        .WithDescription("Get Orders by Customer");
    }
}