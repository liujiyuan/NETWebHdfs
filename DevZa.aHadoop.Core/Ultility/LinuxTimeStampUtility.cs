using System;

namespace DevZa.aHadoop.Ultility
{
    public class LinuxTimeStampUtility
    {
        private static readonly DateTime UnixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        public static long GetCurrentUnixTimestampMillis()
        {
            return (long)(DateTime.UtcNow - UnixEpoch).TotalMilliseconds;
        }

        public static DateTime? DateTimeFromUnixTimestampMillis(long millis)
        {
            if (millis.Equals(0)) return null;
            return UnixEpoch.AddMilliseconds(millis);
        }

        public static long GetCurrentUnixTimestampSeconds()
        {
            return (long)(DateTime.UtcNow - UnixEpoch).TotalSeconds;
        }

        public static DateTime? DateTimeFromUnixTimestampSeconds(long seconds)
        {
            if (seconds.Equals(0)) return null;
            return UnixEpoch.AddSeconds(seconds);
        }
    }
}
