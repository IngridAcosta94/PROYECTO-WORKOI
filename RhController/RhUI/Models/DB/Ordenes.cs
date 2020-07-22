using System;
using System.Collections.Generic;

namespace RhUI.Models.DB
{
    public partial class Ordenes
    {
        public Ordenes()
        {
            Candidatos = new HashSet<Candidatos>();
        }

        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool Status { get; set; }
        public string PuestoSolicitado { get; set; }
        public int EmpresaId { get; set; }

        public virtual Empresas Empresa { get; set; }
        public virtual ICollection<Candidatos> Candidatos { get; set; }
    }
}
