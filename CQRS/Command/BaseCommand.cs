using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Command
{
    public class BaseCommand
    {
        public Guid Id { get; private set; }
        public BaseCommand(Guid id)
        {
            Id = id;
        }
    }
}
