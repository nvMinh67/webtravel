using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using System;
using WebApplication5.Entity;

namespace WebApplication5.Middleware

{
    public class AdminMiddleware  : IMiddleware
    {
     
     
        //private readonly RequestDelegate _next;

        //public AdminMiddleware(RequestDelegate next)
        //{
    

        //    _next = next;

        //}

        //public async Task InvokeAsync(HttpContext context)
        //{
         
        //    if (context.Request.Path == "/admin")
        //    {
        //        var user = context.User;
        //        if (!context.User.IsInRole("admin"))
        //        {
        //            await context.Response.WriteAsync("ban khong duoc phep truy cap");
        //            context.Response.Headers.Add("admin Middleware", "ban khong duoc phep truy cap");
        //        }
        //        else 
        //        {
        //            await _next(context);
        //        }
              
        //    }
        //    else
        //    {
        //        await _next(context);
        //    }
        //}

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            if (context.Request.Path == "/admin")
            {
                var user = context.User;
                if (!context.User.IsInRole("admin"))
                {
                    await context.Response.WriteAsync("ban khong duoc phep truy cap");
                    context.Response.Headers.Add("admin Middleware", "ban khong duoc phep truy cap");
                }
                else
                {
                    await next(context);
                }

            }
            else
            {
                await next(context);
            }
       
        }
        //public async Task InvokeAsync (HttpContext context,RequestDelegate next)
        //{
        //    if(context.Request.Path == "/admin")
        //    {
        //        var user = await UserManager.GetUserAsync(context.User);
        //        if (user.Id == null){
        //            await context.Response.WriteAsync("ban khong duoc phep truy cap");
        //            context.Response.Headers.Add("admin Middleware", "ban khong duoc phep truy cap");
        //        }
        //        await next(context);
        //    }

        //}
    }
}
