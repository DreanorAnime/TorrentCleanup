using TorrentCleanupDLL;

namespace TorrentCleanup
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Cleanup cleanup = new Cleanup();
            cleanup.Clean();
        }
    }
}