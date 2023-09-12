using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Identity;
using StudentProjectManager.Models.auth;

namespace StudentProjectManager.Auth
{
    public static class CustomAuthenticationMiddlewareExtensions
    {
        public static IApplicationBuilder UseCustomAuthentication(this IApplicationBuilder builder)
        {
            builder.Map("/logout", b =>
            {
                b.Run(async context =>
                {
                    try
                    {
                        await context.SignOutAsync("Identity.Application");
                    } catch (Exception ex)
                    {
                        context.Response.Redirect("/");
                    } finally
                    {
                        context.Response.Redirect("/");
                    }                                  
                });
            });
            return builder.UseMiddleware<CustomAuthenticationMiddleware>();
        }
    }
    public class CustomAuthenticationMiddleware
    {
        private readonly RequestDelegate _next;

        public CustomAuthenticationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext, SignInManager<ApplicationUser> signInManager)
        {
            if (httpContext.Request.Path.StartsWithSegments("/customlogin"))
            {
                var userName = httpContext.Request.Form["UserName"].ToString();
                var password = httpContext.Request.Form["Password"].ToString();

                var result = await signInManager.PasswordSignInAsync(userName, password, isPersistent: false, lockoutOnFailure: false);

                if (result.Succeeded)
                {
                    httpContext.Response.Redirect("/");
                }
                else
                {
                    httpContext.Response.Redirect("/login?error=true");
                }
            }
            else
            {
                await _next(httpContext);
            }
        }
    }

}
