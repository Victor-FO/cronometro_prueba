using cronometro_prueba.BaseClass;
using cronometro_prueba.Services;
using cronometro_prueba.Interfaces;
using GalaSoft.MvvmLight;
using Prism.Commands;
using System;
using System.ComponentModel;
using System.Windows.Threading;

namespace cronometro_prueba.ViewModels
{
    public class CronometroViewModel : BindableObject
    {
        #region Variables
        //Variable  del tipo ICronometro
        private readonly ICronometro _cronometro;
        private bool _isRunning;
        string timerCount;
        #endregion
        #region Propiedades       
        //Propiedad que bindeamos en la vista y que cada vez que cambia de valor se actualiza
        public string TimerCounter
        {
            get { return timerCount; }
            set
            {
                if (timerCount != value)
                {
                    SetProperty(ref timerCount, value);
                }
            }
        }
        public bool IsRunning 
        {
            get { return _isRunning; }
            set
            {
                if (_isRunning != value)
                {
                    SetProperty(ref _isRunning, value);
                }
            }
        }
        #endregion
        #region Commmands
        //Uso el NuGet de de Prism para los DelegateCommand que usaremos en los botones
        //Comando para el botón de Start
        public DelegateCommand StartCmd { get; set; }
        //Comando para el botón de Pause
        public DelegateCommand PauseCmd { get; set; }
        //Comando para el botón de Stop
        public DelegateCommand StopCmd { get; set; }
        #endregion
        #region Constructor
        /// <summary>
        /// Constructor del ViewModel con inyección de dependencias
        /// </summary>
        /// <param name="cronometro"></param>
        public CronometroViewModel(ICronometro cronometro)
        {
            _cronometro = cronometro;
            _cronometro.OnTimeElapsed += _cronometro_OnTimeElapsed;
            timerCount = _cronometro.TimerCount;
            StartCmd = new DelegateCommand(Start, () => true);
            StopCmd = new DelegateCommand(Stop, CanStopOrPauseStopWatch);
            PauseCmd = new DelegateCommand(Pause, CanStopOrPauseStopWatch);
           
        }
        #endregion
        #region Métodos private      
        /// <summary>
        /// Método que actualiza la propiedad TimerCounter para que se actualice en la vista
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _cronometro_OnTimeElapsed(object sender, EventArgs e)
        {
            TimerCounter = _cronometro.TimerCount;
        }
        /// <summary>
        /// Método que ejecuta el comando start
        /// </summary>
        private void Start()
        {
            _cronometro.StartCronometro();
            _isRunning = true;
            RaiseExecutionChange();
        }
        /// <summary>
        /// Método que ejecuta el comando pause
        /// </summary>
        private void Pause()
        {
            _cronometro.PauseCronometro();
           
        }
        /// <summary>
        /// Método que ejecuta el comando stop
        /// </summary>
        private void Stop()
        {
            _cronometro.StopCronometro();
            TimerCounter = _cronometro.TimerCount;
            _isRunning = false;
            RaiseExecutionChange();
        }
        //Comprobación de si el cronñometro está corriendo o no 
        private bool CanStopOrPauseStopWatch()
        {
            bool canStop = IsRunning;

            return canStop;
        }
        //Reevalua los botones para ver si pueden ser pulsados
        private void RaiseExecutionChange()
        {
            StopCmd.RaiseCanExecuteChanged();
            PauseCmd.RaiseCanExecuteChanged();
        }      
        #endregion

    }
}

