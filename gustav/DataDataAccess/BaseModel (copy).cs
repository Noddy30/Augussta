using System;
namespace gustav.Models
{
    public class BaseModel
    {
        public bool isDeleted { get; set; }
        public DateTime CreatedTimestamp = DateTime.Now;
        public string Id = Guid.NewGuid().ToString();
    }
}

