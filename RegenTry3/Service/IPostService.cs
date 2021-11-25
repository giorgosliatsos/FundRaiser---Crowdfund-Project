using RegenTry3.dto;
using RegenTry3.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegenTry3.Service
{
    public interface IPostService
    {
        public ApiResponse<Post> CreatePost(Post post);
        public ApiResponse<Post> ReadPost(int postId);

        public ApiResponse<List<Post>> ReadPost(int pageCount, int pageSize);

        public ApiResponse<Post> UpdatePost(int postId, Post post);

        public ApiResponse<bool> DeletePost(int postId);
    }
}
