using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Reto.Contpaqi.Web.Models
{
    public class EstadoCivil
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EstadoCivilId { get; set; }
        public string Descripcion { get; set; }
    }
}
