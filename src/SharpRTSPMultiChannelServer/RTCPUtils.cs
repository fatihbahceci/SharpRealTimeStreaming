﻿using System;
using System.Buffers.Binary;

namespace SharpRTSPMultiChannelServer
{
    public static class RTCPUtils
    {
        public const int RTCP_VERSION = 2;
        public const int RTCP_PACKET_TYPE_SENDER_REPORT = 200;

        public static void WriteRTCPHeader(Span<byte> rtcp_sender_report, int version, bool hasPadding, int reportCount, int packetType, int length, uint ssrc)
        {
            rtcp_sender_report[0] = (byte)((version << 6) + ((hasPadding ? 1 : 0) << 5) + reportCount);
            rtcp_sender_report[1] = (byte)packetType;
            BinaryPrimitives.WriteUInt16BigEndian(rtcp_sender_report.Slice(2), (ushort)length);
            BinaryPrimitives.WriteUInt32BigEndian(rtcp_sender_report.Slice(4), ssrc);
        }

        public static void WriteSenderReport(Span<byte> rtcpSenderReport, DateTime now, uint rtp_timestamp, uint rtpPacketCount, uint octetCount)
        {
            // Bytes 8, 9, 10, 11 and 12,13,14,15 are the Wall Clock
            // Bytes 16,17,18,19 are the RTP payload timestamp

            // NTP Most Signigicant Word is relative to 0h, 1 Jan 1900
            // This will wrap around in 2036
            DateTime ntp_start_time = new DateTime(1900, 1, 1, 0, 0, 0, DateTimeKind.Utc);

            TimeSpan tmpTime = now - ntp_start_time;
            double totalSeconds = tmpTime.TotalSeconds; // Seconds and fractions of a second

            uint ntp_msw_seconds = (uint)Math.Truncate(totalSeconds); // whole number of seconds
            uint ntp_lsw_fractions = (uint)(totalSeconds % 1 * uint.MaxValue); // fractional part, scaled between 0 and MaxInt

            // cross check...   double ntp = ntp_msw_seconds + (ntp_lsw_fractions / UInt32.MaxValue);
            BinaryPrimitives.WriteUInt32BigEndian(rtcpSenderReport.Slice(8), ntp_msw_seconds);
            BinaryPrimitives.WriteUInt32BigEndian(rtcpSenderReport.Slice(12), ntp_lsw_fractions);
            BinaryPrimitives.WriteUInt32BigEndian(rtcpSenderReport.Slice(16), rtp_timestamp);
            BinaryPrimitives.WriteUInt32BigEndian(rtcpSenderReport.Slice(20), rtpPacketCount);
            BinaryPrimitives.WriteUInt32BigEndian(rtcpSenderReport.Slice(24), octetCount);
        }
    }
}
