using NUnit.Framework;
using Assert = Xunit.Assert;

namespace LeetCode;

public class Problem0933
{
    public class RecentCounter
    {
        private const int MAX_TIME = 3000;
        private Queue<int> _queue = new();

        public int Ping(int t)
        {
            _queue.Enqueue(t);
            while (_queue.Count != 0 && _queue.Peek() < t - MAX_TIME)
            {
                _queue.Dequeue();
            }
            return _queue.Count;
        }
    }
}