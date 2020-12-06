﻿using System;
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

        }

        private void Button2_MouseLeave(object sender, EventArgs e)
        {

        }
        private void Speedrun_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }

        private void Records_Load(object sender, EventArgs e)
        {

        }

        async private void Button1_Click(object sender, EventArgs e)
        {
            FadeOut(this, 2);
            MainMenu MainMenu = new MainMenu();
            MainMenu.Show();
            MainMenu.Opacity = 0.0;
            MainMenu.Location = this.Location;
            FadeIn(MainMenu, 2);
            await Task.Delay(50);
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
            GC.WaitForPendingFinalizers();
            Close();
        }

        private void Button1_MouseEnter(object sender, EventArgs e)
        {

        }

        private void Button1_MouseLeave(object sender, EventArgs e)
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
    }
}