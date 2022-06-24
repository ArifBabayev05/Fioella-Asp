using System;
using DAL.Entity;

namespace DAL.Models
{
	public class ExpertPosition : IEntity
	{
        public int Id { get; set; }
        public int PositionId { get; set; }
        public Position Position { get; set; }
        public int ExpertId { get; set; }
        public Expert Expert { get; set; }
    }
}

