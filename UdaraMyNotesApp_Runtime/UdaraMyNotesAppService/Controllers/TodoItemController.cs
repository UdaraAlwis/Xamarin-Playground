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
    public class MyNoteController : TableController<MyNote>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            UdaraMyNotesAppContext context = new UdaraMyNotesAppContext();
            DomainManager = new EntityDomainManager<MyNote>(context, Request);
        }

        // GET tables/MyNote
        public IQueryable<MyNote> GetAllMyNoteItems()
        {
            return Query();
        }

        // GET tables/MyNote/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<MyNote> GetMyNoteItem(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/MyNote/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<MyNote> PatchMyNoteItem(string id, Delta<MyNote> patch)
        {
            return UpdateAsync(id, patch);
        }

        // POST tables/MyNote
        public async Task<IHttpActionResult> PostMyNote(MyNote item)
        {
            MyNote current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/MyNote/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteMyNote(string id)
        {
            return DeleteAsync(id);
        }
    }
}