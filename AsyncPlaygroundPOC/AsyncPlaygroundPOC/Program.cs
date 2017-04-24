using Microsoft.Owin.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncPlaygroundPOC
{
    class Program
    {
        static void Main(string[] args)
        {
            // Start OWIN host
            using (WebApp.Start<Startup>(url: "http://localhost:8000"))
            {

            }
        }
    }
}
