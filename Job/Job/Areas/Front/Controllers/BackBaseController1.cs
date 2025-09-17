using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Text.Json;
using Job.Models;

public abstract class BackBaseController2 : Controller
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        var json = HttpContext.Session.GetString(CDictionary.SK_LOGINED_USER);
        if (!string.IsNullOrEmpty(json))
        {
            var m = JsonSerializer.Deserialize<TManager>(json);
            ViewBag.ManagerName = m?.ManagerName;
            ViewBag.ManagerId = m?.ManagerId;
        }
        base.OnActionExecuting(context);
    }
}