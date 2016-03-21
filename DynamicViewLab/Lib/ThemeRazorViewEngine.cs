using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DynamicViewLab.Lib
{
    public class ThemeViewEngine : RazorViewEngine
    {
        public ThemeViewEngine() : base()
        {
            AreaViewLocationFormats = new[] { "~/Areas/{2}/Theme/#Theme#/Views/{1}/{0}.cshtml"
                                            , "~/Areas/{2}/Theme/#Theme#/Views/Shared/{0}.cshtml"};
            AreaMasterLocationFormats = new[] { "~/Areas/{2}/Theme/#Theme#/Views/{1}/{0}.cshtml"
                                                 ,"~/Areas/{2}/Theme/#Theme#/Views/Shared/{0}.cshtml"};
            AreaPartialViewLocationFormats = new[] {"~/Areas/{2}/Theme/#Theme#/Views/{1}/{0}.cshtml"
                                                   ,"~/Areas/{2}/Theme/#Theme#/Views/Shared/{0}.cshtml"};
            ViewLocationFormats = new[] { "~/Theme/#Theme#/Views/{1}/{0}.cshtml"
                                         ,"~/Theme/#Theme#/Views/Shared/{0}.cshtml"};
            MasterLocationFormats = new[] {  "~/Theme/#Theme#/Views/{1}/{0}.cshtml"
                                            ,"~/Theme/#Theme#/Views/Shared/{0}.cshtml"};
            PartialViewLocationFormats = new[] {"~/Theme/#Theme#/Views/{1}/{0}.cshtml",
                                                 "~/Theme/#Theme#/Views/Shared/{0}.cshtml"};
        }
        protected override IView CreatePartialView(ControllerContext controllerContext, string partialPath)

        {
            var theme = GetTheme(controllerContext);
            return base.CreatePartialView(controllerContext, partialPath.Replace("#Theme#", theme));
        }
        protected override IView CreateView(ControllerContext controllerContext, string viewPath, string masterPath)

        {
            var theme = GetTheme(controllerContext);
            return base.CreateView(controllerContext, viewPath.Replace("#Theme#", theme), masterPath.Replace("#Theme#", theme));
        }
        protected override bool FileExists(ControllerContext controllerContext, string virtualPath)

        {
            var theme = GetTheme(controllerContext);
            return base.FileExists(controllerContext, virtualPath.Replace("#Theme#", theme));
        }

        private string GetTheme(ControllerContext controllerContext)
        {
            var cookie = controllerContext.RequestContext.HttpContext.Request.Cookies["theme"];
            return cookie == null ? null : cookie.Value;
        }


    }



}