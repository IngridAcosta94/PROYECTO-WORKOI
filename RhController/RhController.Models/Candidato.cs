using System;

namespace RhController.Models
{
	public class Candidato
	{
		public int CandidatoId { get; set; }
		public string Nombre { get; set; }
		public string Apellido { get; set; }
		//public date FechaNac { get; set; }
        public bool EstadoCivil { get; set;}
		public string Genero { get; set; }
		public string Correo { get; set; }


		//referencias
		public int NacionalidadId { get; set; }
		public Nacionalidad Nacionalidad { get; set; }
        public int OrdenId { get; set; }















	}
}
