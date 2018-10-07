using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using XFS4NET.Logger;

namespace Daricheh.Kiosk.Service
{
    public static class NativeMethods
    {
        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern IntPtr LoadLibrary(string dllToLoad);

        [DllImport("kernel32.dll")]
        private static extern IntPtr GetProcAddress(IntPtr hModule, string procedureName);

        [DllImport("kernel32.dll")]
        public static extern bool FreeLibrary(IntPtr hModule);

        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool SetDllDirectory(string lpPathName);



        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        static extern IntPtr GetModuleHandle(string moduleName);

        private static IntPtr IsModuleLoaded(string moduleName)
        {
            // Get the module in the process according to the module name.
            IntPtr hMod = GetModuleHandle(moduleName);
            return hMod;
        }

        public static IntPtr FindAndLoadModule(string dllName)
        {
            L4Logger.Info("try to load moudle " + dllName);
            var handdler = IsModuleLoaded(dllName.Substring(0, dllName.LastIndexOf(".")));
            if (handdler != IntPtr.Zero)
            {
                L4Logger.Info("module loaded before Handdler => " + handdler.ToString());
                return handdler;
            }
            var path = AssemblyDirectory;
            string[] files = Directory.GetFiles(path,
                dllName,
                SearchOption.AllDirectories);
            var dllpath = files.FirstOrDefault(c => c.Contains(dllName));
            if (dllpath != null)
            {
                L4Logger.Info("Dll found path = " + dllpath);
                var dllDir = dllpath.Replace("\\" + dllName, string.Empty);
                L4Logger.Info("Dll Directory found path = " + dllDir);
                SetDllDirectory(dllDir);
                handdler = LoadLibrary(dllpath);
                L4Logger.Info("Dll loaded handller = " + handdler.ToString());
                if (handdler == IntPtr.Zero)
                {
                    L4Logger.Info("module loaded Failed ErrorCode => " + Marshal.GetLastWin32Error().ToString());
                }
                else
                {
                    L4Logger.Info("module loaded runtime Handdler => " + handdler.ToString());
                }
                return handdler;
            }
            return IntPtr.Zero;
        }
        private static string AssemblyDirectory
        {
            get
            {
                string codeBase = Assembly.GetExecutingAssembly().CodeBase;
                UriBuilder uri = new UriBuilder(codeBase);
                string path = Uri.UnescapeDataString(uri.Path);
                return Path.GetDirectoryName(path);
            }
        }

        private static List<FileInfo> Files;
        private static IntPtr GetFunctionPointerForDelegate<T>(T delegateCallback, out object binder)
        where T : class
        {
            var del = delegateCallback as Delegate;
            IntPtr result;

            try
            {
                result = Marshal.GetFunctionPointerForDelegate(del);
                binder = del;
            }
            catch (ArgumentException) // generic type delegate
            {
                var delegateType = typeof(T);
                var method = delegateType.GetMethod("Invoke");
                var returnType = method.ReturnType;
                var paramTypes =
                    method
                    .GetParameters()
                    .Select((x) => x.ParameterType)
                    .ToArray();

                // builder a friendly name for our assembly, module, and proxy type
                var nameBuilder = new StringBuilder();
                nameBuilder.Append(delegateType.Name);
                foreach (var pType in paramTypes)
                {
                    nameBuilder
                        .Append("`")
                        .Append(pType.Name);
                }
                var name = nameBuilder.ToString();

                // check if we've previously proxied this type before
                var proxyAssemblyExist =
                    AppDomain
                    .CurrentDomain
                    .GetAssemblies()
                    .FirstOrDefault((x) => x.GetName().Name == name);

                Type proxyType;
                if (proxyAssemblyExist == null)
                {
                    /// create a proxy assembly
                    var proxyAssembly = AppDomain.CurrentDomain.DefineDynamicAssembly(
                        new AssemblyName(name),
                        AssemblyBuilderAccess.Run
                    );
                    var proxyModule = proxyAssembly.DefineDynamicModule(name);
                    // begin creating the proxy type
                    var proxyTypeBuilder = proxyModule.DefineType(name,
                        TypeAttributes.AutoClass |
                        TypeAttributes.AnsiClass |
                        TypeAttributes.Sealed |
                        TypeAttributes.Public,
                        typeof(MulticastDelegate)
                    );
                    // implement the basic methods of a delegate as the compiler does
                    var methodAttributes =
                        MethodAttributes.Public |
                        MethodAttributes.HideBySig |
                        MethodAttributes.NewSlot |
                        MethodAttributes.Virtual;
                    proxyTypeBuilder
                        .DefineConstructor(
                            MethodAttributes.FamANDAssem |
                            MethodAttributes.Family |
                            MethodAttributes.HideBySig |
                            MethodAttributes.RTSpecialName,
                            CallingConventions.Standard,
                            new Type[] { typeof(object), typeof(IntPtr) })
                        .SetImplementationFlags(
                            MethodImplAttributes.Runtime |
                            MethodImplAttributes.Managed
                        );
                    proxyTypeBuilder
                        .DefineMethod(
                            "BeginInvoke",
                            methodAttributes,
                            typeof(IAsyncResult),
                            paramTypes)
                        .SetImplementationFlags(
                            MethodImplAttributes.Runtime |
                            MethodImplAttributes.Managed);
                    proxyTypeBuilder
                        .DefineMethod(
                            "EndInvoke",
                            methodAttributes,
                            null,
                            new Type[]
                            { typeof(IAsyncResult) })
                        .SetImplementationFlags(
                            MethodImplAttributes.Runtime |
                            MethodImplAttributes.Managed);
                    proxyTypeBuilder
                        .DefineMethod(
                            "Invoke",
                            methodAttributes,
                            returnType,
                            paramTypes)
                        .SetImplementationFlags(
                            MethodImplAttributes.Runtime |
                            MethodImplAttributes.Managed);
                    // create & wrap an instance of the proxy type
                    proxyType = proxyTypeBuilder.CreateType();
                }
                else
                {
                    // pull the type from an existing proxy assembly
                    proxyType = proxyAssemblyExist.GetType(name);
                }
                // marshal and bind the proxy so the pointer doesn't become invalid
                var repProxy = Delegate.CreateDelegate(proxyType, del.Target, del.Method);
                result = Marshal.GetFunctionPointerForDelegate(repProxy);
                binder = Tuple.Create(del, repProxy);
            }
            return result;
        }
    }
}
