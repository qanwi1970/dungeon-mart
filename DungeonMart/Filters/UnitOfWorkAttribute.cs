using System.Net.Http;
using System.Web.Http.Filters;
using DungeonMart.Data.Repositories;

namespace DungeonMart.Filters
{
    public class UnitOfWorkAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            if (actionExecutedContext.Exception == null && actionExecutedContext.Response.IsSuccessStatusCode)
            {
                var unitOfWork =
                    actionExecutedContext.Request.GetDependencyScope().GetService(typeof (IUnitOfWork)) as IUnitOfWork;
                if (unitOfWork != null)
                {
                    unitOfWork.Commit();
                }
            }

            base.OnActionExecuted(actionExecutedContext);
        }
    }
}