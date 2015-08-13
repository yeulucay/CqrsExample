using CQRS.Event;
using CQRS.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Command
{
    public class GenericCreateCommandHandler<T> : ICommandHandler<GenericCreateCommand<T>> where T : class
    {      
        public void Execute(GenericCreateCommand<T> command) 
        {
            GenericCreateCommand<T> createCommand = (GenericCreateCommand<T>)command;
            T dto = createCommand.GetDto;

            var genericOnCreated = new GenericOnCreatedEvent<T>(Guid.NewGuid(), dto);

            EventRepository.Instance.AddEvent<GenericOnCreatedEvent<T>>(genericOnCreated);
        }
    }


}
