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
    public partial class CFGEditor : Form
    {
        public CFGEditor()
        {
            InitializeComponent();
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

        private void Button1_Click(object sender, EventArgs e)
        {
            pictureBox1.Focus();
            if (File.Exists(@".\\Half-Life\valve_WON\autoexec.cfg"))
            {
                Process.Start("notepad.exe", @".\\Half-Life\valve_WON\autoexec.cfg"); // Запускаю блокнотом файл конфигурации Half-Life
            }
            else
            {
                MessageBox.Show(
"Конфиг не найден. Убедитесь, что файл autoexec.cfg присутствует в папке valve_WON.",
"HLSP",
MessageBoxButtons.OK,
MessageBoxIcon.Error,
MessageBoxDefaultButton.Button1);
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

        private void Button2_Click(object sender, EventArgs e)
        {
            pictureBox1.Focus();
            if (File.Exists(@".\\Half-Life\gearbox_WON\autoexec.cfg"))
            {
                Process.Start("notepad.exe", @".\\Half-Life\gearbox_WON\autoexec.cfg"); // Запускаю блокнотом файл конфигурации Opposing Force
            }
            else
            {
                MessageBox.Show(
"Конфиг не найден. Убедитесь, что файл autoexec.cfg присутствует по пути Half-Life/gearbox_WON.",
"HLSP",
MessageBoxButtons.OK,
MessageBoxIcon.Error,
MessageBoxDefaultButton.Button1);
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

        private void Button3_Click(object sender, EventArgs e)
        {
            pictureBox1.Focus();
            Process.Start("notepad.exe", @".\\Half-Life\bshift\autoexec.cfg"); // Запускаю блокнотом файл конфигурации Blue Shift
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

        private void Button4_Click(object sender, EventArgs e)
        {
            pictureBox1.Focus();
            Process.Start("notepad.exe", @".\\OpenAG\ag\autoexec.cfg"); // Запускаю блокнотом файл конфигурации OpenAG
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
            pictureBox1.Focus();
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

        async private void Button9_Click(object sender, EventArgs e)
        {
            Info Info = (Info)Application.OpenForms["Info"];
            if (Info == null) // optimizator activated, если форма не была создана, то давай уже создавайся
            {
                FadeOut(this, 2);
                Info Inf = new Info();
                Inf.Show();
                Inf.Opacity = 0.0;
                Inf.Location = this.Location;
                await Task.Delay(50);
                FadeIn(Inf, 2);
                Hide();
            }
            else
            {
                FadeOut(this, 2);
                Info.Show(); // АГА ПОПАВСЯ, ТЫ ДУМАЛ МНЕ ТУТ ОПЕРАТИВУ НЕМНОГО ЗАНЯТЬ?
                Info.Opacity = 0.0;
                Info.Location = this.Location;
                await Task.Delay(50);
                FadeIn(Info, 2);
                await Task.Delay(50);
                Hide();
            }
        }

        private void Button9_MouseEnter(object sender, EventArgs e)
        {
            button9.UseVisualStyleBackColor = false;
            button9.FlatAppearance.MouseOverBackColor = Color.FromArgb(10, Color.White);
        }

        private void Button9_MouseLeave(object sender, EventArgs e)
        {
            button9.UseVisualStyleBackColor = true;
            button9.FlatAppearance.MouseOverBackColor = Color.FromArgb(100, Color.Transparent);
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
        private void Form8_Load(object sender, EventArgs e)
        {
            MainMenu MainMenu = (MainMenu)Application.OpenForms["MainMenu"];
            this.Opacity = 0.0;
            this.Location = MainMenu.Location;
        }

        private async void FadeIn(Form o, int interval = 228)
        {
            while (o.Opacity < 1.0)
            {
                await Task.Delay(interval);
                o.Opacity += 0.10;
            }
            o.Opacity = 1; // Сделать окно полностью видимым      
        }

        private async void FadeOut(Form o, int interval = 228)
        {
            while (o.Opacity > 0.0)
            {
                await Task.Delay(interval);
                o.Opacity -= 0.10;
            }
            o.Opacity = 0; // Сделать окно полностью невидимым       
        }

        private void CFGEditor_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
