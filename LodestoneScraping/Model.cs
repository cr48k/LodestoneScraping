using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Text.RegularExpressions;

namespace LodestoneScraping
{
    public class Retainer
    {
        private string id, name, owner, server, url;
        private long last_update, gil;
        private List<Item> items;

        /// <summary>
        /// リテイナー名
        /// </summary>
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        /// <summary>
        /// リテイナー所有キャラクター名
        /// </summary>
        public string Owner
        {
            get { return owner; }
            set { owner = value; }
        }
        /// <summary>
        /// リテイナー所有キャラクター所属サーバー名
        /// </summary>
        public string Server
        {
            get { return server; }
            set { server = value; }
        }
        /// <summary>
        /// リテイナーページURL
        /// </summary>
        public string Url
        {
            get { return url; }
            set
            {
                url = value;
                var regex = new Regex(@"http://jp.finalfantasyxiv.com/lodestone/character/\d+/retainer/(\w+)/", RegexOptions.IgnoreCase | RegexOptions.Singleline);
                var match = regex.Match(url).Groups[1].Value;
                id = match;
            }
        }
        /// <summary>
        /// リテイナーデータ最終更新日時
        /// </summary>
        public long LastUpdate
        {
            get { return last_update; }
            set { last_update = value; }
        }
        /// <summary>
        /// リテイナー所持アイテムリスト
        /// </summary>
        public List<Item> Items
        {
            get { return items; }
            set { items = value; }
        }
        /// <summary>
        /// 所持ギル
        /// </summary>
        public long Gil
        {
            get { return gil; }
            set { gil = value; }
        }
        /// <summary>
        /// リテイナーID
        /// </summary>
        public string Id
        {
            get { return id; }
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="name">リテイナー名</param>
        /// <param name="owner">リテイナー所有キャラクター名</param>
        /// <param name="server">リテイナー所有キャラクター所属サーバー名</param>
        /// <param name="url">リテイナーページURL</param>
        /// <param name="last_update">リテイナーデータ最終更新日時</param>
        public Retainer(string name, string owner, string server, string url, long last_update)
        {
            Name = name;
            Owner = owner;
            Server = server;
            Url = url;
            LastUpdate = last_update;
            Items = new List<Item>();
            Gil = 0;
        }
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="name">リテイナー名</param>
        /// <param name="owner">リテイナー所有キャラクター名</param>
        /// <param name="server">リテイナー所有キャラクター所属サーバー名</param>
        /// <param name="url">リテイナーページURL</param>
        public Retainer(string name, string owner, string server, string url) : this(name, owner, server, url, 0) { }
    }

    public class Item
    {
        private string name;
        private bool hq;
        private int quantity;

        /// <summary>
        /// アイテム名
        /// </summary>
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        /// <summary>
        /// HQフラグ
        /// </summary>
        public bool Hq
        {
            get { return hq; }
            set { hq = value; }
        }
        /// <summary>
        /// 数量
        /// </summary>
        public int Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="name">アイテム名</param>
        /// <param name="hq">HQフラグ</param>
        /// <param name="qty">数量</param>
        public Item(string name, bool hq, int qty)
        {
            Name = name;
            Hq = hq;
            Quantity = qty;
        }
    }
}
