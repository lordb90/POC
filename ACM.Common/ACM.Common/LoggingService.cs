using System;
using System.Collections.Generic;

namespace ACM.Common
{
    public class LoggingService
    {
        public static void WriteToFile<T>(List<T> changedItems)
            where T : ILoggable
        {
            foreach(var item in changedItems)
            {
                Console.WriteLine(item.Log());
            }
        }
    }
}
