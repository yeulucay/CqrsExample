using CQRS.Command;
using CQRS.DomainModel;
using CQRS.Helper;
using DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;


namespace FileManager.Controllers
{
    [RoutePrefix("api/File")]
    public class FileController : ApiController
    {
        [HttpPost]
        [Route("Create")]
        public HttpResponseMessage Create(File fileDto)
        {
            CommandManager cm = new CommandManager();

            cm.Send(new GenericCreateCommand<File>(Guid.NewGuid(), fileDto));

            return new HttpResponseMessage(HttpStatusCode.OK);
        }
    }
}