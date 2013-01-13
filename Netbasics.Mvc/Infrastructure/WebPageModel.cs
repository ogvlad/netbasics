using System.Collections.Generic;
using Netbasics.Mvc.Breadcrumbs;

namespace Netbasics.Mvc.Infrastructure
{
    public abstract class WebPageModel
    {
        public string BrowserTitle { get; set; }
        public string PageTitle { get; set; }
        public string MetaKeywords { get; set; }
        public string MetaDescription { get; set; }

        public BreadcrumbsCollection Breadcrumbs { get; protected set; }

        public WebPageModel()
        {
            Breadcrumbs = new BreadcrumbsCollection();
        }
    }
}