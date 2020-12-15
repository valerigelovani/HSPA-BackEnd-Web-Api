﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace HSPA_Web_Api.Extensions
{
    public static class ExceptionMiddlewareExtensions
    {
        public static void ConfigureExceptionHandler(this IApplicationBuilder app,
            IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage(); // detaluri exception ebi aqedan modis
            }
            else
            {
                app.UseExceptionHandler( // tu rame cnobili exception iqneba zemot ^ mouvlis ifshi is metodi,  danarchen unknow erors aq gavfiltravt
                    options =>
                    {
                        options.Run(
                            async context =>
                            {
                                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                                var ex = context.Features.Get<IExceptionHandlerFeature>();
                                if (ex != null)
                                {
                                    await context.Response.WriteAsync(ex.Error.Message);
                                }
                            }
                           );
                    }
                    );
            }
        }
    }
}
