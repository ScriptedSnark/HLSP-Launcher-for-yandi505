using HLSP_Launcher_for_yandi505.Properties;
using System;
using System.Drawing;
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
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            pictureBox1.Focus();

            Environment.Exit(0);
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
            speedrun.Document.Body.Style = "zoom:80%";
            HtmlElement head = speedrun.Document.GetElementsByTagName("head")[0];
            HtmlElement scriptEl = speedrun.Document.CreateElement("script");
            scriptEl.SetAttribute("language", "javascript");
            scriptEl.InnerHtml = Resources.TextFile1;
            head.AppendChild(scriptEl);
            speedrun.Document.Window.ScrollTo(55, 615);
        }

        private void Records_Load(object sender, EventArgs e)
        {
            MainMenu MainMenu = (MainMenu)Application.OpenForms["MainMenu"];
            MainMenu.Opacity = 0.0;
            MainMenu.Location = this.Location;
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

        async private void Button1_Click(object sender, EventArgs e)
        {
            pictureBox1.Focus();
            GC.Collect();
            GC.Collect();
            GC.WaitForPendingFinalizers();

            MainMenu MM = (MainMenu)Application.OpenForms["MainMenu"];
            if (MM == null) // optimizator activated, если форма не была создана, то давай уже создавайся
            {
                FadeOut(this, 2);
                MainMenu MainMenu = new MainMenu(); // Создание нового экземпляра формы
                MainMenu.Show(); // Отображаю форму
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
                Controls.Remove(speedrun);
                speedrun.Dispose();
                speedrun = null;
                this.Dispose();
            }
        }

        private void Button1_MouseEnter(object sender, EventArgs e)
        {
            button1.UseVisualStyleBackColor = false;
            button1.FlatAppearance.MouseOverBackColor = Color.FromArgb(6, Color.FloralWhite);
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
            pictureBox1.Focus();

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
                Controls.Remove(speedrun);
                speedrun.Dispose();
                speedrun = null;
                this.Dispose();
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
                Controls.Remove(speedrun);
                speedrun.Dispose();
                speedrun = null;
                this.Dispose();
            }
        }
        private void Button7_MouseEnter(object sender, EventArgs e)
        {
            button7.UseVisualStyleBackColor = false;
            button7.FlatAppearance.MouseOverBackColor = Color.FromArgb(6, Color.FloralWhite);
        }

        private void Button7_MouseLeave(object sender, EventArgs e)
        {
            button7.UseVisualStyleBackColor = true;
            button7.FlatAppearance.MouseOverBackColor = Color.FromArgb(100, Color.Transparent);
        }

        private void Optimizator()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Optimizator();
        }

        private void Records_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
