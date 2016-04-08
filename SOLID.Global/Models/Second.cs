using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SOLID.Global.Interfaces.DAL;

namespace SOLID.Global.Models
{
    public class Second : IEntity
    {
        public int Id { get; set; }

        public string Description { get; set; }

    }
}
