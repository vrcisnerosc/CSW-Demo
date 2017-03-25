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
    public class BookController : ApiController
    {
        #region Services ---------------------
        private readonly IBookService _bookService;
        private readonly IBookQueryService _bookQueryService;
        #endregion
        #region Constructor ------------------
        public BookController(IBookService bookService, IBookQueryService bookQueryService)
        {
            this._bookService = bookService;
            this._bookQueryService = bookQueryService;
        }
        #endregion
        #region Actions ----------------------        
        [HttpGet]
        [Route("books")]
        [ResponseType(typeof(RepresentationCollection<BookListRep>))]
        public IHttpActionResult List()
        {
            var list = this._bookQueryService.Find();

            var collection = new RepresentationCollection<BookDto, BookListRep>(list);

            return this.Ok(collection);
        }

        [HttpGet]
        [Route("books/{id}", Name = BookResourceNames.Routes.GetById)]
        public IHttpActionResult Get(string id)
        {
            try
            {
                var entity = this._bookQueryService.FindById(Guid.Parse(id));

                if (entity == null)
                    return this.NotFound();

                var representation = Mapper.Map<BookRep>(entity);

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
        [Route("books", Name = BookResourceNames.Routes.PostCreate)]
        public IHttpActionResult Create(BookPostRep resource)
        {
            if (!this.ModelState.IsValid)
                return this.BadRequest(this.ModelState);

            try
            {
                var @event = new BookCreateEvent
                {
                    Name = resource.Name,
                    AuthorId = resource.AuthorId,
                    CategoryId = resource.CategoryId
                };

                this._bookService.Add(@event);

                return this.CreatedAtRoute(BookResourceNames.Routes.GetById, new { id = @event.Id }, resource);
            }
            catch (Exception ex)
            {
                return this.InternalServerError(ex);
            }
        }

        [HttpPut]
        [Route("books/{id}", Name = BookResourceNames.Routes.PutUpdate)]
        public IHttpActionResult Update(string id, BookPostRep resource)
        {
            if (!this.ModelState.IsValid)
                return this.BadRequest(this.ModelState);

            try
            {
                var @event = new BookUpdateEvent
                {
                    Id = Guid.Parse(id),
                    Name = resource.Name,
                    AuthorId = resource.AuthorId,
                    CategoryId = resource.CategoryId
                };

                this._bookService.Update(@event);

                return this.CreatedAtRoute(BookResourceNames.Routes.GetById, new { id = @event.Id }, new { });
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
        [Route("books/{id}", Name = BookResourceNames.Routes.Delete)]
        public IHttpActionResult Delete(string id)
        {
            try
            {
                this._bookService.Delete(Guid.Parse(id));

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
        #endregion
    }
}
