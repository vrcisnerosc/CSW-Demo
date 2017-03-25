using AutoMapper;
using CSW.BookLibrary.Infrastructure.Rest.Model;
using CSW.BookLibrary.QueryLayer;
using CSW.BookLibrary.QueryLayer.Model;
using CSW.BookLibrary.Rest.Model;
using CSW.BookLibrary.Rest.Names;
using CSW.BookLibrary.TaskLayer;
using CSW.BookLibrary.TaskLayer.Model;
using System;
using System.Data.Entity.Core;
using System.Web.Http;
using System.Web.Http.Description;

namespace CSW.BookLibrary.Rest.Controllers
{
    [RoutePrefix("api")]
    public class CategoryController : ApiController
    {
        #region Services ---------------------
        private readonly ICategoryService _categoryService;
        private readonly ICategoryQueryService _categoryQueryService;
        private readonly IBookQueryService _bookQueryService;
        #endregion
        #region Constructor ------------------
        public CategoryController(ICategoryService categoryService, ICategoryQueryService categoryQueryService, IBookQueryService bookQueryService)
        {
            this._categoryService = categoryService;
            this._categoryQueryService = categoryQueryService;
            this._bookQueryService = bookQueryService;
        }
        #endregion
        #region Actions ----------------------        
        [HttpGet]
        [Route("categories")]
        [ResponseType(typeof(RepresentationCollection<CategoryListRep>))]
        public IHttpActionResult List()
        {
            var list = this._categoryQueryService.Find();

            var collection = new RepresentationCollection<CategoryDto, CategoryListRep>(list);

            return this.Ok(collection);
        }

        [HttpGet]
        [Route("categories/{id}", Name = CategoryResourceNames.Routes.GetById)]
        public IHttpActionResult Get(string id)
        {
            try
            {
                var entity = this._categoryQueryService.FindById(Guid.Parse(id));

                if (entity == null)
                    return this.NotFound();

                var representation = Mapper.Map<CategoryRep>(entity);

                return this.Ok(representation);
            }
            catch (FormatException)
            {
                return this.NotFound();
            }
            catch (Exception ex)
            {
                return this.InternalServerError(ex);
            }
        }

        [HttpPost]
        [Route("categories", Name = CategoryResourceNames.Routes.PostCreate)]
        public IHttpActionResult Create(CategoryPostRep resource)
        {
            if (!this.ModelState.IsValid)
                return this.BadRequest(this.ModelState);

            try
            {
                var @event = new CategoryCreateEvent
                {
                    Name = resource.Name,
                    Description = resource.Description
                };

                this._categoryService.Add(@event);

                return this.CreatedAtRoute(CategoryResourceNames.Routes.GetById, new { id = @event.Id }, resource);
            }
            catch (Exception ex)
            {
                return this.InternalServerError(ex);
            }
        }

        [HttpPut]
        [Route("categories/{id}", Name = CategoryResourceNames.Routes.PutUpdate)]
        public IHttpActionResult Update(string id, CategoryPostRep resource)
        {
            if (!this.ModelState.IsValid)
                return this.BadRequest(this.ModelState);

            try
            {
                var @event = new CategoryUpdateEvent
                {
                    Id = Guid.Parse(id),
                    Name = resource.Name,
                    Description = resource.Description
                };

                this._categoryService.Update(@event);

                return this.CreatedAtRoute(CategoryResourceNames.Routes.GetById, new { id = @event.Id }, new { });
            }
            catch (FormatException)
            {
                return this.BadRequest();
            }
            catch (ObjectNotFoundException)
            {
                return this.NotFound();
            }
            catch (Exception ex)
            {
                return this.InternalServerError(ex);
            }
        }

        [HttpDelete]
        [Route("categories/{id}", Name = CategoryResourceNames.Routes.Delete)]
        public IHttpActionResult Delete(string id)
        {
            try
            {
                this._categoryService.Delete(Guid.Parse(id));

                return this.Ok();
            }
            catch (FormatException)
            {
                return this.BadRequest();
            }
            catch (ObjectNotFoundException)
            {
                return this.NotFound();
            }
            catch (Exception ex)
            {
                return this.InternalServerError(ex);
            }
        }

        [HttpGet]
        [Route("categories/{id}/books")]
        [ResponseType(typeof(RepresentationCollection<BookListRep>))]
        public IHttpActionResult ListBooks(string id)
        {
            var list = this._bookQueryService.FindByCategory(Guid.Parse(id));

            var collection = new RepresentationCollection<BookDto, BookListRep>(list);

            return this.Ok(collection);
        }
        #endregion
    }
}