using System;
using System.Collections.Generic;

namespace SharpRTSPMultiChannelServer.Common
{
    public interface IRtpSender
    {
        void FeedInRawRTP(int streamType, uint rtpTimestamp, List<Memory<byte>> rtpPackets, string[] forIps);
        bool CanAcceptNewSamples();
        //Create an event named ClientRemoved having client ip address as parameter
        /// <summary>
        /// Client removed event. Parameter is the client IP address and ID port.
        /// </summary>
        event EventHandler<string> ClientRemoved;

    }
}
