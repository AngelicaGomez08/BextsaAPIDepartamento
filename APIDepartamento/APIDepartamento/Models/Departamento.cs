using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace APIDepartamento.Models
{
    public class Departamento
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        [ForeignKey("Pais")]
        public int IdPais { get; set; }
        [JsonIgnore]
        public Pais? Pais { get; set; }

    }
}
