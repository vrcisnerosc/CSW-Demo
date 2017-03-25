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
    public class AuthorController : ApiController
    {
        #region Services ---------------------
        private readonly IAuthorService _authorService;
        private readonly IAuthorQueryService _authorQueryService;
        private readonly IBookQueryService _bookQueryService;
        #endregion
        #region Constructor ------------------
        public AuthorController(IAuthorService authorService, IAuthorQueryService authorQueryService, IBookQueryService bookQueryService)
        {
            this._authorService = authorService;
            this._authorQueryService = authorQueryService;
            this._bookQueryService = bookQueryService;
        }
        #endregion
        #region Actions ----------------------        
        [HttpGet]
        [Route("authors")]
        [ResponseType(typeof(RepresentationCollection<AuthorListRep>))]
        public IHttpActionResult List()
        {
            var list = this._authorQueryService.Find();

            var collection = new RepresentationCollection<AuthorDto, AuthorListRep>(list);

            return this.Ok(collection);
        }

        [HttpGet]
        [Route("authors/{id}", Name = AuthorResourceNames.Routes.GetById)]
        public IHttpActionResult Get(string id)
        {
            try
            {
                var entity = this._authorQueryService.FindById(Guid.Parse(id));

                if (entity == null)
                    return this.NotFound();

                var representation = Mapper.Map<AuthorRep>(entity);

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
        [Route("authors", Name = AuthorResourceNames.Routes.PostCreate)]
        public IHttpActionResult Create(AuthorPostRep resource)
        {
            if (!this.ModelState.IsValid)
                return this.BadRequest(this.ModelState);

            try
            {
                var @event = new AuthorCreateEvent
                {
                    FirstName = resource.FirstName,
                    LastName = resource.LastName,
                    Country = resource.Country
                };

                this._authorService.Add(@event);

                return this.CreatedAtRoute(AuthorResourceNames.Routes.GetById, new { id = @event.Id }, resource);
            }
            catch (Exception ex)
            {
                return this.InternalServerError(ex);
            }
        }

        [HttpPut]
        [Route("authors/{id}", Name = AuthorResourceNames.Routes.PutUpdate)]
        public IHttpActionResult Update(string id, AuthorPostRep resource)
        {
            if (!this.ModelState.IsValid)
                return this.BadRequest(this.ModelState);

            try
            {
                var @event = new AuthorUpdateEvent
                {
                    Id = Guid.Parse(id),
                    FirstName = resource.FirstName,
                    LastName = resource.LastName,
                    Country = resource.Country
                };

                this._authorService.Update(@event);

                return this.CreatedAtRoute(AuthorResourceNames.Routes.GetById, new { id = @event.Id }, new { });
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
        [Route("authors/{id}", Name = AuthorResourceNames.Routes.Delete)]
        public IHttpActionResult Delete(string id)
        {
            try
            {
                this._authorService.Delete(Guid.Parse(id));

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
        [Route("authors/{id}/books")]
        [ResponseType(typeof(RepresentationCollection<BookListRep>))]
        public IHttpActionResult ListBooks(string id)
        {
            var list = this._bookQueryService.FindByAuthor(Guid.Parse(id));

            var collection = new RepresentationCollection<BookDto, BookListRep>(list);

            return this.Ok(collection);
        }
        #endregion
    }
}
