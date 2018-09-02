using System;
using System.IO.Ports;

namespace UART_interface
{
    class SerialPortSettings
    {
        /// <summary>
        /// Имя последовательного порта
        /// </summary>
        private static string portName = "COM1";
        /// <summary>
        /// Протокол контроля четности
        /// </summary>
        private static Parity parity = Parity.None;
        /// <summary>
        /// Стандартное число стоповых бит в байте
        /// </summary>
        private static StopBits stopBits = StopBits.One;
        /// <summary>
        /// Скорость передачи (в бодах)
        /// </summary>
        private static int baudRate = 115200;
        /// <summary>
        /// Стандартное число бит данных в байте
        /// </summary>
        private static int dataBits = 8;
        /// <summary>
        /// Размер въходного и выходного буферов
        /// </summary>
        private static int bufferSize = 8192;
        /// <summary>
        /// Произошли изменения в настройках или нет
        /// </summary>
        private static bool isChanged = false;

        /// <summary>
        /// Записывает новые настройки для последовательного порта
        /// </summary>
        /// <param name="portName">Имя последовательного порта</param>
        /// <param name="parity">Протокол контроля четности</param>
        /// <param name="stopBits">Стандартное число стоповых бит в байте</param>
        /// <param name="baudRate">Скорость передачи (в бодах)</param>
        /// <param name="dataBits">Стандартное число бит данных в байте</param>
        /// <param name="bufferSize">Размер въходного и выходного буферов</param>
        public static void WriteSettings(object portName, object parity, object stopBits,
            object baudRate, object dataBits, object bufferSize)
        {
            SerialPortSettings.portName = Convert.ToString(portName).Replace(" ", ""); // Сохраняем правильное имя порта
            // Сохраняем протокол контроля четности в зависимости от выбора
            switch (Convert.ToString(parity))
            {
                case "None":
                    SerialPortSettings.parity = Parity.None;
                    break;
                case "Space":
                    SerialPortSettings.parity = Parity.Space;
                    break;
                case "Odd":
                    SerialPortSettings.parity = Parity.Odd;
                    break;
                case "Even":
                    SerialPortSettings.parity = Parity.Even;
                    break;
                case "Mark":
                    SerialPortSettings.parity = Parity.Mark;
                    break;
                default:
                    SerialPortSettings.parity = Parity.None;
                    break;
            }
            // Сохраняем настройки стоповых бит
            switch(Convert.ToString(stopBits))
            {
                case "None":
                    SerialPortSettings.stopBits = StopBits.None;
                    break;
                case "1":
                    SerialPortSettings.stopBits = StopBits.One;
                    break;
                case "1.5":
                    SerialPortSettings.stopBits = StopBits.OnePointFive;
                    break;
                case "2":
                    SerialPortSettings.stopBits = StopBits.Two;
                    break;
                default:
                    SerialPortSettings.stopBits = StopBits.One;
                    break;
            }
            SerialPortSettings.baudRate = Convert.ToInt32(baudRate); // Сохраняем настройки скорости передачи (в бодах)
            SerialPortSettings.dataBits = Convert.ToInt32(dataBits); // Сохраняем настройки бит данных
            SerialPortSettings.bufferSize = Convert.ToInt32(bufferSize); // Сохраняем настройки размера буффера чтения и записи
            isChanged = true; // Указываем что настройки изменились
        }

        /// <summary>
        /// Читает и применяет новые настройки последовательного порта
        /// </summary>
        /// <param name="serialPort">Экземпляр последовательного порта</param>
        /// <returns>Экземпляр последовательного порта с обновленными настройками</returns>
        public static SerialPort ReadSettings(SerialPort serialPort)
        {
            // Если в настройках были какие-либо изменения
            if (isChanged)
            {
                serialPort.BaudRate = baudRate; // Применяем новою скорость передачи (в бодах)
                serialPort.DataBits = dataBits; // Применяем новые настройки бит данных
                serialPort.Parity = parity; // Применяем новые настройки для протокола контроля четности
                serialPort.PortName = portName; // Применяем новыенастройки для имени порта
                serialPort.ReadBufferSize = bufferSize; // Применяем новые настройки для размера буффера чтения
                serialPort.WriteBufferSize = bufferSize; // Применяем новые настройки для размера буффера записи
                serialPort.StopBits = stopBits; // Применяем новые настройки для стоповых бит
                isChanged = false; // Указываем что новых настроек нет
            }
            
            return serialPort; // Отправляем на выход функции экземпляр порта с обновленными настройками
        }

        /// <summary>
        /// Возвращает строковое представление имени последовательного порта
        /// </summary>
        /// <returns>Строковое представление имени последовательного порта</returns>
        public static string GetStringPortName()
        {
            return portName.Insert(3, " ");
        }

        /// <summary>
        /// Возвращает строковое представление скорости передачи
        /// </summary>
        /// <returns>Строковое представление скорости передачи</returns>
        public static string GetStringBaudRate()
        {
            return baudRate.ToString();
        }

        /// <summary>
        /// Возвращает строковое представление размера буфера для чтения и записи
        /// </summary>
        /// <returns>Строковое представление размера буфера для чтения и записи</returns>
        public static string GetStringBufferSize()
        {
            return bufferSize.ToString();
        }

        /// <summary>
        /// Возвращает строковое представление бит данных
        /// </summary>
        /// <returns>Строковое представление бит данных</returns>
        public static string GetStringDataBits()
        {
            return dataBits.ToString();
        }

        /// <summary>
        /// Возвращает строковое представление протокола контроля четности
        /// </summary>
        /// <returns>Строковое представление протокола контроля четности</returns>
        public static string GetStringParity()
        {
            switch(parity)
            {
                case Parity.None:
                    return "None";
                case Parity.Even:
                    return "Even";
                case Parity.Mark:
                    return "Mark";
                case Parity.Odd:
                    return "Odd";
                case Parity.Space:
                    return "Space";
                default:
                    return "None";
            }
        }

        /// <summary>
        /// Возвращает строковое представление стоповых бит
        /// </summary>
        /// <returns>Строковое представление стоповых бит</returns>
        public static string GetStringStopBits()
        {
            switch (stopBits)
            {
                case StopBits.None:
                    return "None";
                case StopBits.One:
                    return "1";
                case StopBits.OnePointFive:
                    return "1.5";
                case StopBits.Two:
                    return "2";
                default:
                    return "1";
            }
        }

        /// <summary>
        /// Устанавливает значение для имени последовательного порта
        /// </summary>
        /// <param name="portName">Имя последовательного порта</param>
        public static void SetStringPortName(string portName)
        {
            SerialPortSettings.portName = portName;
        }


        public static void SetIsChanged(bool isChanged)
        {
            SerialPortSettings.isChanged = isChanged;
        }
    }
}
