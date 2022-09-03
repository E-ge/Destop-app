using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace SporSalonuUyeTakip
{
    public partial class Form1 : Form
    {
        ArrayList uye = new ArrayList(); //Salona Kayıt olan üye bilgileri
        ArrayList uye_paket = new ArrayList(); //Üyelerin kalan günleri
        ArrayList uye_kalangun = new ArrayList();
        ArrayList uye_olcu = new ArrayList();//daha girilmedi
        ArrayList uye_cinsiyet = new ArrayList();
        ArrayList uye_yas = new ArrayList();

        int sec;
        public Form1()
        {
            InitializeComponent();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            button2.Enabled = false;
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }
        void listele()
        {
                listBox1.Items.Clear();
                comboBox2.Items.Clear();
            for(int i=0; i<uye.Count; i++)
            {

                uye_yas.Add(numericUpDown8.Text).ToString();

                if (radioButton1.Checked == true) //kadın ise
                {
                   
                    uye_cinsiyet.Add(radioButton1.Text).ToString();
                    listBox1.Items.Add(uye[i].ToString() + " - " + uye_paket[i].ToString()+" - " + uye_cinsiyet[i].ToString()+" - " + uye_yas[i].ToString()+" Yaş ");
                    comboBox2.Items.Add(uye[i].ToString());

                } 
                else if (radioButton2.Checked == true)//erkek ise
                {
                    uye_cinsiyet.Add(radioButton2.Text).ToString();
                    listBox1.Items.Add(uye[i].ToString() + " - " + uye_paket[i].ToString() + " - " + uye_cinsiyet[i].ToString() + " - " + uye_yas[i].ToString() + " Yaş ");
                    comboBox2.Items.Add(uye[i].ToString());
                } 
                
            }
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            if (textBox1.Text == "") 
            {
                MessageBox.Show("Üye Bilgisi Girmediniz");
            }
            else 
            {
                
                
                uye.Add(textBox1.Text);
                uye_paket.Add(comboBox1.Text);
                if (comboBox1.Text == "1 ay") uye_kalangun.Add(30);
                else if (comboBox1.Text == "3 ay") uye_kalangun.Add(90);
                else if (comboBox1.Text == "6 ay") uye_kalangun.Add(120);
                else if (comboBox1.Text == "12 ay") uye_kalangun.Add(365);

                textBox1.Text = "";
                comboBox1.Text = "";
                button2.Enabled = true;
                listele();
                numericUpDown8.Value = 14;
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            sec = comboBox2.SelectedIndex;
            //listBox2.Items.Add(uye[sec].ToString());
            label7.Text = uye_cinsiyet[sec].ToString();
            label15.Text = "";
            label6.Text = "";

        }

        private void button2_Click(object sender, EventArgs e)
        {                                                       //Kaydedilen üye verilerini silme
            try
            {
                uye.RemoveAt(listBox1.SelectedIndex);
                uye_paket.RemoveAt(listBox1.SelectedIndex);
                uye_kalangun.RemoveAt(listBox1.SelectedIndex);
                uye_cinsiyet.RemoveAt(listBox1.SelectedIndex);
                listele();
                if (uye.Count == 0) button2.Enabled = false;
            }
            catch 
            {
                MessageBox.Show("Silmek İstediğiniz Üyeyi Seçmediniz");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Double boy, kilo, boyun, bel, basen, sonuc_vke, sonuc_vyo, v, a, b, c, d, p, f, g;

            boy = Convert.ToDouble(numericUpDown1.Value);
            kilo = Convert.ToDouble(textBox2.Text);
            boy = boy / 100;
            sonuc_vke = kilo / (boy * boy);
            sonuc_vke = Math.Round((sonuc_vke),2);
            label15.Text = sonuc_vke.ToString();
            
            boyun = Convert.ToDouble(textBox3.Text);
            bel = Convert.ToDouble(textBox4.Text);
            basen = Convert.ToDouble(textBox5.Text);

            basen = basen * 0.393701;
            boyun = boyun * 0.393701;
            bel = bel * 0.393701;
            boy = boy * 0.393701;
            v = 1.0324;
            a = 0.19077;
            b = 0.15456;
            c = 495;
            d = 450;
            p = 1.29579;
            f = 0.35004;
            g = 0.15456;

            if (label7.Text == "Erkek")
            {   
                sonuc_vyo = ((c / (v - a * Math.Log10(bel - boyun) + b * Math.Log10(boy)) - d)/10);
                sonuc_vyo = Math.Round((sonuc_vyo),2);
                label6.Text = sonuc_vyo.ToString();
                listBox2.Text = boyun.ToString();
                listBox2.Text = bel.ToString();
                listBox2.Text = boy.ToString();
            }
            else if (label7.Text == "Kadın")
            {
                sonuc_vyo = ((c / (p - f * Math.Log10(bel + basen - boyun) + g * Math.Log10(boy)) - d) / 10);
                sonuc_vyo = Math.Round((sonuc_vyo),2);
                label6.Text = sonuc_vyo.ToString();
                listBox2.Text = boyun.ToString();
                listBox2.Text = bel.ToString();
                listBox2.Text = boy.ToString();

            }

            numericUpDown1.Value = 0;
            textBox2.Text="";
            textBox3.Text="";
            textBox4.Text="";
            textBox5.Text="";

            listBox2.Items.Add(uye[sec].ToString() + " - " + uye_cinsiyet[sec].ToString());
            listBox2.Items.Add("Vücut Kitle Endeksi" + sonuc_vke.ToString());
            listBox2.Items.Add("Vücut Yağ Oranı" + label6.Text);
            
        }
    }
}
