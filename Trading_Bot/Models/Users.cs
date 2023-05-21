using AuthenticationService.Models;

namespace AuthenticationService.Modells
{
    public class Users
    {
        public int? Id { get; set; }
        public string? UserName { get; set; }
        public byte[]? PasswordHash { get; set; }
        public byte[]? PasswordSalt { get; set; }
    }


public static class UsersModelEndpoints
{
	public static void MapUsersModelEndpoints (this IEndpointRouteBuilder routes)
    {
        routes.MapGet("/api/UsersModel", () =>
        {
            return new [] { new UsersModel() };
        })
        .WithName("GetAllUsersModels")
        .Produces<UsersModel[]>(StatusCodes.Status200OK);

        routes.MapGet("/api/UsersModel/{id}", (int id) =>
        {
            //return new UsersModel { ID = id };
        })
        .WithName("GetUsersModelById")
        .Produces<UsersModel>(StatusCodes.Status200OK);

        routes.MapPut("/api/UsersModel/{id}", (int id, UsersModel input) =>
        {
            return Results.NoContent();
        })
        .WithName("UpdateUsersModel")
        .Produces(StatusCodes.Status204NoContent);

        routes.MapPost("/api/UsersModel/", (UsersModel model) =>
        {
            //return Results.Created($"/UsersModels/{model.ID}", model);
        })
        .WithName("CreateUsersModel")
        .Produces<UsersModel>(StatusCodes.Status201Created);

        routes.MapDelete("/api/UsersModel/{id}", (int id) =>
        {
            //return Results.Ok(new UsersModel { ID = id });
        })
        .WithName("DeleteUsersModel")
        .Produces<UsersModel>(StatusCodes.Status200OK);
    }
}}
