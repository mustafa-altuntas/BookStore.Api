using System;

namespace BookStore.Api.Services
{
    public class ConsoleLogger : ILoggerService
    {
        public void Write(string message)
        {
            Console.WriteLine("[ConsoleLogger] -"+message);
        }
    }
}
