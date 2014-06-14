using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Util
{
    class Timer
    {
        public static WaitTimer CreateWait(TimeSpan timeSpan)
        {
            return new WaitTimer(timeSpan);
        }
    }

    class WaitTimer
    {
        private DateTime _target;
        private TimeSpan _span;

        public WaitTimer(TimeSpan timeSpan)
        {
            _span = timeSpan;
        }

        public void Start()
        {
            _target = DateTime.Now + _span;
        }

        public bool Check()
        {
            return DateTime.Now > _target;
        }
    }
}
