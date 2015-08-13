using CQRS.Event;
using CQRS.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Command
{
    public class GenericCreateCommandHandler : ICommandHandler<CreateCommand>
    {      
        public void Execute(CreateCommand command) 
        {
            CreateCommand createCommand = (CreateCommand)command;


            var genericOnCreated = new ItemCreatedEvent(Guid.NewGuid(), createCommand.Name, createCommand.CreateDate);

            EventRepository.Instance.AddEvent<ItemCreatedEvent>(genericOnCreated);
        }
    }


}
