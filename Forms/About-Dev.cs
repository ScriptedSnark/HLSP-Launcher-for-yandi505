using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace HLSP_Launcher_for_yandi505
{
    public partial class About_Dev : Form
    {
        public About_Dev()
        {
            InitializeComponent();
            GC.Collect();
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Clipboard.SetText("ScriptedSnark#0341");
            MessageBox.Show(
    "Скопировано в буфер обмена.",
    "HLSP",
    MessageBoxButtons.OK,
    MessageBoxIcon.Information,
    MessageBoxDefaultButton.Button1);

            GC.Collect();
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Clipboard.SetText("yandi505#1366");
            MessageBox.Show(
    "Скопировано в буфер обмена.",
    "HLSP",
    MessageBoxButtons.OK,
    MessageBoxIcon.Information,
    MessageBoxDefaultButton.Button1);

            GC.Collect();
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

        async private void button3_Click(object sender, EventArgs e)
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

        private void button3_MouseEnter(object sender, EventArgs e)
        {
            button3.UseVisualStyleBackColor = false;
            button3.FlatAppearance.MouseOverBackColor = Color.FromArgb(10, Color.White);
        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {
            button3.UseVisualStyleBackColor = true;
            button3.FlatAppearance.MouseOverBackColor = Color.FromArgb(100, Color.Transparent);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
"Внимание! При нажатии на кнопку Да, у вас откроется браузер. Согласны ли вы перейти по ссылке?",
"HLSP",
MessageBoxButtons.YesNo,
MessageBoxIcon.Warning,
MessageBoxDefaultButton.Button1);

            if (result == DialogResult.Yes)
            Process.Start("https://www.donationalerts.com/r/yandi505");
        }

        private void button5_MouseEnter(object sender, EventArgs e)
        {
            button5.UseVisualStyleBackColor = false;
            button5.FlatAppearance.MouseOverBackColor = Color.FromArgb(15, Color.Orange);
        }

        private void button5_MouseLeave(object sender, EventArgs e)
        {
            button5.UseVisualStyleBackColor = true;
            button5.FlatAppearance.MouseOverBackColor = Color.FromArgb(100, Color.Transparent);
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

        private void About_Dev_Load(object sender, EventArgs e)
        {
            MainMenu MainMenu = (MainMenu)Application.OpenForms["MainMenu"];
            this.Opacity = 0.0;
            this.Location = MainMenu.Location;
        }

        private void About_Dev_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
"Внимание! При нажатии на кнопку Да, у вас откроется браузер. Согласны ли вы перейти по ссылке?",
"HLSP",
MessageBoxButtons.YesNo,
MessageBoxIcon.Warning,
MessageBoxDefaultButton.Button1);

            if (result == DialogResult.Yes)
                Process.Start("https://vk.com/grunge_isdead");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
"Внимание! При нажатии на кнопку Да, у вас откроется браузер. Согласны ли вы перейти по ссылке?",
"HLSP",
MessageBoxButtons.YesNo,
MessageBoxIcon.Warning,
MessageBoxDefaultButton.Button1);

            if (result == DialogResult.Yes)
                Process.Start("https://steamcommunity.com/id/yandi505");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
"Внимание! При нажатии на кнопку Да, у вас откроется браузер. Согласны ли вы перейти по ссылке?",
"HLSP",
MessageBoxButtons.YesNo,
MessageBoxIcon.Warning,
MessageBoxDefaultButton.Button1);

            if (result == DialogResult.Yes)
                Process.Start("https://steamcommunity.com/id/scriptedsnark");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
"Внимание! При нажатии на кнопку Да, у вас откроется браузер. Согласны ли вы перейти по ссылке?",
"HLSP",
MessageBoxButtons.YesNo,
MessageBoxIcon.Warning,
MessageBoxDefaultButton.Button1);

            if (result == DialogResult.Yes)
                Process.Start("https://vk.com/bogdansp2019");
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button9_MouseEnter(object sender, EventArgs e)
        {
            button9.UseVisualStyleBackColor = false;
            button9.FlatAppearance.MouseOverBackColor = Color.FromArgb(25, Color.Red);
        }

        private void button9_MouseLeave(object sender, EventArgs e)
        {
            button9.UseVisualStyleBackColor = true;
            button9.FlatAppearance.MouseOverBackColor = Color.FromArgb(100, Color.Transparent);
        }
    }
}
