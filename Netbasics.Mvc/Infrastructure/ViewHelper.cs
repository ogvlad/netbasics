﻿using System.Web;
using System.Web.Mvc;

namespace Netbasics.Mvc.Infrastructure
{
    public static class ViewHelper
    {
        public static IHtmlString ActiveIfCurrent(this WebViewPage page, string action, string ctrl, string area)
        {
            HttpRequestBase request = page.Request;
            string areaName = (string) request.RequestContext.RouteData.DataTokens["area"] ?? "";
            string controllerName = (string) request.RequestContext.RouteData.Values["controller"] ?? "";
            string actionName = (string) request.RequestContext.RouteData.Values["action"] ?? "";

            if (area == areaName && ctrl == controllerName && action == actionName)
            {
                return page.Html.Raw("class=\"active\"");
            }
            return page.Html.Raw("");
        }

        public static IHtmlString BootstrapValidationSummary(this HtmlHelper html)
        {
            string retVal = "";
            if (html.ViewData.ModelState.IsValid)
                return html.Raw("");
            retVal += "<div class='alert alert-error'>";
            retVal += "<ul>";
            foreach (string key in html.ViewData.ModelState.Keys)
            {
                foreach (ModelError err in html.ViewData.ModelState[key].Errors)
                    retVal += "<li>" + html.Encode(err.ErrorMessage) + "</li>";
            }
            retVal += "</ul></div>";
            return html.Raw(retVal);
        }
    }
}