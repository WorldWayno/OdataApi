using System.Web.Http;
using System.Web.OData.Builder;
using System.Web.OData.Extensions;
using Microsoft.Data.Edm.Library;
using Northwind.Data.Models;
using Microsoft.OData.Edm;

namespace NorthWind.Api
{
    public class ODataConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API routes
            config.MapHttpAttributeRoutes();

            ODataModelBuilder builder = new ODataConventionModelBuilder();

            var employees = builder.EntityType<Employee>();
            employees.HasMany(e => e.Orders);

            builder.EntitySet<Employee>("Employees");

            var orders = builder.EntityType<Order>();
            orders.HasKey(o => o.OrderID);
            orders.HasRequired(o => o.Employee);

            builder.EntitySet<Order>("Orders");


            config.MapODataServiceRoute(
                routeName: "ODataRoute",
                routePrefix: "odata",
                model: builder.GetEdmModel());
        }

        public static IEdmModel GetEdmModel()
        {
            var builder = new ODataModelBuilder();

            var employee = builder.EntityType<Employee>();
            employee.HasKey(e => e.EmployeeID);
            employee.HasMany(e => e.Orders);

            var order = builder.EntityType<Order>();
            order.HasKey(c => c.OrderID);
            order.HasMany(c => c.OrderDetails);

            return builder.GetEdmModel();
        }
    }
}