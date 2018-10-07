using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace XFS4NET.Wrapper.Common
{
    public class XFSUtil
    {
        private static Regex regVersion = new Regex(@"^\d+\.\d+$");
        public static readonly int IntPtrSize = 0;
        public static ConcurrentDictionary<RuntimeTypeHandle, int> marshalSizeCache = new ConcurrentDictionary<RuntimeTypeHandle, int>();
        static XFSUtil()
        {
            IntPtrSize = Marshal.SizeOf(typeof(IntPtr));
        }
        public static void PtrToStructure<T>(IntPtr ptr, ref T p) where T : struct
        {
            p = (T)Marshal.PtrToStructure(ptr, typeof(T));
        }
        public static int ParseVersionString(string lowVersion, string hightVersion)
        {
            if (regVersion.IsMatch(lowVersion) && regVersion.IsMatch(hightVersion))
            {
                string[] ssLow = lowVersion.Split('.');
                string[] ssHigh = hightVersion.Split('.');
                int low = int.Parse(ssLow[0]) | (int.Parse(ssLow[1]) << 8);
                int high = int.Parse(ssHigh[0]) | (int.Parse(ssHigh[1]) << 8);
                return high | (low << 16);
            }
            return -1;
        }
        public static T[] XFSPtrToArray<T>(IntPtr ptr)
        {
            if (ptr != IntPtr.Zero)
            {
                int len = 0;
                for (int i = 0; Marshal.ReadIntPtr(IntPtr.Add(ptr, i)) != IntPtr.Zero; i += IntPtrSize)
                    ++len;
                if (len > 0)
                {
                    T[] arr = new T[len];
                    for (int i = 0; i < len; ++i)
                    {
                        arr[i] = (T)Marshal.PtrToStructure(Marshal.ReadIntPtr(IntPtr.Add(ptr, i * IntPtrSize)), typeof(T));
                    }
                    return arr;
                }
            }
            return new T[0];
        }

        public static int GetMarshalSize(Type t)
        {
            RuntimeTypeHandle ptr = t.TypeHandle;
            int size = 0;
            if (!marshalSizeCache.TryGetValue(ptr, out size))
            {
                size = Marshal.SizeOf(t);
                marshalSizeCache.TryAdd(ptr, size);
            }
            return size;
        }

        public static string[] GetSeratedStringFromPointer(IntPtr ptr)
        {
            if (ptr != IntPtr.Zero)
            {
                List<string> strLst = new List<string>(12);
                byte[] buf = new byte[128];
                bool zeroFlag = false;
                int bufIndex = 0;
                for (int i = 0; ; ++i)
                {
                    byte bTemp = Marshal.ReadByte(ptr, i);
                    if (bTemp == 0)
                    {
                        if (zeroFlag)
                        {
                            break;
                        }
                        else
                        {
                            zeroFlag = true;
                            if (bufIndex > 0)
                            {
                                strLst.Add(Encoding.Default.GetString(buf, 0, bufIndex));
                            }
                            bufIndex = 0;
                        }
                    }
                    else
                    {
                        zeroFlag = false;
                        if (bufIndex == buf.Length)
                        {
                            byte[] bufTemp = new byte[buf.Length * 2];
                            Array.Copy(buf, bufTemp, buf.Length);
                            buf = bufTemp;
                        }
                        buf[bufIndex++] = bTemp;
                    }
                }
                return strLst.ToArray();
            }
            return null;
        }
    }
}
