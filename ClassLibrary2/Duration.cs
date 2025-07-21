using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary2
{
    internal class Duration
    {
        public int Hours { get; set; }
        public int Minutes { get; set; }
        public int Seconds { get; set; }

        public Duration(int hours, int minutes, int seconds)
        {
            Hours = hours;
            Minutes = minutes;
            Seconds = seconds;
            Normalize();
        }

        public Duration(int totalSeconds)
        {
            Hours = totalSeconds / 3600;
            totalSeconds %= 3600;
            Minutes = totalSeconds / 60;
            Seconds = totalSeconds % 60;
        }

        private void Normalize()
        {
            if (Seconds >= 60)
            {
                Minutes += Seconds / 60;
                Seconds %= 60;
            }

            if (Minutes >= 60)
            {
                Hours += Minutes / 60;
                Minutes %= 60;
            }
        }

        public override string ToString()
        {
            if (Hours > 0)
                return $"Hours: {Hours}, Minutes :{Minutes}, Seconds :{Seconds}";
            else
                return $"Minutes :{Minutes}, Seconds :{Seconds}";
        }

        public override bool Equals(object obj)
        {
            if (obj is Duration d)
            {
                return this.Hours == d.Hours &&
                       this.Minutes == d.Minutes &&
                       this.Seconds == d.Seconds;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return Hours.GetHashCode() ^ Minutes.GetHashCode() ^ Seconds.GetHashCode();
        }

        private int TotalSeconds => Hours * 3600 + Minutes * 60 + Seconds;

        public static Duration operator +(Duration d1, Duration d2)
        {
            return new Duration(d1.TotalSeconds + d2.TotalSeconds);
        }

        public static Duration operator +(Duration d, int seconds)
        {
            return new Duration(d.TotalSeconds + seconds);
        }

        public static Duration operator +(int seconds, Duration d)
        {
            return new Duration(d.TotalSeconds + seconds);
        }

        public static Duration operator -(Duration d1, Duration d2)
        {
            int diff = d1.TotalSeconds - d2.TotalSeconds;
            return new Duration(Math.Max(diff, 0)); 
        }

        public static Duration operator ++(Duration d)
        {
            return new Duration(d.TotalSeconds + 60);
        }

        public static Duration operator --(Duration d)
        {
            return new Duration(Math.Max(d.TotalSeconds - 60, 0));
        }

        public static bool operator >(Duration d1, Duration d2)
        {
            return d1.TotalSeconds > d2.TotalSeconds;
        }

        public static bool operator <(Duration d1, Duration d2)
        {
            return d1.TotalSeconds < d2.TotalSeconds;
        }

        public static bool operator >=(Duration d1, Duration d2)
        {
            return d1.TotalSeconds >= d2.TotalSeconds;
        }

        public static bool operator <=(Duration d1, Duration d2)
        {
            return d1.TotalSeconds <= d2.TotalSeconds;
        }

        // Overload true/false to evaluate in if
        public static bool operator true(Duration d) => d.TotalSeconds > 0;
        public static bool operator false(Duration d) => d.TotalSeconds <= 0;

        // Explicit cast to DateTime
        public static explicit operator DateTime(Duration d)
        {
            return new DateTime(1, 1, 1, d.Hours, d.Minutes, d.Seconds);
        }
    }
}
