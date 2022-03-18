using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VGame {
    public class sp : Lng {

        protected override void ImplementationRun() {
            #region Menus

            //Warnings Menu
            menus[0] = "Warning Message 1";
            menus[1] = "Warning Message 2";
            menus[2] = "Salir";
            menus[3] = "Jugar";

            //MainMenu
            menus[4] = "Inicio";
            menus[5] = "Extras";
            menus[6] = "Opciones";
            menus[7] = "Salir";

            //StartGame Menu
            menus[8] = "Iniciar Partida";
            menus[9] = "Saltar Intro";
            menus[10] = "Reiniciar Partida";
            menus[11] = "Ok";

            //Options Menu
            menus[12] = "Video";
            menus[13] = "Audio";
            menus[14] = "Controles";

            //Audio Menu
            menus[15] = "Maestro";
            menus[16] = "Voz";
            menus[17] = "Música";
            menus[18] = "Efectos";

            //Video Menu
            menus[19] = "Pantalla Completa";
            menus[20] = "Modo Ventana";
            menus[21] = "Aplicar";

            //Version
            menus[22] = "Versión";

            //Controls Menu
            menus[23] = "Clic Izquierdo para Moverse";
            menus[24] = "Clic Derecho para Abrir el Menú de Pausa";
            menus[25] = "Tocar con Un Dedo para Moverse";
            menus[26] = "Tocar con Dos Dedos para Abrir el Menú de Pausa";

            //Extras Menu
            menus[27] = "Continuar";
            #endregion

            #region dialogue
            dialogue[0] = "Esto es un dialogo.";
            #endregion

        }


    }
}