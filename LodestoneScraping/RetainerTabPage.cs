using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Data.SQLite;
using System.IO;
using LodestoneScraping.Properties;
using System.Text.RegularExpressions;

namespace LodestoneScraping
{
    public partial class RetainerTabPage : UserControl
    {
        private static readonly DateTime UNIX_EPOCH = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        private DataTable table = new DataTable();

        public string RetainerName { get; set; }
        public string ServerName { get; set; }
        public string OwnerName { get; set; }
        public string RetainerId { get; set; }
        public long LastUpdate { get; set; }
        public long Gil { get; set; }

        public RetainerTabPage()
        {
            InitializeComponent();
        }
        public RetainerTabPage(string id) : this()
        {
            RetainerId = id;
        }
        public RetainerTabPage(Retainer r) : this()
        {
            RetainerId = r.Id;
            RetainerName = r.Name;
            ServerName = r.Server;
            OwnerName = r.Owner;
            LastUpdate = r.LastUpdate;
            Gil = r.Gil;
        }
        protected override void OnLoad(EventArgs e)
        {
            itemDataGridView.DataSource = table;

            retainerGilLabel.Text = Gil.ToString("N0");
            retainerLastUpdateLabel.Text = UNIX_EPOCH.AddSeconds(LastUpdate).ToString("yyyy/MM/dd HH:mm:ss");
            retainerNameLabel.Text = RetainerName;
            retainerServerLabel.Text = ServerName;
            retainerOwnerLabel.Text = OwnerName;
            retainerIdLabel.Text = RetainerId;

            base.OnLoad(e);
        }

        private void RetainerTabPage_Load(object sender, EventArgs e)
        {
            using (var cn = new SQLiteConnection("Data Source=lds.db"))
            using (var adp = new SQLiteDataAdapter("SELECT item_name AS アイテム名, item_hq AS HQ, item_qty AS 所持数 FROM RetainerItemView WHERE retainer_id = '" + RetainerId + "'", cn))
            {
                adp.Fill(table);
            }
        }

        private void exportButton_Click(object sender, EventArgs e)
        {
            //データ出力処理 (CSV)
            string path = "";

            var sfd = new SaveFileDialog();
            var dir = Settings.Default.DirectoryPath;
            sfd.FileName = "lds_export_" + RetainerName + "_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".csv";
            sfd.InitialDirectory = (dir == "" ? Application.StartupPath : dir);
            sfd.Filter = "CSVファイル(*.csv)|*.csv|すべてのファイル(*.*)|*.*";
            sfd.RestoreDirectory = true;
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                path = sfd.FileName;
                Settings.Default.DirectoryPath = Path.GetDirectoryName(path);
                Settings.Default.Save();
            }
            else
            {
                return;
            }

            string data = "アイテム名,所持数,リテイナー名,キャラクター名\r\n";
            for (int i = 0; i < itemDataGridView.Rows.Count; i++)
            {
                var c = itemDataGridView.Rows[i].Cells;
                var item_name = c[0].Value.ToString();
                var item_hq = (c[1].Value.ToString() == "1" ? "HQ" : "");
                var item_qty = c[2].Value.ToString();
                data += item_name + item_hq + "," + item_qty + "," + RetainerName + "," + OwnerName + "\r\n";
            }

            using (var sw = new StreamWriter(path, false, Encoding.GetEncoding("shift_jis")))
            {
                sw.Write(data);
            }

            MessageBox.Show(path + " にエクスポートしました。", "エクスポート完了", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
