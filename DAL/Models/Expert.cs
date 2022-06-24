using DAL.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models
{
    public class Expert : BaseEntity
    {
        public string FullName { get; set; }
        public string Position { get; set; }

        public int? ImageId { get; set; }
        public Image Image { get; set; }
    }
}
