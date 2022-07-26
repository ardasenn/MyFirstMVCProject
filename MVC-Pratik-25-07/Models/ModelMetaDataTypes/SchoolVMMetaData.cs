using System;
using System.ComponentModel.DataAnnotations;

namespace MVC_Pratik_25_07.Models.ModelMetaDataTypes
{
    public class SchoolVMMetaData
    {
        [Required(ErrorMessage = "İsim girişi zorunludur")]
        [StringLength(25, ErrorMessage = "25 karakterden fazla olamaz.")]
        public string Name { get; set; }


    }
}
