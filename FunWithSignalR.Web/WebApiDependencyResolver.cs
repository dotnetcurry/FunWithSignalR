using System;
using System.Collections.Generic;
using System.Configuration;
using System.Web.Http.Services;
using FunWithSignalR.Domain.Repository;
using FunWithSignalRDI.Web.Controllers;

namespace FunWithSignalRDI.Web
{
    public class WebApiDependencyResolver : IDependencyResolver
    {
        IBlogPostRepository _repository;

        public WebApiDependencyResolver(IBlogPostRepository repository)
        {
            _repository = repository;
        }

        public object GetService(Type serviceType)
        {
            if (typeof(DevController) == serviceType)
            {
                return new DevController(_repository);
            }
            return null;
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return new List<object>();
        }
    }
}