using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Reto.Contpaqi.Database.Models
{
    public class Empleado
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EmpleadoId { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public int Edad { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public int GeneroId { get; set; }
        public int EstadoCivilId { get; set; }
        public string Rfc { get; set; }
        public int DireccionId { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public string Puesto { get; set; }
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
