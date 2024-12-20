namespace SharpRTSPMultiChannelServer.Common
{
    public interface ITracksProvider
    {
        /// <summary>
        /// Even remote addresses in same address have port number after the ip address. Example: 127.0.0.1:49283
        /// Yeap, I am surprised too.  -FBC
        /// I've searched a little bit and found that it is a ephemeral port number. 
        /// It is used to identify the client side of the connection. -FBC
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="remoteAddress"></param>
        /// <param name="requestUrl"></param>
        /// <returns></returns>
        Tracks GetTracks(IRtpSender sender, string remoteAddress, string requestUrl);
    }
}
