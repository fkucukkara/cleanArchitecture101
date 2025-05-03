using Domain.Abstractions;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Posts.Queries;
public class GetPostsQueryHandler(IRepository<Post> postRepository) : IRequestHandler<GetPostsQuery, GetPostsQueryResponse>
{
    public async Task<GetPostsQueryResponse> Handle(GetPostsQuery request, CancellationToken cancellationToken)
    {
        var posts = await postRepository.GetQueryable().ToListAsync(cancellationToken);

        return new GetPostsQueryResponse { Posts = posts };
    }
}
