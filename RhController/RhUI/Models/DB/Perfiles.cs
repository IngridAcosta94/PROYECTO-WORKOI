using System;
using System.Collections.Generic;

namespace RhUI.Models.DB
{
    public partial class Perfiles
    {
        public Perfiles()
        {
            Cuentas = new HashSet<Cuentas>();
            Empleados = new HashSet<Empleados>();
        }

        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool Status { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<Cuentas> Cuentas { get; set; }
        public virtual ICollection<Empleados> Empleados { get; set; }
    }
}
