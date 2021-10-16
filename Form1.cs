using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.IO.Ports;
using System.Media;

namespace WindowsFormsApp4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }
        SoundPlayer player = new SoundPlayer();//SoundPlayer nesnesi oluşturulur.
        private void Form1_Load(object sender, EventArgs e)
        {
            string[] ports = SerialPort.GetPortNames();
            foreach (string port in ports)
            {
                comboBox1.Items.Add(port);
            }
            timer2.Enabled = true;
            timer3.Enabled = false;
            SoundPlayer player = new SoundPlayer();//SoundPlayer nesnesi oluşturulur.
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string x = comboBox1.SelectedItem.ToString();
            serialPort1.PortName = x;
            serialPort1.BaudRate = 2000000;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Interval = 1200;
            string dataFromArduino = serialPort1.ReadExisting().ToString();
            string[] dataTempHumid = dataFromArduino.Split('*');



    //BURASI ALARM İÇİN TANIMLAMA YAPILAN YER   
   decimal sicaklik = Convert.ToDecimal(dataTempHumid[0]); // İLK KANAL ALARM SICAKLIK   (DOLUM)
   decimal sicaklik1 = Convert.ToDecimal(dataTempHumid[2]); // İKİNCİ KANAL ALARM SICAKLIK (İMALAT)
   decimal sicaklik2 = Convert.ToDecimal(dataTempHumid[4]); //ÜÇÜNCÜ KANAL ALARM SICAKLIK (IPK)
   decimal sicaklik3 = Convert.ToDecimal(dataTempHumid[6]);// DÖRDÜNCÜ KANAL ALARM SICAKLIK (KORİDOR)


            // POMAT DOLUM İÇİN ALARM AYARLAMALARI

            //SICAK İÇİN

            if (sicaklik >250 )
            {
                groupBox1.BackColor = Color.Red;//BURAYI DEĞİŞTİR
                SoundPlayer player = new SoundPlayer();//SoundPlayer nesnesi oluşturulur.
                string path = Application.StartupPath.ToString() + "\\beep-10.wav"; // Ses dosyası Bin\\Debug içindeki yeri. Dosyayı Debug içinden aldım.
                player.SoundLocation = path;//Ses dosyasının yolunu player a yükledik.
                player.Play(); //Ses dosyasını çal.
                textBox8.Text = "Sıcak";//BURAYI DEĞİŞTİR
            }
            else
            {
                groupBox1.BackColor = Color.GreenYellow;//BURAYI DEĞİŞTİR
                textBox8.Clear(); //BURAYI DEĞİŞTİR
                textBox8.Text= "Uygun"; //BURAYI DEĞİŞTİR

            }

            //SOĞUK İÇİN

            if  (sicaklik <170)
            {
                groupBox1.BackColor = Color.Red;//BURAYI DEĞİŞTİR
                SoundPlayer player = new SoundPlayer();//SoundPlayer nesnesi oluşturulur.
                string path = Application.StartupPath.ToString() + "\\beep-10.wav"; // Ses dosyası Bin\\Debug içindeki yeri. Dosyayı Debug içinden aldım.
                player.SoundLocation = path;//Ses dosyasının yolunu player a yükledik.
                player.Play(); //Ses dosyasını çal.
                textBox8.Text = "Soğuk";//BURAYI DEĞİŞTİR
            }
            else
            {
               groupBox1.BackColor = Color.GreenYellow;//BURAYI DEĞİŞTİR
                textBox8.Clear();//BURAYI DEĞİŞTİR
                textBox8.Text = "Uygun";//BURAYI DEĞİŞTİR

            }


            //POMAT İMALAT İÇİN ALARM AYARLAMALARI

            //SICAK İÇİN

            if (sicaklik1 > 250)
            {
                groupBox3.BackColor = Color.Red;//BURAYI DEĞİŞTİR

                SoundPlayer player = new SoundPlayer();//SoundPlayer nesnesi oluşturulur.
                string path = Application.StartupPath.ToString() + "\\beep-10.wav"; // Ses dosyası Bin\\Debug içindeki yeri. Dosyayı Debug içinden aldım.
                player.SoundLocation = path;//Ses dosyasının yolunu player a yükledik.
                player.Play(); //Ses dosyasını çal.
                textBox9.Text = "Sıcak"; //BURAYI DEĞİŞTİR
            }
            else
            {
               groupBox3.BackColor = Color.GreenYellow;//BURAYI DEĞİŞTİR
                textBox9.Clear(); //BURAYI DEĞİŞTİR
                textBox9.Text = "Uygun";//BURAYI DEĞİŞTİR
            }

            //SOĞUK İÇİN

            if (sicaklik1 < 170)
            {
                groupBox3.BackColor = Color.Red; //BURAYI DEĞİŞTİR

                SoundPlayer player = new SoundPlayer();//SoundPlayer nesnesi oluşturulur.
                string path = Application.StartupPath.ToString() + "\\beep-10.wav"; // Ses dosyası Bin\\Debug içindeki yeri. Dosyayı Debug içinden aldım.
                player.SoundLocation = path;//Ses dosyasının yolunu player a yükledik.
                player.Play(); //Ses dosyasını çal.
                textBox9.Text = "Soğuk"; //BURAYI DEĞİŞTİR
            }
            else
            {
                groupBox3.BackColor = Color.GreenYellow; //BURAYI DEĞİŞTİR
                textBox9.Clear(); //BURAYI DEĞİŞTİR
                textBox9.Text = "Uygun";//BURAYI DEĞİŞTİR
            }

     ////////////IPK İÇİN ALARM AYARLAMALARI////////////////////////

            //SICAK İÇİN

            if (sicaklik1 > 250)
            {
                groupBox4.BackColor = Color.Red; //BURAYI DEĞİŞTİR

                SoundPlayer player = new SoundPlayer();//SoundPlayer nesnesi oluşturulur.
                string path = Application.StartupPath.ToString() + "\\beep-10.wav"; // Ses dosyası Bin\\Debug içindeki yeri. Dosyayı Debug içinden aldım.
                player.SoundLocation = path;//Ses dosyasının yolunu player a yükledik.
                player.Play(); //Ses dosyasını çal.
                textBox10.Text = "Sıcak";
            }
            else
            {
                groupBox4.BackColor = Color.GreenYellow;//BURAYI DEĞİŞTİR
                textBox10.Clear(); //BURAYI DEĞİŞTİR
                textBox10.Text = "Uygun"; //BURAYI DEĞİŞTİR
            }

            //SOĞUK İÇİN

            if (sicaklik1 < 170)
            {
                groupBox4.BackColor = Color.Red; //BURAYI DEĞİŞTİR

                SoundPlayer player = new SoundPlayer();//SoundPlayer nesnesi oluşturulur.
                string path = Application.StartupPath.ToString() + "\\beep-10.wav"; // Ses dosyası Bin\\Debug içindeki yeri. Dosyayı Debug içinden aldım.
                player.SoundLocation = path;//Ses dosyasının yolunu player a yükledik.
                player.Play(); //Ses dosyasını çal.
                textBox10.Text = "Soğuk";  //BURAYI DEĞİŞTİR
            }
            else
            {
                groupBox4.BackColor = Color.GreenYellow; //BURAYI DEĞİŞTİR
                textBox10.Clear();  //BURAYI DEĞİŞTİR
                textBox10.Text = "Uygun"; //BURAYI DEĞİŞTİR
            }



            ////////////POMAT KORİDOR İÇİN ALARM AYARLAMALARI////////////////////////

            //SICAK İÇİN

            if (sicaklik1 > 250)
            {
                groupBox5.BackColor = Color.Red; //BURAYI DEĞİŞTİR

                SoundPlayer player = new SoundPlayer();//SoundPlayer nesnesi oluşturulur.
                string path = Application.StartupPath.ToString() + "\\beep-10.wav"; // Ses dosyası Bin\\Debug içindeki yeri. Dosyayı Debug içinden aldım.
                player.SoundLocation = path;//Ses dosyasının yolunu player a yükledik.
                player.Play(); //Ses dosyasını çal.
                textBox13.Text = "Sıcak";
            }
            else
            {
                groupBox5.BackColor = Color.GreenYellow;//BURAYI DEĞİŞTİR
                textBox13.Clear(); //BURAYI DEĞİŞTİR
                textBox13.Text = "Uygun"; //BURAYI DEĞİŞTİR
            }

            //SOĞUK İÇİN

            if (sicaklik1 < 170)
            {
                groupBox5.BackColor = Color.Red; //BURAYI DEĞİŞTİR

                SoundPlayer player = new SoundPlayer();//SoundPlayer nesnesi oluşturulur.
                string path = Application.StartupPath.ToString() + "\\beep-10.wav"; // Ses dosyası Bin\\Debug içindeki yeri. Dosyayı Debug içinden aldım.
                player.SoundLocation = path;//Ses dosyasının yolunu player a yükledik.
                player.Play(); //Ses dosyasını çal.
                textBox13.Text = "Soğuk";  //BURAYI DEĞİŞTİR
            }
            else
            {
                groupBox5.BackColor = Color.GreenYellow; //BURAYI DEĞİŞTİR
                textBox13.Clear();  //BURAYI DEĞİŞTİR
                textBox13.Text = "Uygun"; //BURAYI DEĞİŞTİR
            }





            //POMAT DOLUM

            textBox4.Text = dataFromArduino.Split('*')[0];
            textBox5.Text = dataFromArduino.Split('*')[1];

            //POMAT İMALAT

            textBox7.Text = dataFromArduino.Split('*')[2];
            textBox6.Text = dataFromArduino.Split('*')[3];

            //IPK ODASI

            textBox7.Text = dataFromArduino.Split('*')[4];
            textBox6.Text = dataFromArduino.Split('*')[5];

            //POMAT KORİDOR

            textBox7.Text = dataFromArduino.Split('*')[6];
            textBox6.Text = dataFromArduino.Split('*')[7];


         
            serialPort1.DiscardInBuffer();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            textBox3.Text = DateTime.Now.ToLongTimeString();
            textBox2.Text = DateTime.Today.ToShortDateString();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            try
            {
                if (!serialPort1.IsOpen)
                    serialPort1.Open();
            }
            catch
            {
                MessageBox.Show("Seri Port Seçin!");
            }
            StreamWriter dosya = File.AppendText("D:\\deneme.txt");
            //  dosya.Write(textBox2.Text+"--"+textBox3.Text+"--"+textBox4.Text+"--"+textBox1.Text+ "-\n");
            dosya.Write("Tarih"+"---------"+"Saat" + "---" + "K1sıc" + "-" + "Alrm" + "-" + "K1nem" + "-" + "K2sıc" + "-" + "Alrm" + "--" + "K2nem" + "K3sıc" + "-" + "Alrm" + "--" + "K3nem" + "K4sıc" + "-" + "Alrm" + "--" + "K4nem" + Environment.NewLine);
            dosya.Close();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            timer1.Stop();
          //  serialPort1.DiscardInBuffer();
            serialPort1.Close();
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {


            timer3.Start();
        }

        

        private void timer3_Tick(object sender, EventArgs e)
        {
            StreamWriter dosya = File.AppendText("D:\\deneme.txt");
            //  dosya.Write(textBox2.Text+"--"+textBox3.Text+"--"+textBox4.Text+"--"+textBox1.Text+ "-\n");
            dosya.Write(textBox2.Text + "--" + textBox3.Text + "--" + textBox4.Text + "--" + textBox8.Text + "--" + textBox5.Text + "--" + textBox7.Text + "--" + textBox9.Text + "--" + textBox6.Text + "--" + textBox12.Text+ "--" + textBox10.Text+ "--" + textBox11.Text+ "--" + textBox15.Text + "--" + textBox13.Text+ "--" + textBox14.Text+ Environment.NewLine);
            dosya.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            for (int i = 0; i <= 10; i++) 
            { player.Stop(); }
            
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }
    }
}
