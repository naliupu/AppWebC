using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppWebC.Models
{
    public class PersonaViewModel
    {
        public virtual int Id { get; set; }

        public virtual string nombre { get; set; }

        public virtual string direccion { get; set; }

        public virtual string telefono { get; set; }

        public virtual DateTime fecha_nacimiento { get; set; }

        public virtual int? edad { get; set; }

        public virtual int id_color { get; set; }

        public virtual string id_usuario { get; set; }

        public virtual string color { get; set; }
    }
}