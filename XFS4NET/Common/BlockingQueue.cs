using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using XFS4NET.Logger;

namespace Daricheh.Kiosk.Service.Common
{
    public class BlockingQueue<T> where T : TaskModel
    {
        private bool closing;
        private readonly Queue<TaskModel> queue = new Queue<TaskModel>();
        public event Action<TaskModel> ObjectTimeout;
        System.Threading.CancellationTokenSource CancellationTokenSource;


        public int Count
        {
            get
            {
                lock (queue)
                {
                    return queue.Count;
                }
            }
        }

        public BlockingQueue()
        {
            lock (queue)
            {
                closing = false;
                Monitor.PulseAll(queue);
            }
        }


        public bool Enqueue(T item)
        {           
            lock (queue)
            {
                if (this.Count > 0)
                {
                    var _item = queue.Dequeue();
                    if (_item.WaitForResponse)
                    {
                        L4Logger.Info("Can not insert item must WaitForResponse => " + _item.MethodName);
                        queue.Enqueue(_item);
                        item.Dispose();
                        return false;
                    }
                    else
                    {

                    }
                }
                if (closing || null == item)
                {
                    return false;
                }

                queue.Enqueue(item);
                CancellationTokenSource?.Dispose();
                CancellationTokenSource = new System.Threading.CancellationTokenSource();
                System.Threading.Tasks.Task.Run(async delegate
                {
                    await Task.Delay(item.CommandTimeSpan, CancellationTokenSource.Token);

                    if (!CancellationTokenSource.IsCancellationRequested)
                    {
                        if (ObjectTimeout != null)
                        {
                            if (queue.Count > 0)
                            {
                                var value = (T)queue.Dequeue();
                                L4Logger.Info( string.Format("object Dequeue Timeout method {0} guid {1} ", value.MethodName,value.guid));
                                value.Dispose();
                                ObjectTimeout.Invoke(value);
                            }
                        }
                    }
                });

                L4Logger.Info(string.Format("item inserted  {0}  Timeout  {1}  WaitForResponse {2}  guid {3}",
                    item.MethodName,item.CommandTimeSpan,item.WaitForResponse,item.guid));

                if (queue.Count == 1)
                {
                    // wake up any blocked dequeue
                    Monitor.PulseAll(queue);
                }
                item = null;
                return true;
            }
        }


        public void Close()
        {
            lock (queue)
            {
                if (!closing)
                {
                    closing = true;
                    queue.Clear();
                    Monitor.PulseAll(queue);
                }
            }
        }


        public bool TryDequeue(out T value, int timeout = Timeout.Infinite)
        {
            lock (queue)
            {
                while (queue.Count == 0)
                {
                    if (closing || (timeout < Timeout.Infinite) || !Monitor.Wait(queue, timeout))
                    {
                        value = default(T);
                        CancellationTokenSource?.Cancel();
                        value.Dispose();
                        return false;
                    }
                }
                CancellationTokenSource?.Cancel();
                value = (T)queue.Dequeue();
                value.Dispose();
                GC.Collect();
                return true;
            }
        }

        public void Clear()
        {
            lock (queue)
            {
                CancellationTokenSource?.Cancel();
                CancellationTokenSource = new System.Threading.CancellationTokenSource();
                queue.Clear();
                Monitor.Pulse(queue);
            }
        }
    }
}
