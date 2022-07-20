using ShortStoryNetwork.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShortStoryNetwork.IServices
{
    public interface IPostService
    {
        Task<Post> addEditPost(Post oPost);

        Task<IEnumerable<Post>> getAllPosts();
        Task<Post> getPostbyId(int postId);

        Task<Post> DeletePost(int postId);

        Task<Post> isPostExixt(int postId);
    }
}
