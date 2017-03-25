using CSW.BookLibrary.Infrastructure.Proxy;
using CSW.BookLibrary.Site.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Net.Http;
using CSW.BookLibrary.Rest.Model;
using CSW.BookLibrary.Site.Models;

namespace CSW.BookLibrary.Site.Controllers
{
    public class BookController : Controller
    {
        private readonly IHttpProxyService _proxy;

        public BookController(IHttpProxyService proxy)
        {
            this._proxy = proxy;
        }

        public async Task<ActionResult> Index()
        {
            BookViewModel model = new BookViewModel();
            var response = await this._proxy.GetAsync("books");
            dynamic responseContent = await response.Content.ReadAsAsync<Object>();

            model.Books = responseContent.Items.ToObject<List<Book>>();
            model.SelectedBook = null;
            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> New()
        {
            BookViewModel model = new BookViewModel();
            var responseList = await this._proxy.GetAsync("books");
            dynamic responseContent = await responseList.Content.ReadAsAsync<Object>();

            model.Books = responseContent.Items.ToObject<List<Book>>();
            model.SelectedBook = null;
            model.DisplayMode = "WriteOnly";
            ViewBag.Authors = await GetAuthorListItem();
            ViewBag.Categories = await GetCategoryListItem();
            return View("Index", model);
        }

        [HttpPost]
        public async Task<ActionResult> Insert(Book obj)
        {
            var resource = new BookPostRep
            {
                Name = obj.Name,
                AuthorId = obj.AuthorId,
                CategoryId = obj.CategoryId
            };

            var response = await _proxy.PostAsync("books", resource: resource);

            if (response.IsSuccessStatusCode)
            {
                BookViewModel model = new BookViewModel();
                var responseList = await this._proxy.GetAsync("books");
                dynamic responseContent = await responseList.Content.ReadAsAsync<Object>();

                model.Books = responseContent.Items.ToObject<List<Book>>();
                model.SelectedBook = model.Books.Find(o => o.Id == obj.Id);
                model.DisplayMode = "ReadOnly";
                return View("Index", model);
            }

            return View("Index");
        }

        [HttpPost]
        public async Task<ActionResult> Select(string id)
        {
            BookViewModel model = new BookViewModel();
            var responseList = await this._proxy.GetAsync("books");
            dynamic responseContent = await responseList.Content.ReadAsAsync<Object>();

            model.Books = responseContent.Items.ToObject<List<Book>>();
            model.SelectedBook = model.Books.Find(o => o.Id == Guid.Parse(id));
            model.DisplayMode = "ReadOnly";
            return View("Index", model);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(Book obj)
        {
            BookViewModel model = new BookViewModel();
            var responseList = await this._proxy.GetAsync("books");
            dynamic responseContent = await responseList.Content.ReadAsAsync<Object>();

            model.Books = responseContent.Items.ToObject<List<Book>>();
            model.SelectedBook = model.Books.Find(o => o.Id == obj.Id);
            model.DisplayMode = "ReadWrite";
            ViewBag.Authors = await GetAuthorListItem();
            ViewBag.Categories = await GetCategoryListItem();
            return View("Index", model);
        }

        [HttpPost]
        public async Task<ActionResult> Update(Book obj)
        {
            var resource = new BookPostRep
            {
                Name = obj.Name,
                AuthorId = obj.AuthorId,
                CategoryId = obj.CategoryId
            };

            var response = await _proxy.PutAsync("books/" + obj.Id, resource: resource);

            if (response.IsSuccessStatusCode)
            {
                BookViewModel model = new BookViewModel();
                var responseList = await this._proxy.GetAsync("books");
                dynamic responseContent = await responseList.Content.ReadAsAsync<Object>();

                model.Books = responseContent.Items.ToObject<List<Book>>();

                model.SelectedBook = model.Books.Find(o => o.Id == obj.Id);
                model.DisplayMode = "ReadOnly";
                return View("Index", model);
            }

            return View("Index");
        }

        [HttpPost]
        public async Task<ActionResult> Delete(string id)
        {
            var response = await _proxy.DeleteAsync("books/" + id);

            if (response.IsSuccessStatusCode)
            {
                BookViewModel model = new BookViewModel();
                var responseList = await this._proxy.GetAsync("books");
                dynamic responseContent = await responseList.Content.ReadAsAsync<Object>();

                model.Books = responseContent.Items.ToObject<List<Book>>();

                model.SelectedBook = null;
                model.DisplayMode = "";
                return View("Index", model);
            }

            return View("Index");
        }

        [HttpPost]
        public async Task<ActionResult> Cancel(string id)
        {
            BookViewModel model = new BookViewModel();
            var responseList = await this._proxy.GetAsync("books");
            dynamic responseContent = await responseList.Content.ReadAsAsync<Object>();

            model.Books = responseContent.Items.ToObject<List<Book>>();

            model.SelectedBook = model.Books.Find(o => o.Id == Guid.Parse(id));
            model.DisplayMode = "ReadOnly";
            return View("Index", model);
        }

        [NonAction]
        public async Task<List<SelectListItem>> GetAuthorListItem()
        {
            List<SelectListItem> lst = new List<SelectListItem>();

            var response = await this._proxy.GetAsync("authors");
            dynamic responseContent = await response.Content.ReadAsAsync<Object>();

            foreach (Author item in responseContent.Items.ToObject<List<Author>>())
            {
                lst.Add(new SelectListItem { Value = item.Id.ToString(), Text = string.Concat(item.FirstName, " ", item.LastName) });
            }

            return lst;
        }

        [NonAction]
        public async Task<List<SelectListItem>> GetCategoryListItem()
        {
            List<SelectListItem> lst = new List<SelectListItem>();

            var response = await this._proxy.GetAsync("categories");
            dynamic responseContent = await response.Content.ReadAsAsync<Object>();

            foreach (Category item in responseContent.Items.ToObject<List<Category>>())
            {
                lst.Add(new SelectListItem { Value = item.Id.ToString(), Text = item.Name });
            }

            return lst;
        }
    }
}