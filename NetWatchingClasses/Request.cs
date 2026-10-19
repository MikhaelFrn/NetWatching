namespace NetWatchingClasses
{
    public class Request
    {
        public int Id { get; set; }
        public int Port { get; set; }

        public Request (int port) {
            this.Port = port;
        }
    }
}
