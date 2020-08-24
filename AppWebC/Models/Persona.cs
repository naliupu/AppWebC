using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace AppWebC.Models
{
    [Table("Persona")]
    public partial class Persona
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual int Id { get; set; }

        [Required(ErrorMessage = "El nombre es requerido")]
        [MaxLength(20, ErrorMessage = "El nombre debe tener maximo 20 caracteres")]
        [Display(Name = "Nombre")]
        public virtual string nombre { get; set; }

        [Required(ErrorMessage = "La direccion es requerida")]
        [Display(Name = "Direccion")]
        public virtual string direccion { get; set; }

        [Required(ErrorMessage = "El numero de telefono es requerido")]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Telefono")]
        public virtual string telefono { get; set; }

        [Required(ErrorMessage = "La fecha de nacimiento es requerida")]
        [DataType(DataType.Date)]
        [Display(Name = "fecha de nacimiento")]
        public virtual DateTime fecha_nacimiento { get; set; }

        public virtual int? edad { get; set; }

        [Required]
        [Display(Name = "Color")]
        public virtual int id_color { get; set; }

        [Required]
        [Display(Name = "Usuario")]
        public virtual string id_usuario { get; set; }


    }
}