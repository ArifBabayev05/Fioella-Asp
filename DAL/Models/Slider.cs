using DAL.Base;
using DAL.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models
{
    public class Slider : BaseEntity, IEntity
    {
        public int? ImageId { get; set; }
        public Image Image { get; set; }
    }
}
