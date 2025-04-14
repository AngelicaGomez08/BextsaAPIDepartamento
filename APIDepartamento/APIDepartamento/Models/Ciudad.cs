using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace APIDepartamento.Models
{
    public class Ciudad
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        [ForeignKey("Departamento")]
        public int IdDepartamento { get; set; }
        [JsonIgnore]
        public Departamento? Departamento { get; set; }
    }
}
