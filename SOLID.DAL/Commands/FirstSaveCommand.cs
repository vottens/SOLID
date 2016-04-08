using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using RefactorThis.GraphDiff;
using SOLID.Global.Interfaces.BLL;
using SOLID.Global.Interfaces.DAL;
using SOLID.Global.Models;

namespace SOLID.DAL.Commands
{
    public class FirstSaveCommand : IFirstSaveCommand, ICommand
    {
        private readonly IRepository<First> _repository;

        public FirstSaveCommand(IRepository<First> repository)
        {
            _repository = repository;
        }

        public void SaveObjectGraph(First first)
        {
            Expression<Func<IUpdateConfiguration<First>, object>> expression = e => e.OwnedCollection(a => a.Seconds);
            _repository.InsertOrUpdate(first, expression);
            _repository.Save();
        }
    }
}
