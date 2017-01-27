using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO;
using System.Net;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;

namespace LodestoneScraping
{
    public partial class mainForm : Form
    {
        private static readonly string FFXIV_DOMAIN = "http://jp.finalfantasyxiv.com";
        private static readonly DateTime UNIX_EPOCH = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        private Icon favicon = null;
        private long _ldst_id = -1;
        private bool isParsing = false;
        private List<Retainer> retainer_list;

        public mainForm()
        {
            InitializeComponent();
            CoInternetSetFeatureEnabled(DISABLE_NAVIGATION_SOUNDS, SET_FEATURE_ON_PROCESS, true);

            retainer_list = new List<Retainer>();
        }

        #region Disable WebBrowser navigating (click) sound
        private const int DISABLE_NAVIGATION_SOUNDS = 21;
        private const int SET_FEATURE_ON_PROCESS = 0x00000002;
        [DllImport("urlmon.dll")]
        [PreserveSig]
        [return: MarshalAs(UnmanagedType.Error)]
        static extern int CoInternetSetFeatureEnabled(int FeatureEntry, [MarshalAs(UnmanagedType.U4)] int dwFlags, bool fEnable);
        #endregion

        private void SwitchControleEnabled(bool parsing)
        {
            mainWebBrowser.AllowNavigation = !parsing;
            parsingPanel.Visible = parsing;
            retainerListBox.Enabled = !parsing;
            selectAllCheckBox.Enabled = !parsing;
            exportMessageLabel.Enabled = !parsing;
            exportButton.Enabled = !parsing;
        }

        private async void StartParsing()
        {
            isParsing = true;
            SwitchControleEnabled(isParsing);

            List<Retainer> list = await GetRetainerData();
            MergeRetainerList(list);

            isParsing = false;
            SwitchControleEnabled(isParsing);
        }

        private async void mainWebBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            // タスクバーアイコンをfaviconに設定
            if (favicon == null) Icon = await GetFavicon();

            // キャラクター情報更新
            var ldst_id = await UpdateCharacterInfo();
            //Debug.WriteLine(ldst_id);
            if (ldst_id != _ldst_id)
            {
                _ldst_id = ldst_id;
                StartParsing();
            }
        }

        private void mainWebBrowser_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            // mainWebBrowserのURLを取得し表示する
            urlTextBox.Text = mainWebBrowser.Url.ToString();
        }

        #region 進捗ダイアログ関連
        /// <summary>
        /// 進捗を報告する
        /// </summary>
        /// <param name="pct">プログレスバーの割合</param>
        private void ReportProgress(int pct)
        {
            if (pct < parsingProgressBar.Minimum) { pct = parsingProgressBar.Minimum; }
            if (pct > parsingProgressBar.Maximum) { pct = parsingProgressBar.Maximum; }
            parsingProgressBar.Value = pct;
        }
        /// <summary>
        /// 進捗を報告する
        /// </summary>
        /// <param name="status">状況</param>
        private void ReportProgress(string status)
        {
            parsingProgressLabel.Text = status;
        }
        /// <summary>
        /// 進捗を報告する
        /// </summary>
        /// <param name="pct">プログレスバーの割合</param>
        /// <param name="status">状況</param>
        private void ReportProgress(int pct, string status)
        {
            ReportProgress(pct);
            ReportProgress(status);
        }
        /// <summary>
        /// 進捗をリセットする
        /// </summary>
        private void ResetProgress()
        {
            ReportProgress(0, "");
        }
        #endregion

        /// <summary>
        /// mainWebBrowserで表示しているfaviconデータを取得する
        /// </summary>
        /// <returns>favicon</returns>
        private Task<Icon> GetFavicon()
        {
            string iconUrl = null;

            // HtmlDocumentを構築
            var doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(mainWebBrowser.DocumentText);
            // relにiconが含まれるlinkタグを抽出
            foreach (var linkTag in doc.DocumentNode.SelectNodes(@"//link[contains(@rel,'icon')]"))
            {
                var href = linkTag.Attributes["href"].Value;
                // 絶対URLに変換
                if (href.StartsWith("http")) { iconUrl = href; }
                else if (href.StartsWith("/")) { iconUrl = mainWebBrowser.Url.Host + href; }
                else { iconUrl = (new Uri(mainWebBrowser.Url, href)).ToString(); }
                break;
            }

            if (iconUrl != null)
            {
                // アイコンデータを取得
                using (var webClient = new WebClient())
                using (var stream = new MemoryStream(webClient.DownloadData(iconUrl)))
                {
                    favicon = new Icon(stream);
                }
            }

            if (iconUrl == null || favicon == null)
            {
                // データ取得ができなかった場合
                return Task.Run(() =>
                {
                    return Icon;
                });
            }
            else
            {
                // データ取得ができた場合
                return Task.Run(() => {
                    return favicon;
                });
            }
        }

        /// <summary>
        /// キャラクター情報を取得する
        /// </summary>
        /// <returns></returns>
        private Task<long> UpdateCharacterInfo()
        {
            long ldst_id = 0;
            var doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(mainWebBrowser.DocumentText);

            var login_node = doc.DocumentNode.SelectSingleNode("//div[contains(@class,'l__header__login')]");
            var chara_node = doc.DocumentNode.SelectSingleNode("//div[contains(@class,'head-my-character__box')]");
            if (login_node != null)
            {
                characterNameLabel.Text = "-";
                serverNameLabel.Text = "-";
                ldst_id = 0;
            }
            else if (chara_node != null)
            {
                if (long.TryParse(chara_node.SelectSingleNode("//ul[contains(@class,'my-menu__colmun')]/li[1]/a[2]").Attributes["href"].Value.Split('/')[3].Trim(), out ldst_id) == false) { ldst_id = 0; }
                characterNameLabel.Text = chara_node.SelectSingleNode("//span[contains(@class,'head-my-character__name')]").InnerText.Trim();
                serverNameLabel.Text = chara_node.SelectSingleNode("//span[contains(@class,'head-my-character__worldstatus')]").InnerText.Trim();
            }

            return Task.Run(() =>
            {
                return ldst_id;
            });
        }

        /// <summary>
        /// リテイナーデータを取得する
        /// </summary>
        /// <returns></returns>
        private Task<List<Retainer>> GetRetainerData()
        {
            ReportProgress(0, "リテイナーデータ構築開始");
            var retainers = new List<Retainer>();

            // subWebBrowserを使ってリテイナーページにアクセス
            ReportProgress(5, "リテイナーページにアクセスしています");
            var retainer_url = FFXIV_DOMAIN + "/lodestone/character/" + _ldst_id + "/retainer/";
            subWebBrowser.Navigate(retainer_url);
            while (subWebBrowser.ReadyState != WebBrowserReadyState.Complete) { Application.DoEvents(); }

            // HtmlDocumentを構築して読み込む
            ReportProgress(10, "HtmlDocumentを構築しています");
            HtmlAgilityPack.HtmlNode.ElementsFlags.Remove("option");
            var doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(subWebBrowser.DocumentText);

            // リテイナー一覧を取得
            ReportProgress(20, "リテイナー一覧を取得しています");
            var retainer_list_nodes = doc.DocumentNode.SelectNodes(@"//div[contains(@class,'retainer--select')]/select/option");
            if (retainer_list_nodes == null) { Debug.WriteLine("retainer list node is  null"); return Task.Run(() => { return retainers; }); }
            foreach (var node in retainer_list_nodes)
            {
                if (node.Attributes["value"].Value == "") continue;

                var name = node.InnerText.Trim();
                var url = FFXIV_DOMAIN + node.Attributes["value"].Value;
                var retainer = new Retainer(name, characterNameLabel.Text, serverNameLabel.Text, url, 0);
                retainers.Add(retainer);
            }

            // 各リテイナーのデータを取得
            for (var i = 0; i < retainers.Count; i++)
            {
                ReportProgress(20 + (i + 1) * 80 / retainers.Count, "リテイナーデータを取得しています (" + (i + 1) + "/" + retainers.Count + ")");
                var url = retainers[i].Url + "baggage/";
                subWebBrowser.Navigate(url);
                while (subWebBrowser.ReadyState != WebBrowserReadyState.Complete) { Application.DoEvents(); }

                doc.LoadHtml(subWebBrowser.DocumentText);

                var last_update_node = doc.DocumentNode.SelectSingleNode(@"//div[contains(@class,'ymd')]/span/script");
                var regex = new Regex(@"ldst_strftime\(([0-9]+), 'YMDHM'\);", RegexOptions.IgnoreCase | RegexOptions.Singleline);
                var last_update = long.Parse(regex.Match(last_update_node.InnerHtml).Groups[1].Value);
                retainers[i].LastUpdate = last_update;
                try
                {
                    var item_nodes = doc.DocumentNode.SelectNodes(@"//tbody[contains(@id,'retainer_baggage_tbody')]/tr");
                    var items = new List<Item>();
                    foreach (var item_node in item_nodes)
                    {
                        var item_name = item_node.SelectSingleNode(@".//div[contains(@class,'item_link')]//a").InnerText;
                        var hq_flag = item_node.SelectSingleNode(@".//div[contains(@class,'item_link')]//img[contains(@class,'ic_item_quality')]") != null ? true : false;
                        var stack_count = int.Parse(item_node.Attributes["data-stack"].Value);
                        items.Add(new Item(item_name, hq_flag, stack_count));
                    }
                    retainers[i].Items = items;
                }
                catch (Exception e) { Debug.WriteLine(e.Message); }
            }

            ReportProgress(100);

            return Task.Run(() =>
            {
                return retainers;
            });
        }

        private void MergeRetainerList(List<Retainer> list)
        {
            // 既存のリストと比較し更新があれば変更
            foreach (var r in list)
            {
                var li = retainer_list.FindIndex(item => (item.Name == r.Name && item.Server == r.Server));
                if (li == -1)
                {
                    // 既存のリストに存在しない場合
                    retainer_list.Add(r);
                }
                else
                {
                    // 既存のリストに存在する場合、更新日時を比較
                    if (r.LastUpdate > retainer_list[li].LastUpdate)
                    {
                        // 更新されていた場合
                        retainer_list[li] = r;
                    }
                }
            }

            // リストボックスデータ更新
            retainerListBox.BeginUpdate();
            retainerListBox.Items.Clear();
            foreach (var r in retainer_list)
            {
                retainerListBox.Items.Add(r.Name + "<" + r.Owner + " (" + r.Server + ")> / " + r.Id);
            }
            retainerListBox.EndUpdate();
        }

        private void mainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // 処理中にフォームを閉じないようにする
            if (isParsing)
            {
                e.Cancel = true;
            }
        }

        #region ListBox全て選択用
        [DllImport("User32.dll", EntryPoint = "SendMessage")]
        private static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        private const int LB_SETSEL = 0x185;
        #endregion

        private bool modify_from_listbox_flag = false;

        private void selectAllCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (selectAllCheckBox.Checked)
            {
                SendMessage(retainerListBox.Handle, LB_SETSEL, 1, -1);
                retainerListBox.SetSelected(0, true);
            }
            else if (!modify_from_listbox_flag)
            {
                retainerListBox.ClearSelected();
            }
            modify_from_listbox_flag = false;
        }

        private void retainerListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (retainerListBox.SelectedItems.Count < retainerListBox.Items.Count)
            {
                modify_from_listbox_flag = true;
                selectAllCheckBox.Checked = false;
            } else if (retainerListBox.SelectedItems.Count == retainerListBox.Items.Count)
            {
                selectAllCheckBox.Checked = true;
            }

            if (retainerListBox.SelectedItems.Count == 0) { exportMessageLabel.Text = "選択中のデータを"; }
            else { exportMessageLabel.Text = "選択中の" + retainerListBox.SelectedItems.Count + "件のデータを"; }
        }

        private void exportButton_Click(object sender, EventArgs e)
        {
            //TODO:データ出力処理
        }
    }
}
