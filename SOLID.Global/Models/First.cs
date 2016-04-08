using System.Collections.Generic;
using SOLID.Global.Interfaces.DAL;

namespace SOLID.Global.Models
{
    public class First: IEntity
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public virtual ICollection<Second> Seconds { get; set; }
    }
}
