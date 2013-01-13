using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace Netbasics.Mvc.Infrastructure
{
    public static class StaticFileHelper
    {
        private static readonly string _assemblyVersion;

        static StaticFileHelper()
        {
            _assemblyVersion = Assembly.GetExecutingAssembly().GetName().Version.ToString();
        }

        public static string StaticFile(this UrlHelper html, string filename)
        {
            var virtualPath = (
                html.RequestContext.HttpContext.IsDebuggingEnabled
                    ? DebugVirtualPath(filename, html.RequestContext.HttpContext.Server)
                    : ReleaseVirtualPath(filename)
            );

            var root = html.RequestContext.HttpContext.Request.ApplicationPath;
            if (root.Length > 1) // e.g. "/myapp" instead of just "/"
            {
                virtualPath = root + virtualPath;
            }
            return virtualPath;
        }

        static string ReleaseVirtualPath(string filename)
        {
            // Insert the assembly version into the path (not the query string).
            // This seems to be more reliable when proxies are involved:
            // http://www.stevesouders.com/blog/2008/08/23/revving-filenames-dont-use-querystring/
            return String.Format("/static/{0}/{1}", _assemblyVersion, filename);
        }

        static string DebugVirtualPath(string filename, HttpServerUtilityBase server)
        {
            return String.Format("/{0}", filename);
            // Use query string to break caching. This means the file's path
            // still matches the development file system.
            var absoluteFilename = server.MapPath("~/" + filename);
            var version = File.GetLastWriteTime(absoluteFilename).Ticks.ToString();
            return String.Format("/static/{0}./{1}", version, filename);
        }
    }
}