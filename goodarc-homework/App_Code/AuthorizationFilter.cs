using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Homework {
    public class AuthorizationFilter : IAuthorizationFilter {
        public void OnAuthorization(AuthorizationFilterContext context) {
            // 如果驗證失敗，可以讓 pipeline 短路
            //if (!context.HttpContext.Session.TryGetValue(clsDefine.SKusername, out byte[] temp)) {
            //    context.Result = new UnauthorizedResult();
            //}
        }
    }
}
