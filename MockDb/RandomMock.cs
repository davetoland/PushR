using MockDb.PushR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MockDb
{
    public class RandomMock
    {
        private static bool _running = false;
        private static Dictionary<int, string> _dataLookup;

        public RandomMock()
        {
            _dataLookup = new Dictionary<int, string>();
            _dataLookup.Add(0, "a1");
            _dataLookup.Add(1, "r1");
            _dataLookup.Add(2, "q1");
            _dataLookup.Add(3, "tb1");
            _dataLookup.Add(4, "th1");
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

			while (_running)
			{
                int lookup = new Random().Next(0, 4);
                string type = _dataLookup[lookup];
                
                var data = new PushData
				{
                    DataType = type,
					Content = string.Format("<data><from><source='MockDb!' /><sent>{0}</sent></from><data>", DateTime.Now)
				};
                
				Console.WriteLine("Generating '{0}' update", type);
				service.NotifyUpdate(data);
				await Task.Delay(2500);
			}

			return;
		}

		public static void Stop()
		{
			_running = false;
		}
    }
}
