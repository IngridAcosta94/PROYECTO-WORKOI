using System;
using System.Collections.Generic;

namespace RhUI.Models.DB
{
    public partial class Empleados
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool Status { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Correo { get; set; }
        public int PerfilId { get; set; }

        public virtual Perfiles Perfil { get; set; }
    }
}
