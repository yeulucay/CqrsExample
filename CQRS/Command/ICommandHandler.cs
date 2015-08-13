using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Command
{
    interface ICommandHandler<TCommand> where TCommand : BaseCommand
    {
        void Execute(TCommand command);
    }
}
