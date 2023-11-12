using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Agreat.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [DisplayName("Наименование категории")]
        [Required(ErrorMessage ="Поле не может быть пустым")]
        public string Name { get; set; }

        [DisplayName("Номер отображения")]
        [Required(ErrorMessage = "Поле не может быть пустым")]
        [Range(1,25,ErrorMessage ="Поле  должно быть больше 0")]
        public int DisplayOrder { get; set; }
    }
}
