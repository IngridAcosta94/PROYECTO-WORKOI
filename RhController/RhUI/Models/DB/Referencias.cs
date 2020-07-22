using System;
using System.Collections.Generic;

namespace RhUI.Models.DB
{
    public partial class Referencias
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool Status { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public string RazonSocial { get; set; }
        public string NombreInformante { get; set; }
        public string PuestoInformante { get; set; }
        public string NombreJefe { get; set; }
        public string PuestoJefe { get; set; }
        public int SueldoInicial { get; set; }
        public int SueldoFinal { get; set; }
        public DateTime FechaInicLab { get; set; }
        public DateTime FechaFinLab { get; set; }
        public string MotivoSeparacion { get; set; }
        public string Comentarios { get; set; }
        public int CandidatoId { get; set; }
        public int PuestoId { get; set; }

        public virtual Candidatos Candidato { get; set; }
        public virtual Puestos Puesto { get; set; }
    }
}
