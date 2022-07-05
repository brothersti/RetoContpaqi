using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Reto.Contpaqi.Api.Models
{
    public class Direccion
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DireccionId { get; set; }
        [Required]
        public string Calle { get; set; }
        [Required]
        public string NumeroInterior { get; set; }
        [Required]
        public string NumeroExterior { get; set; }
        [Required]
        public string CodigoPostal { get; set; }
        [Required]
        public string Municipio { get; set; }
        [Required]
        public string Estado { get; set; }
        [Required]
        public string Pais { get; set; }
    }
}

