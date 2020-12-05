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

namespace HLSP_Launcher_for_yandi505
{
    public partial class CFGEditor : Form
    {
        public CFGEditor()
        {
            InitializeComponent(); // Инициализирую компонент
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
            Process.Start("notepad.exe", @".\\Half-Life\valve_WON\autoexec.cfg"); // Запускаю блокнотом файл конфигурации Half-Life
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
            Process.Start("notepad.exe", @".\\Half-Life\gearbox_WON\autoexec.cfg"); // Запускаю блокнотом файл конфигурации Opposing Force
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
            FadeOut(this, 2);
            MainMenu Form1 = new MainMenu();
            Form1.Opacity = 0.0;
            Form1.Show();
            FadeIn(Form1, 2);
            await Task.Delay(50);
            this.Close();
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
            button5.UseVisualStyleBackColor = false;
            button5.FlatAppearance.MouseOverBackColor = Color.FromArgb(100, Color.Transparent);
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
            button6.FlatAppearance.MouseOverBackColor = Color.FromArgb(10, Color.Red);
        }

        private void Button6_MouseLeave(object sender, EventArgs e)
        {
            button6.UseVisualStyleBackColor = false;
            button6.FlatAppearance.MouseOverBackColor = Color.FromArgb(100, Color.Transparent);
        }

        async private void Button9_Click(object sender, EventArgs e)
        {
            FadeOut(this, 2);
            Info Form3 = new Info();
            Form3.Opacity = 0.0;
            Form3.Show();
            FadeIn(Form3, 2);
            await Task.Delay(50);
            this.Close();
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
    }
}
