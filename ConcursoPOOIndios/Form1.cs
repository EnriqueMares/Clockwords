using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ConcursoPOOIndios
{
    public partial class lblRespuesta : Form
    {
        public lblRespuesta()
        {
            InitializeComponent();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        palabras Palabrita = new palabras();
        string[] arregloPregunta;
        string[] arregloRespuesta;
        string respuesta;
        int vidas = 5;
        int segundos = 30;
        bool acierto = false;
        private void btnJugar_Click(object sender, EventArgs e)
        {
            arregloPregunta = new string[5];            

            Palabrita.LlenarArregloABC();
            arregloPregunta = Palabrita.LlenarArregloPregunta(arregloPregunta);
            lblPalabra.Text = Palabrita.RegresarCadena(arregloPregunta);
            lblVidas.Text = vidas.ToString();
            Palabrita.Acierto = acierto;

            tmrTiempo.Start();
            btnJugar.Enabled = false;
        }

        private void btnValidar_Click(object sender, EventArgs e)
        {
            string[] arregloPregunta2 = new string[5];
            respuesta = txtRespuesta.Text;
            arregloRespuesta = new string[respuesta.Length];
            arregloRespuesta = Palabrita.RegresarArregloRespuesta(respuesta);
            Palabrita.DarPuntos(arregloPregunta, arregloRespuesta);

            for (int casillero = 0; casillero < 5; casillero++)
            {
                arregloPregunta2[casillero] = arregloPregunta[casillero];
            }

            arregloPregunta2=Palabrita.LimpiarArreglo(arregloPregunta2);
            arregloPregunta2=Palabrita.CrearOtraPalabra(arregloPregunta, arregloRespuesta);

            for (int casillero = 0; casillero < arregloPregunta.Length; casillero++)
            {
                arregloPregunta[casillero] = arregloPregunta2[casillero];
            }


            lblPuntos.Text = Palabrita.Puntos.ToString();
            lblPalabra.Text = Palabrita.RegresarCadena(arregloPregunta);
        }

        private void tmrTiempo_Tick(object sender, EventArgs e)
        {
            if (segundos >= 1)
            {
                segundos--;
            }
            
            lblSegundos.Text = segundos.ToString();
            if (Palabrita.Acierto==true)
            {
                segundos = 30;
                lblSegundos.Text = segundos.ToString();
                Palabrita.Acierto = false;
            }

            if (Palabrita.Acierto==false && segundos==0)
            {
                vidas--;
                lblVidas.Text = vidas.ToString();
                segundos = 30;
            }

        }

        private void lblRespuesta_Load(object sender, EventArgs e)
        {
            lblPuntos.Text = "0";
            lblVidas.Text = vidas.ToString();
            lblSegundos.Text = "30";
            lblPalabra.Text = "";
        }
    }
}
