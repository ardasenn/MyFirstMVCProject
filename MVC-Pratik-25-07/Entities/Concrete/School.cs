using Microsoft.AspNetCore.Mvc;
using MVC_Pratik_25_07.Entities.Abstract;
using MVC_Pratik_25_07.Models.ModelMetaDataTypes;
using System.Collections.Generic;

namespace MVC_Pratik_25_07.Entities.Concrete
{
    [ModelMetadataType(typeof(SchoolVMMetaData))]
    public class School : BaseEntity
    {
        public School()
        {
            Students=new List<Student>();
           
        }
        public ICollection<Student> Students { get; set; }
      
    }
}
