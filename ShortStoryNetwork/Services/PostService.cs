using Dapper;
using ShortStoryNetwork.Context;
using ShortStoryNetwork.IServices;
using ShortStoryNetwork.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;

namespace ShortStoryNetwork.Services
{
    public class PostService : IPostService
    {

        private readonly DBContext _context;

        public PostService(DBContext context)
        {
            _context = context;
        }
        Post oPost = new Post();

        public async Task<Post> addEditPost(Post oPost)
        {
            var spName = "usp_CRUDPost";

            using(var connection = _context.CreateConnection())
            {
                connection.Open();
                DynamicParameters para = new DynamicParameters();
                para.Add("@ACTION", "E");
                para.Add("@PostId", oPost.PostId);
                para.Add("@UserId", oPost.UserId);
                para.Add("@Post", oPost.PostName);
                para.Add("@PostDate", oPost.PostDate);

                var result = await connection.QueryAsync<Post>(spName, para, commandType: CommandType.StoredProcedure);

                return result.FirstOrDefault();
            }
        }

        public async Task<Post> DeletePost(int postId)
        {
            var spName = "usp_CRUDPost";

            using (var connection = _context.CreateConnection())
            {
                connection.Open();
                DynamicParameters para = new DynamicParameters();
                para.Add("@ACTION", "D");
                para.Add("@PostId", postId);                

                var result = await connection.QueryAsync<Post>(spName, para, commandType: CommandType.StoredProcedure);

                return result.FirstOrDefault();
            }
        }

        public async Task<IEnumerable<Post>> getAllPosts()
        {
            var spName = "usp_CRUDPost";

            using (var connection = _context.CreateConnection())
            {
                connection.Open();
                DynamicParameters para = new DynamicParameters();
                para.Add("@ACTION", "A");
                

                var result = await connection.QueryAsync<Post>(spName, para, commandType: CommandType.StoredProcedure);

                return result.ToList();
            }
        }

        public async Task<Post> getPostbyId(int postId)
        {
            var spName = "usp_CRUDPost";

            using (var connection = _context.CreateConnection())
            {
                connection.Open();
                DynamicParameters para = new DynamicParameters();
                para.Add("@ACTION", "A");
                para.Add("@PostId", postId);


                var result = await connection.QueryAsync<Post>(spName, para, commandType: CommandType.StoredProcedure);

                return result.FirstOrDefault();
            }
        }

        public async Task<Post> isPostExixt(int postId)
        {
            var spName = "usp_CRUDPost";

            using (var connection = _context.CreateConnection())
            {
                connection.Open();
                DynamicParameters para = new DynamicParameters();
                para.Add("@ACTION", "A");
                para.Add("@PostId", postId);


                var result = await connection.QueryAsync<Post>(spName, para, commandType: CommandType.StoredProcedure);

                return result.FirstOrDefault();
            }
        }
    }
}
