using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Command
{
    public class GenericCreateCommand<T> : BaseCommand where T : class
    {
        private T commandItem;

        public GenericCreateCommand(Guid id, T CommandItem) : base(id) 
        {
            this.commandItem = CommandItem;
        }

        public T GetDto { get { return this.commandItem; } }
    }
}
