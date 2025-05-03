using Domain.Entities;
using MediatR;

namespace Application.Posts.Commands;
public sealed class CreatePostCommand : IRequest<CreatePostCommandResponse>
{
    public required Post Post { get; set; }
}
