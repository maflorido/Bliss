using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using Microsoft.AspNetCore.Routing;
using System.Linq;

namespace BlissRecruitment.Api.Infra.CustomParameters
{
    public class RequireParameterAttribute : ActionMethodSelectorAttribute
    {
        public RequireParameterAttribute(params string [] valueName)
        {
            ValueName = valueName;
        }
                

        public override bool IsValidForRequest(RouteContext routeContext, ActionDescriptor action)
        {
            bool isOk = true;
            foreach (var queryParameters in routeContext.HttpContext.Request.Query)
                if (!ValueName.Contains(queryParameters.Key))
                    isOk = false;
            
            return isOk && routeContext.HttpContext.Request.Query.Count == ValueName.Length;
        }

        public string[] ValueName { get; private set; }
    }
}
