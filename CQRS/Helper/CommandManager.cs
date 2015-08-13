using CQRS.Command;
using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Helper
{
    public class CommandManager
    {
        public void Send<T>(T command) where T : BaseCommand
        {
            var handlers = GetHandlerTypes<T>();

            var commandHandler = handlers.Select(handler =>
                (ICommandHandler<T>)ObjectFactory.GetInstance(handler)).FirstOrDefault();


            if (commandHandler != null)
            {
                commandHandler.Execute(command);
            }
        }

        private List<Type> GetHandlerTypes<T>() where T : BaseCommand
        {
           
            var handlers = typeof(ICommandHandler<>).Assembly.GetExportedTypes().Where(x => x.GetInterfaces()
                    .Any(a => a.IsGenericType && a.GetGenericTypeDefinition() == typeof(ICommandHandler<>))).ToList();  

            //var handlers = typeof(ICommandHandler<>).Assembly.GetExportedTypes()
            //    .Where(x => x.GetInterfaces()
            //        .Any(a => a.IsGenericType && a.GetGenericTypeDefinition() == typeof(ICommandHandler<>)))
            //        .Where(h => h.GetInterfaces()
            //            .Any(ii => ii.GetGenericArguments()
            //                .Any(aa => aa == typeof(T)))).ToList();


            return handlers;
        }
    }
}
