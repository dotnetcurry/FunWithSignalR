using System.Collections.Generic;
using System.Linq;
using FunWithSignalR.Domain.Model;

namespace FunWithSignalR.Domain.Repository
{
    public interface IBlogPostRepository
    {
        IEnumerable<BlogPost> GetAllBlogPosts();
        void CreateBlogPost(BlogPost post);
        BlogPost ReadBlogPost(int id);
        void UpdateBlogPost(BlogPost post);
        void DeleteBlogPost(int id);
    }
}
