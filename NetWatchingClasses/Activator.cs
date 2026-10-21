using System;

namespace NetWatchingClasses
{
    public class Activator
	{
		public Activator()
		{
		}

		public static void Activate(string[] parameters)
		{
			if (parameters.Length < 1)
			{
				Console.WriteLine("You must enter a server name or IP address");
				return;
			}

			Console.WriteLine("TCP pinging {0}", parameters);
			ServerRequestsManager srm = new ServerRequestsManager();
			srm.ServerName = parameters[0];

			//loops over the 65536 ports, the index starts at 1 to skip over port 0 (it's usually not a typical service port),
			for (int i = 1; i < 65536; i++)
			{
				srm.ProduceRequest()
			}
			while (srm.QueueLength > 0) {
				Thread.Sleep(1000);
			}




        }
	}
}

