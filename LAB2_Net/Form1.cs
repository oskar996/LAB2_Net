using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using Newtonsoft.Json;
using System.Data.Entity;

namespace LAB2_Net
{
    
    public partial class Form1 : Form
    {
        DateTime aktualna;
        public Form1()
        {
            InitializeComponent();
            aktualna = dateTimePicker2.Value.Date;
        }

        private async void button1_ClickAsync(object sender, EventArgs e)
        {
            string call;

            if (aktualna == dateTimePicker2.Value.Date)
            {
                listBox1.Items.Add("dzis");
                call = "https://openexchangerates.org/api/latest.json?app_id=88b7aa6e19d94030a07972f315c03fe5";
            }
            else
            {
                int dzien = dateTimePicker2.Value.Day;
                int miesiac = dateTimePicker2.Value.Month;
                int rok = dateTimePicker2.Value.Year;
                string dz = dzien.ToString();
                if (dzien < 10)
                {
                    dz = "0" + dz;
                }
                string mies = miesiac.ToString();
                if (dateTimePicker2.Value.Month < 10)
                {
                    mies = "0" + mies;
                }
                string ro = rok.ToString();
                string polecenie = ro + '-' + mies + '-' + dz;
                call = "https://openexchangerates.org/api/historical/" + polecenie + ".json?app_id=88b7aa6e19d94030a07972f315c03fe5";
            }
            HttpClient client = new HttpClient();
            string response = await client.GetStringAsync(call);
            Rootobject Wartosci = JsonConvert.DeserializeObject<Rootobject>(response);
            textBox1.Text = "USD";
            if (radioButton1.Checked)
            {
                listBox1.Items.Add("PLN:" + Wartosci.rates.PLN);
            }
            else if (radioButton2.Checked)
            {
                listBox1.Items.Add("GBP:" + Wartosci.rates.GBP);
            }
            else if (radioButton3.Checked)
            {
                listBox1.Items.Add("CHF:" + Wartosci.rates.CHF);
            }
            else
            {
                listBox1.Items.Add("W wenezueli stabilnie:) VES:" + Wartosci.rates.VES);
            }
        }
        
    }
}
