using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using FunWithSignalR.Domain.Repository;
using FunWithSignalR.Domain.Model;

namespace FunWithSignalRDI.Web.Controllers
{
    public class DevController : ApiController
    {
        IBlogPostRepository _repository;

        public DevController(IBlogPostRepository repository)
        {
            _repository = repository;
        }

        // GET /api/values
        public IEnumerable<BlogPost> Get()
        {
            return _repository.GetAllBlogPosts();
        }

        // GET /api/values/5
        public HttpResponseMessage<BlogPost> Get(int id)
        {
            BlogPost post = _repository.ReadBlogPost(id);
            if (post != null)
            {
                return new HttpResponseMessage<BlogPost>(post, System.Net.HttpStatusCode.OK);
            }
            else
            {
                return new HttpResponseMessage<BlogPost>(null, System.Net.HttpStatusCode.NotFound);
            }
        }

        // POST /api/values
        public HttpResponseMessage Post(BlogPost newPost)
        {
            _repository.CreateBlogPost(newPost);
            return new HttpResponseMessage(System.Net.HttpStatusCode.Created);
        }

        // PUT /api/values/5
        public HttpResponseMessage Put(BlogPost existingPost)
        {
            _repository.UpdateBlogPost(existingPost);
            return new HttpResponseMessage(System.Net.HttpStatusCode.Created);
        }

        // DELETE /api/values/5
        public HttpResponseMessage Delete(int id)
        {
            return new HttpResponseMessage(System.Net.HttpStatusCode.Forbidden);
        }
    }

}