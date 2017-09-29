using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.OData;
using Microsoft.Azure.Mobile.Server;
using UdaraMyNotesAppService.DataObjects;
using UdaraMyNotesAppService.Models;

namespace UdaraMyNotesAppService.Controllers
{
    public class TodoItemController : TableController<MyNote>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            UdaraMyNotesAppContext context = new UdaraMyNotesAppContext();
            DomainManager = new EntityDomainManager<MyNote>(context, Request);
        }

        // GET tables/TodoItem
        public IQueryable<MyNote> GetAllMyNoteItems()
        {
            return Query();
        }

        // GET tables/TodoItem/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<MyNote> GetMyNoteItem(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/TodoItem/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<MyNote> PatchMyNoteItem(string id, Delta<MyNote> patch)
        {
            return UpdateAsync(id, patch);
        }

        // POST tables/TodoItem
        public async Task<IHttpActionResult> PostTodoItem(MyNote item)
        {
            MyNote current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/TodoItem/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteTodoItem(string id)
        {
            return DeleteAsync(id);
        }
    }
}