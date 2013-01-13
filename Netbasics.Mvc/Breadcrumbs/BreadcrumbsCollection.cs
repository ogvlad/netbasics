using System.Collections;
using System.Collections.Generic;

namespace Netbasics.Mvc.Breadcrumbs
{
    public sealed class BreadcrumbsCollection : IEnumerable<Breadcrumb>
    {
        private readonly List<Breadcrumb> _inner = new List<Breadcrumb>();

        public BreadcrumbsCollection Add(string title, string url = "")
        {
            _inner.Add(new Breadcrumb { Title = title, Url = url});
            return this;
        }

        public IEnumerator<Breadcrumb> GetEnumerator()
        {
            return _inner.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}