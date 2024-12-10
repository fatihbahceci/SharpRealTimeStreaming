namespace SharpRTSPMultiChannelServer
{
    public interface ITracksProvider
    {
        Tracks GetTracks(IRtpSender sender, string requestUrl);
    }
}
