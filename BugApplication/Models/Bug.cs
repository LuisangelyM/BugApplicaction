using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugApplication.Models
{
    [Table("Bugs")]
    public class Bug
    {
        [Key] // 2. Agrega este "atributo" justo arriba del Id
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Prioridad { get; set; }
     
        public string? Descripcion { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime FechaRegistro{ get; set; }
        public string? Reportero { get; set; }
        public string? Estado { get; set; }
    }
}
