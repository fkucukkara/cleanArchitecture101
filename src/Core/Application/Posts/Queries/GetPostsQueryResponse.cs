using Domain.Entities;

namespace Application.Posts.Queries;
public class GetPostsQueryResponse
{
    public IEnumerable<Post>? Posts { get; set; }
}
