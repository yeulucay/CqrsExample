using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Repository;
using DomainModel;

namespace CQRS.Event
{
    class GenericOnCreatedEventHandler<T> : IEventHandler where T : class
    {

        public async Task Handle(BaseEvent @event)
        {
            if (@event is GenericOnCreatedEvent<T>)
            {
                var onCreateEvent = (GenericOnCreatedEvent<T>)@event;

                T dto = onCreateEvent.GetDto;

                GenericDataRepository<T> genericRepo = new GenericDataRepository<T>();

                await genericRepo.Add(dto);
                
                //TODO: Here, create object in DB
            }
        }
    }
}
