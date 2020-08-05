using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Xamarin.Forms;

namespace Evidence_Forms
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        protected override void OnAppearing()
        {
            base.OnAppearing();
            VypocitejSaldo();
            // Nastaví texty s aktuálními časy
            NastavTexty();

            // Načte původní čas příchodu
            prichodCas = (Application.Current as App).Prichod;
        }

        public MainPage()
        {
            InitializeComponent();
        }


        public TimeSpan delkaSmeny = new TimeSpan(0, 8, 0, 1, 0);
        public DateTime prichodCas = new DateTime();
        public DateTime odchodCas = new DateTime();
        public TimeSpan saldo = new TimeSpan();
        public TimeSpan saldoCelkem = new TimeSpan();

        void PrichodBtn(object sender, EventArgs e)
        {
            prichodCas = DateTime.Now;
            (Application.Current as App).Prichod = prichodCas;
            Application.Current.SavePropertiesAsync();
            NastavTextPrichod();
        }

        void OdchodBtn(object sender, EventArgs e)
        {
            odchodCas = DateTime.Now;
            (Application.Current as App).Odchod = odchodCas;
            VypocitejSaldo();
            (Application.Current as App).Saldo = saldo;
            Application.Current.SavePropertiesAsync();
            NastavTexty();
        }

        void VypocitejSaldo()
        {
            saldo = (odchodCas - prichodCas)-delkaSmeny;
            saldoCelkem += saldo;
        }

        void NastavTextPrichod()
        {
            prichodLabel.Text = ((Application.Current as App).Prichod).ToString("HH:mm:ss");
        }

        void NastavTextOdchod()
        {
            odchodLabel.Text = ((Application.Current as App).Odchod).ToString("HH:mm:ss");
        }



        void NastavTextSaldo()
        {
            string formatSaldo = (saldo < TimeSpan.Zero ? "\\-" : "") + "hh\\:mm\\:ss";
            saldoLabel.Text = ((Application.Current as App).Saldo).ToString(formatSaldo);
        }

        void NastavTextSaldoCelkem()
        {
            string formatSaldo = (saldoCelkem < TimeSpan.Zero ? "\\-" : "") + "hh\\:mm\\:ss";
            saldoCelkemLabel.Text = ((Application.Current as App).SaldoCelkem).ToString(formatSaldo);
        }

        void NastavTexty()
        {
            NastavTextPrichod();
            NastavTextOdchod();
            NastavTextSaldo();
            NastavTextSaldoCelkem();
        }

    }
}
