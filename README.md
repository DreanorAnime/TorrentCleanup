# TorrentCleanup
Once your torrent has downloaded it will trigger this program if you set up your config correctly.

If you use a host other than 127.0.0.1 you have to pass it to the program as a parameter.

Change your torrent config to allow the following: (TransmissionQT config) 

```json
{
    "rpc-enabled": true,
    "rpc-port": 9091,
    "rpc-username": "",
    "script-torrent-done-enabled": true,
    "script-torrent-done-filename": "INSERTYOURPATHHERE\\TorrentCleanup.exe",
}
```
