﻿using System;
using System.Collections.Generic;
using System.Text;

namespace RhController.Models
{
	public interface IEntity
	{
		public int Id { get; set; }
		public bool Status { get; set; }
		public DateTime CreatedAT { get; set; }
		public DateTime? UpdatedAT { get; set; }
	}
}