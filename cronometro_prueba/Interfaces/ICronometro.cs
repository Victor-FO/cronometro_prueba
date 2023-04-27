using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cronometro_prueba.Interfaces
{
    public interface ICronometro
    {
        #region Propiedades
        //Propiedad que usaremos para pasar el tiempo a nuestro ViewModel y por tanto se actualizará en la Vista
        String TimerCount { get; set; }
        #endregion
        #region Eventos
        //Evento por el cual pasaremos el valor de TimerCount actualizado al ViewModel
        event EventHandler OnTimeElapsed;
        #endregion
        #region Métodos
        //Meétodo que se encargará de inicializar el Stopwatch y el Timer
        void StartCronometro();
        //Meétodo que se encargará de Pausar el Stopwatch y el Timer
        void PauseCronometro();
        //Meétodo que se encargará de Parar y reiniciar el Stopwatch y el Timer
        void StopCronometro();
        #endregion
    }
}
