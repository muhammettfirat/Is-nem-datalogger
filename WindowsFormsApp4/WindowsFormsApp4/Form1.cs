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
            timer3.Enabled = true;
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
        //    int sicaklik = Convert.ToInt32(textBox4.Text);
   decimal sicaklik = Convert.ToDecimal(dataTempHumid[0]);
   decimal sicaklik1 = Convert.ToDecimal(dataTempHumid[2]);
            if (sicaklik >250 )
            {
                groupBox1.BackColor = Color.Red;
SoundPlayer player = new SoundPlayer();//SoundPlayer nesnesi oluşturulur.
string path = Application.StartupPath.ToString() + "\\beep-10.wav"; // Ses dosyası Bin\\Debug içindeki yeri. Dosyayı Debug içinden aldım.
player.SoundLocation = path;//Ses dosyasının yolunu player a yükledik.
player.Play(); //Ses dosyasını çal.
                textBox8.Text = "Sıcak";
            }
            else
            {
                groupBox1.BackColor = Color.GreenYellow;
                textBox8.Clear();
            }
            if  (sicaklik <170)
            {
                groupBox1.BackColor = Color.Red;
                SoundPlayer player = new SoundPlayer();//SoundPlayer nesnesi oluşturulur.
                string path = Application.StartupPath.ToString() + "\\beep-10.wav"; // Ses dosyası Bin\\Debug içindeki yeri. Dosyayı Debug içinden aldım.
                player.SoundLocation = path;//Ses dosyasının yolunu player a yükledik.
                player.Play(); //Ses dosyasını çal.
                textBox8.Text = "Soğuk";
            }
            else
            {
               groupBox1.BackColor = Color.GreenYellow;
                textBox8.Clear();
            }
            if (sicaklik1 > 250)
            {
                groupBox3.BackColor = Color.Red;

                SoundPlayer player = new SoundPlayer();//SoundPlayer nesnesi oluşturulur.
                string path = Application.StartupPath.ToString() + "\\beep-10.wav"; // Ses dosyası Bin\\Debug içindeki yeri. Dosyayı Debug içinden aldım.
                player.SoundLocation = path;//Ses dosyasının yolunu player a yükledik.
                player.Play(); //Ses dosyasını çal.
                textBox9.Text = "Sıcak";
            }
            else
            {
               groupBox3.BackColor = Color.GreenYellow;
                textBox9.Clear();
            }
            if (sicaklik1 < 170)
            {
                groupBox3.BackColor = Color.Red;

                SoundPlayer player = new SoundPlayer();//SoundPlayer nesnesi oluşturulur.
                string path = Application.StartupPath.ToString() + "\\beep-10.wav"; // Ses dosyası Bin\\Debug içindeki yeri. Dosyayı Debug içinden aldım.
                player.SoundLocation = path;//Ses dosyasının yolunu player a yükledik.
                player.Play(); //Ses dosyasını çal.
                textBox9.Text = "Soğuk";
            }
            else
            {
                groupBox3.BackColor = Color.GreenYellow;
                textBox9.Clear();
            }
            textBox4.Text = dataFromArduino.Split('*')[0];
            textBox5.Text = dataFromArduino.Split('*')[1];
            textBox7.Text = dataFromArduino.Split('*')[2];
            textBox6.Text = dataFromArduino.Split('*')[3];
            //   textBox5.Text = dataTempHumid[1].ToString();
            // label4.Text = dataFromArduino+"";  
            //   decimal nem = Convert.ToDecimal(dataFromArduino.Split()[1]);
            //    textBox5.Text = nem.ToString(); 
            // label5.Text = dataFromArduino.Split(',')[0]+"%";
            //  textBox5.Text = dataFromArduino.Split(',')[1]+"C";
            serialPort1.DiscardInBuffer();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            textBox3.Text = DateTime.Now.ToLongTimeString();
            textBox2.Text = DateTime.Today.ToLongDateString();

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

    
        
        }

        

        private void timer3_Tick(object sender, EventArgs e)
        {
            StreamWriter dosya = File.AppendText("C:\\deneme.txt");
            //  dosya.Write(textBox2.Text+"--"+textBox3.Text+"--"+textBox4.Text+"--"+textBox1.Text+ "-\n");
            dosya.Write(textBox3.Text + "--" + textBox2.Text + "--" + textBox4.Text + "--" + textBox5.Text+ "--" + textBox4.Text + "--" + textBox5.Text + "--" + textBox8.Text + "--" + textBox7.Text + "--" + textBox6.Text+ "--" + textBox9.Text+ "-\n");
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
    }
}
