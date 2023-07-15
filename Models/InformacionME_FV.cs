using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ColumnAttribute = SQLite.ColumnAttribute;
using TableAttribute = SQLite.TableAttribute;

namespace ProyectoP2ME.FV.Models
{
    [Table("Informacion")]
    public class InformacionME_FV
    {
        [PrimaryKey, AutoIncrement,NotNull,Column("Id")]
        public int ID { get; set; }
        public int IdInfo { get; set; }
        [Column("Semestre"), Indexed,NotNull]
        public string Semestre { get; set; }
        [NotNull]
        public string Materia { get; set; }
        [NotNull]
        public string NombreProfesor { get; set; }
        [NotNull]
        public string Calificacion { get; set; }
        [MaxLength(100)]
        public string Descripcion { get; set; }
        [NotNull]
        public string Cualidad { get; set; }
        [NotNull]
        public string Horario { get; set; }
    }
}
