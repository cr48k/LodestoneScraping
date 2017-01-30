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
    }
}
