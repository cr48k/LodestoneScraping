using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Data;
using System.Data.SQLite;
using System.Diagnostics;
using Microsoft.Win32;
using System.IO;

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

            // データベースチェック
            try
            {
                using (SQLiteConnection cn = new SQLiteConnection("Data Source=lds.db"))
                {
                    cn.Open();
                    using (SQLiteCommand cmd = cn.CreateCommand())
                    {
                        // 設定用テーブル作成
                        cmd.CommandText = "CREATE TABLE IF NOT EXISTS Settings ("
                                          + "item TEXT PRIMARY KEY, "
                                          + "value TEXT NOT NULL"
                                          + ");";
                        cmd.ExecuteNonQuery();
                        // バージョンチェック
                        string dbv = null;
                        var pv = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
                        cmd.CommandText = "SELECT value FROM Settings WHERE item = 'version';";
                        using (var rdr = cmd.ExecuteReader())
                        {
                            while (rdr.Read())
                            {
                                dbv = (string)rdr[0];
                            }
                        }
                        if (dbv == null)
                        {
                            cmd.CommandText = "INSERT INTO Settings VALUES ('version', '" + pv.ToString() + "');";
                            cmd.Prepare();
                            cmd.ExecuteNonQuery();
                        }
                        else
                        {
                            var dv = new Version(dbv);
                            if (pv > dv)
                            {
                                cmd.CommandText = "UPDATE Settings SET value = '" + pv.ToString() + "' WHERE item = 'version';";
                                cmd.Prepare();
                                cmd.ExecuteNonQuery();
                            }
                        }

                        // リテイナーテーブル作成
                        cmd.CommandText = "CREATE TABLE IF NOT EXISTS Retainer ("
                                          + "retainer_id TEXT PRIMARY KEY, "
                                          + "retainer_name TEXT NOT NULL, "
                                          + "owner_name TEXT NOT NULL, "
                                          + "owner_server TEXT NOT NULL, "
                                          + "retainer_url TEXT NOT NULL, "
                                          + "itemdata_id TEXT"
                                          + ", FOREIGN KEY (itemdata_id) REFERENCES Retainer(itemdata_id)"
                                          + ");";
                        cmd.ExecuteNonQuery();
                        // アイテムデータリストテーブル作成
                        cmd.CommandText = "CREATE TABLE IF NOT EXISTS ItemDataList ("
                                          + "itemdata_id TEXT PRIMARY KEY, "
                                          + "retainer_id TEXT NOT NULL, "
                                          + "last_update INTEGER NOT NULL, "
                                          + "timestamp INTEGER NOT NULL, "
                                          + "gil INTEGER NOT NULL"
                                          + ", FOREIGN KEY (retainer_id) REFERENCES Retainer(retainer_id)"
                                          + ");";
                        cmd.ExecuteNonQuery();
                        // アイテムデータテーブル作成
                        cmd.CommandText = "CREATE TABLE IF NOT EXISTS ItemData ("
                                          + "itemdata_id TEXT NOT NULL, "
                                          + "item_name TEXT NOT NULL, "
                                          + "item_hq INTEGER NOT NULL, "
                                          + "item_qty INTEGER NOT NULL"
                                          + ", FOREIGN KEY (itemdata_id) REFERENCES ItemDataList(itemdata_id)"
                                          + ");";
                        cmd.ExecuteNonQuery();

                        // ビュー作成
                        cmd.CommandText = "CREATE VIEW IF NOT EXISTS RetainerItemView AS "
                                          + "SELECT retainer_id, item_name, item_hq, item_qty FROM Retainer "
                                          + "NATURAL INNER JOIN ItemData";
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                Debug.WriteLine(e.StackTrace);
            }

            // Updater起動
            if (File.Exists(@".\Updater.exe")) { Process.Start(@".\Updater.exe", Process.GetCurrentProcess().Id.ToString()); }

            // mainForm表示
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
