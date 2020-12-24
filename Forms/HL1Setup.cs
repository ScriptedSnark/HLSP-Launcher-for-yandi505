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
using System.IO;

namespace HLSP_Launcher_for_yandi505
{
    public partial class HL1Setup : Form
    {
        public HL1Setup()
        {
            InitializeComponent();

            GC.Collect();
            GC.Collect();
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
            const string HLpath = @".\\Half-Life\hl.exe";
            const string BXTpath = @".\\Bunnymod XT\Injector.exe";
            const string RInputpath = @".\\RInput\RInput.exe";
            const string LiveSplitpath = @".\\LiveSplit\LiveSplit.exe";

            if (File.Exists(HLpath))
            {
                Process.Start(HLpath, "-game valve_WON -noforcemparams +exec autoexec.cfg");
                await Task.Delay(1000);
                Application.Exit();
            }
            else
            {
                MessageBox.Show(
"Не удалось запустить Half-Life, так как отсутствует hl.exe. Проверьте целостность сборки.",
"HLSP",
MessageBoxButtons.OK,
MessageBoxIcon.Error,
MessageBoxDefaultButton.Button1);
                GC.Collect();
                GC.Collect();
                GC.WaitForPendingFinalizers();

                if (File.Exists(BXTpath))
                {
                    if (checkBox1.Checked == true)
                    {
                        Process.Start(BXTpath, "-processname hl.exe");
                    }
                }
                else
                {
                    MessageBox.Show(
"Не удалось запустить утилиту BXT, так как отсутствует Injector.exe. Проверьте целостность сборки.",
"HLSP",
MessageBoxButtons.OK,
MessageBoxIcon.Error,
MessageBoxDefaultButton.Button1);
                }

                if (File.Exists(RInputpath))
                {
                    if (checkBox2.Checked == true)
                    {
                        Process.Start(RInputpath, "hl.exe");
                    }
                }
                else
                {
                    MessageBox.Show(
"Не удалось запустить RInput, так как отсутствует RInput.exe. Проверьте целостность сборки.",
"HLSP",
MessageBoxButtons.OK,
MessageBoxIcon.Error,
MessageBoxDefaultButton.Button1);
                }

                if (File.Exists(LiveSplitpath))
                {
                    if (checkBox3.Checked == true)
                    {
                        Process.Start(LiveSplitpath);
                    }
                }
                else
                {
                    MessageBox.Show(
"Не удалось запустить LiveSplit, так как отсутствует LiveSplit.exe. Проверьте целостность сборки.",
"HLSP",
MessageBoxButtons.OK,
MessageBoxIcon.Error,
MessageBoxDefaultButton.Button1);
                }
            }
        }

        private void Button2_MouseEnter(object sender, EventArgs e)
        {
            button2.UseVisualStyleBackColor = false;
            button2.FlatAppearance.MouseOverBackColor = Color.FromArgb(10, Color.Fuchsia);
        }

        private void Button2_MouseLeave(object sender, EventArgs e)
        {
            button2.UseVisualStyleBackColor = false;
            button2.FlatAppearance.MouseOverBackColor = Color.FromArgb(100, Color.Transparent);
        }

        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void CheckBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void CheckBox3_CheckedChanged(object sender, EventArgs e)
        {

        }

        async private void Button3_Click(object sender, EventArgs e)
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
                await Task.Delay(50);
                Hide();
            }
            else
            {
                FadeOut(this, 2);
                GS.Show(); // АГА ПОПАВСЯ, ТЫ ДУМАЛ МНЕ ТУТ ОПЕРАТИВУ НЕМНОГО ЗАНЯТЬ?
                GS.Opacity = 0.0;
                GS.Location = this.Location;
                await Task.Delay(50);
                FadeIn(GS, 2);
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

        private void Form4_Load(object sender, EventArgs e)
        {
            GameSelection GameSelection = (GameSelection)Application.OpenForms["GameSelection"];
            this.Opacity = 0.0;
            this.Location = GameSelection.Location;
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Button4_MouseEnter(object sender, EventArgs e)
        {
            button4.UseVisualStyleBackColor = false;
            button4.FlatAppearance.MouseOverBackColor = Color.FromArgb(25, Color.Red);
        }

        private void Button4_MouseLeave(object sender, EventArgs e)
        {
            button4.UseVisualStyleBackColor = true;
            button4.FlatAppearance.MouseOverBackColor = Color.FromArgb(100, Color.Transparent);
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

        private void HL1Setup_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
