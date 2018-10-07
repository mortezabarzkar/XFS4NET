using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Daricheh.Kiosk.Service.Common
{
    public class TaskModel : IDisposable
    {
        public TaskModel()
        {
            this.guid = Guid.NewGuid();
        }
        public string MethodName { get; set; }
        public List<string> Reponses { get; set; }

        public bool WaitForResponse { get; set; } = true;

        public int CommandTimeSpan { get; set; } = (int) 60000;
        public Guid guid { get; set; }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
            GC.Collect();
        }
    }
}
