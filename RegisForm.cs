using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PokeMen
{
    public partial class RegisForm : Form
    {
        public RegisForm(int accountid)
        {
            InitializeComponent();
            this.accountid = accountid;
        }

        private HttpClient client = new HttpClient();
        private String link;
        private int accountid;
        private bool state;
        private void RegisForm_Load(object sender, EventArgs e)
        {
            //link = "http://127.0.0.1:5000/poke/";
            link = "http://bot.bejjox.my.id:8080/poke/";
            state = false;
        }
        private async Task<bool> setUsername(int ids, String user)
        {
            var response = await client.GetStringAsync(link + "setUsername/"+ids+"&"+user);
            var hasil = JsonConvert.DeserializeObject<Username>(response);
            return hasil.result;
        }
        private async void btnOk_Click(object sender, EventArgs e)
        {
            if (txtUser.Text.Trim()!="")
            {
                if (txtUser.Text.Trim().Length<=8)
                {
                    var a = await setUsername(accountid, txtUser.Text.Trim().ToLower());
                    if (a)
                    {
                        this.Hide();
                        state = true;
                    }
                    else
                    {
                        label2.Text = "Username already used";
                    }
                }
                else
                {
                    label2.Text = "Username too long, max 8 char";
                }
            }
        }
        public bool getState()
        {
            return state;
        }
    }
}
