using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Event
{
    [Serializable]
    public class BaseEvent
    {
        public Guid Id { get; private set; }
        public BaseEvent(Guid Id)
        {
            this.Id = Id;
        }
    }
}
