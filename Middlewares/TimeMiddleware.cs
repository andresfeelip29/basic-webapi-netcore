//clase middleware para concatenar la fecha actual del servidor a la respuesta

namespace webapi.Middlewares;
public class TimeMiddleware
{

    readonly RequestDelegate next;

    public TimeMiddleware(RequestDelegate nextRequest)
    {

        this.next = nextRequest;

    }

    public async Task Invoke(Microsoft.AspNetCore.Http.HttpContext context)
    {

        //se llama al middleware sigiente
        await next(context);

        //se le concatena a la respuesta la hora del servidor
        if (context.Request.Query.Any(p => p.Key == "time"))
        {
            await context.Response.WriteAsync(DateTime.Now.ToShortTimeString());
        }


    }

}

//se crea la clase estatica que va ser llamada
public static class TimeMiddlewareExtension
{

    public static IApplicationBuilder UseTimeMiddleware(this IApplicationBuilder builder)
    {

        return builder.UseMiddleware<TimeMiddleware>();
    }
}