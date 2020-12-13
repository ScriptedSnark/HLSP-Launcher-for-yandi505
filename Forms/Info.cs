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
using System.Media;
using HLSP_Launcher_for_yandi505.Properties;

namespace HLSP_Launcher_for_yandi505
{
    public partial class Info : Form
    {
        public Info()
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
        }

        private int counter = 0;


        async private void Button1_Click(object sender, EventArgs e)
        {
            counter++;

            if (counter == 15)
            {
                SoundPlayer player = new SoundPlayer(Resources.activated);
                player.Play();
                DialogResult result = MessageBox.Show(
"Ты активировал пасхалку. Если ты перейдешь по видео, то узнаешь как играть на этой сборке без лицензии. Перейти по ссылке на видео?",
"HLSP",
MessageBoxButtons.YesNo,
MessageBoxIcon.Warning,
MessageBoxDefaultButton.Button1);
                if (result == DialogResult.Yes)
                Process.Start("https://youtu.be/Zjselp9uRgM");
                await Task.Delay(100);
                Application.Restart();
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {

        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        async private void Button4_Click(object sender, EventArgs e)
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
                Close();
            }
            else
            {
                FadeOut(this, 2);
                MM.Activate(); // АГА ПОПАВСЯ, ТЫ ДУМАЛ МНЕ ТУТ ОПЕРАТИВУ НЕМНОГО ЗАНЯТЬ?
                MM.Opacity = 0.0;
                MM.Location = this.Location;
                MM.Show();
                await Task.Delay(50);
                FadeIn(MM, 2);
                await Task.Delay(50);
                Close();
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
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
            button5.FlatAppearance.MouseOverBackColor = Color.FromArgb(10, Color.Fuchsia);
        }

        private void Button5_MouseLeave(object sender, EventArgs e)
        {
            button5.UseVisualStyleBackColor = true;
            button5.FlatAppearance.MouseOverBackColor = Color.FromArgb(100, Color.Transparent);
        }
    }
}
