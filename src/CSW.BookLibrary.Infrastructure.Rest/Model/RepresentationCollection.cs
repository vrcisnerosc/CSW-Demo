using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSW.BookLibrary.Infrastructure.Rest.Model
{
    public class RepresentationCollection<T>
    {
        #region Properties -------------------
        public IEnumerable<T> Items { get; set; }
        public LinkCollection Links { get; set; }
        #endregion
        #region Constructor ------------------
        public RepresentationCollection()
        {
            this.Items = new List<T>();
            this.Links = new LinkCollection();
        }
        public RepresentationCollection(IEnumerable<T> items)
        {
            this.Items = items;
        }
        #endregion
    }

    public class RepresentationCollection<TFrom, TTo>
    {
        #region Properties -------------------
        public IEnumerable<TTo> Items { get; set; }
        public LinkCollection Links { get; set; }
        #endregion
        #region Constructor ------------------
        public RepresentationCollection()
        {
            this.Items = new List<TTo>();
            this.Links = new LinkCollection();
        }
        public RepresentationCollection(IEnumerable<TFrom> items)
        {
            this.Items = Mapper.Map<IEnumerable<TTo>>(items);
            this.Links = new LinkCollection();
        }
        #endregion
    }
}
