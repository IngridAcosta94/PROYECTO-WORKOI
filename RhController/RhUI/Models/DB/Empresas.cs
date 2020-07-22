using System;
using System.Collections.Generic;

namespace RhUI.Models.DB
{
    public partial class Empresas
    {
        public Empresas()
        {
            Ordenes = new HashSet<Ordenes>();
        }

        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool Status { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Correo { get; set; }
        public string Telefono { get; set; }
        public int PerfilId { get; set; }

        public virtual ICollection<Ordenes> Ordenes { get; set; }
    }
}
