using Domain.Abstractions;
using Domain.Entities;
using MediatR;

namespace Application.Posts.Commands;
public class CreatePostCommandHandler(IRepository<Post> postRepository) : IRequestHandler<CreatePostCommand, CreatePostCommandResponse>
{
    public async Task<CreatePostCommandResponse> Handle(CreatePostCommand request, CancellationToken cancellationToken)
    {
        var result = await postRepository.CreateAsync(request.Post);
        return new CreatePostCommandResponse { Id = result.Id };
    }
}
