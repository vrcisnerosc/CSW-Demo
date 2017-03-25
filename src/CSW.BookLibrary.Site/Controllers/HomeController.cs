using CSW.BookLibrary.Infrastructure.Proxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using System.Web.Mvc;
using CSW.BookLibrary.Site.Models;
using CSW.BookLibrary.Site.ViewModels;

namespace CSW.BookLibrary.Site.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHttpProxyService _proxy;

        public HomeController(IHttpProxyService proxy)
        {
            this._proxy = proxy;
        }

        public async Task<ActionResult> Index(HomeViewModel model)
        {
            ViewBag.Authors = await GetAuthorListItem();
            return View(model);
        }

        public async Task<ActionResult> Books(string authorId)
        {
            var response = await this._proxy.GetAsync(string.Format("authors/{0}/books", authorId));
            dynamic responseContent = await response.Content.ReadAsAsync<Object>();
            HomeViewModel model = new HomeViewModel();
            model.Books = responseContent.Items.ToObject<List<Book>>();
            ViewBag.Authors = await GetAuthorListItem();
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
    }
}