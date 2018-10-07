using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XFS4NET.Model.Common
{
    public enum DEVSTATUS : ushort
    {        
        WFS_STAT_DEVONLINE = 0,
        WFS_STAT_DEVOFFLINE = 1,
        WFS_STAT_DEVPOWEROFF = 2,
        WFS_STAT_DEVNODEVICE = 3,
        WFS_STAT_DEVHWERROR = 4,
        WFS_STAT_DEVUSERERROR = 5,
        WFS_STAT_DEVBUSY = 6,
        WFS_STAT_DEVFRAUDATTEMPT = 7,
        WFS_STAT_DEVPOTENTIALFRAUD = 8
    }
    public enum AntiFraudModule : ushort
    {
        WFS_AFMNOTSUPP = 0,
        WFS_AFMOK = 1,
        WFS_AFMINOP = 2,
        WFS_AFMDEVICEDETECTED = 3,
        WFS_AFMUNKNOWN = 4
    }
}
