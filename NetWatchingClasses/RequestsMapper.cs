using System;

namespace NetWatchingClasses
{
	public class RequestsMapper
	{
		public string ServerName { get; set; } //can be an IP or a domain name
		public int QueueLength { get; set; }
        public RequestsMapper()
		{
			QueueLength = 0;
		}
	}
}

