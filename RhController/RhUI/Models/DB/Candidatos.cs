using System;
using System.Collections.Generic;

namespace RhUI.Models.DB
{
    public partial class Candidatos
    {
        public Candidatos()
        {
            Referencias = new HashSet<Referencias>();
        }

        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool Status { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Curp { get; set; }
        public string Direccion { get; set; }
        public DateTime FechaNac { get; set; }
        public string EstadoCivil { get; set; }
        public string PhotoCandidato { get; set; }
        public bool Genero { get; set; }
        public string Correo { get; set; }
        public int NacionalidadId { get; set; }
        public int OrdenId { get; set; }
        public int DocumentoId { get; set; }
        public int? DcumentacionId { get; set; }

        public virtual Documentaciones Dcumentacion { get; set; }
        public virtual Nacionalidades Nacionalidad { get; set; }
        public virtual Ordenes Orden { get; set; }
        public virtual ICollection<Referencias> Referencias { get; set; }
    }
}
