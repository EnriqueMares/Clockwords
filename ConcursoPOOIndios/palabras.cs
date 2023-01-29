using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConcursoPOOIndios
{
    class palabras
    {
        string[] arregloABC = new string[27];
        string[] arregloPalabraAzar = new string[5];
        string[] arregloRespuesta;
        string cadena;
        int puntos;
        bool acierto;

        public string Cadena 
        {
            get { return cadena; }
            set { cadena=value;} 
        }

        public int Puntos
        {
            get { return puntos; }
            set { puntos = value; }
        }

        public bool Acierto
        {
            get { return acierto; }
            set { acierto = value; }
        }

        public void LlenarArregloABC()
        {
            arregloABC[0] = "A";
            arregloABC[1] = "B";
            arregloABC[2] = "C";
            arregloABC[3] = "D";
            arregloABC[4] = "E";
            arregloABC[5] = "F";
            arregloABC[6] = "G";
            arregloABC[7] = "H";
            arregloABC[8] = "I";
            arregloABC[9] = "J";
            arregloABC[10] = "K";

            arregloABC[11] = "L";
            arregloABC[12] = "M";
            arregloABC[13] = "N";
            arregloABC[14] = "Ñ";
            arregloABC[15] = "O";
            arregloABC[16] = "P";
            arregloABC[17] = "Q";
            arregloABC[18] = "R";
            arregloABC[19] = "S";
            arregloABC[20] = "T";

            arregloABC[21] = "U";
            arregloABC[22] = "V";
            arregloABC[23] = "W";
            arregloABC[24] = "X";
            arregloABC[25] = "Y";
            arregloABC[26] = "Z";
        }

        public string[] LlenarArregloPregunta(string[] arregloPregunta)
        {
            int numero = 0;
            Random azar = new Random();
            for (int casillero = 0; casillero < 5; casillero++)
            {
                numero = azar.Next(0, 27);
                arregloPregunta[casillero] = arregloABC[numero];

            }
            return arregloPregunta;
        }

        public string RegresarCadena(string[] arregloPregunta)
        {
            string cadena = "";
            for (int casillero = 0; casillero <5; casillero++)
            {
                cadena += arregloPregunta[casillero];
            }
            return cadena;
        }

        public string[] RegresarArregloRespuesta(string respuesta)
        {
            arregloRespuesta = new string[respuesta.Length];
            for (int casillero = 0; casillero < respuesta.Length; casillero++)
            {
                arregloRespuesta[casillero] = respuesta.Substring(casillero, 1);
            }
            return arregloRespuesta;
        }

        public void DarPuntos(string[] arregloPregunta, string[] arregloRespuesta)
        {
            for (int casillero1 = 0; casillero1 < arregloRespuesta.Length; casillero1++)
            {
                for (int casillero2 = 0; casillero2 < arregloPregunta.Length; casillero2++)
                {
                    if (arregloRespuesta[casillero1].ToUpper() == arregloPregunta[casillero2].ToUpper())
                    {
                        puntos += 10;
                        acierto = true;
                    }
                }
            }
        }

        public string[] LimpiarArreglo(string[] arregloPregunta)
        {
            for (int casillero = 0; casillero <arregloPregunta.Length; casillero++)
            {
                arregloPregunta[casillero] = null;
            }
            return arregloPregunta;
        }


        public string[] CrearOtraPalabra(string[] arregloPregunta, string[] arregloRespuesta)
        {
            Random azar = new Random();
            for (int casillero1 = 0; casillero1 < arregloRespuesta.Length; casillero1++)
            {
                for (int casillero2 = 0; casillero2 < arregloPregunta.Length; casillero2++)
                {
                    if (arregloRespuesta[casillero1].ToUpper()==arregloPregunta[casillero2].ToUpper())
                    {
                        int numero = azar.Next(0, 27);
                        arregloPregunta[casillero2] = arregloABC[numero];
                    }
                }
            }
            return arregloPregunta;
        }
    }
}
