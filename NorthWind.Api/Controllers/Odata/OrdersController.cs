using System.Linq;
using System.Web.Http;
using System.Web.OData;
using Northwind.Data;
using Northwind.Data.Models;

namespace NorthWind.Api.Controllers.Odata
{
    public class OrdersController : ODataController
    {
        private NorthwindContext db = new NorthwindContext();

        [EnableQuery]
        public IQueryable<Order> Get()
        {
            return db.Orders.AsQueryable();
        }

        [EnableQuery]
        public SingleResult<Order> Get([FromODataUri] int key)
        {
            IQueryable<Order> result = db.Orders.Where(p => p.OrderID == key);
            return SingleResult.Create(result);
        }

        private bool OrderExists(int key)
        {
            return db.Orders.Any(p => p.OrderID == key);
        }
        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}