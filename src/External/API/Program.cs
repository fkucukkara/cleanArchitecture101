using API.Extensions;
using Application.Extensions;
using Application.Posts.Commands;
using Application.Posts.Queries;
using Domain.Entities;
using Infrastructure.Extensions;
using MediatR;

var builder = WebApplication.CreateBuilder(args);
builder.Logging.ClearProviders();
builder.Logging.AddConsole();

builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApplication();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    await app.SetupDatabaseAsync();
    app.MapOpenApi();
}

app.UseHttpsRedirection();

var v1 = app.MapGroup("/v1/posts");

v1.MapGet("/", async Task<IResult> (IMediator mediator) =>
{
    return TypedResults.Ok(await mediator.Send(new GetPostsQuery()));
});

v1.MapPost("/", async Task<IResult> (IMediator mediator, Post post) =>
{
    var response = await mediator.Send(new CreatePostCommand { Post = post });

    return TypedResults.Created($"/v1/posts/{post.Id}", post);
});

app.Run();
