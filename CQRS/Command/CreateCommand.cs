using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Command
{
    public class CreateCommand : BaseCommand
    {
        public string Name { get; set; }
        public DateTime CreateDate { get; set; }

        public CreateCommand(Guid id, string name, DateTime createDate) : base(id) 
        {
            this.Name = name;
            this.CreateDate = createDate;
        }

    }
}
