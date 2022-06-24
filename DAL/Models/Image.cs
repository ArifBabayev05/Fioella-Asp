using DAL.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models
{
    public class Image : BaseEntity
    {
        public string Name { get; set; }

        public List<Expert> Experts { get; set; }
        public List<Product> Products { get; set; }
        public List<Slider> Sliders { get; set; }
    }
}
