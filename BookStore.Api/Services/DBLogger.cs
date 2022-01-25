using System;

namespace BookStore.Api.Services
{
    public class DBLogger : ILoggerService
    {
        public void Write(string message)
        {
            Console.WriteLine("[DBLogger] -" + message);

        }
    }
}
