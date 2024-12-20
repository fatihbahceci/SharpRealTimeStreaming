namespace SharpRTSPMultiChannelServer.Common
{
    public class Tracks
    {
        ///// <summary>
        ///// Video track. Must be set before starting the server.
        ///// </summary>
        public ITrack VideoTrack { get; private set; }

        ///// <summary>
        ///// Audio track.
        ///// </summary>
        public ITrack AudioTrack { get; private set; }

        public void SetVideoTrack(ITrack track, IRtpSender sender)
        {
            if (track != null)
            {
                track.Sink = sender;
            }
            this.VideoTrack = track;
        }

        public void SetAudioTrack(ITrack track, IRtpSender sender)
        {
            if (track != null)
            {
                track.Sink = sender;
            }
            this.AudioTrack = track;
        }
    }
}
