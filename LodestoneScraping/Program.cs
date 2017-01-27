using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Diagnostics;
using Microsoft.Win32;

namespace LodestoneScraping
{
    static class Program
    {
        enum IEVersion
        {
            /// <summary>Internet Explorer 7 (!DOCTYPE で指定がある場合は、Standards モードになります。)</summary>
            IE7 = 7000,
            /// <summary>Internet Explorer 8 (!DOCTYPE で指定がある場合は、Standards モードになります。)</summary>
            IE8 = 8000,
            /// <summary>Internet Explorer 8, Standards モード</summary>
            IE8Standards = 8888,
            /// <summary>Internet Explorer 9 (!DOCTYPE で指定がある場合は、Standards モードになります。)</summary>
            IE9 = 9000,
            /// <summary>Internet Explorer 9, Standards モード</summary>
            IE9Standards = 9999,
            /// <summary>Internet Explorer 10 (!DOCTYPE で指定がある場合は、Standards モードになります。)</summary>
            IE10 = 10000,
            /// <summary>Internet Explorer 10, Standards モード</summary>
            IE10Standards = 10001,
            /// <summary>Internet Explorer 11</summary>
            IE11 = 11000,
            /// <summary>Internet Explorer 11, Edge モード</summary>
            IE11Edge = 11001,
        }

        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Debug.WriteLine("\r\n--- " + DateTime.Now.ToString() + " ---\r\n");

            // WebBrowser の IE バージョン変更に使用するレジストリ情報
            const string FEATURE_BROWSER_EMULATION = @"Software\Microsoft\Internet Explorer\Main\FeatureControl\FEATURE_BROWSER_EMULATION";
            RegistryKey regkey = Registry.CurrentUser.CreateSubKey(FEATURE_BROWSER_EMULATION);
            string proc_name = Process.GetCurrentProcess().ProcessName + ".exe";
            string proc_dbg_name = Process.GetCurrentProcess().ProcessName + ".vshost.exe";
            var version = IEVersion.IE11Edge;

            // レジストリを登録
            regkey.SetValue(proc_name, version, RegistryValueKind.DWord);
            regkey.SetValue(proc_dbg_name, version, RegistryValueKind.DWord);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new mainForm());

            // レジストリを削除
            regkey.DeleteValue(proc_name);
            regkey.DeleteValue(proc_dbg_name);
            regkey.Close();
        }
    }
}
