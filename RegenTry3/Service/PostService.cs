using RegenTry3.dto;
using RegenTry3.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegenTry3.Service
{
    public class PostService : IPostService

    {
        private readonly CrmDbContext _db;

        public PostService(CrmDbContext db)
        {
            _db = db;
        }

        public ApiResponse<Post> CreatePost(Post post)
        {
            if (post == null)
            {
                return new ApiResponse<Post>()
                {
                    Data = null,
                    Description = "Post was null ",
                    StatusCode = 1
                };
            }

            _db.Posts.Add(post);
            try { _db.SaveChanges(); }
            catch 
            { 
                return new ApiResponse<Post>() { 
                    Data = null, 
                    Description = "Post not Saved to Database", 
                    StatusCode = 2 
                }; 
            }

            
                return new ApiResponse<Post>()
                {
                    Data = post,
                    Description = "Post Succesfully Posted",
                    StatusCode = 0
                };
          

        }

        public ApiResponse<bool> DeletePost(int postId)
        {
            var post = _db.Posts.Find(postId);
            if (post == null) return new ApiResponse<bool>() { Data = false, Description = "Post was Null", StatusCode = 1 };
            
            _db.Posts.Remove(post);
            if (_db.SaveChanges() == 1)
            {
                return new ApiResponse<bool>() { Data = true, Description = "Post Succesfully Deleted", StatusCode = 0 };
            }
            else {
                return new ApiResponse<bool>() { Data = false, Description = "Post Delete Failed", StatusCode = 2 };
            }
        }

        public ApiResponse<Post> ReadPost(int postId)
        {

            if (_db.Posts.Find(postId) != null)
            {
                return new ApiResponse<Post>()
                {
                    Data = _db.Posts.Find(postId),
                    Description = "Post Found",
                    StatusCode = 0
                };
            }
            else
            {
                return new ApiResponse<Post>()
                {
                    Data = null,
                    Description = "Post not Found",
                    StatusCode = 1
                };
            }
            
        }

        public ApiResponse<List<Post>> ReadPost(int pageCount, int pageSize)
        {
            if (pageCount <= 0) pageCount = 1;
            if (pageSize <= 0 || pageSize > 20) pageSize = 20;

            return new ApiResponse<List<Post>>()
            {
                Data = _db.Posts
                .Skip((pageCount - 1) * pageSize)
                .Take(pageSize)
                .ToList(),
                Description = "",
                StatusCode = 0
            };
        }

        public ApiResponse<Post> UpdatePost(int postId, Post post)
        {
            var dbPost = _db.Posts.Find(postId);
            if (dbPost == null) throw new KeyNotFoundException();
            dbPost.Text = post.Text;
            dbPost.Photos = post.Photos;
            dbPost.Videos = post.Videos;

            _db.SaveChanges();
            return new ApiResponse<Post>()
            {
                Data = dbPost,
                Description = "Post Succesfully Updated",
                StatusCode = 0
            };
        }
    }
}
