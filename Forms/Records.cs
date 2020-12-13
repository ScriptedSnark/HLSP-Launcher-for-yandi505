using HLSP_Launcher_for_yandi505.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HLSP_Launcher_for_yandi505
{
    public partial class Records : Form
    {
        public Records()
        {
            InitializeComponent();
            GC.Collect(1, GCCollectionMode.Optimized);
            GC.WaitForPendingFinalizers();
            GC.Collect(1, GCCollectionMode.Optimized);
            GC.WaitForPendingFinalizers();

            int num = 0;
            TimerCallback tm = new TimerCallback(Optimization);
            System.Threading.Timer timer = new System.Threading.Timer(tm, num, 0, 5000);
        }

        async private void Optimization(object obj)
        {
            GC.Collect(1, GCCollectionMode.Optimized);
            GC.WaitForPendingFinalizers();
            GC.Collect(1, GCCollectionMode.Optimized);
            GC.WaitForPendingFinalizers();
            await Task.Delay(500);
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }
        private void Button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Button2_MouseEnter(object sender, EventArgs e)
        {
            button2.UseVisualStyleBackColor = false;
            button2.FlatAppearance.MouseOverBackColor = Color.FromArgb(25, Color.Red);
        }

        private void Button2_MouseLeave(object sender, EventArgs e)
        {
            button2.UseVisualStyleBackColor = true;
            button2.FlatAppearance.MouseOverBackColor = Color.FromArgb(100, Color.Transparent);
        }
        private void Speedrun_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            speedrun.Document.Body.Style = "zoom:80%;overflow:hidden";
            HtmlElement head = speedrun.Document.GetElementsByTagName("head")[0];
            HtmlElement scriptEl = speedrun.Document.CreateElement("script");
            scriptEl.SetAttribute("language", "javascript");
            scriptEl.InnerHtml = Resources.TextFile1;
            head.AppendChild(scriptEl);
            speedrun.Document.Window.ScrollTo(55, 615);
        }

        private void Records_Load(object sender, EventArgs e)
        {

        }

        async private void Button1_Click(object sender, EventArgs e)
        {
            GC.Collect();
            GC.Collect();
            GC.WaitForPendingFinalizers();

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
                speedrun.Dispose();
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
                speedrun.Dispose();
            }
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

        async private void Button7_Click(object sender, EventArgs e)
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
                Info.Activate(); // АГА ПОПАВСЯ, ТЫ ДУМАЛ МНЕ ТУТ ОПЕРАТИВУ НЕМНОГО ЗАНЯТЬ?
                Info.Opacity = 0.0;
                Info.Location = this.Location;
                await Task.Delay(50);
                FadeIn(Info, 2);
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
    }
}
