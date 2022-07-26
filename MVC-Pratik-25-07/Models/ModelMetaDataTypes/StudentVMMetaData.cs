using System.ComponentModel.DataAnnotations;

namespace MVC_Pratik_25_07.Models.ModelMetaDataTypes
{
    public class StudentVMMetaData
    {
        [Required(ErrorMessage = "İsim girişi zorunludur")]
        [StringLength(25, ErrorMessage = "25 karakterden fazla olamaz.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "sınıf girişi zorunludur,Sınıfsız Öğrenci mi olur")]
        [StringLength(10, ErrorMessage = "10 karakterden fazla olamaz.")]
        public string Class { get; set; }
    }
}
