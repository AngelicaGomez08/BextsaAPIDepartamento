using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace APIDepartamento.Models
{
    public class Pais
    {
        public int Id { get; set; }

        [Required]
        public string Nombre { get; set; }
        [JsonIgnore]
        public ICollection<Departamento>? Departamentos { get; set; }
    }
}
