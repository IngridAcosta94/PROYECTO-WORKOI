using System;
using System.Collections.Generic;

namespace RhUI.Models.DB
{
    public partial class Puestos
    {
        public Puestos()
        {
            Referencias = new HashSet<Referencias>();
        }

        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool Status { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<Referencias> Referencias { get; set; }
    }
}
