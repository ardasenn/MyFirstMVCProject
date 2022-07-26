using System.ComponentModel.DataAnnotations;

namespace MVC_Pratik_25_07.Models.ModelMetaDataTypes
{
    public class LessonVMMetaData
    {
        [Required(ErrorMessage = "İsim girişi zorunludur")]
        [StringLength(5, ErrorMessage = "25 karakterden fazla olamaz.")]
        public string Name { get; set; }
    }
}
