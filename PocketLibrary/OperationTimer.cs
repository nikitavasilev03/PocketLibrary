using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
    public class OperationTimer : IPLType, IDisposable
    {
        private Stopwatch m_startTime;

        public string sTime { get => $"{m_startTime.Elapsed}"; }

        public OperationTimer()
        {
            m_startTime = Stopwatch.StartNew();
        }
        public void Dispose()
        {
            
        }
    }
}
