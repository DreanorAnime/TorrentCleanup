using System.Collections.Generic;
using System.Linq;
using Transmission.API.RPC;
using Transmission.API.RPC.Entity;

namespace TorrentCleanupDLL
{
    public class Cleanup
    {
        public void Clean()
        {
            string host = $"http://127.0.0.1:9091/transmission/rpc";

            Client client = new Client(host);

            var torrentsInfo = client.TorrentGet(TorrentFields.ALL_FIELDS);
            var torrentsToRemove = new List<int>();

            foreach (var torrent in torrentsInfo.Torrents)
            {
                var stats = torrent.Files.ToList();
                var totalDownload = stats.Sum(x => x.BytesCompleted);
                var totalSize = stats.Sum(x => x.Length);

                if (totalDownload == totalSize)
                {
                    torrentsToRemove.Add(torrent.ID);
                }
            }

            client.TorrentRemove(torrentsToRemove.ToArray());
        }
    }
}