using System;

namespace MVC_Pratik_25_07.Entities.Abstract
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreationTime { get; set; } = DateTime.Now;
    }
}
