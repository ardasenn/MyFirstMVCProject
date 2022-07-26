using Microsoft.AspNetCore.Mvc;
using MVC_Pratik_25_07.Entities.Abstract;
using MVC_Pratik_25_07.Models.ModelMetaDataTypes;
using System.Collections;
using System.Collections.Generic;

namespace MVC_Pratik_25_07.Entities.Concrete
{
    [ModelMetadataType(typeof(StudentVMMetaData))]
    public class Student :BaseEntity
    {
        public Student()
        {
            Lessons=new HashSet<Lesson>();
        }
        public string Class { get; set; }

        public int? SchoolID { get; set; }

        public School School { get; set; }

        public ICollection<Lesson> Lessons { get; set; }

    }
}
