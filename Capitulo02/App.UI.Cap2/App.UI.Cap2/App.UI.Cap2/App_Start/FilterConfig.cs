﻿using System.Web;
using System.Web.Mvc;

namespace App.UI.Cap2
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
