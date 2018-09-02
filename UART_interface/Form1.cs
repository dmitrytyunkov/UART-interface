using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UART_interface
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
            try
            {
                serialPortUART.Open();
            }
            catch (System.IO.IOException ex)
            {
                richTextBoxMainOut.AppendText("Невозможно открыть последовательный порт: " + ex.Message + Environment.NewLine);
            }
        }


        #region Обработчики команд по UART пока на кнопках
        private void button1_Click(object sender, EventArgs e)
        {
            richTextBoxMainOut.SelectionColor = Color.Red;
            richTextBoxMainOut.AppendText("ВНИМАНИЕ!!! Обнаруженно движение с ЗАПАДНОЙ стороны периметра" + Environment.NewLine);
            richTextBoxMainOut.SelectionStart = richTextBoxMainOut.Text.Length;
            richTextBoxMainOut.ScrollToCaret();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            richTextBoxMainOut.SelectionColor = Color.Red;
            richTextBoxMainOut.AppendText("ВНИМАНИЕ!!! Обнаруженно движение с ВОСТОЧНОЙ стороны периметра" + Environment.NewLine);
            richTextBoxMainOut.SelectionStart = richTextBoxMainOut.Text.Length;
            richTextBoxMainOut.ScrollToCaret();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            richTextBoxMainOut.SelectionColor = Color.Green;
            richTextBoxMainOut.AppendText("Шлакбаум ОТКРЫТ" + Environment.NewLine);
            richTextBoxMainOut.SelectionStart = richTextBoxMainOut.Text.Length;
            richTextBoxMainOut.ScrollToCaret();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            richTextBoxMainOut.SelectionColor = Color.Green;
            richTextBoxMainOut.AppendText("Шлакбаум ЗАКРЫТ" + Environment.NewLine);
            richTextBoxMainOut.SelectionStart = richTextBoxMainOut.Text.Length;
            richTextBoxMainOut.ScrollToCaret();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            richTextBoxMainOut.SelectionColor = Color.Red;
            richTextBoxMainOut.AppendText("ВНИМАНИЕ!!! Обнаруженна сейсмическая активность на ЮЖНОЙ стороне периметра" + Environment.NewLine);
            richTextBoxMainOut.SelectionStart = richTextBoxMainOut.Text.Length;
            richTextBoxMainOut.ScrollToCaret();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            richTextBoxMainOut.SelectionColor = Color.Green;
            richTextBoxMainOut.AppendText("Машина подъехала к въезду на охраняемый периметр" + Environment.NewLine);
            richTextBoxMainOut.SelectionStart = richTextBoxMainOut.Text.Length;
            richTextBoxMainOut.ScrollToCaret();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            richTextBoxMainOut.SelectionColor = Color.Green;
            richTextBoxMainOut.AppendText("Машина въехала на охраняемый периметр" + Environment.NewLine);
            richTextBoxMainOut.SelectionStart = richTextBoxMainOut.Text.Length;
            richTextBoxMainOut.ScrollToCaret();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            richTextBoxMainOut.SelectionColor = Color.Green;
            richTextBoxMainOut.AppendText("Машина подъехала к выезду с охраняемого периметра" + Environment.NewLine);
            richTextBoxMainOut.SelectionStart = richTextBoxMainOut.Text.Length;
            richTextBoxMainOut.ScrollToCaret();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            richTextBoxMainOut.SelectionColor = Color.Green;
            richTextBoxMainOut.AppendText("Машина выехала с охраняемого периметра" + Environment.NewLine);
            richTextBoxMainOut.SelectionStart = richTextBoxMainOut.Text.Length;
            richTextBoxMainOut.ScrollToCaret();
        }
        #endregion

        #region Обработчик команд UART
        private void serialPortUART_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            this.Invoke(new EventHandler(DoUpdate));
        }

        private void DoUpdate(object sender, EventArgs e)
        {
            switch(serialPortUART.ReadLine())
            {
                case "MOVE_DETECT_WEST":
                    richTextBoxMainOut.SelectionColor = Color.Red;
                    richTextBoxMainOut.AppendText("ВНИМАНИЕ!!! Обнаруженно движение с ЗАПАДНОЙ стороны периметра" + Environment.NewLine);
                    richTextBoxMainOut.SelectionStart = richTextBoxMainOut.Text.Length;
                    richTextBoxMainOut.ScrollToCaret();
                    break;
                case "MOVE_DETECT_EAST":
                    richTextBoxMainOut.SelectionColor = Color.Red;
                    richTextBoxMainOut.AppendText("ВНИМАНИЕ!!! Обнаруженно движение с ВОСТОЧНОЙ стороны периметра" + Environment.NewLine);
                    richTextBoxMainOut.SelectionStart = richTextBoxMainOut.Text.Length;
                    richTextBoxMainOut.ScrollToCaret();
                    break;
                case "BUZZ_DETECT":
                    richTextBoxMainOut.SelectionColor = Color.Red;
                    richTextBoxMainOut.AppendText("ВНИМАНИЕ!!! Обнаруженна сейсмическая активность на ЮЖНОЙ стороне периметра" + Environment.NewLine);
                    richTextBoxMainOut.SelectionStart = richTextBoxMainOut.Text.Length;
                    richTextBoxMainOut.ScrollToCaret();
                    break;
                case "DOOR_OPENING":
                    richTextBoxMainOut.SelectionColor = Color.Green;
                    richTextBoxMainOut.AppendText("Шлакбаум ОТКРЫТ" + Environment.NewLine);
                    richTextBoxMainOut.SelectionStart = richTextBoxMainOut.Text.Length;
                    richTextBoxMainOut.ScrollToCaret();
                    break;
                case "DOOR_CLOSING":
                    richTextBoxMainOut.SelectionColor = Color.Green;
                    richTextBoxMainOut.AppendText("Шлакбаум ЗАКРЫТ" + Environment.NewLine);
                    richTextBoxMainOut.SelectionStart = richTextBoxMainOut.Text.Length;
                    richTextBoxMainOut.ScrollToCaret();
                    break;
                case "CAR_AT_ENTRANCE":
                    richTextBoxMainOut.SelectionColor = Color.Green;
                    richTextBoxMainOut.AppendText("Машина подъехала к въезду на охраняемый периметр" + Environment.NewLine);
                    richTextBoxMainOut.SelectionStart = richTextBoxMainOut.Text.Length;
                    richTextBoxMainOut.ScrollToCaret();
                    break;
                case "CAR_MOVED_IN":
                    richTextBoxMainOut.SelectionColor = Color.Green;
                    richTextBoxMainOut.AppendText("Машина въехала на охраняемый периметр" + Environment.NewLine);
                    richTextBoxMainOut.SelectionStart = richTextBoxMainOut.Text.Length;
                    richTextBoxMainOut.ScrollToCaret();
                    break;
                case "CAR_AT_EXIT":
                    richTextBoxMainOut.SelectionColor = Color.Green;
                    richTextBoxMainOut.AppendText("Машина подъехала к выезду с охраняемого периметра" + Environment.NewLine);
                    richTextBoxMainOut.SelectionStart = richTextBoxMainOut.Text.Length;
                    richTextBoxMainOut.ScrollToCaret();
                    break;
                case "CAR_LEFT":
                    richTextBoxMainOut.SelectionColor = Color.Green;
                    richTextBoxMainOut.AppendText("Машина выехала с охраняемого периметра" + Environment.NewLine);
                    richTextBoxMainOut.SelectionStart = richTextBoxMainOut.Text.Length;
                    richTextBoxMainOut.ScrollToCaret();
                    break;
            }
        }
        #endregion

        private void buttonSettings_Click(object sender, EventArgs e)
        {
            if (serialPortUART.IsOpen)
                serialPortUART.Close();
            FormSettings formSettings = new FormSettings();
            formSettings.ShowDialog(); // Отображение окна для настройки последовательного порта
            serialPortUART = SerialPortSettings.ReadSettings(serialPortUART); // Применение новых настроек
            try
            {
                serialPortUART.Open();
            }
            catch (System.IO.IOException ex)
            {
                richTextBoxMainOut.AppendText("Невозможно открыть последовательный порт: " + ex.Message + Environment.NewLine);
            }
        }
    }
}
