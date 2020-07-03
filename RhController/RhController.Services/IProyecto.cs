using RhController.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RhController.Services
{
	public interface IProyecto<T> where T : BaseEntity
	{
		public IEnumerable<T> GetAll();
		public T Get(int id);
		public int Insert(T obj);
		public void Update(T obj);
		public void Delete(T obj);
	}
}
