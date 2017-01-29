using MockDb.PushR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MockDb
{
    public class RequestsMock
    {
        private static bool _running = false;
        private static Dictionary<int, string> _dataLookup;

        public RequestsMock()
        {
            try
            {
                Task.WaitAll(Start());
            }
            catch (Exception e) { }
        }

        public static async Task Start()
        {
            _running = true;
            var service = new PushR.DataServiceClient();
            int counter = 1;

            while (_running)
            {
                Console.WriteLine("Generating new Quote Request...{0}", counter++);
                int num = new Random().Next(25, 150) * 100;
                service.NewQuoteRequest(DateTime.Now, num, "MockDb Request Generator", 123, Guid.NewGuid().ToString());
                await Task.Delay(num);
            }

            return;
        }

        public static void Stop()
        {
            _running = false;
        }
    }
}
