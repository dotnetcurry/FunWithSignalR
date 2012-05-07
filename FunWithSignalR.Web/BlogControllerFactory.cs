using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Routing;
using FunWithSignalR.Controllers;
using FunWithSignalR.Domain.Repository;
using FunWithSignalRDI.Web.Controllers;

namespace FunWithSignalR
{
    public class BlogControllerFactory: DefaultControllerFactory
    {
        private readonly Dictionary<string, Func<RequestContext, IController>> _controllerMap;

        public BlogControllerFactory(IBlogPostRepository repository)
        {
            if (repository == null)
            {
                throw new ArgumentNullException("repository");
            }
            this._controllerMap = new Dictionary<string, Func<RequestContext, IController>>();
            this._controllerMap["Home"] = context => new HomeController();
            this._controllerMap["ViewSwitcher"] = context => new ViewSwitcherController();
            this._controllerMap["BlogPost"] = context => new BlogPostController(repository);
        }

        public override IController CreateController(RequestContext requestContext, string controllerName)
        {
            if (this._controllerMap.ContainsKey(controllerName))
            {
                return this._controllerMap[controllerName](requestContext);
            }
            else
            {
                return null;
            }
        }
    }
}