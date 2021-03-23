using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace MoneyCurrency
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private double getRate(string fromCurrency, string toCurrency)
        {
            var json = "";
            string rate = "";
            try
            {
                string url = string.Format("https://free.currconv.com/api/v7/convert?q={0}_{1}&compact=ultra&apiKey=1b71d51db3a25220383e", fromCurrency.ToUpper(), toCurrency.ToUpper());
                string key = string.Format("{0}_{1}", fromCurrency.ToUpper(), toCurrency.ToUpper());

                json = new WebClient().DownloadString(url);
                dynamic stuff = JsonConvert.DeserializeObject(json);
                rate = stuff[key];
            }
            catch
            {
                rate = "0";
            }

            return double.Parse(rate);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ConvertMoney();
        }

        private void ConvertMoney()
        {
            Rupiah.Text = "IDR";
            if (this.comboBox1.SelectedItem.ToString() == "USD")
            {
                double rate = getRate(Rupiah.Text, comboBox1.SelectedItem.ToString());
                double output = (double.Parse(RupiahCurrency.Text) * rate)/10000000;

                Result.Text = Math.Round(output, 5) + ""; 
            }
            else if (this.comboBox1.SelectedItem.ToString() == "JPY")
            {
                double rate = getRate(Rupiah.Text, comboBox1.SelectedItem.ToString());
                double output = (double.Parse(RupiahCurrency.Text) * rate)/1000000;

                Result.Text = Math.Round(output, 5) + ""; 
            }
            
        }
    }
}
