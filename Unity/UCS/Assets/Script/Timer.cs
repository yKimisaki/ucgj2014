using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Util
{
    class WaitTimer
    {
        private DateTime _target;

        public void Start(TimeSpan timeSpan)
        {
            _target = DateTime.Now + timeSpan;
        }

        public bool Check()
        {
            return DateTime.Now > _target;
        }
    }
}
