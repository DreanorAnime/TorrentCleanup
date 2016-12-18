using System;
using System.Collections.Generic;
using System.Linq;
using Transmission.API.RPC;
using Transmission.API.RPC.Entity;

namespace TorrentCleanup
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string ip = args.Length == 0 ? "127.0.0.1" : args[0];

            string host = $"http://{ip}:9091/transmission/rpc";

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

                    Console.WriteLine($"Torrent added: {torrent.Name}");
                }
            }

            client.TorrentRemove(torrentsToRemove.ToArray());
        }
    }
}