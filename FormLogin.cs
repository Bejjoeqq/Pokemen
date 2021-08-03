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
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private String link;
        private String appVersion;
        private HttpClient client = new HttpClient();
        private bool mouseDown;
        private Point offset;
        private void FormLogin_MouseDown(object sender, MouseEventArgs e)
        {
            offset.X = e.X;
            offset.Y = e.Y;
            mouseDown = true;
        }

        private void FormLogin_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                Point currentScreen = PointToScreen(e.Location);
                Location = new Point(currentScreen.X - offset.X,currentScreen.Y-offset.Y);
            }
        }

        private void FormLogin_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            //link = "http://127.0.0.1:5000/poke/";
            link = "http://bot.bejjox.my.id:8080/poke/";
            this.ActiveControl = label1;
            label2.Hide();
            appVersion = "V1.1";
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private async Task<Account> getAcc(String user, String paswd)
        {
            var response = await client.GetStringAsync(link+"getAccount/"+user.ToLower()+"&"+paswd);
            var hasil = JsonConvert.DeserializeObject<Account>(response);
            return hasil;
        }
        private async Task<String> getVersion()
        {
            var response = await client.GetStringAsync(link+"getVersion");
            var hasil = JsonConvert.DeserializeObject<Version>(response);
            return hasil.result;
        }
        private async void btnLogin_Click(object sender, EventArgs e)
        {
            var a = await getAcc(txtUser.Text, txtPass.Text);
            //var a = await getAcc("aldhiya.rozak@gmail.com","Bejjo123");
            if (a.result==1)
            {
                String b = await getVersion();
                if (b==appVersion)
                {
                    if (a.user_id==0)
                    {
                        RegisForm rg = new RegisForm(a.account_id);
                        rg.ShowDialog();
                        if (rg.getState())
                        {
                            var c = await getAcc(txtUser.Text, txtPass.Text);
                            new LobbyForm(c.account_id, c.user_id, c.name, c.poke_name, c.power, c.hp, c.atk, c.def, c.satk, c.sdef, c.speed, c.floor, c.exp_user, c.exp_poke, c.poke_idx, c.diamond, c.pokecoin, c.pokeball, c.stardust).Show();
                            this.Hide();
                        }
                    }
                    else
                    {
                        new LobbyForm(a.account_id, a.user_id, a.name, a.poke_name, a.power, a.hp, a.atk, a.def, a.satk, a.sdef, a.speed, a.floor, a.exp_user, a.exp_poke, a.poke_idx, a.diamond, a.pokecoin, a.pokeball, a.stardust).Show();
                        this.Hide();
                    }
                }
                else
                {
                    label2.Show();
                    label2.Text = "Update required";
                    System.Diagnostics.Process.Start("https://bejjox.my.id");
                }
            }
            else
            {
                label2.Show();
                label2.Text = "Incorrect email or password";
            }
        }

        private void lblRegis_MouseEnter(object sender, EventArgs e)
        {
            lblRegis.ForeColor = Color.Gainsboro;
        }

        private void lblRegis_MouseLeave(object sender, EventArgs e)
        {
            lblRegis.ForeColor = Color.Firebrick;
        }

        private void lblRegis_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://bejjox.my.id");
        }

        private void txtUser_Enter(object sender, EventArgs e)
        {
            if (txtUser.Text=="Email")
            {
                txtUser.Text = "";
            }
        }

        private void txtUser_Leave(object sender, EventArgs e)
        {
            if (txtUser.Text=="")
            {
                txtUser.Text = "Email";
            }
        }

        private void txtPass_Enter(object sender, EventArgs e)
        {
            if (txtPass.Text=="Password")
            {
                txtPass.Text = "";
                txtPass.PasswordChar = '*';
            }
        }

        private void txtPass_Leave(object sender, EventArgs e)
        {
            if (txtPass.Text=="")
            {
                txtPass.Text = "Password";
                txtPass.PasswordChar = '\0';
            }
        }
    }
}
