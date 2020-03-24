using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataBase;
using Microsoft.AspNetCore.Mvc;

namespace IT_Dnistro.Component
{
    public class NavigationMenuViewComponent : ViewComponent
    {
        private DatabaseContext _db;
        public NavigationMenuViewComponent(DatabaseContext context)
        {
            _db = context;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedCategory = RouteData?.Values["tourType"];
            return View(_db.TourTypes
                .Select(x => x.TourTypeName));
        }
    }
}
