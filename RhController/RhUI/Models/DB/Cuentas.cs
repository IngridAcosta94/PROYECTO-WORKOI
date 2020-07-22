using System;
using System.Collections.Generic;

namespace RhUI.Models.DB
{
    public partial class Cuentas
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool Status { get; set; }
        public string Nombre { get; set; }
        public string Contraseña { get; set; }
        public int PerfilId { get; set; }

        public virtual Perfiles Perfil { get; set; }
    }
}
