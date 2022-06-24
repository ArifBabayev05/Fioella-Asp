using DAL.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models
{
    public class Slider : BaseEntity
    {
        public int? ImageId { get; set; }
        public Image Image { get; set; }
    }
}
