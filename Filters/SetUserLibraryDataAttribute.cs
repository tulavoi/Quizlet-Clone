using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace QuizletClone.Filters
{
    public class SetUserLibraryDataAttribute : ActionFilterAttribute
    {
        private readonly string _activePage = "UserLibrary";

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            // Lấy username từ route
            var username = context.RouteData.Values["username"]?.ToString();
            if (username != null && context.Controller is Controller controller)
            {
                controller.ViewBag.Username = username;  // Gán username vào ViewBag
                controller.ViewData["ActivePage"] = _activePage; // Gán _activePage vào ViewData
            }

            base.OnActionExecuting(context);
        }
    }
}
