using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Diagnostics;
using System.Net;
using System.IO;
using System.IO.Compression;
using System.Windows.Forms;

namespace Updater
{
    class Program
    {
        static void Main(string[] args)
        {
            // 引数チェック
            if (args.Length == 0) { return; }

            // 本体ファイルの存在チェック
            if (!File.Exists(@".\LodestoneScraping.exe"))
            {
                MessageBox.Show("LodestoneScraping.exe が見つかりません。", "LodestoneScrapingUpdater", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 本体ファイルのバージョンを取得
            var vi = FileVersionInfo.GetVersionInfo("LodestoneScraping.exe");
            Version current_version = new Version(vi.FileVersion);
            
            // 最新バージョンの確認
            Version latest_version = null;
            using (var wc = new WebClient())
            using (var st = wc.OpenRead(@"https://raw.githubusercontent.com/cr48k/LodestoneScraping/master/Releases/Notes/version.info"))
            {
                var sr = new StreamReader(st, Encoding.UTF8);
                var v = sr.ReadToEnd();
                latest_version = new Version(v);
            }

            // バージョン比較
            if (current_version >= latest_version)
            {
                //MessageBox.Show("更新はありません。", "LodestoneScrapingUpdater", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var r = MessageBox.Show("バージョン " + latest_version.ToString() + " が利用可能です。ダウンロードしますか？", "LodestoneScrapingUpdater", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.No) { return; }

            // 最新バージョンをダウンロード
            Directory.CreateDirectory(@".\tmp");
            string path = @".\tmp\update.zip";
            using (var wc = new WebClient())
            {
                wc.DownloadFile(@"https://github.com/cr48k/LodestoneScraping/raw/master/Releases/LodestoneScraping_" + latest_version.ToString() + @".zip", path);
            }
            using (var zip = ZipFile.OpenRead(path))
            {
                var e = zip.GetEntry("LodestoneScraping_" + latest_version.ToString() + "/LodestoneScraping.exe");
                if (e != null)
                {
                    // LodestoneScraping を終了する
                    Process.GetProcessById(int.Parse(args[0])).Kill();
                    while (!Process.GetProcessById(int.Parse(args[0])).WaitForExit(1000)) { }
                    // ファイル展開
                    try
                    {
                        e.ExtractToFile(@".\LodestoneScraping.exe", true);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("エラーが発生したため中断します。", "LodestoneScrapingUpdater", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            Directory.Delete(@".\tmp", true);

            MessageBox.Show("更新が完了しました。", "LodestoneScrapingUpdater", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
