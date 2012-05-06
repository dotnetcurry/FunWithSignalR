using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FunWithSignalR.Domain.Repository;
using FunWithSignalR.Domain.Model;

namespace FunWithSignalR.Controllers
{ 
    public class BlogPostController : Controller
    {
        private IBlogPostRepository _repository;

        public BlogPostController(IBlogPostRepository repository)
        {
            _repository = repository;
        }

        //
        // GET: /BlogPost/

        public ViewResult Index()
        {
            return View(_repository.GetAllBlogPosts());
        }

        //
        // GET: /BlogPost/Details/5

        public ViewResult Details(int id)
        {
            BlogPost blogpost = _repository.ReadBlogPost(id);
            return View(blogpost);
        }

        //
        // GET: /BlogPost/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /BlogPost/Create

        [HttpPost]
        public ActionResult Create(BlogPost blogpost)
        {
            if (ModelState.IsValid)
            {
                _repository.CreateBlogPost(blogpost);
                return RedirectToAction("Index");  
            }

            return View(blogpost);
        }
        
        //
        // GET: /BlogPost/Edit/5
 
        public ActionResult Edit(int id)
        {
            BlogPost blogpost = _repository.ReadBlogPost(id);
            return View(blogpost);
        }

        //
        // POST: /BlogPost/Edit/5

        [HttpPost]
        public ActionResult Edit(BlogPost blogpost)
        {
            if (ModelState.IsValid)
            {
                _repository.UpdateBlogPost(blogpost);
                return RedirectToAction("Index");
            }
            return View(blogpost);
        }

        //
        // GET: /BlogPost/Review/5

        public ActionResult Review(int id)
        {
            BlogPost blogpost = _repository.ReadBlogPost(id);
            return View(blogpost);
        }

        //
        // POST: /BlogPost/Review/5

        [HttpPost]
        public ActionResult Review(BlogPost blogpost)
        {
            if (ModelState.IsValid)
            {
                _repository.UpdateBlogPost(blogpost);
                return RedirectToAction("Index");
            }
            return View(blogpost);
        }

        //
        // GET: /BlogPost/Delete/5
 
        public ActionResult Delete(int id)
        {
            BlogPost blogpost = _repository.ReadBlogPost(id);
            return View(blogpost);
        }

        //
        // POST: /BlogPost/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            _repository.DeleteBlogPost(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            //db.Dispose();
            base.Dispose(disposing);
        }
    }
}