using cronometro_prueba.BaseClass;
using cronometro_prueba.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Timers;
using System.Threading.Tasks;
using System.Windows.Threading;
using System.Windows;

namespace cronometro_prueba.Services
{
    public class CronometroService : ICronometro
    {
        #region Variables
        //Inicializamos el campo para que aparezca el texto del cronometro en 00:00:00
        private string _timerText = "00:00:00";       
        //Declaracion del Stopwath que mide el tiempo transcurrido
        private readonly Stopwatch _stopwatch;
        //Declaración del Timer que disparará el evento cada X segundos
        private Timer _timer;
        //Declaración del evento que pasará el tiempo transcurrido
        public event EventHandler OnTimeElapsed;
        #endregion
        #region Propiedades
        //Propiedad publica del tiempo que mostraremos actualizado
        public string TimerCount
        {
            get => _timerText ;
            set => _timerText = value;
        }
        #endregion
        #region Constructor
        /// <summary>
        /// Constructor del servicio que implementa la interfaz ICronometro e inicializa el Stopwatch y el Timer cada 1 segundo (1000ms) 
        /// Despues actualiza el Timer
        /// </summary>
        public CronometroService()
        {
            _stopwatch = new Stopwatch();
            _timer = new Timer(1000);
            _timer.Elapsed += TimeElapsed;            
        }
        #endregion
        #region Metodos implementados de la interfaz
        /// <summary>
        /// Método que arranca el StopWatch y el Timer
        /// </summary>
        public void StartCronometro()
        {
            _stopwatch.Start();
            _timer.Start();
           
        }
        /// <summary>
        /// Método que pausa el StopWatch y el Timer
        /// </summary>
        public void PauseCronometro()
        {
            _stopwatch.Stop();
            _timer.Stop();
        }
        /// <summary>
        /// Método que para el StopWatch y el Timer
        /// </summary>
        public void StopCronometro()
        {
            _stopwatch.Stop();
            _timer.Stop();
            _stopwatch.Reset();
            TimerCount = _stopwatch.Elapsed.ToString(@"hh\:mm\:ss");            
        }
        /// <summary>
        /// Método que actualiza la propiedad TimerCount con el tiempo transcurrido del Stopwatch
        /// Cada segundo evalua el evento OnTimeElapsed
        /// </summary>
        /// <param name="sender">Lleva el intervalo de 1000ms</param>
        /// <param name="e"></param>
        private void TimeElapsed(object sender, ElapsedEventArgs e)
        {
            TimerCount = _stopwatch.Elapsed.ToString(@"hh\:mm\:ss");
            if (OnTimeElapsed != null)
            {
                OnTimeElapsed(this, EventArgs.Empty);
            }
            
        }
        #endregion
    }
}
