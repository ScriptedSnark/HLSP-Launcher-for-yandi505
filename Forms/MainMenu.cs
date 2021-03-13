using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using DiscordRPC;
using System.Net;

namespace HLSP_Launcher_for_yandi505
{
    public partial class MainMenu : Form
    {
        MainController controller;
        public MainMenu()
        {
            InitializeComponent();
            controller = new MainController();
            controller.updateRPC();
            pictureBox1.Focus();

            GC.Collect();
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // VERSION OF HLSP
            string HLSPversion = "1.1";
            // VERSION OF HLSP

            // Плавность запуска
            Opacity = 0.0;
            FadeIn(this, 5);

            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
            WebClient webClient = new WebClient();

            try
            {
                if (!webClient.DownloadString("https://raw.githubusercontent.com/ScriptedSnark/HLSP-Launcher-for-yandi505/master/update_version.txt").Contains(HLSPversion))
                {
                    if (MessageBox.Show("Доступно новое обновление HLSP. Желаете ли вы установить самую последнюю версию?", "HLSP", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        using (var client = new WebClient())
                        {
                            Process.Start("Updater.exe");
                            Close();
                        }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(
        ex.Message,
        "HLSP",
        MessageBoxButtons.OK,
        MessageBoxIcon.Error,
        MessageBoxDefaultButton.Button1);
            }
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
            CFGEditor CE = (CFGEditor)Application.OpenForms["CFGEditor"];
            if (CE == null) // optimizator activated, если форма не была создана, то давай уже создавайся
            {
                FadeOut(this, 1);
                CFGEditor CFGEdit = new CFGEditor(); // Создание нового экземпляра формы
                CFGEdit.Show(); // Отображаю форму
                await Task.Delay(50);
                FadeIn(CFGEdit, 1);
                await Task.Delay(50);
                Hide();
            }
            else
            {
                FadeOut(this, 1);
                CE.Show(); // АГА ПОПАВСЯ, ТЫ ДУМАЛ МНЕ ТУТ ОПЕРАТИВУ НЕМНОГО ЗАНЯТЬ?
                CE.Opacity = 0.0;
                CE.Location = this.Location;
                await Task.Delay(50);
                FadeIn(CE, 1);
                await Task.Delay(50);
                Hide();
            }
            pictureBox1.Focus();
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

            this.Focus();
        }

        private void Button6_MouseEnter(object sender, EventArgs e)
        {
            button6.UseVisualStyleBackColor = false;
            button6.FlatAppearance.MouseOverBackColor = Color.FromArgb(10, Color.Red);
        }

        private void Button6_MouseLeave(object sender, EventArgs e)
        {
            button6.UseVisualStyleBackColor = true;
            button6.FlatAppearance.MouseOverBackColor = Color.FromArgb(100, Color.Transparent);
        }
        async private void Button1_Click(object sender, EventArgs e)
        {
            pictureBox1.Focus();

            GameSelection GS = (GameSelection)Application.OpenForms["GameSelection"];
            if (GS == null) // optimizator activated, если форма не была создана, то давай уже создавайся
            {
                FadeOut(this, 1);
                GameSelection GameSelection = new GameSelection(controller); // Отображаю форму
                GameSelection.Show();
                await Task.Delay(50);
                FadeIn(GameSelection, 1);
                await Task.Delay(50);
                Hide();
            }
            else
            {
                FadeOut(this, 1);
                GS.Opacity = 0.0;
                GS.Location = this.Location;
                GS.Show(); // АГА ПОПАВСЯ, ТЫ ДУМАЛ МНЕ ТУТ ОПЕРАТИВУ НЕМНОГО ЗАНЯТЬ?
                await Task.Delay(50);
                FadeIn(GS, 1);
                await Task.Delay(50);
                Hide();
            }

            GC.Collect();
            GC.Collect();
            GC.WaitForPendingFinalizers();
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

        private void Button8_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
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
                FadeOut(this, 1);
                Info Inf = new Info();
                Inf.Show();
                await Task.Delay(50);
                FadeIn(Inf, 1);
                await Task.Delay(50);
                Hide();
            }
            else
            {
                FadeOut(this, 1);
                Info.Opacity = 0.0;
                Info.Location = this.Location;
                Info.Show(); // АГА ПОПАВСЯ, ТЫ ДУМАЛ МНЕ ТУТ ОПЕРАТИВУ НЕМНОГО ЗАНЯТЬ?
                await Task.Delay(50);
                FadeIn(Info, 1);
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
            pictureBox1.Focus();

            DialogResult result = MessageBox.Show(
"Внимание! При нажатии на кнопку Да, у вас откроется браузер. Согласны ли вы перейти по ссылке?",
"HLSP",
MessageBoxButtons.YesNo,
MessageBoxIcon.Warning,
MessageBoxDefaultButton.Button1);

            if (result == DialogResult.Yes)
                Process.Start("https://vk.com/@grunge_isdead-speedrunpackage");
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

        async private void Button4_Click_1(object sender, EventArgs e)
        {
            pictureBox1.Focus();
            Records Records = (Records)Application.OpenForms["Records"];
            if (Records == null) // optimizator activated, если форма не была создана, то давай уже создавайся
            {
                FadeOut(this, 1);
                Records Rec = new Records(); // Создание нового экземпляра формы
                Rec.Show(); // Отображаю форму
                Rec.Opacity = 0.0;
                Rec.Location = this.Location;
                await Task.Delay(50);
                FadeIn(Rec, 1);
                await Task.Delay(50);
                Hide();
            }
            else
            {
                Records.Show(); // АГА ПОПАВСЯ, ТЫ ДУМАЛ МНЕ ТУТ ОПЕРАТИВУ НЕМНОГО ЗАНЯТЬ?
                Records.Opacity = 0.0;
                Records.Location = this.Location;
                await Task.Delay(50);
                FadeIn(Records, 1);
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

        async private void button9_Click(object sender, EventArgs e)
        {
            pictureBox1.Focus();
            About_Dev AboutDev = (About_Dev)Application.OpenForms["About_Dev"];
            if (AboutDev == null) // optimizator activated, если форма не была создана, то давай уже создавайся
            {
                FadeOut(this, 1);
                About_Dev About = new About_Dev(); // Создание нового экземпляра формы
                About.Show(); // Отображаю форму
                await Task.Delay(50);
                FadeIn(About, 1);
                await Task.Delay(50);
                Hide();
            }
            else
            {
                FadeOut(this, 1);
                AboutDev.Show();
                AboutDev.Opacity = 0.0;
                AboutDev.Location = this.Location;
                await Task.Delay(50);
                FadeIn(AboutDev, 1);
                await Task.Delay(50);
                Hide();
            }
        }

        private void button9_MouseEnter(object sender, EventArgs e)
        {
            button9.UseVisualStyleBackColor = false;
            button9.FlatAppearance.MouseOverBackColor = Color.FromArgb(5, Color.Aquamarine);
        }

        private void button9_MouseLeave(object sender, EventArgs e)
        {
            button9.UseVisualStyleBackColor = true;
            button9.FlatAppearance.MouseOverBackColor = Color.FromArgb(100, Color.Transparent);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Changelog Changelog = (Changelog)Application.OpenForms["Changelog"];
            if (Changelog == null) // optimizator activated, если форма не была создана, то давай уже создавайся
            {
                Changelog Log = new Changelog(); // Создание нового экземпляра формы
                Log.Show(); // Отображаю форму
            }
            else
            {
                Changelog.Show();
            }
        }
        private async void FadeIn(Form o, int interval = 228)
        {
            while (o.Opacity < 1.0)
            {
                await Task.Delay(interval);
                o.Opacity += 0.10;
            }
            o.Opacity = 1;
        }

        private async void FadeOut(Form o, int interval = 228)
        {
            while (o.Opacity > 0.0)
            {
                await Task.Delay(interval);
                o.Opacity -= 0.10;
            }
            o.Opacity = 0;
        }
    }
}
