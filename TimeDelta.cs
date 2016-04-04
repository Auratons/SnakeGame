using System;

namespace hw3
{
    class TimeDelta
    {
        private static TimeDelta timer = new TimeDelta();
        private DateTime currTime;
        private DateTime startTime;

        public static TimeDelta GetTimer()
        {
            return timer;
        }

        public TimeDelta()
        {
            startTime = DateTime.Now;
            currTime = startTime;
        }

        public void Update()
        {
            currTime = DateTime.Now;
        }

        public DateTime Current()
        {
            return currTime;
        }

        public DateTime RealCurrent()
        {
            return DateTime.Now;
        }

        public long RealDelta()
        {
            return (long)((DateTime.Now - currTime).TotalMilliseconds);
        }

        public long Delta()
        {
            return (long)(currTime - startTime).TotalSeconds;
        }
    }
}
