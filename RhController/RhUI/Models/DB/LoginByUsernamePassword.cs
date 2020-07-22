using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RhUI.Models.DB
{
	public partial class LoginByUsernamePassword
	{
		public int Id { get; set; }
		public string username { get; set; }
		public string password { get; set; }
	}
}
