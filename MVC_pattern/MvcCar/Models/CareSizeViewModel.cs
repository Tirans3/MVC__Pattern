using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace MvcCar.Models
{
    public class CareSizeViewModel
    {
        public List<Car> Cars{ get; set; }
        public SelectList Sizes { get; set; }
        public string CarSize { get; set; }
        public string SearchString { get; set; }
    }
}

