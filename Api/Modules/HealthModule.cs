using Carter;
using Carter.Response;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using System;
using HttpRequest = Microsoft.AspNetCore.Http.HttpRequest;

namespace CarterApi.Api.Modules
{
    public class HealthModule : CarterModule
    {
        public HealthModule()
        {
            Get("/", async (req, resp) => await resp.WriteAsync("ALIVE"));
           
        }

    }
}
