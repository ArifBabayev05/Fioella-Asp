using DAL.Models;
using System.Collections.Generic;

namespace Floria.ViewModels
{
    public class HomeVM
    {
        public List<Slider> Sliders { get; set; }
        public List<Product> Products { get; set; }
        public List<Category> Categories { get; set; }
        public List<Expert> Experts { get; set; }
    }
}
