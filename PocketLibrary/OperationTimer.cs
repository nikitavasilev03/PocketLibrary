using System;
using System.Diagnostics;

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
            m_startTime.Stop();
        }
    }
}
