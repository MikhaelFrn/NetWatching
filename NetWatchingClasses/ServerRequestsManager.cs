using System;
using System.Net.Sockets;

namespace NetWatchingClasses
{
	public class ServerRequestsManager
	{
		public string ServerName { get; set; } //can be an IP or a domain name
		public int QueueLength { get; set; } //amount of request queued

        public ServerRequestsManager()
		{
			QueueLength = 0;
		}

		public void ProduceRequest (Request req)
		{
			ThreadPool.QueueUserWorkItem(new WaitCallback(ConsumeRequest), req);
			QueueLength++;
		}
		public void ConsumeRequest (Object obj)
		{
			Request req = (Request) obj;
			if (req.Port % 100 == 0) //at every 100 requests
			{
				Console.WriteLine("Thread {0} consumes request {1}", Thread.CurrentThread.GetHashCode(), ((Request)obj).Id); 
				//thread hash replaces {0}, request id replaces {1}
			};

			try
			{
				TcpClient client = new TcpClient();
				client.Connect(ServerName, req.Port);
			} 
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
				QueueLength--;
				return;
			};

			Console.WriteLine("Server {0} at port {1}", ServerName, req.Port);
			QueueLength--;
		}
	}
}

