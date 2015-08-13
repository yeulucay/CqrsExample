using CQRS.Event;
using CQRS.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Repository
{
    public class EventRepository
    {
        private static volatile EventRepository instance;
        private static object syncRoot = new object();

        private readonly EventManager em;

        List<BaseEvent> eventList;

        private EventRepository()
        {
            em = new EventManager();
            this.eventList = new List<BaseEvent>();
        }

        public static EventRepository Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new EventRepository();
                    }
                }
                return instance;
            }
        }

        public void AddEvent<T>(BaseEvent @event) where T : BaseEvent
        {
            this.eventList.Add(@event);

            this.em.PublishByEventId<T>(@event.Id);
        }

        public BaseEvent GetEventById(Guid Id)
        {
            return this.eventList.Where(x => x.Id == Id).SingleOrDefault();
        }


    }

}
