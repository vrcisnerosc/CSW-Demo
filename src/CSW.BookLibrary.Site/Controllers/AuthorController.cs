using CSW.BookLibrary.Infrastructure.Proxy;
using CSW.BookLibrary.Rest.Model;
using CSW.BookLibrary.Site.ViewModels;
using System;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Net.Http;
using System.Collections.Generic;
using CSW.BookLibrary.Site.Models;

namespace CSW.BookLibrary.Site.Controllers
{
    public class AuthorController : Controller
    {
        private readonly IHttpProxyService _proxy;

        public AuthorController(IHttpProxyService proxy)
        {
            this._proxy = proxy;
        }

        public async Task<ActionResult> Index()
        {
            AuthorViewModel model = new AuthorViewModel();
            var response = await this._proxy.GetAsync("authors");
            dynamic responseContent = await response.Content.ReadAsAsync<Object>();

            model.Authors = responseContent.Items.ToObject<List<Author>>();
            model.SelectedAuthor = null;
            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> New()
        {
            AuthorViewModel model = new AuthorViewModel();
            var responseList = await this._proxy.GetAsync("authors");
            dynamic responseContent = await responseList.Content.ReadAsAsync<Object>();

            model.Authors = responseContent.Items.ToObject<List<Author>>();
            model.SelectedAuthor = null;
            model.DisplayMode = "WriteOnly";
            return View("Index", model);
        }

        [HttpPost]
        public async Task<ActionResult> Insert(Author obj)
        {
            var resource = new AuthorPostRep
            {
                FirstName = obj.FirstName,
                LastName = obj.LastName,
                Country=obj.Country
            };

            var response = await _proxy.PostAsync("authors", resource: resource);

            if (response.IsSuccessStatusCode)
            {
                AuthorViewModel model = new AuthorViewModel();
                var responseList = await this._proxy.GetAsync("authors");
                dynamic responseContent = await responseList.Content.ReadAsAsync<Object>();

                model.Authors = responseContent.Items.ToObject<List<Author>>();
                model.SelectedAuthor = model.Authors.Find(o => o.Id == obj.Id);
                model.DisplayMode = "ReadOnly";
                return View("Index", model);
            }

            return View("Index");
        }

        [HttpPost]
        public async Task<ActionResult> Select(string id)
        {
            AuthorViewModel model = new AuthorViewModel();
            var responseList = await this._proxy.GetAsync("authors");
            dynamic responseContent = await responseList.Content.ReadAsAsync<Object>();

            model.Authors = responseContent.Items.ToObject<List<Author>>();
            model.SelectedAuthor = model.Authors.Find(o => o.Id == Guid.Parse(id));
            model.DisplayMode = "ReadOnly";
            return View("Index", model);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(Author obj)
        {
            AuthorViewModel model = new AuthorViewModel();
            var responseList = await this._proxy.GetAsync("authors");
            dynamic responseContent = await responseList.Content.ReadAsAsync<Object>();

            model.Authors = responseContent.Items.ToObject<List<Author>>();
            model.SelectedAuthor = model.Authors.Find(o => o.Id == obj.Id);
            model.DisplayMode = "ReadWrite";
            return View("Index", model);
        }

        [HttpPost]
        public async Task<ActionResult> Update(Author obj)
        {
            var resource = new AuthorPostRep
            {
                FirstName = obj.FirstName,
                LastName = obj.LastName,
                Country = obj.Country
            };

            var response = await _proxy.PutAsync("authors/" + obj.Id, resource: resource);

            if (response.IsSuccessStatusCode)
            {
                AuthorViewModel model = new AuthorViewModel();
                var responseList = await this._proxy.GetAsync("authors");
                dynamic responseContent = await responseList.Content.ReadAsAsync<Object>();

                model.Authors = responseContent.Items.ToObject<List<Author>>();

                model.SelectedAuthor = obj;
                model.DisplayMode = "ReadOnly";
                return View("Index", model);
            }

            return View("Index");
        }

        [HttpPost]
        public async Task<ActionResult> Delete(string id)
        {
            var response = await _proxy.DeleteAsync("authors/" + id);

            if (response.IsSuccessStatusCode)
            {
                AuthorViewModel model = new AuthorViewModel();
                var responseList = await this._proxy.GetAsync("authors");
                dynamic responseContent = await responseList.Content.ReadAsAsync<Object>();

                model.Authors = responseContent.Items.ToObject<List<Author>>();

                model.SelectedAuthor = null;
                model.DisplayMode = "";
                return View("Index", model);
            }

            return View("Index");
        }

        [HttpPost]
        public async Task<ActionResult> Cancel(string id)
        {
            AuthorViewModel model = new AuthorViewModel();
            var responseList = await this._proxy.GetAsync("authors");
            dynamic responseContent = await responseList.Content.ReadAsAsync<Object>();

            model.Authors = responseContent.Items.ToObject<List<Author>>();

            model.SelectedAuthor = model.Authors.Find(o => o.Id == Guid.Parse(id));
            model.DisplayMode = "ReadOnly";
            return View("Index", model);
        }
    }
}