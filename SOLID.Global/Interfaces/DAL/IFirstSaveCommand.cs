using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SOLID.Global.Models;

namespace SOLID.Global.Interfaces.DAL
{
    public interface IFirstSaveCommand
    {
        void SaveObjectGraph(First first);
    }
}
