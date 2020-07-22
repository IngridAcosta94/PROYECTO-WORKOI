using System;
using System.Collections.Generic;

namespace RhUI.Models.DB
{
    public partial class Documentaciones
    {
        public Documentaciones()
        {
            Candidatos = new HashSet<Candidatos>();
        }

        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool Status { get; set; }
        public string Tipo { get; set; }

        public virtual ICollection<Candidatos> Candidatos { get; set; }
    }
}
