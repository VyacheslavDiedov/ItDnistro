using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataBase;
using Microsoft.AspNetCore.Mvc;

namespace IT_Dnistro.Component
{
    public class NavigationMenuMainViewComponent : ViewComponent
    {
        private DatabaseContext _db;
        private static int IdTour;
        public NavigationMenuMainViewComponent(DatabaseContext context)
        {
            _db = context;
        }

        public IViewComponentResult Invoke(int idTour)
        {
            if (idTour == 0)
            {
                if (_db.TourTypes.FirstOrDefault()?.Id == null)
                {
                    IdTour = 0;
                }

                if (_db.TourTypes.FirstOrDefault()?.Id != null)
                {
                    IdTour = _db.TourTypes.First().Id;
                }
            }
            if (idTour > 0)
            {
                IdTour = idTour;
            }
            var item = _db.TourTypes.Where(x => x.Id != IdTour).ToList();
            return View(item);
        }
    }
}