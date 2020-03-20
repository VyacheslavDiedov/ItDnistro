using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IT_Dnistro.ViewModels
{
    public class GalleryViewModel
    {
        public IEnumerable<DataBase.TourPhoto> Photos { get; set; }
        public IEnumerable<DataBase.TourType> Tours { get; set; }
    }
}
