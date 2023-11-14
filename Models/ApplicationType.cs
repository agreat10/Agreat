using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Agreat.Models
{
    public class ApplicationType
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="Поле не должно быть пустым")]
        [DisplayName("Наименование типа товара")]
        public string Name { get; set; }
    }
}
