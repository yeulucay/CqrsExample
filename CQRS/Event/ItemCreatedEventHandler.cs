using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Repository;
using DomainModel;

namespace CQRS.Event
{
    public class ItemCreatedEventHandler : IEventHandler
    {

        public async Task Handle(BaseEvent @event)
        {
            if (@event is ItemCreatedEvent)
            {
                ItemCreatedEvent onCreateEvent = (ItemCreatedEvent)@event;

                File file = new File
                {
                    Id = 1,
                    Name = onCreateEvent.Name,
                    CreateDate = onCreateEvent.CreateDate
                };

                GenericDataRepository<File> genericRepo = new GenericDataRepository<File>();

                await genericRepo.Add(file);
                
                //TODO: Here, create object in DB
            }
        }
    }
}
