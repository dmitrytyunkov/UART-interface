using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UART_interface
{
    public partial class FormAbout : Form
    {
        public FormAbout()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Обработчик нажатия кнопки "ОК"
        /// </summary>
        /// <param name="sender">Отправитель события</param>
        /// <param name="e">Аргументы события</param>
        private void buttonOk_Click(object sender, EventArgs e)
        {
            Close(); // Закрытие окна
        }
    }
}
