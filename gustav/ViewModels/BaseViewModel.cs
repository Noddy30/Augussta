using System;
namespace gustav.ViewModels
{
    public class BaseViewModel
    {
        public bool isDeleted { get; set; }
        public DateTime CreatedTimestamp = DateTime.Now;
        public string Id = Guid.NewGuid().ToString();
    }
}

