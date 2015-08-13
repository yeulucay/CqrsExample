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
        public HttpResponseMessage Create(FileDto fileDto)
        {
            CommandManager cm = new CommandManager();

            cm.Send(new CreateCommand(Guid.NewGuid(), fileDto.Name, fileDto.CreateDate));

            return new HttpResponseMessage(HttpStatusCode.OK);
        }
    }
}