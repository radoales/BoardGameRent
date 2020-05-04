namespace BGRent.Server.Infrastructure.Extensions.Filters
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Filters;
    public class ModelOrNotFoundActionFilter : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Result is ObjectResult objectResult)
            {
                var model = objectResult.Value;

                if (model == null)
                {
                    context.Result = new NotFoundResult();
                }
            }
        }
    }
}
