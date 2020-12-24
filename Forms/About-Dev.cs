using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
    "Discord разработчика ScriptedSnark успешно скопирован в буфер обмена!",
    "HLSP",
    MessageBoxButtons.OK,
    MessageBoxIcon.Information,
    MessageBoxDefaultButton.Button1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Clipboard.SetText("yandi505#1366");
            MessageBox.Show(
    "Discord разработчика yandi505 успешно скопирован в буфер обмена!",
    "HLSP",
    MessageBoxButtons.OK,
    MessageBoxIcon.Information,
    MessageBoxDefaultButton.Button1);
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

        private void button5_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.donationalerts.com/r/yandi505");
        }

        private void button5_MouseEnter(object sender, EventArgs e)
        {

        }

        private void button5_MouseLeave(object sender, EventArgs e)
        {

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

        }
    }
}
