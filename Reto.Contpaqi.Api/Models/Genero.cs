using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Reto.Contpaqi.Api.Models
{
    public class Genero
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int GeneroId { get; set; }
        public string Descripcion { get; set; }
    }
}
