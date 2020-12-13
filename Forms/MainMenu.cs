using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using DiscordRPC;
using DiscordRPC.Logging;
using System.Net;

namespace HLSP_Launcher_for_yandi505
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();

            pictureBox1.Focus();

            client = new DiscordRpcClient("734435821310050446");

            client.OnReady += (sender, e) =>
            {
                Console.WriteLine("Received Ready from user {0}", e.User.Username);
            };

            client.Logger = new ConsoleLogger() { Level = LogLevel.Warning };

            client.OnPresenceUpdate += (sender, e) =>
            {
                Console.WriteLine("Received Update! {0}", e.Presence);
            };

            client.Initialize();

            client.SetPresence(new RichPresence()
            {
                Details = "discord.gg/E5kg4qV",
                State = "Находится в лаунчере",
                Timestamps = Timestamps.Now,
                Assets = new Assets()
                {
                    LargeImageKey = "image_large",
                    LargeImageText = "YouTube: Уголок Спидраннера",
                    SmallImageKey = "image_small"
                }
            });

            WebClient webClient = new WebClient();

            try
            {
                if (!webClient.DownloadString("https://raw.githubusercontent.com/ScriptedSnark/HLSP-Launcher-for-yandi505/master/update_version.txt").Contains("1.0.0.0"))
                {
                    if (MessageBox.Show("Доступно новое обновление HLSP. Желаете ли вы установить самую последнюю версию?", "HLSP", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        using (var client = new WebClient())
                        {
                            Process.Start("Updater.exe");
                            Application.Exit();
                        }
                }
            }
            catch
            {

            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Плавность запуска
            this.Opacity = 0;
            FadeIn(this, 20);
        }

        public DiscordRpcClient client;

        protected override void WndProc(ref Message m) // Этот код делает возможность передвижения формы без окна
        {
            if (m.Msg == 0x84)
            {
                base.WndProc(ref m);
                if ((int)m.Result == 0x1)
                    m.Result = (IntPtr)0x2;
                return;
            }

            base.WndProc(ref m);
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            pictureBox1.Focus();

            DialogResult result = MessageBox.Show(
        "Внимание! При нажатии на кнопку Да, у вас откроется браузер. Согласны ли вы перейти по ссылке?", 
        "HLSP", 
        MessageBoxButtons.YesNo, 
        MessageBoxIcon.Warning, 
        MessageBoxDefaultButton.Button1);
         
    if (result == DialogResult.Yes)
        Process.Start("https://discord.gg/E5kg4qV");
        }

        private void Button5_MouseEnter(object sender, EventArgs e)
        {
            button5.UseVisualStyleBackColor = false;
            button5.FlatAppearance.MouseOverBackColor = Color.FromArgb(25, Color.Blue);
        }

        private void Button5_MouseLeave(object sender, EventArgs e)
        {
            button5.UseVisualStyleBackColor = true;
            button5.FlatAppearance.MouseOverBackColor = Color.FromArgb(100, Color.Transparent);
        }

        async private void Button2_Click(object sender, EventArgs e)
        {
            pictureBox1.Focus();
            CFGEditor CE = (CFGEditor)Application.OpenForms["CFGEditor"];
            if (CE == null) // optimizator activated, если форма не была создана, то давай уже создавайся
            {
                FadeOut(this, 2);
                CFGEditor CFGEdit = new CFGEditor(); // Создание нового экземпляра формы
                CFGEdit.Show(); // Отображаю форму
                CFGEdit.Opacity = 0.0;
                CFGEdit.Location = this.Location;
                await Task.Delay(50);
                FadeIn(CFGEdit, 2);
                await Task.Delay(50);
                Hide();
            }
            else
            {
                CE.Activate(); // АГА ПОПАВСЯ, ТЫ ДУМАЛ МНЕ ТУТ ОПЕРАТИВУ НЕМНОГО ЗАНЯТЬ?
                CE.Location = this.Location;
                await Task.Delay(50);
                FadeIn(CE, 2);
                await Task.Delay(50);
                Hide();
            }
        }

        private void Button2_MouseEnter(object sender, EventArgs e)
        {
            button2.UseVisualStyleBackColor = false;
            button2.FlatAppearance.MouseOverBackColor = Color.FromArgb(10, Color.White);
        }

        private void Button2_MouseLeave(object sender, EventArgs e)
        {
            button2.UseVisualStyleBackColor = true;
            button2.FlatAppearance.MouseOverBackColor = Color.FromArgb(100, Color.Transparent);
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            pictureBox1.Focus();

            DialogResult result = MessageBox.Show(
"Внимание! При нажатии на кнопку Да, у вас откроется браузер. Согласны ли вы перейти по ссылке?",
"HLSP",
MessageBoxButtons.YesNo,
MessageBoxIcon.Warning,
MessageBoxDefaultButton.Button1);

            if (result == DialogResult.Yes)
            Process.Start("https://www.youtube.com/channel/UCyfrmhORgydjd2cHFwB7YVw");
        }

        private void Button6_MouseEnter(object sender, EventArgs e)
        {
            button6.UseVisualStyleBackColor = false;
            button6.FlatAppearance.MouseOverBackColor = Color.FromArgb(25, Color.Red);
        }

        private void Button6_MouseLeave(object sender, EventArgs e)
        {
            button6.UseVisualStyleBackColor = true;
            button6.FlatAppearance.MouseOverBackColor = Color.FromArgb(100, Color.Transparent);
        }
        async private void Button1_Click(object sender, EventArgs e)
        {
            GameSelection GS = (GameSelection)Application.OpenForms["GameSelection"];
            if (GS == null) // optimizator activated, если форма не была создана, то давай уже создавайся
            {
                FadeOut(this, 2);
                GameSelection GameSelection = new GameSelection(); // Создание нового экземпляра формы
                GameSelection.Show(); // Отображаю форму
                GameSelection.Opacity = 0.0;
                GameSelection.Location = this.Location;
                await Task.Delay(50);
                FadeIn(GameSelection, 2);
                Hide();
            }
            else
            {
                GS.Activate(); // АГА ПОПАВСЯ, ТЫ ДУМАЛ МНЕ ТУТ ОПЕРАТИВУ НЕМНОГО ЗАНЯТЬ?
                GameSelection GameSelection = new GameSelection();
                GameSelection.Opacity = 0.0;
                GameSelection.Location = this.Location;
                await Task.Delay(50);
                FadeIn(GameSelection, 2);
                Hide();
            }

            pictureBox1.Focus();
        }

        private void Button1_MouseEnter(object sender, EventArgs e)
        {
            button1.UseVisualStyleBackColor = false;
            button1.FlatAppearance.MouseOverBackColor = Color.FromArgb(10, Color.White);
        }

        private void Button1_MouseLeave(object sender, EventArgs e)
        {
            button1.UseVisualStyleBackColor = true;
            button1.FlatAppearance.MouseOverBackColor = Color.FromArgb(100, Color.Transparent);
        }

        private void Button4_Click(object sender, EventArgs e)
        {

        }

        private void Button8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Button8_MouseEnter(object sender, EventArgs e)
        {
            button8.UseVisualStyleBackColor = false;
            button8.FlatAppearance.MouseOverBackColor = Color.FromArgb(25, Color.Red);
        }

        private void Button8_MouseLeave(object sender, EventArgs e)
        {
            button8.UseVisualStyleBackColor = true;
            button8.FlatAppearance.MouseOverBackColor = Color.FromArgb(100, Color.Transparent);

        }
        async private void Button7_Click(object sender, EventArgs e)
        {
            Info Info = (Info)Application.OpenForms["Info"];
            if (Info == null) // optimizator activated, если форма не была создана, то давай уже создавайся
            {
                FadeOut(this, 2);
                Info.Show();
                Info.Opacity = 0.0;
                Info.Location = this.Location;
                await Task.Delay(50);
                FadeIn(Info, 2);
                await Task.Delay(50);
                Hide();
            }
            else
            {
                Info.Activate(); // АГА ПОПАВСЯ, ТЫ ДУМАЛ МНЕ ТУТ ОПЕРАТИВУ НЕМНОГО ЗАНЯТЬ?
                Info.Opacity = 0.0;
                Info.Location = this.Location;
                await Task.Delay(50);
                FadeIn(Info, 2);
                await Task.Delay(50);
                Hide();
            }

            pictureBox1.Focus();
        }

        private void Button7_MouseEnter(object sender, EventArgs e)
        {
            button7.UseVisualStyleBackColor = false;
            button7.FlatAppearance.MouseOverBackColor = Color.FromArgb(10, Color.White);
        }

        private void Button7_MouseLeave(object sender, EventArgs e)
        {
            button7.UseVisualStyleBackColor = true;
            button7.FlatAppearance.MouseOverBackColor = Color.FromArgb(100, Color.Transparent);
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            Process.Start(@".\\.ИНСТРУКЦИЯ И БИНДЫ.txt");

            pictureBox1.Focus();
        }

        private void Button3_MouseEnter(object sender, EventArgs e)
        {
            button3.UseVisualStyleBackColor = false;
            button3.FlatAppearance.MouseOverBackColor = Color.FromArgb(10, Color.White);
        }

        private void Button3_MouseLeave(object sender, EventArgs e)
        {
            button3.UseVisualStyleBackColor = true;
            button3.FlatAppearance.MouseOverBackColor = Color.FromArgb(100, Color.Transparent);
        }

        private async void FadeIn(Form o, int interval = 228)
        {
            while (o.Opacity < 1.0)
            {
                await Task.Delay(interval);
                o.Opacity += 0.10;
            }
            o.Opacity = 1; //make fully visible       
        }

        private async void FadeOut(Form o, int interval = 228)
        {
            while (o.Opacity > 0.0)
            {
                await Task.Delay(interval);
                o.Opacity -= 0.10;
            }
            o.Opacity = 0; //make fully invisible       
        }

        async private void Button4_Click_1(object sender, EventArgs e)
        {
            pictureBox1.Focus();
            Records Records = (Records)Application.OpenForms["Records"];
            if (Records == null) // optimizator activated, если форма не была создана, то давай уже создавайся
            {
                FadeOut(this, 2);
                Records Rec = new Records(); // Создание нового экземпляра формы
                Rec.Show(); // Отображаю форму
                Rec.Opacity = 0.0;
                Rec.Location = this.Location;
                await Task.Delay(50);
                FadeIn(Rec, 2);
                await Task.Delay(50);
                Hide();
            }
            else
            {
                Records.Activate(); // АГА ПОПАВСЯ, ТЫ ДУМАЛ МНЕ ТУТ ОПЕРАТИВУ НЕМНОГО ЗАНЯТЬ?
                Records Rec = new Records();
                Rec.Opacity = 0.0;
                Rec.Location = this.Location;
                await Task.Delay(50);
                FadeIn(Rec, 2);
                await Task.Delay(50);
                Hide();
            }
        }
        private void Button4_MouseEnter(object sender, EventArgs e)
        {
            button4.UseVisualStyleBackColor = false;
            button4.FlatAppearance.MouseOverBackColor = Color.FromArgb(25, Color.Blue);
        }

        private void Button4_MouseLeave(object sender, EventArgs e)
        {
            button4.UseVisualStyleBackColor = true;
            button4.FlatAppearance.MouseOverBackColor = Color.FromArgb(100, Color.Transparent);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
