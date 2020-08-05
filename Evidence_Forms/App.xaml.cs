using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Evidence_Forms
{
    public partial class App : Application
    {
        const string prichod = "prichod";
        const string odchod = "odchod";
        const string saldo = "saldo";
        const string saldoCelkem = "saldoCelkem";

        public DateTime Prichod { get; set; }
        public DateTime Odchod { get; set; }
        public TimeSpan Saldo { get; set; }
        public TimeSpan SaldoCelkem { get; set; }
            public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
            if(Properties.ContainsKey(prichod))
            {
                Prichod = (DateTime)Properties[prichod];
            }

            if(Properties.ContainsKey(odchod))
            {
                Odchod = (DateTime)Properties[odchod];
            }

            if(Properties.ContainsKey(saldo))
            {
                Saldo = (TimeSpan)Properties[saldo];
            }

            if (Properties.ContainsKey(saldoCelkem))
            {
                Saldo = (TimeSpan)Properties[saldoCelkem];
            }
        }

        protected override void OnSleep()
        {
            Properties[prichod] = Prichod;
            Properties[odchod] = Odchod;
            Properties[saldo] = Saldo;
            Properties[saldoCelkem] = SaldoCelkem;
        }

        protected override void OnResume()
        {
        }
    }
}
