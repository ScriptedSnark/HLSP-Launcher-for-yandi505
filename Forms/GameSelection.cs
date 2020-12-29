using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;

namespace HLSP_Launcher_for_yandi505
{
    public partial class GameSelection : Form
    {
        MainController controller;
        public GameSelection(MainController prevFormController)
        {
            InitializeComponent();
            controller = prevFormController;
            GC.Collect(1, GCCollectionMode.Optimized);
            GC.WaitForPendingFinalizers();
            GC.Collect(1, GCCollectionMode.Optimized);
            GC.WaitForPendingFinalizers();
        }

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

            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
"Внимание! При нажатии на кнопку Да, у вас откроется браузер. Согласны ли вы перейти по ссылке?",
"HLSP",
MessageBoxButtons.YesNo,
MessageBoxIcon.Warning,
MessageBoxDefaultButton.Button1);

            if (result == DialogResult.Yes)
                Process.Start("https://discord.gg/E5kg4qV");
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
"Внимание! При нажатии на кнопку Да, у вас откроется браузер. Согласны ли вы перейти по ссылке?",
"HLSP",
MessageBoxButtons.YesNo,
MessageBoxIcon.Warning,
MessageBoxDefaultButton.Button1);

            if (result == DialogResult.Yes)
                Process.Start("https://www.youtube.com/channel/UCyfrmhORgydjd2cHFwB7YVw");
        }

        async private void Button8_Click(object sender, EventArgs e)
        {
            MainMenu MM = (MainMenu)Application.OpenForms["MainMenu"];
            if (MM == null) // optimizator activated, если форма не была создана, то давай уже создавайся
            {
                FadeOut(this, 2);
                MainMenu MainMenu = new MainMenu(); // Создание нового экземпляра формы
                MainMenu.Show(); // Отображаю форму
                MainMenu.Opacity = 0.0;
                MainMenu.Location = this.Location;
                await Task.Delay(50);
                FadeIn(MainMenu, 2);
                await Task.Delay(50);
                Hide();
            }
            else
            {
                FadeOut(this, 2);
                MM.Opacity = 0.0;
                MM.Location = this.Location;
                MM.Show();
                await Task.Delay(50);
                FadeIn(MM, 2);
                await Task.Delay(50);
                Hide();
            }
        }

        private void Button8_MouseEnter(object sender, EventArgs e)
        {
            button8.UseVisualStyleBackColor = false;
            button8.FlatAppearance.MouseOverBackColor = Color.FromArgb(10, Color.White);
        }

        private void Button8_MouseLeave(object sender, EventArgs e)
        {
            button8.UseVisualStyleBackColor = true;
            button8.FlatAppearance.MouseOverBackColor = Color.FromArgb(100, Color.Transparent);
        }

        private void Button9_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Button9_MouseEnter(object sender, EventArgs e)
        {
            button9.UseVisualStyleBackColor = false;
            button9.FlatAppearance.MouseOverBackColor = Color.FromArgb(25, Color.Red);
        }

        private void Button9_MouseLeave(object sender, EventArgs e)
        {
            button9.UseVisualStyleBackColor = true;
            button9.FlatAppearance.MouseOverBackColor = Color.FromArgb(100, Color.Transparent);
        }

        async private void Button1_Click(object sender, EventArgs e)
        {
            HL1Setup HL1 = (HL1Setup)Application.OpenForms["HL1Setup"];
            if (HL1 == null) // optimizator activated, если форма не была создана, то давай уже создавайся
            {
                FadeOut(this, 2);
                HL1Setup HL1Setup = new HL1Setup(controller); // Создание нового экземпляра формы
                HL1Setup.Show(); // Отображаю форму
                await Task.Delay(50);
                FadeIn(HL1Setup, 2);
                await Task.Delay(50);
                Hide();
            }
            else
            {
                FadeOut(this, 2);
                HL1.Opacity = 0.0;
                HL1.Location = this.Location;
                HL1.Show();
                await Task.Delay(50);
                FadeIn(HL1, 2);
                await Task.Delay(50);
                Hide();
            }
        }

        private void Button1_MouseEnter(object sender, EventArgs e)
        {
            button1.UseVisualStyleBackColor = true;
            button1.FlatAppearance.MouseOverBackColor = Color.FromArgb(10, Color.White);
        }

        private void Button1_MouseLeave(object sender, EventArgs e)
        {
            button1.UseVisualStyleBackColor = true;
            button1.FlatAppearance.MouseOverBackColor = Color.FromArgb(100, Color.Transparent);
        }
        async private void Button2_Click(object sender, EventArgs e)
        {
            OP4Setup OP4 = (OP4Setup)Application.OpenForms["OP4Setup"];
            if (OP4 == null) // optimizator activated, если форма не была создана, то давай уже создавайся
            {
                FadeOut(this, 2);
                OP4Setup OP4Setup = new OP4Setup(controller); // Создание нового экземпляра формы
                OP4Setup.Show(); // Отображаю форму
                await Task.Delay(50);
                FadeIn(OP4Setup, 2);
                await Task.Delay(50);
                Hide();
            }
            else
            {
                FadeOut(this, 2);
                OP4.Opacity = 0.0;
                OP4.Location = this.Location;
                OP4.Show();
                await Task.Delay(50);
                FadeIn(OP4, 2);
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

        async private void Button3_Click(object sender, EventArgs e)
        {
            BSSetup BS = (BSSetup)Application.OpenForms["BSSetup"];
            if (BS == null) // optimizator activated, если форма не была создана, то давай уже создавайся
            {
                FadeOut(this, 2);
                BSSetup BSSetup = new BSSetup(controller); // Создание нового экземпляра формы
                BSSetup.Show(); // Отображаю форму
                await Task.Delay(50);
                FadeIn(BSSetup, 2);
                await Task.Delay(50);
                Hide();
            }
            else
            {
                FadeOut(this, 2);
                BS.Opacity = 0.0;
                BS.Location = this.Location;
                BS.Show();
                await Task.Delay(50);
                FadeIn(BS, 2);
                await Task.Delay(50);
                Hide();
            }
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

        async private void Button4_Click(object sender, EventArgs e)
        {
            if (File.Exists(@".\\OpenAG\hl.exe"))
            {
                Process.Start(@".\\OpenAG\hl.exe", "-game ag -noforcemparams +exec autoexec.cfg");

                await Task.Delay(4500);
                controller.updateRPC("discord.gg/E5kg4qV", "Играет в OpenAG", "ag");
                timer1.Start();
            }
            else
            {
                MessageBox.Show(
"Не удалось запустить OpenAG, так как отсутствует hl.exe. Проверьте целостность сборки.",
"HLSP",
MessageBoxButtons.OK,
MessageBoxIcon.Error,
MessageBoxDefaultButton.Button1);
                GC.Collect();
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
        }

        public void Checker()
        {
            if (Process.GetProcessesByName("hl").Length != 0)
            {

            }
            else
            {
                Show();
                controller.updateRPC("discord.gg/E5kg4qV", "Находится в лаунчере", "image_small");
                timer1.Stop();
            }
        }

        private void Button4_MouseEnter(object sender, EventArgs e)
        {
            button4.UseVisualStyleBackColor = false;
            button4.FlatAppearance.MouseOverBackColor = Color.FromArgb(10, Color.White);
        }

        private void Button4_MouseLeave(object sender, EventArgs e)
        {
            button4.UseVisualStyleBackColor = true;
            button4.FlatAppearance.MouseOverBackColor = Color.FromArgb(100, Color.Transparent);
        }

        async private void Button7_Click(object sender, EventArgs e)
        {
            Info Inf = (Info)Application.OpenForms["Info"];
            if (Inf == null) // optimizator activated, если форма не была создана, то давай уже создавайся
            {
                FadeOut(this, 2);
                Info Info = new Info(); // Создание нового экземпляра формы
                Info.Show(); // Отображаю форму
                await Task.Delay(50);
                FadeIn(Info, 2);
                await Task.Delay(50);
                Hide();
            }
            else
            {
                FadeOut(this, 2);
                Inf.Show(); // АГА ПОПАВСЯ, ТЫ ДУМАЛ МНЕ ТУТ ОПЕРАТИВУ НЕМНОГО ЗАНЯТЬ?
                Inf.Opacity = 0.0;
                Inf.Location = this.Location;
                await Task.Delay(50);
                FadeIn(Inf, 2);
                await Task.Delay(50);
                Hide();
            }
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

        private void Form2_Load(object sender, EventArgs e)
        {
            MainMenu MainMenu = (MainMenu)Application.OpenForms["MainMenu"];
            this.Opacity = 0.0;
            this.Location = MainMenu.Location;
        }

        private void GameSelection_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Checker();
        }
    }
}
