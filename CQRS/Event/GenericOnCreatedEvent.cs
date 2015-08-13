using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Event
{
    class GenericOnCreatedEvent<T> : BaseEvent where T : class
    {
        private T Dto;

        public GenericOnCreatedEvent(Guid id, T Dto)
            : base(id) 
        {
            this.Dto = Dto;
        }

        public T GetDto { get { return this.Dto; } }
    }
}
