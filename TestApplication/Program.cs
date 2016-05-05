using System;
using System.Net.Http;
using System.Windows.Forms;
using log4net;
using log4net.Config;

// ReSharper disable CatchAllClause

namespace Crisp.Diagnostics.TestApplication
{
    static class Program
    {
        private static ILog log;
        private static Random random;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            XmlConfigurator.Configure();
            random = new Random();
            log = LogManager.GetLogger("Test Application");
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Application.Run(new TestForm());
        }

        class TestForm : Form
        {
            private HttpClient httpClient;

            public TestForm()
            {
                httpClient = new HttpClient();

                var timer = new Timer
                {
                    Enabled = true,
                    Interval = 1000
                };

                timer.Tick += Timer_Tick;
                timer.Start();

                WindowState = FormWindowState.Minimized;
                ShowInTaskbar = false;
            }


            private static void Timer_Tick(object sender, EventArgs e)
            {
                var timer = (Timer)sender;
                timer.Interval = random.Next(1, 750);

                if (random.Next(0, 2) == 1)
                    log.Info("Stuff and things in progress.");

                if (random.Next(0, 2) == 1)
                    log.Info("Doing another thing. This thing is a bit different.");

                if (random.Next(0, 2) == 1)
                    log.Info("Just finished checking stuff.");

                try
                {
                    if (random.Next(0, 2) == 1)
                        switch (random.Next(0, 6))
                        {
                            case 0: throw new ArgumentNullException();
                            case 1: throw new MissingMethodException();
                            case 2: throw new ApplicationException();
                            case 3: throw new ArithmeticException();
                            case 4: throw new IndexOutOfRangeException();
                            case 5: throw new TimeZoneNotFoundException();
                        }
                }
                catch (Exception x)
                {
                    log.Error("Exception encountered while attempting to do the thing.", x);
                }
            }
        }
    }
}
