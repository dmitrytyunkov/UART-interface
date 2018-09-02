using System;
using System.Windows.Forms;

namespace UART_interface
{
    public partial class FormSettings : Form
    {
        public FormSettings()
        {
            InitializeComponent();
            // ---------- Инициализация начальных значений ----------
            comboBoxPortName.SelectedIndex =  
                comboBoxPortName.Items.IndexOf(SerialPortSettings.GetStringPortName());
            comboBoxParity.SelectedIndex = 
                comboBoxParity.Items.IndexOf(SerialPortSettings.GetStringParity());
            comboBoxStopBits.SelectedIndex = 
                comboBoxStopBits.Items.IndexOf(SerialPortSettings.GetStringStopBits());
            comboBoxDataBits.SelectedIndex = 
                comboBoxDataBits.Items.IndexOf(SerialPortSettings.GetStringDataBits());
            comboBoxBaudRate.SelectedIndex = 
                comboBoxBaudRate.Items.IndexOf(SerialPortSettings.GetStringBaudRate());
            comboBoxBufferSize.SelectedIndex = 
                comboBoxBufferSize.Items.IndexOf(SerialPortSettings.GetStringBufferSize());
            // ------------------------------------------------------
        }

        /// <summary>
        /// Обработчик нажатия кнопки "Сохранить"
        /// </summary>
        /// <param name="sender">Отправитель события</param>
        /// <param name="e">Аргументы события</param>
        private void buttonSave_Click(object sender, EventArgs e)
        {
            SerialPortSettings.WriteSettings(comboBoxPortName.Items[comboBoxPortName.SelectedIndex],
                comboBoxParity.Items[comboBoxParity.SelectedIndex],
                comboBoxStopBits.Items[comboBoxStopBits.SelectedIndex],
                comboBoxBaudRate.Items[comboBoxBaudRate.SelectedIndex],
                comboBoxDataBits.Items[comboBoxDataBits.SelectedIndex],
                comboBoxBufferSize.Items[comboBoxBufferSize.SelectedIndex]); // Запись новых настроек
            Close(); // Закрытие окна
        }

        /// <summary>
        /// Обработчик нажатия кнопки "Отмена"
        /// </summary>
        /// <param name="sender">Отправитель события</param>
        /// <param name="e">Аргументы события</param>
        private void buttonCancle_Click(object sender, EventArgs e)
        {
            Close(); // Закрытие окна
        }
    }
}
