using System;
using System.Collections.Generic;
using DAL.Base;
using DAL.Entity;
using Microsoft.EntityFrameworkCore;

namespace DAL.Models
{
	public class Position : BaseEntity, IEntity
    {

        public string Name { get; set; }
        public List<ExpertPosition> ExpertPositions { get; set; }
 

    }
}

