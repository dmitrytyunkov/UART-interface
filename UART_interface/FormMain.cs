using System;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Windows.Forms;

namespace UART_interface
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            bool portExist = false; // Найден ли существующий последовательный порт
            InitializeComponent();

            buttonOpenClose.Location = new Point(Width / 2 - buttonOpenClose.Width / 2, buttonOpenClose.Location.Y); // Размещаем кнопку открытия/закрытия порта по центру окна

            // Перебераем все существующие порты
            foreach (var port in SerialPort.GetPortNames())
            {
                portExist = true; // Существующий порт найден
                SerialPortSettings.SetStringPortName(port); // Сохраняем имя порта
                break; // Перестаем перебирать если нашли хоть один существующий порт
            }
            SerialPortSettings.SetIsChanged(true); // Установить в true чтобы применить начальные настройки
            serialPortUART = SerialPortSettings.ReadSettings(serialPortUART); // Задаем новые настройки порта
            // Проверяем был ли найден хоть один порт
            if (portExist)
                try
                {
                    serialPortUART.Open(); // Попытка открыть порт
                    richTextBoxMainOut.AppendText(DateTime.Now.ToString("G") +
                        ": Центральный узел подключен, узел расположен на порту " +
                        serialPortUART.PortName + Environment.NewLine); // Вывод в лог сообщения с указанием текущей даты и времени
                    richTextBoxMainOut.SelectionStart = richTextBoxMainOut.Text.Length; // Перенос каретки в конец текста
                    richTextBoxMainOut.ScrollToCaret(); // Прокрутка текстового поля к каретке
                    portExist = false; // Сбрасываем найденый порт
                }
                catch (Exception ex)
                {
                    richTextBoxMainOut.AppendText(DateTime.Now.ToString("G") +
                        ": Невозможно открыть последовательный порт: " + ex.Message +
                        Environment.NewLine); // Вывод в лог сообщения с указанием текущей даты и времени
                    richTextBoxMainOut.SelectionStart = richTextBoxMainOut.Text.Length; // Перенос каретки в конец текста
                    richTextBoxMainOut.ScrollToCaret(); // Прокрутка текстового поля к каретке
                }
            else
            {
                richTextBoxMainOut.AppendText(DateTime.Now.ToString("G") +
                        ": Центральный узел системы не подключен к компьютеру, подключите центральный узел и выполните настройку программы" +
                        Environment.NewLine); // Вывод в лог сообщения с указанием текущей даты и времени
                richTextBoxMainOut.SelectionStart = richTextBoxMainOut.Text.Length; // Перенос каретки в конец текста
                richTextBoxMainOut.ScrollToCaret(); // Прокрутка текстового поля к каретке
            }

            // Проверяем открыт ли последовательный порт
            if(serialPortUART.IsOpen)
                buttonOpenClose.Text = "Закрыть порт"; // Если порт открыт выводим на кнопке надпись о закрытии порта
            else
                buttonOpenClose.Text = "Открыть порт"; // Если порт закрыт выводим на кнопке надпись об открытии порта
        }


        /// <summary>
        /// Обработчик новых данных поступивших на последовательный порт
        /// </summary>
        /// <param name="sender">Отправитель события</param>
        /// <param name="e">Аргументы события</param>
        private void serialPortUART_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            this.Invoke(new EventHandler(DoUpdate)); // Порождение в текущем потоке нового обработчика события
        }

        /// <summary>
        /// Обработчик событий для обновления данных
        /// </summary>
        /// <param name="sender">Отправитель события</param>
        /// <param name="e">Аргументы события</param>
        private void DoUpdate(object sender, EventArgs e)
        {
            try
            {
                // Вывод текста в лог в зависимости от пришедшего на последовательный порт сообщения
                switch (serialPortUART.ReadLine())
                {
                    case "MOVE_DETECT_WEST":
                        richTextBoxMainOut.SelectionColor = Color.Red; // Задание цвета вывода текста в лог
                        richTextBoxMainOut.AppendText(DateTime.Now.ToString("G") +
                            ": ВНИМАНИЕ!!! Обнаруженно движение с ЗАПАДНОЙ стороны периметра" +
                            Environment.NewLine); // Вывод в лог сообщения с указанием текущей даты и времени
                        richTextBoxMainOut.SelectionStart = richTextBoxMainOut.Text.Length; // Перенос каретки в конец текста
                        richTextBoxMainOut.ScrollToCaret(); // Прокрутка текстового поля к каретке
                        break;
                    case "MOVE_DETECT_EAST":
                        richTextBoxMainOut.SelectionColor = Color.Red; // Задание цвета вывода текста в лог
                        richTextBoxMainOut.AppendText(DateTime.Now.ToString("G") +
                            ": ВНИМАНИЕ!!! Обнаруженно движение с ВОСТОЧНОЙ стороны периметра" +
                            Environment.NewLine); // Вывод в лог сообщения с указанием текущей даты и времени
                        richTextBoxMainOut.SelectionStart = richTextBoxMainOut.Text.Length; // Перенос каретки в конец текста
                        richTextBoxMainOut.ScrollToCaret(); // Прокрутка текстового поля к каретке
                        break;
                    case "BUZZ_DETECT":
                        richTextBoxMainOut.SelectionColor = Color.Red; // Задание цвета вывода текста в лог
                        richTextBoxMainOut.AppendText(DateTime.Now.ToString("G") +
                            ": ВНИМАНИЕ!!! Обнаруженна сейсмическая активность на ЮЖНОЙ стороне периметра" +
                            Environment.NewLine); // Вывод в лог сообщения с указанием текущей даты и времени
                        richTextBoxMainOut.SelectionStart = richTextBoxMainOut.Text.Length; // Перенос каретки в конец текста
                        richTextBoxMainOut.ScrollToCaret(); // Прокрутка текстового поля к каретке
                        break;
                    case "DOOR_OPENING":
                        richTextBoxMainOut.SelectionColor = Color.Green; // Задание цвета вывода текста в лог
                        richTextBoxMainOut.AppendText(DateTime.Now.ToString("G") +
                            ": Шлагбаум ОТКРЫТ" +
                            Environment.NewLine); // Вывод в лог сообщения с указанием текущей даты и времени
                        richTextBoxMainOut.SelectionStart = richTextBoxMainOut.Text.Length; // Перенос каретки в конец текста
                        richTextBoxMainOut.ScrollToCaret(); // Прокрутка текстового поля к каретке
                        break;
                    case "DOOR_CLOSING":
                        richTextBoxMainOut.SelectionColor = Color.Green; // Задание цвета вывода текста в лог
                        richTextBoxMainOut.AppendText(DateTime.Now.ToString("G") +
                            ": Шлагбаум ЗАКРЫТ" +
                            Environment.NewLine); // Вывод в лог сообщения с указанием текущей даты и времени
                        richTextBoxMainOut.SelectionStart = richTextBoxMainOut.Text.Length; // Перенос каретки в конец текста
                        richTextBoxMainOut.ScrollToCaret(); // Прокрутка текстового поля к каретке
                        break;
                    case "CAR_AT_ENTRANCE":
                        richTextBoxMainOut.SelectionColor = Color.Green; // Задание цвета вывода текста в лог
                        richTextBoxMainOut.AppendText(DateTime.Now.ToString("G") +
                            ": Машина подъехала к въезду на охраняемый периметр" +
                            Environment.NewLine); // Вывод в лог сообщения с указанием текущей даты и времени
                        richTextBoxMainOut.SelectionStart = richTextBoxMainOut.Text.Length; // Перенос каретки в конец текста
                        richTextBoxMainOut.ScrollToCaret(); // Прокрутка текстового поля к каретке
                        break;
                    case "CAR_MOVED_IN":
                        richTextBoxMainOut.SelectionColor = Color.Green; // Задание цвета вывода текста в лог
                        richTextBoxMainOut.AppendText(DateTime.Now.ToString("G") +
                            ": Машина въехала на охраняемый периметр" +
                            Environment.NewLine); // Вывод в лог сообщения с указанием текущей даты и времени
                        richTextBoxMainOut.SelectionStart = richTextBoxMainOut.Text.Length; // Перенос каретки в конец текста
                        richTextBoxMainOut.ScrollToCaret(); // Прокрутка текстового поля к каретке
                        break;
                    case "CAR_AT_EXIT":
                        richTextBoxMainOut.SelectionColor = Color.Green; // Задание цвета вывода текста в лог
                        richTextBoxMainOut.AppendText(DateTime.Now.ToString("G") +
                            ": Машина подъехала к выезду с охраняемого периметра" +
                            Environment.NewLine); // Вывод в лог сообщения с указанием текущей даты и времени
                        richTextBoxMainOut.SelectionStart = richTextBoxMainOut.Text.Length; // Перенос каретки в конец текста
                        richTextBoxMainOut.ScrollToCaret(); // Прокрутка текстового поля к каретке
                        break;
                    case "CAR_LEFT":
                        richTextBoxMainOut.SelectionColor = Color.Green; // Задание цвета вывода текста в лог
                        richTextBoxMainOut.AppendText(DateTime.Now.ToString("G") +
                            ": Машина выехала с охраняемого периметра" +
                            Environment.NewLine); // Вывод в лог сообщения с указанием текущей даты и времени
                        richTextBoxMainOut.SelectionStart = richTextBoxMainOut.Text.Length; // Перенос каретки в конец текста
                        richTextBoxMainOut.ScrollToCaret(); // Прокрутка текстового поля к каретке
                        break;
                }
            }
            catch (IOException ex)
            {
                buttonOpenClose.Text = "Открыть порт";
                richTextBoxMainOut.AppendText(DateTime.Now.ToString("G") +
                            ": Центральный узел ОТКЛЮЧЕН. Подключите центральный узел, выполните настройку программы и продолжайте работу" +
                            Environment.NewLine); // Вывод в лог сообщения с указанием текущей даты и времени
                richTextBoxMainOut.SelectionStart = richTextBoxMainOut.Text.Length; // Перенос каретки в конец текста
                richTextBoxMainOut.ScrollToCaret(); // Прокрутка текстового поля к каретке
            }

            // Проверяем открыт ли последовательный порт и необходимо ли изменить надпись на кнопке
            if (serialPortUART.IsOpen && buttonOpenClose.Text.Equals("Открыть порт"))
                buttonOpenClose.Text = "Закрыть порт"; // Если порт открыт выводим на кнопке надпись о закрытии порта
            else if (!serialPortUART.IsOpen && buttonOpenClose.Text.Equals("Закрыть порт"))
                buttonOpenClose.Text = "Открыть порт"; // Если порт закрыт выводим на кнопке надпись об открытии порта
        }

        /// <summary>
        /// Обработчик нажатия кнопки "Настройки"
        /// </summary>
        /// <param name="sender">Отправитель события</param>
        /// <param name="e">>Аргументы события</param>
        private void buttonSettings_Click(object sender, EventArgs e)
        {
            // Проверка открыт ли порт
            if (serialPortUART.IsOpen)
            {
                serialPortUART.Close(); // Закрытие порта если он открыт
                buttonOpenClose.Text = "Закрыть порт"; // Если порт открыт выводим на кнопке надпись о закрытии порта
            }

            FormSettings formSettings = new FormSettings(); // Создание нового экземпляра окна настроек
            formSettings.ShowDialog(); // Отображение окна для настройки последовательного порта
            serialPortUART = SerialPortSettings.ReadSettings(serialPortUART); // Применение новых настроек
            try
            {
                serialPortUART.Open(); // Попытка открытия последовательного порта с новыми настройками
                richTextBoxMainOut.AppendText(DateTime.Now.ToString("G") +
                    ": Центральный узел подключен, узел расположен на порту " + 
                    serialPortUART.PortName + Environment.NewLine); // Вывод в лог сообщения с указанием текущей даты и времени
                richTextBoxMainOut.SelectionStart = richTextBoxMainOut.Text.Length; // Перенос каретки в конец текста
                richTextBoxMainOut.ScrollToCaret(); // Прокрутка текстового поля к каретке
            }
            catch (Exception ex)
            {
                richTextBoxMainOut.AppendText(DateTime.Now.ToString("G") +
                    ": Невозможно открыть последовательный порт: " + ex.Message +
                    Environment.NewLine); // Вывод в лог сообщения с указанием текущей даты и времени
                richTextBoxMainOut.SelectionStart = richTextBoxMainOut.Text.Length; // Перенос каретки в конец текста
                richTextBoxMainOut.ScrollToCaret(); // Прокрутка текстового поля к каретке
            }

            // Проверяем открыт ли последовательный порт и необходимо ли изменить надпись на кнопке
            if (serialPortUART.IsOpen && buttonOpenClose.Text.Equals("Открыть порт"))
                buttonOpenClose.Text = "Закрыть порт"; // Если порт открыт выводим на кнопке надпись о закрытии порта
            else if (!serialPortUART.IsOpen && buttonOpenClose.Text.Equals("Закрыть порт"))
                buttonOpenClose.Text = "Открыть порт"; // Если порт закрыт выводим на кнопке надпись об открытии порта
        }

        /// <summary>
        /// Обработчик нажатия кнопки "Очистить лог"
        /// </summary>
        /// <param name="sender">Отправитель события</param>
        /// <param name="e">Аргументы события</param>
        private void buttonClear_Click(object sender, EventArgs e)
        {
            richTextBoxMainOut.Clear(); // Очистка текстового поля
        }

        /// <summary>
        /// Обработчик нажатия кнопки "Сохранить лог"
        /// </summary>
        /// <param name="sender">Отправитель события</param>
        /// <param name="e">Аргументы события</param>
        private void buttonSave_Click(object sender, EventArgs e)
        {
            // Проверка на существование дирректории
            if (!Directory.Exists("logs"))
                Directory.CreateDirectory("logs"); // Создание дирректории для сохранения логов

            string path = ("logs/" + DateTime.Now.ToString("G") + ".log").Replace(":", "-"); // Путь для сохранения лог-файла, в качестве имени файла используется текущая дата и время
            File.WriteAllLines(path, richTextBoxMainOut.Lines); // Запись всего содержимого текстового поля в файл
            // Проверка на существование файла
            if (File.Exists(path)) 
                MessageBox.Show("Лог-файл успешно сохранен по адресу: " + 
                    Path.GetFullPath(path), "Сохранение...", MessageBoxButtons.OK, 
                    MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1, 
                    MessageBoxOptions.DefaultDesktopOnly); // Вывод сообщения об успешном сохранении файла, с указанием полного пути до него
            else
                MessageBox.Show("Сохранить лог-файл не удалось", "Сохранение...", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error, 
                    MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly); // Вывод сообщения о не успешном сохранении файла
        }

        /// <summary>
        /// Обработчик нажатия кнопки "О приложении..."
        /// </summary>
        /// <param name="sender">Отправитель события</param>
        /// <param name="e">Аргументы события</param>
        private void buttonAbout_Click(object sender, EventArgs e)
        {
            FormAbout formAbout = new FormAbout(); // Создание нового экземпляра окна "О приложении..."
            formAbout.Show(); // Отображение окна "О приложении..."
        }

        /// <summary>
        /// Обработчик закрытия окна приложения
        /// </summary>
        /// <param name="sender">Отправитель события</param>
        /// <param name="e">Аргументы события</param>
        private void FormMain_FormClosing(object sender, EventArgs e)
        {
            if (serialPortUART.IsOpen)
                serialPortUART.Close();
        }

        private void buttonOpenClose_Click(object sender, EventArgs e)
        {
            Button button = sender as Button; // Определяем отправителя сообщения как кнопку
            // Проверяем какой текст на кнопке и выполняем действия в зависимости от этого
            switch (button.Text)
            {
                case "Открыть порт":
                    try
                    {
                        serialPortUART.Open(); // Попытка открыть порт
                        richTextBoxMainOut.AppendText(DateTime.Now.ToString("G") +
                            ": Центральный узел подключен, узел расположен на порту " +
                            serialPortUART.PortName + Environment.NewLine); // Вывод в лог сообщения с указанием текущей даты и времени
                        richTextBoxMainOut.SelectionStart = richTextBoxMainOut.Text.Length; // Перенос каретки в конец текста
                        richTextBoxMainOut.ScrollToCaret(); // Прокрутка текстового поля к каретке
                    }
                    catch (Exception ex)
                    {
                        richTextBoxMainOut.AppendText(DateTime.Now.ToString("G") +
                            ": Невозможно открыть последовательный порт: " + ex.Message +
                            Environment.NewLine); // Вывод в лог сообщения с указанием текущей даты и времени
                        richTextBoxMainOut.SelectionStart = richTextBoxMainOut.Text.Length; // Перенос каретки в конец текста
                        richTextBoxMainOut.ScrollToCaret(); // Прокрутка текстового поля к каретке
                    }
                    break;
                case "Закрыть порт":
                    try
                    {
                        serialPortUART.Close(); // Попытка закрыть порт
                        richTextBoxMainOut.AppendText(DateTime.Now.ToString("G") +
                            ": Последовательный порт " + serialPortUART.PortName +
                            " закрыт" + Environment.NewLine); // Вывод в лог сообщения с указанием текущей даты и времени
                        richTextBoxMainOut.SelectionStart = richTextBoxMainOut.Text.Length; // Перенос каретки в конец текста
                        richTextBoxMainOut.ScrollToCaret(); // Прокрутка текстового поля к каретке
                    }
                    catch (Exception ex)
                    {
                        richTextBoxMainOut.AppendText(DateTime.Now.ToString("G") +
                            ": Невозможно закрыть последовательный порт: " + ex.Message +
                            Environment.NewLine); // Вывод в лог сообщения с указанием текущей даты и времени
                        richTextBoxMainOut.SelectionStart = richTextBoxMainOut.Text.Length; // Перенос каретки в конец текста
                        richTextBoxMainOut.ScrollToCaret(); // Прокрутка текстового поля к каретке
                    }
                    break;
            }

            // Проверяем открыт ли последовательный порт и необходимо ли изменить надпись на кнопке
            if (serialPortUART.IsOpen && buttonOpenClose.Text.Equals("Открыть порт"))
                buttonOpenClose.Text = "Закрыть порт"; // Если порт открыт выводим на кнопке надпись о закрытии порта
            else if (!serialPortUART.IsOpen && buttonOpenClose.Text.Equals("Закрыть порт"))
                buttonOpenClose.Text = "Открыть порт"; // Если порт закрыт выводим на кнопке надпись об открытии порта
        }
    }
}
