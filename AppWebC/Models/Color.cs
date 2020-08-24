using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppWebC.Models
{
    [Table("Color")]
    public partial class Color
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual int Id { get; set; }


        [Required(ErrorMessage = "El nombre del color es requerido")]
        [MinLength(2, ErrorMessage = "El nombre del color debe tener mas de 2 caracteres")]
        [Display(Name = "Nombre")]
        public virtual string nombre_color { get; set; }

        [Required(ErrorMessage = "El color es requerido")]
        [MinLength(2)]
        public virtual string color { get; set; }
    }
}