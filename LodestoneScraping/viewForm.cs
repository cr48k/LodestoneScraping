using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Data.SQLite;

namespace LodestoneScraping
{
    public partial class viewForm : Form
    {
        public List<Retainer> RetainerList { get; set; }

        public viewForm()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            foreach (var r in RetainerList)
            {
                var content = new RetainerTabPage(r);
                content.Name = "retainer_" + r.Id;
                content.Dock = DockStyle.Fill;

                var tab = new TabPage();
                tab.Text = r.Name;
                tab.Controls.Add(content);

                viewTabControl.TabPages.Add(tab);
            }
            base.OnLoad(e);
        }
    }
}
