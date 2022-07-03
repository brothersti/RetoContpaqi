using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Reto.Contpaqi.Web.Models
{
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EmpleadoId { get; set; }

        [Required(AllowEmptyStrings =false)]
        [StringLength(50, ErrorMessage ="El campo nombre es requerido")]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }

        [Required(AllowEmptyStrings = false)]
        [StringLength(50, ErrorMessage = "El campo Apellido Paterno es requerido y puede tener un maximo de 50 carácteres")]
        [Display(Name = "Apellido Paterno")]
        public string ApellidoPaterno { get; set; }

        [Required(AllowEmptyStrings = false)]
        [StringLength(50, ErrorMessage = "El campo Apellido Materno es requerido y puede tener un maximo de 50 carácteres")]
        [Display(Name = "Apellido Materno")]
        public string ApellidoMaterno { get; set; }

        [Required]
        [RegularExpression(pattern: "^[1-9]{3}$", ErrorMessage = "El campo Edad es requerido y puede tener un maximo de 3 carácteres")]
        [Display(Name = "Edad")]
        public int Edad { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha Nacimiento")]
        public DateTime FechaNacimiento { get; set; }

        [Required]
        [Display(Name = "Genero")]
        public int GeneroId { get; set; }


        [Required]
        [Display(Name = "EstadoCivil")]
        public int EstadoCivilId { get; set; }

        [Required(AllowEmptyStrings =false)]
        [StringLength(12, ErrorMessage = "El campo RFC es requerido y puede tener un maximo de 12 carácteres")]
        [Display(Name = "Rfc")]
        public string Rfc { get; set; }

        public int DireccionId { get; set; }

        [Required(AllowEmptyStrings = false)]
        [DataType(DataType.EmailAddress)]
        [StringLength(80, ErrorMessage = "El campo RFC es requerido y puede tener un maximo de 80 carácteres")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(AllowEmptyStrings = false)]
        [RegularExpression(pattern:"^[0-9]{10}$", ErrorMessage = "El campo Telefono es requerido y puede tener un maximo de 10 carácteres")]
        [Display(Name = "Telefono")]
        public string Telefono { get; set; }

        [Required(AllowEmptyStrings = false)]
        [StringLength(12, ErrorMessage = "El campo Puesto es requerido y puede tener un maximo de 12 carácteres")]
        [Display(Name = "Puesto")]
        public string Puesto { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime FechaAlta { get; set; }

        public DateTime FechaBaja { get; set; }

        [ForeignKey("DireccionId")]
        public virtual Direccion Direccion { get; set; }

        [ForeignKey("GeneroId")]
        public virtual Genero Genero { get; set; }

        [ForeignKey("EstadoCivilId")]
        public virtual EstadoCivil EstadoCivil { get; set; }
    }
}
