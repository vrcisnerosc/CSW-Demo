using CSW.BookLibrary.Infrastructure.Proxy;
using CSW.BookLibrary.Rest.Model;
using CSW.BookLibrary.Site.Models;
using CSW.BookLibrary.Site.ViewModels;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace CSW.BookLibrary.Site.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IHttpProxyService _proxy;

        public CategoryController(IHttpProxyService proxy)
        {
            this._proxy = proxy;
        }

        public async Task<ActionResult> Index()
        {
            CategoryViewModel model = new CategoryViewModel();
            var response = await this._proxy.GetAsync("categories");
            dynamic responseContent = await response.Content.ReadAsAsync<Object>();

            model.Categories = responseContent.Items.ToObject<List<Category>>();
            model.SelectedCategory = null;
            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> New()
        {
            CategoryViewModel model = new CategoryViewModel();
            var responseList = await this._proxy.GetAsync("categories");
            dynamic responseContent = await responseList.Content.ReadAsAsync<Object>();

            model.Categories = responseContent.Items.ToObject<List<Category>>();
            model.SelectedCategory = null;
            model.DisplayMode = "WriteOnly";
            return View("Index", model);
        }

        [HttpPost]
        public async Task<ActionResult> Insert(Category obj)
        {
            var resource = new CategoryPostRep
            {
                Name = obj.Name,
                Description = obj.Description
            };

            var response = await _proxy.PostAsync("categories", resource: resource);

            if (response.IsSuccessStatusCode)
            {
                CategoryViewModel model = new CategoryViewModel();
                var responseList = await this._proxy.GetAsync("categories");
                dynamic responseContent = await responseList.Content.ReadAsAsync<Object>();

                model.Categories = responseContent.Items.ToObject<List<Category>>();
                model.SelectedCategory = model.Categories.Find(o => o.Id == obj.Id);
                model.DisplayMode = "ReadOnly";
                return View("Index", model);
            }

            return View("Index");
        }

        [HttpPost]
        public async Task<ActionResult> Select(string id)
        {
            CategoryViewModel model = new CategoryViewModel();
            var responseList = await this._proxy.GetAsync("categories");
            dynamic responseContent = await responseList.Content.ReadAsAsync<Object>();

            model.Categories = responseContent.Items.ToObject<List<Category>>();
            model.SelectedCategory = model.Categories.Find(o => o.Id == Guid.Parse(id));
            model.DisplayMode = "ReadOnly";
            return View("Index", model);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(Category obj)
        {
            CategoryViewModel model = new CategoryViewModel();
            var responseList = await this._proxy.GetAsync("categories");
            dynamic responseContent = await responseList.Content.ReadAsAsync<Object>();

            model.Categories = responseContent.Items.ToObject<List<Category>>();
            model.SelectedCategory = model.Categories.Find(o => o.Id == obj.Id);
            model.DisplayMode = "ReadWrite";
            return View("Index", model);
        }

        [HttpPost]
        public async Task<ActionResult> Update(Category obj)
        {
            var resource = new CategoryPostRep
            {
                Name = obj.Name,
                Description = obj.Description
            };

            var response = await _proxy.PutAsync("categories/" + obj.Id, resource: resource);

            if (response.IsSuccessStatusCode)
            {
                CategoryViewModel model = new CategoryViewModel();
                var responseList = await this._proxy.GetAsync("categories");
                dynamic responseContent = await responseList.Content.ReadAsAsync<Object>();

                model.Categories = responseContent.Items.ToObject<List<Category>>();

                model.SelectedCategory = obj;
                model.DisplayMode = "ReadOnly";
                return View("Index", model);
            }

            return View("Index");
        }

        [HttpPost]
        public async Task<ActionResult> Delete(string id)
        {
            var response = await _proxy.DeleteAsync("categories/" + id);

            if (response.IsSuccessStatusCode)
            {
                CategoryViewModel model = new CategoryViewModel();
                var responseList = await this._proxy.GetAsync("categories");
                dynamic responseContent = await responseList.Content.ReadAsAsync<Object>();

                model.Categories = responseContent.Items.ToObject<List<Category>>();

                model.SelectedCategory = null;
                model.DisplayMode = "";
                return View("Index", model);
            }

            return View("Index");
        }

        [HttpPost]
        public async Task<ActionResult> Cancel(string id)
        {
            CategoryViewModel model = new CategoryViewModel();
            var responseList = await this._proxy.GetAsync("categories");
            dynamic responseContent = await responseList.Content.ReadAsAsync<Object>();

            model.Categories = responseContent.Items.ToObject<List<Category>>();

            model.SelectedCategory = model.Categories.Find(o => o.Id == Guid.Parse(id));
            model.DisplayMode = "ReadOnly";
            return View("Index", model);
        }
    }
}