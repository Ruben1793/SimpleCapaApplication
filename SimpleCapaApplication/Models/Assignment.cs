using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleCapaApplication.Models
{
    public class Assignment
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("AssignmentName")]
        public string Name { get; set; }

        public int CAPAId { get; set; }

        [ForeignKey("CAPAId")]
        [DisplayName("CAPA")]
        public virtual Capa Owner { get; set; }

        [DataType(DataType.Date)]
        [DisplayName("Fecha de Entrega")]
        public string FC { get; set; }

        public string Descripcion { get; set; }

        [DisplayName("Status Assignment")]
        public Status StatusAssigment { get; set; }

        public enum Status
        {
            Started,

            Progress,

            Finished
        }
    }
}