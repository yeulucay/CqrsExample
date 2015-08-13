using CQRS.Event;
using CQRS.Repository;
using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Helper
{
    public class EventManager
    {
        public void PublishByEventId<T>(Guid id) where T : BaseEvent
        {
            Publish<T>((T)EventRepository.Instance.GetEventById(id));
        }

        private void Publish<T>(T @event) where T : BaseEvent
        {
            var handlers = GetHandlerTypes<T>().ToList();
            var eventHandler = handlers.Select(handler =>
                (IEventHandler<T>)ObjectFactory.GetInstance(handler)).FirstOrDefault();

            if (eventHandler != null)
            {
                eventHandler.Handle(@event);
            }
        }

        private IEnumerable<Type> GetHandlerTypes<T>() where T : BaseEvent
        {
           var handlers = typeof(IEventHandler<>).Assembly.GetExportedTypes()
                .Where(x => x.GetInterfaces()
                    .Any(a => a.IsGenericType && a.GetGenericTypeDefinition() == typeof(IEventHandler<>)))
                    .Where(h => h.GetInterfaces()
                        .Any(ii => ii.GetGenericArguments()
                            .Any(aa => aa == typeof(T)))).ToList();

            return handlers;
        }
    }
}
