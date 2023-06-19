namespace Zadanie8.Middlewares
{
    public class ErrorHandlerMiddleware
    {
        public RequestDelegate _next;
        public ErrorHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                var directory = Directory.GetCurrentDirectory();
                var fullPath = Path.Combine(directory, "Log/log.txt");

                using (StreamWriter writer = File.AppendText(fullPath))
                writer.WriteLine(ex.Message + " [" + DateTime.Now + "]");

                context.Response.StatusCode = 500;
                await context.Response.WriteAsJsonAsync("Couldn't connect to server");
            }
        }
    }
}
