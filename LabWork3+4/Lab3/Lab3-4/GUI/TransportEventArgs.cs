using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Model.Transport;

namespace GUI
{
    /// <summary>
    /// Класс аргумента для передачи данныых
    /// </summary>
    public class TransportEventArgs : EventArgs
    {
        /// <summary>
        /// Транспорт для передачи
        /// </summary>
        public TransportBase SendingTransport { get; }

        /// <summary>
        /// Конструктор для передачи транспорта
        /// </summary>
        /// <param name="sendingTransport">Транспорт</param>
        public TransportEventArgs(TransportBase sendingTransport)
        {
            SendingTransport = sendingTransport;
        }
    }
}
