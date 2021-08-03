using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PokeMen
{
    public partial class LobbyForm : Form
    {
        public LobbyForm(int accountid,int userid, String username, String pokename, int power, int hp, int atk, int def, int satk, int sdef, int speed, int floor, int expuser, int exppoke, int pokeidx, int diamond, int pokecoin, int pokeball, int stardust)
        {
            InitializeComponent();
            hero = new Player(username,power,hp,atk,def,satk,sdef,speed,pokeidx);
            this.username = username;
            this.power = power.ToString();
            this.expuser = expuser+3;
            this.pokecoin = pokecoin;
            this.pokeball = pokeball;
            this.stardust = stardust;
            this.diamond = diamond;
            this.accountid = accountid;
            this.userid = userid;
            this.floor = floor;
        }


        private HttpClient client = new HttpClient();
        private static Random rnd = new Random();
        private bool mouseDown;
        private Point offset;
        private int stateChat;
        private bool statePnlChat;
        private int stateBattle;
        private Player hero;
        private Player enemy;
        private String link;

        private int accountid;
        private int userid;
        private String username;
        private String power;
        private int expuser;
        private int pokecoin;
        private int pokeball;
        private int stardust;
        private int diamond;
        private int floor;
        private void loadChar()
        {
            int lvl = 0;
            lblUsername.Text = username;
            lblCP.Text = power;
            lblPokecoin.Text = pokecoin.ToString();
            lblPokeball.Text = pokeball.ToString();
            lblDiamond.Text = diamond.ToString();
            lblStardust.Text = stardust.ToString()+"/100";


            for (int i = 1; i <= 5; i++)
            {
                if (expuser>=i * 3)
                {
                    lvl += 1;
                    setLvlEx(lvl, expuser - (i * 3), 3);
                }
            }
            for (int i = 3; i <= 7; i++)
            {
                if (expuser >= i * 6)
                {
                    lvl += 1;
                    setLvlEx(lvl, expuser - (i * 6), 6);
                }
            }
            for (int i = 4; i <= 8; i++)
            {
                if (expuser >= i * 12)
                {
                    lvl += 1;
                    setLvlEx(lvl, expuser - (i * 12), 12);
                }
            }
            for (int i = 4; i <= 8; i++)
            {
                if (expuser >= i * 27)
                {
                    lvl += 1;
                    setLvlEx(lvl, expuser - (i * 27), 27);
                }
            }
            for (int i = 3; i <= 7; i++)
            {
                if (expuser >= i * 81)
                {
                    lvl += 1;
                    setLvlEx(lvl, expuser - (i * 81), 81);
                }
            }
        }
        private int getLvl(int xp)
        {
            int lvl = 0;
            for (int i = 1; i <= 5; i++)
            {
                if (xp >= i * 3)
                {
                    lvl += 1;
                }
            }
            for (int i = 3; i <= 7; i++)
            {
                if (xp >= i * 6)
                {
                    lvl += 1;
                }
            }
            for (int i = 4; i <= 8; i++)
            {
                if (xp >= i * 12)
                {
                    lvl += 1;
                }
            }
            for (int i = 4; i <= 8; i++)
            {
                if (xp >= i * 27)
                {
                    lvl += 1;
                }
            }
            for (int i = 3; i <= 7; i++)
            {
                if (xp >= i * 81)
                {
                    lvl += 1;
                }
            }
            return lvl;
        }
        private void setLvlEx(int lvl, int exp,int max)
        {
            lblLevel.Text = lvl.ToString();
            lblExp.Text = "(" + exp.ToString() + "/" + max + ")";
            pnlFront.Width = 30 + (int)(150 * exp/max);
        }
        private void clearPanel()
        {
            statePnlChat = false;
            pnlGacha.SendToBack();
            pnlList.SendToBack();
            pnlChat.SendToBack();
            pnlShop.SendToBack();
            pnlRank.SendToBack();
        }
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            offset.X = e.X;
            offset.Y = e.Y;
            mouseDown = true;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                Point currentScreen = PointToScreen(e.Location);
                Location = new Point(currentScreen.X - offset.X, currentScreen.Y - offset.Y);
            }
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            pictureBox1.Image = Properties.Resources.pikachu_1;
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            pictureBox1.Image = Properties.Resources.pikachu;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            new BoxForm().ShowDialog();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            new BoxForm().ShowDialog();
        }
        private void showAtkHero(double atk)
        {
            lblAtkHero.Text = String.Format("{0:0.00}", atk)+" Crit!";

            lblAtkHero.BringToFront();
            pctAtkHero.Show();

            pctEnemy.Location = new Point(652, 308);
            Thread.Sleep(2);
            pctEnemy.Location = new Point(672, 308);
            Thread.Sleep(2);
            pctEnemy.Location = new Point(662, 308);
        }
        private void showDefHero(double def)
        {
            lblDefHero.Text = String.Format("{0:0.00}", def)+ " Block!";

            lblDefHero.BringToFront();
            pctAtkEnemy.Show();

            pctHero.Location = new Point(98, 308);
            Thread.Sleep(2);
            pctHero.Location = new Point(118, 308);
            Thread.Sleep(2);
            pctHero.Location = new Point(108, 308);
        }
        private void showAtkEnemy(double atk)
        {
            lblAtkEnemy.Text = String.Format("{0:0.00}", atk)+ " Crit!";

            lblAtkEnemy.BringToFront();
            pctAtkEnemy.Show();

            pctHero.Location = new Point(98, 308);
            Thread.Sleep(2);
            pctHero.Location = new Point(118, 308);
            Thread.Sleep(2);
            pctHero.Location = new Point(108, 308);
        }
        private void showDefEnemy(double def)
        {
            lblDefEnemy.Text = String.Format("{0:0.00}", def)+ " Block!";

            lblDefEnemy.BringToFront();
            pctAtkHero.Show();

            pctEnemy.Location = new Point(652, 308);
            Thread.Sleep(2);
            pctEnemy.Location = new Point(672, 308);
            Thread.Sleep(2);
            pctEnemy.Location = new Point(662, 308);
        }
        private void clearShowAtk()
        {
            lblAtkEnemy.SendToBack();
            lblAtkHero.SendToBack();

            lblDefEnemy.SendToBack();
            lblDefHero.SendToBack();

            pctAtkEnemy.Hide();
            pctAtkHero.Hide();
        }
        private async Task setAtt(int n)
        {
            await client.GetStringAsync(link + "setWin/" + userid + "&" + n + "&" + n + "&" + n + "&" + n + "&" + n + "&" + n);
        }
        private async Task setWin()
        {
            await client.GetStringAsync(link + "setWin/" + userid+"&"+enemy.getPokeid());
        }
        private async Task<List<Enemy>> getEnemy()
        {
            var response = await client.GetStringAsync(link + "getEnemy/" + userid+"&"+floor);
            var hasil = JsonConvert.DeserializeObject<EnemyCollection>(response);
            return hasil.result;
        }
        private async Task setFloor()
        {
            await client.GetStringAsync(link + "setFloor/" + userid);
        }
        private async Task setExp(int n)
        {
            await client.GetStringAsync(link + "setExp/" + userid + "&" + n);
        }
        private async Task setDiamond(int n)
        {
            await client.GetStringAsync(link + "setDiamond/" + userid + "&" + n);
        }
        private async Task setPokeball(int n)
        {
            await client.GetStringAsync(link + "setPokeball/" + userid + "&" + n);
        }
        private async Task setPokecoin(int n)
        {
            await client.GetStringAsync(link + "setPokecoin/" + userid + "&" + n);
        }
        private async Task setStardust(int n)
        {
            await client.GetStringAsync(link + "setStardust/" + userid + "&" + n);
        }
        private async Task<Account> getUpdate()
        {
            var response = await client.GetStringAsync(link + "getUpdate/" + accountid);
            var hasil = JsonConvert.DeserializeObject<Account>(response);
            return hasil;
        }
        private async Task<List<Chat>> getChat()
        {
            var response = await client.GetStringAsync(link+"getChat");
            var hasil = JsonConvert.DeserializeObject<ChatCollection>(response);
            return hasil.result;
        }
        private async Task<List<Rank>> getRank()
        {
            var response = await client.GetStringAsync(link+"getRank");
            var hasil = JsonConvert.DeserializeObject<RankCollection>(response);
            return hasil.result;
        }
        private async Task setChat()
        {
            await client.GetStringAsync(link + "setChat/"+accountid+"&"+txtChat.Text);
        }
        private void LobbyForm_Load(object sender, EventArgs e)
        {
            //link = "http://127.0.0.1:5000/poke/";
            link = "http://bot.bejjox.my.id:8080/poke/";
            pctGacha.Parent = pctBackground;
            pctGacha.Location = new Point(500, 450);

            pctDungeon.Parent = pctBackground;
            pctDungeon.Location = new Point(780, 150);

            pctShop.Parent = pctBackground;
            pctShop.Location = new Point(820,385);

            pctLeader.Parent = pctBackground;
            pctLeader.Location = new Point(530, 130);

            pctArena.Parent = pctBackground;
            pctArena.Location = new Point(350, 110);

            pctHero.Parent = pctBattle;
            pctHero.Location = new Point(108, 308);

            pctEnemy.Parent = pctBattle;
            pctEnemy.Location = new Point(662, 308);

            pctAtkEnemy.Parent = pctBattle;
            pctAtkEnemy.Location = new Point(240, 339);
            pctAtkEnemy.Hide();

            pctAtkHero.Parent = pctBattle;
            pctAtkHero.Location = new Point(582, 339);
            pctAtkHero.Hide();


            loadChar();
            toolTipMessage();
            loadChat();
            lastChat();
            statePnlChat = false;
            timer1.Start();

        }
        private void toolTipMessage()
        {
            toolTip1.SetToolTip(pictureBox43, "Stardust will be filled every minute");
            toolTip1.SetToolTip(lblStardust, "Stardust will be filled every minute");

            toolTip1.SetToolTip(pictureBox42, "Pokeballs");
            toolTip1.SetToolTip(lblPokeball, "Pokeballs");

            toolTip1.SetToolTip(pictureBox41, "Pokecoins");
            toolTip1.SetToolTip(lblPokecoin, "Pokecoins");

            toolTip1.SetToolTip(pictureBox44, "Diamonds");
            toolTip1.SetToolTip(lblDiamond, "Diamonds");
            toolTip1.SetToolTip(pictureBox48, "Top up");

            toolTip1.SetToolTip(pictureBox3, "Combat power");
            toolTip1.SetToolTip(lblCP, "Combat power");

            toolTip1.SetToolTip(pictureBox1, "Close");

            toolTip1.SetToolTip(lblExp, "Experience");
            toolTip1.SetToolTip(lblLevel, "Level");
            toolTip1.SetToolTip(pnlFront, "Progress bar");
            toolTip1.SetToolTip(pnlBack, "Progress bar");

            toolTip1.SetToolTip(pictureBox7, "Library");

            toolTip1.SetToolTip(pctChat, "Chat");

            toolTip1.SetToolTip(pctProfile, "Profile info");
        }
        private void pctGacha_MouseEnter(object sender, EventArgs e)
        {
            pctGacha.Image = Properties.Resources.open_pokeball;
        }

        private void pctGacha_MouseLeave(object sender, EventArgs e)
        {
            pctGacha.Image = Properties.Resources.pokeball;
        }

        private void pctGacha_Click(object sender, EventArgs e)
        {
            clearPanel();
            pnlGacha.BringToFront();
        }

        private void pctDungeon_Click(object sender, EventArgs e)
        {
            clearPanel();
            pnlBattle.BringToFront();
            refreshEnemy();
        }

        private void pctDungeon_MouseEnter(object sender, EventArgs e)
        {
            pctDungeon.Image = Properties.Resources.blue_team;
        }

        private void pctDungeon_MouseLeave(object sender, EventArgs e)
        {
            pctDungeon.Image = Properties.Resources.battle;
        }

        private void pctProfile_Click(object sender, EventArgs e)
        {
            clearPanel();
        }

        private void pnlGacha_Paint(object sender, PaintEventArgs e)
        {
            Graphics v = e.Graphics;
            DrawRoundRect(v, Pens.Firebrick, e.ClipRectangle.Left, e.ClipRectangle.Top, e.ClipRectangle.Width - 1, e.ClipRectangle.Height - 1, 10);
            base.OnPaint(e);
        }
        private void DrawRoundRect(Graphics g, Pen p, float X, float Y, float width, float height, float radius)
        {
            GraphicsPath gp = new GraphicsPath();
            gp.AddLine(X + radius, Y, X + width - (radius * 2), Y);
            gp.AddArc(X + width - (radius * 2), Y, radius * 2, radius * 2, 270, 90);
            gp.AddLine(X + width, Y + radius, X + width, Y + height - (radius * 2));
            gp.AddArc(X + width - (radius * 2), Y + height - (radius * 2), radius * 2, radius * 2, 0, 90);
            gp.AddLine(X + width - (radius * 2), Y + height, X + radius, Y + height);
            gp.AddArc(X, Y + height - (radius * 2), radius * 2, radius * 2, 90, 90);
            gp.AddLine(X, Y + height - (radius * 2), X, Y + radius);
            gp.AddArc(X, Y, radius * 2, radius * 2, 180, 90);
            gp.CloseFigure();
            g.DrawPath(p, gp);
            gp.Dispose();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            clearPanel();
            pnlList.BringToFront();
        }

        private void pnlList_Click(object sender, EventArgs e)
        {
            pnlList.SendToBack();
        }

        private void sideClear(object sender, EventArgs e)
        {
            clearPanel();
        }

        private void pctChat_Click(object sender, EventArgs e)
        {
            clearPanel();
            pnlChat.BringToFront();
            loadChat();
            statePnlChat = true;
        }
        private async void loadChat()
        {
            var a = await getChat();
            lstChat.Items.Clear();
            foreach (var item in a)
            {
                String msg = item.name + " : " + item.message;
                lstChat.Items.Insert(0,msg);
                lastChat();
            }
        }
        private void lastChat()
        {
            lstChat.TopIndex = lstChat.Items.Count - 1;
        }
        private async void sendChat()
        {
            if (txtChat.Text.Trim() == "")
            {
                txtChat.Text = "";
            }
            else if (txtChat.TextLength < 25)
            {
                String message = username + " : " + txtChat.Text.Trim();
                lstChat.Items.Add(message);
                await setChat();
                txtChat.Text = "";
                stateChat = 5;
                lastChat();
            }
            else
            {
                txtChat.Text = "Message too long";
            }
        }
        private void btnSend_Click(object sender, EventArgs e)
        {
            if (stateChat==0)
            {
                sendChat();
            }
            else
            {
                txtChat.Text = "Message too fast";
            }
        }

        private void txtChat_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (stateChat == 0)
                {
                    sendChat();
                }
                else
                {
                    txtChat.Text = "Message too fast";
                }
            }
            if (e.KeyCode == Keys.Escape)
            {
                clearPanel();
            }
        }
        private async void getStardust()
        {
            var a = await getUpdate();
            stardust = a.stardust;
            lblStardust.Text = stardust.ToString() + "/100";
        }
        private async void getDiamond()
        {
            var a = await getUpdate();
            diamond = a.diamond;
            lblDiamond.Text = diamond.ToString();
        }
        private async void getPokecoin()
        {
            var a = await getUpdate();
            pokecoin = a.pokecoin;
            lblPokecoin.Text = pokecoin.ToString();
        }
        private async void getPokeball()
        {
            var a = await getUpdate();
            pokeball = a.pokeball;
            lblPokeball.Text = pokeball.ToString();
        }
        private async void getFloor()
        {
            var a = await getUpdate();
            floor = a.floor;
        }
        private async void getExp()
        {
            var a = await getUpdate();
            expuser = a.exp_user;
            loadChar();
        }
        private async void getHero()
        {
            var a = await getUpdate();
            hero = new Player(a.name, a.power, a.hp, a.atk, a.def, a.satk, a.sdef, a.speed, a.poke_idx);
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            getStardust();

            if (stateChat>0)
            {
                stateChat -= 1;
            }

            if (statePnlChat)
            {
                loadChat();
            }
        }

        private void pictureBox45_Click(object sender, EventArgs e)
        {
            clearPanel();
            pnlShop.BringToFront();
        }

        private void pctShop_MouseEnter(object sender, EventArgs e)
        {
            pctShop.Image = Properties.Resources.pokebag1;
        }

        private void pctShop_MouseLeave(object sender, EventArgs e)
        {
            pctShop.Image = Properties.Resources.pokebag;
        }

        private async void pictureBox45_Click_1(object sender, EventArgs e)
        {
            clearPanel();
            pnlRank.BringToFront();
            lstVRank.Items.Clear();
            var a = await getRank();
            int x = 1;
            foreach (var item in a)
            {
                String[] msg = { x.ToString(), item.name, item.power.ToString(), getLvl(item.exp+3).ToString()};
                var listViewItem = new ListViewItem(msg);
                lstVRank.Items.Add(listViewItem);
                x++;
            }
        }

        private void pictureBox45_MouseEnter(object sender, EventArgs e)
        {
            pctLeader.Image = Properties.Resources.crown1;
        }

        private void pictureBox45_MouseLeave(object sender, EventArgs e)
        {
            pctLeader.Image = Properties.Resources.crown;
        }

        private void pctArena_Click(object sender, EventArgs e)
        {
            clearPanel();
        }

        private void pctArena_MouseEnter(object sender, EventArgs e)
        {
            pctArena.Image = Properties.Resources.fight1;
        }

        private void pctArena_MouseLeave(object sender, EventArgs e)
        {
            pctArena.Image = Properties.Resources.fight;
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox48_Click(object sender, EventArgs e)
        {
            clearPanel();
            System.Diagnostics.Process.Start("https://bejjox.my.id");
        }

        private async void btnBuyMegaCoin_Click(object sender, EventArgs e)
        {
            getDiamond();
            if (diamond >= 10)
            {
                clearPanel();
                await setPokecoin(10000);
                await setDiamond(-10);
                getPokecoin();
                getDiamond();
            }
        }

        private async void btnBuySuperCoin_Click_1(object sender, EventArgs e)
        {
            getDiamond();
            if (diamond >= 90)
            {
                clearPanel();
                await setPokecoin(100000);
                await setDiamond(-90);
                getPokecoin();
                getDiamond();
            }
        }

        private async void btnBuyStardust_Click(object sender, EventArgs e)
        {
            getDiamond();
            if (diamond>=5)
            {
                clearPanel();
                await setStardust(100);
                await setDiamond(-5);
                getStardust();
                getDiamond();
            }
        }

        private async void btnBuyPokeball_Click(object sender, EventArgs e)
        {
            getDiamond();
            if (diamond >= 30)
            {
                clearPanel();
                await setPokeball(3);
                await setDiamond(-30);
                getPokeball();
                getDiamond();
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            clearPanel();
            pnlBattle.SendToBack();
        }

        private async void btnAtk_Click(object sender, EventArgs e)
        {
            getStardust();
            if (stardust>=10)
            {
                clearPanel();
                btnGiveup.BringToFront();
                pnlAtk.SendToBack();
                await setStardust(-10);
                battle.Start();
            }
            else
            {
                lblEnemyInfo.Text = "Need more stardust";
            }
        }

        private void btnGiveup_Click(object sender, EventArgs e)
        {
            clearPanel();
            pnlBattle.SendToBack();
            btnGiveup.SendToBack();
            pnlAtk.BringToFront();
            pbrEnemy.Value = 0;
            pbrHero.Value = 0;

            clearShowAtk();

            battle.Stop();
        }

        private double speedHero;
        private double speedEnemy;
        private int heroCritCount;
        private int enemyCritCount;
        private int heroAbsdCount;
        private int enemyAbsdCount;
        private int heroHitCount;
        private int enemyHitCount;
        //private int heroTotalDmg;
        //private int enemyTotalDmg;
        private void clearResult()
        {
            clearPanel();
            btnGiveup.SendToBack();
            battle.Stop();
            clearShowAtk();

            pnlResult.BringToFront();
            String result = username + "\nHit : " + heroHitCount + "\nCrit : " + heroCritCount + "\nBlock : " + heroAbsdCount;
            lblResultHero.Text = result;

            String result1 = enemy.getName()+"\nHit : " + enemyHitCount + "\nCrit : " + enemyCritCount + "\nBlock : " + enemyAbsdCount;
            lblResultEnemy.Text = result1;
        }
        private async void battle_Tick(object sender, EventArgs e)
        {
            if (stateBattle>50)
            {
                clearShowAtk();
                stateBattle = 0;
            }
            stateBattle += 1;

            if (enemy.getHP() <= 0)
            {

                clearResult();
                pbrEnemy.Value = 0;
                lblWinLose.Text = "You Win";
                await setWin();

                getFloor();
                var a = await getEnemy();
                if (!a.Any())
                {
                    await setFloor();
                    getFloor();
                    lblNextFloor.Text = "Floor up";
                    await setPokeball(2);
                    await setPokecoin(5000);
                    await setDiamond(1);
                    getDiamond();
                    getPokeball();
                    getPokecoin();

                    await setExp(5);
                    getExp();

                }
                else
                {
                    lblNextFloor.Text = "Floor " + floor;
                    await setPokecoin(1000);
                    getPokecoin();

                    await setExp(5);
                    getExp();
                }
            }
            else
            {
                pbrEnemy.Value = (int)((enemy.getHP() * 100) / (enemy.getHPBar()));
            }
            if (hero.getHP() <= 0)
            {
                pbrHero.Value = 0;
                lblWinLose.Text = "You Lose";
                clearResult();
            }
            else
            {
                pbrHero.Value = (int)((hero.getHP() * 100) / (hero.getHPBar()));
            }

            int critHero = hero.getChanceCrit();
            int critEnemy = enemy.getChanceCrit();

            int absdHero = hero.getChanceAbsd();
            int absdEnemy = enemy.getChanceAbsd();

            //additional speed rate
            speedHero += (1 + ((double)hero.getSpeed() / (double)100));
            speedEnemy += (1 + ((double)enemy.getSpeed() / (double)100));

            //atk zone
            if (speedHero > 10)
            {
                heroHitCount += 1;
                double atkx = (hero.getAtk() * critHero);
                double defx = (enemy.getDef() * absdEnemy);
                double heroDmg = atkx / defx;
                enemy.attacked(heroDmg);
                speedHero /= 10;
                if (critHero == 3)
                {
                    heroCritCount += 1;
                    showAtkHero(heroDmg);
                }
                if (absdEnemy == 3)
                {
                    enemyAbsdCount += 1;
                    showDefEnemy(heroDmg);
                }
            }
            if (speedEnemy > 10)
            {
                enemyHitCount += 1;
                double atkx = (enemy.getAtk() * critEnemy);
                double defx = (hero.getDef() * absdHero);
                double enemyDmg = atkx / defx;
                hero.attacked(enemyDmg);
                speedEnemy /= 10;
                if (critEnemy == 3)
                {
                    enemyCritCount += 1;
                    showAtkEnemy(enemyDmg);
                }
                if (absdHero == 3)
                {
                    heroAbsdCount += 1;
                    showDefHero(enemyDmg);
                }
            }
            //Console.WriteLine(hero.getHP());
            //Console.WriteLine(enemy.getHP());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            clearPanel();
            pnlBattle.SendToBack();
            btnGiveup.SendToBack();
            pnlAtk.BringToFront();
            pbrEnemy.Value = 0;
            pbrHero.Value = 0;
            pnlResult.SendToBack();
        }

        private void lstChat_MouseDown(object sender, MouseEventArgs e)
        {
            statePnlChat = false;
        }

        private void lstChat_MouseUp(object sender, MouseEventArgs e)
        {
            statePnlChat = true;
        }

        private void pnlChat_Scroll(object sender, ScrollEventArgs e)
        {
        }

        private void lstVRank_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            e.Graphics.FillRectangle(Brushes.Firebrick, e.Bounds);
            e.DrawText();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            refreshEnemy();
        }
        private async void refreshEnemy()
        {
            getFloor();
            getHero();
            var a = await getEnemy();
            var b = a[rnd.Next(a.Count)];
            enemy = new Player(b.name, b.power, b.hp, b.atk, b.def, b.satk, b.sdef, b.speed, b.poke_id);

            String msg = "Name : " + b.name + "\nPower : " + b.power + "\nHP : " + b.hp + "\nSpatk : " + b.satk + "\nSpdef : " + b.sdef + "\nSpeed : " + b.speed;
            lblEnemyInfo.Text = msg;
            pctEnemy.Load(b.img);
            lblFloor.Text = "Floor "+floor.ToString();
        }
    }
}
