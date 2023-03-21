﻿namespace Assignment.DataLayer.Entities
{
	public class Entity<TId> : IEntity<TId>
	{
		public TId Id { get; set; }

		public DateTimeOffset? CreatedOn { get; set; }

		public DateTimeOffset? ModifiedOn { get; set; }

		public string CreatedBy { get; set; }

		public string ModifiedBy { get; set; }
	}
}
