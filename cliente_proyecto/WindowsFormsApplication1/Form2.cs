using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace WindowsFormsApplication1
{
    public partial class Form2 : Form
    {
        int segundos = 0;
        int player_pos;
        int bomb_pos;
        int idPartida;
        Socket server;
        string name;

        public int[] jugadores_pos;
        public new int[] muros={0,1,2,3,4,5,6,7,8,9,10,14,16,19,20,24,28,29,30,32,39,40,42,43,46,47,49,50,53,59,60,64,66,68,69,70,72,79,80,83,86,89,90,91,92,93,94,95,96,97,98,99}; //Determinamos que botones seran muros

        //Declaramos un array de botones
        private System.Windows.Forms.Button[] btnArray;
        private System.Windows.Forms.Label label2;

        public Form2(int id, Socket server, string name) //Se  establece la imagene fondo, la id de la partida i todos los componentes presentes.
        {
            InitializeComponent();
            this.BackgroundImage = Properties.Resources.fondo_muros_cielo1;
            CheckForIllegalCrossThreadCalls = false;
            this.idPartida = id;
            this.server = server;
            this.name = name;
            label1.Text = Convert.ToString(idPartida);
        }

        private void Form2_Load(object sender, EventArgs e) //Al iniciar el form cargamos los botones
        {
            AddButtons();
        }

        private void AddButtons() //Añadimos los botones que nos serviran como tablero.
        {
            int xPos = 0;
            int yPos = 0;
            //Asignamos en numero de botones = 100
            btnArray = new System.Windows.Forms.Button[100];
            //Create (100) Buttons:
            for (int i = 0; i < 100; i++)
            {
                //Inicializamos una variable
                btnArray[i] = new System.Windows.Forms.Button();
            }
            int n = 0;
            while (n < 100)
            {
                btnArray[n].Tag = n + 1; // Tag del boton
                btnArray[n].Width = 75; // Anchura del boton
                btnArray[n].Height = 75; // Altura del boton
                if (n == 10) // Localizacion de la segunda hilera de botones
                {
                    xPos = 0;
                    yPos = 75;
                }
                else if (n == 20)   // Localizacion de la segunda hilera de botones
                {
                    xPos = 0;
                    yPos = 150;
                }
                else if (n == 30)   // Localizacion de la tercera hilera de botones
                {
                    xPos = 0;
                    yPos = 225;
                }
                else if (n == 40)   // Localizacion de la cuarta hilera de botones
                {
                    xPos = 0;
                    yPos = 300;
                }
                else if (n == 50)   // Localizacion de la quinta hilera de botones
                {
                    xPos = 0;
                    yPos = 375;
                }
                else if (n == 60)   // Localizacion de la sexta hilera de botones
                {
                    xPos = 0;
                    yPos = 450;
                }
                else if (n == 70)   // Localizacion de la septima hilera de botones
                {
                    xPos = 0;
                    yPos = 525;
                }
                else if (n == 80)   // Localizacion de la octava hilera de botones
                {
                    xPos = 0;
                    yPos = 600;
                }
                else if (n == 90)   // Localizacion de la novena hilera de botones
                {
                    xPos = 0;
                    yPos = 675;
                }
                else if (n == 100)  // Localizacion de la décima hilera de botones
                {
                    xPos = 0;
                    yPos = 750;
                }
                // Localizació de los puntos:
                btnArray[n].Left = xPos;
                btnArray[n].Top = yPos;
                // Añadimos los botones al panel:
                panel.Controls.Add(btnArray[n]); // Hacemos que el panel mantenga los botones
                xPos = xPos + btnArray[n].Width; 
                // WEscribimos os caracteres en inglés:
                btnArray[n].Text = (n).ToString();
                btnArray[n].ForeColor = Color.Black;

                //Las siguientes lineas son para descativar los botones que son muros y poner la correspondiente textura a cada boton.
                if (n>=0 & n<10)
                    btnArray[n].Enabled = false;
                else if (n>90 & n<100) //Desactivamos los botones que son muros.
                    btnArray[n].Enabled = false;
                else if (n == 10 || n == 20 || n == 30 || n == 40 || n == 50 || n == 60 || n == 70 || n == 80 || n == 90) //Desactivamos los botones que son muros.
                    btnArray[n].Enabled = false;
                else if (n == 9 || n == 19 || n == 29 || n == 39 || n == 49 || n == 59 || n == 69 || n == 79 || n == 89) //Desactivamos los botones que son muros.
                    btnArray[n].Enabled = false;
                else
                    btnArray[n].BackgroundImage = Properties.Resources.CESPED;

                if (n == 0)
                {
                    btnArray[n].BackgroundImage = Properties.Resources.MURO_7;
                    btnArray[n].Enabled = false;
                }
                else if (n == 1 || n == 2 || n == 3 || n == 5 || n == 7 || n == 8 || n == 91 || n == 92 || n == 94 || n == 95 || n == 97 || n == 98)
                { 
                    btnArray[n].BackgroundImage = Properties.Resources.MURO_1;
                    btnArray[n].Enabled = false;
                }
                else if (n == 4 || n == 6)
                {
                    btnArray[n].BackgroundImage = Properties.Resources.MURO_8;
                    btnArray[n].Enabled = false;
                }
                else if (n == 9)
                {
                    btnArray[n].BackgroundImage = Properties.Resources.MURO_6;
                    btnArray[n].Enabled = false;
                }
                else if (n == 10 || n == 20 || n == 30 || n == 40 || n == 50 || n == 60 || n == 70 || n == 80)
                {
                    btnArray[n].BackgroundImage = Properties.Resources.MURO_3;
                    btnArray[n].Enabled = false;
                }
                else if (n == 19 || n == 39 || n == 49 || n == 59 || n == 79 || n == 89)
                {
                    btnArray[n].BackgroundImage = Properties.Resources.MURO_2;
                    btnArray[n].Enabled = false;
                }
                else if (n == 90)
                {
                    btnArray[n].BackgroundImage = Properties.Resources.MURO_22;
                    btnArray[n].Enabled = false;
                }
                else if (n == 99)
                {
                    btnArray[n].BackgroundImage = Properties.Resources.MURO_23;
                    btnArray[n].Enabled = false;
                }
                else if (n == 93 || n == 96)
                {
                    btnArray[n].BackgroundImage = Properties.Resources.MURO_17;
                    btnArray[n].Enabled = false;
                }
                else if (n == 29 || n == 69)
                {
                    btnArray[n].BackgroundImage = Properties.Resources.MURO_20;
                    btnArray[n].Enabled = false;
                }
                else if (n == 83 || n == 32 || n == 86)
                {
                    btnArray[n].BackgroundImage = Properties.Resources.MURO_14;
                    btnArray[n].Enabled = false;
                }
                else if (n == 42)
                {
                    btnArray[n].BackgroundImage = Properties.Resources.MURO_4;
                    btnArray[n].Enabled = false;
                }
                else if (n == 14)
                {
                    btnArray[n].BackgroundImage = Properties.Resources.MURO_13;
                    btnArray[n].Enabled = false;
                }
                else if (n == 16 || n == 24 || n == 53)
                {
                    btnArray[n].BackgroundImage = Properties.Resources.MURO_9;
                    btnArray[n].Enabled = false;
                }
                else if (n == 28 || n == 46 || n == 68)
                {
                    btnArray[n].BackgroundImage = Properties.Resources.MURO_10;
                    btnArray[n].Enabled = false;
                }
                else if (n == 64 || n == 66 || n == 72)
                {
                    btnArray[n].BackgroundImage = Properties.Resources.MURO_12;
                    btnArray[n].Enabled = false;
                }
                else if (n == 47)
                {
                    btnArray[n].BackgroundImage = Properties.Resources.MURO_11;
                    btnArray[n].Enabled = false;
                }
                else if (n == 43)
                {
                    btnArray[n].BackgroundImage = Properties.Resources.MURO_15;
                    btnArray[n].Enabled = false;
                }

                btnArray[n].FlatStyle = FlatStyle.Flat; //Estilo de botones
                btnArray[n].FlatAppearance.BorderSize = 0;

                /* ****************************************************************
                You can use following code instead previous line
                char[] Alphabet = {'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 
                'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 
                'W', 'X', 'Y', 'Z'};
                btnArray[n].Text = Alphabet[n].ToString();
                //**************************************************************** */

                //El evento de click Button
                btnArray[n].Click += new System.EventHandler(ClickButton);
                n++;
            }
        }

        // Resultado de (Click Button) event, obtiene el siguiente boton
        public void ClickButton(Object sender, System.EventArgs e)
        {
            Button btn = (Button)sender;
            player_pos = Convert.ToInt32(btn.Text);
            //MessageBox.Show(Convert.ToString(player_pos));
            //PintarJugador(player_pos);
            PermitirMovimiento(player_pos);
            string mensaje = "11/" + idPartida + "/" + name + "," + btn.Text;
            // Enviamos al servidor el nombre tecleado
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje); //Envio un vector de bytes
            server.Send(msg);
        }

        public void PermitirMovimiento(int posicion) //Se activan solo los botones adyacentes a la posicion del jugador.
        {
            int n = 0;
            while (n < 100)
            {
                if (n == posicion)
                {
                    btnArray[n].Enabled = true;
                    btnArray[n + 1].Enabled = true;
                    btnArray[n - 1].Enabled = true;
                    btnArray[n + 10].Enabled = true;
                    btnArray[n - 10].Enabled = true;
                }
                if (n != posicion & n != posicion+1 & n != posicion-1 & n != posicion+10 & n != posicion-10)
                    btnArray[n].Enabled = false;
                int m = 0;
                while (m < 52)
                {
                    btnArray[muros[m]].Enabled = false;
                    m++;
                }
                n++;
            }
        }

        private void timer1_Tick(object sender, EventArgs e) //El timer que marca el tiempo de duración de la partida
        {
            segundos = segundos + 1;
        }

        private void chatbutton_Click(object sender, EventArgs e) //Envia al chat el mensaje introducido
        {
            string mensaje = "9/" + idPartida + "/" + name + " : " + chatbox.Text;
            chatbox.Text = "";
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);
        }

        public void RellenaChat(string mensaje) //Rellena el chat con el mensaje recivido
        {
            chat.Items.Insert(0,mensaje);
        }

        public void DibujaPosiciones(string mensaje) //Actualiza todos los botones con las posiciones nuevas de los jugadores y bombas, respetando los muros.
        {
            //MessageBox.Show(mensaje);
            string[] trozos;
            trozos = mensaje.Split(',');
            int num_players=(trozos.Length-1);
            int n = 0;
            while (n < 100)
            {
                if (n != 0 || n != 1 || n != 2 || n != 3 || n != 5 || n != 7 || n != 8 || n != 91 || n != 92 || n != 94 || n != 95 || n != 97 || n != 98 || n != 4 || n != 6 || n != 9 || n != 10 || n != 20 || n != 30 || n != 40 || n != 50 || n != 60 || n != 70 || n != 80 || n != 19 || n != 39 || n != 49 || n != 59 || n != 79 || n != 89 || n != 90 || n != 99 || n != 93 || n != 96 || n != 29 || n != 69 || n != 32 || n != 83 || n != 86 || n != 42 || n != 14 || n != 16 || n != 24 || n != 53 || n != 28 || n != 46 || n != 68 || n != 47 || n != 64 || n != 66 || n != 72 || n != 43)
                {
                    btnArray[n].BackgroundImage = Properties.Resources.CESPED;
                    int i = 0;
                    while (i < (trozos.Length - 1))
                    {
                        string[] cosas_jugador = trozos[i].Split('-');
                        if (btnArray[n].Text == cosas_jugador[0])
                        {
                            if (cosas_jugador[0] != "0" && Convert.ToInt32(cosas_jugador[0]) == player_pos && n == player_pos)
                            {
                                btnArray[n].BackgroundImage = Properties.Resources.MINION_VERDE_FRENTE;
                            }
                            else
                            {
                                if (cosas_jugador[0] != "0")
                                    btnArray[n].BackgroundImage = Properties.Resources.MINION_ROJO_FRENTE;
                            }
                        }
                        else if (btnArray[n].Text == cosas_jugador[1])
                        {
                            if (cosas_jugador[1] != "0")
                            {
                                btnArray[n].BackgroundImage = Properties.Resources.BOMBA_1;
                            }
                        }
                        i++;
                    }
                }
                //Se actualizan las texturas de los botones.
                if (n == 0)
                    btnArray[n].BackgroundImage = Properties.Resources.MURO_7;
                if (n == 1 || n == 2 || n == 3 || n == 5 || n == 7 || n == 8 || n == 91 || n == 92 || n == 94 || n == 95 || n == 97 || n == 98)
                    btnArray[n].BackgroundImage = Properties.Resources.MURO_1;
                if (n == 4 || n == 6)
                    btnArray[n].BackgroundImage = Properties.Resources.MURO_8;
                if (n == 9)
                    btnArray[n].BackgroundImage = Properties.Resources.MURO_6;
                if (n == 10 || n == 20 || n == 30 || n == 40 || n == 50 || n == 60 || n == 70 || n == 80)
                    btnArray[n].BackgroundImage = Properties.Resources.MURO_3;
                if (n == 19 || n == 39 || n == 49 || n == 59 || n == 79 || n == 89)
                    btnArray[n].BackgroundImage = Properties.Resources.MURO_2;
                if (n == 90)
                    btnArray[n].BackgroundImage = Properties.Resources.MURO_22;
                if (n == 99)
                    btnArray[n].BackgroundImage = Properties.Resources.MURO_23;
                if (n == 93 || n == 96)
                    btnArray[n].BackgroundImage = Properties.Resources.MURO_17;
                if (n == 29 || n == 69)
                    btnArray[n].BackgroundImage = Properties.Resources.MURO_20;
                if (n == 83 || n == 32 || n == 86)
                    btnArray[n].BackgroundImage = Properties.Resources.MURO_14;
                if (n == 42)
                    btnArray[n].BackgroundImage = Properties.Resources.MURO_4;
                if (n == 14)
                    btnArray[n].BackgroundImage = Properties.Resources.MURO_13;
                if (n == 16 || n == 24 || n == 53)
                    btnArray[n].BackgroundImage = Properties.Resources.MURO_9;
                if (n == 28 || n == 46 || n == 68)
                    btnArray[n].BackgroundImage = Properties.Resources.MURO_10;
                if (n == 64 || n == 66 || n == 72)
                    btnArray[n].BackgroundImage = Properties.Resources.MURO_12;
                if (n == 47)
                    btnArray[n].BackgroundImage = Properties.Resources.MURO_11;
                if (n == 43)
                    btnArray[n].BackgroundImage = Properties.Resources.MURO_15;
                n++;
            }
        }

        //Función que indica en que posición se suelta la bomba
        public void soltar_bomba_Click(object sender, EventArgs e)
        {
            bomb_pos = player_pos;
            string mensaje = "16/" + idPartida + "/" + name + "," + bomb_pos;
            // Enviamos al servidor el nombre tecleado
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje); //Envio un vector de bytes
            server.Send(msg);
        }

        //Función que explotará la bomba, y es cuando se enviará al servidor el mensaje de explotar
        public void button101_Click(object sender, EventArgs e)
        {
            if (bomb_pos != 0)
            {
                //MessageBox.Show(Convert.ToString(bomb_pos));
                //Comandos para enviar donde tiene que explotar la bomba
                string mensaje = "12/" + idPartida + "/" + name + "," + bomb_pos;
                // Enviamos al servidor el nombre tecleado
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje); //Envio un vector de bytes
                server.Send(msg);
            }
            //Una vez que la soltamos, la reiniciamos a 0
            bomb_pos = 0;
        }

        public void NotificarCambios(string mensaje)
        {
            //Hay dos opciones, que el servidor le envie que ha ganado o que ha perdido
            //Si el jugador ha perdido, se le notificará y este saldrá de la partida
            //Si el jugador ha ganado, se le notificará y este saldrá de la partida
            //MessageBox.Show(mensaje);
            string[] trozos;
            trozos = mensaje.Split(',');
            int bomba_auxiliar = Convert.ToInt32(trozos[1]);
            //MessageBox.Show(trozos[0]);
            if (trozos[0] == "Has MUERTO")
            {
                PintarExplosion(bomba_auxiliar);
                Form3 f3 = new Form3();
                f3.ShowDialog();
                this.Close();
            }
            if (trozos[0] == "Has GANADO")
            {
                PintarExplosion(bomba_auxiliar);
                Form4 f4 = new Form4();
                f4.ShowDialog();
                this.Close();
            }
            if (trozos[0] == "No CAMBIO")
            {
                PintarExplosion(bomba_auxiliar);
            }
        }
        public void NotificarCambios2(string mensaje)
        {
            if (mensaje == "Has GANADO")
            {
                Form4 f4 = new Form4();
                f4.ShowDialog();
                this.Close();
            }
        }

        private void panel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        public void PintarExplosion(int bomba_explosion) //Cambia los graficos de los botones afectador por la explosión de la bomba para que de la impresion de explosión, junto con todos los demas botonoes para evitar problemas.
        {
            int n = 0;
            while (n < 100)
            {
                if (n != 0 || n != 1 || n != 2 || n != 3 || n != 5 || n != 7 || n != 8 || n != 91 || n != 92 || n != 94 || n != 95 || n != 97 || n != 98 || n != 4 || n != 6 || n != 9 || n != 10 || n != 20 || n != 30 || n != 40 || n != 50 || n != 60 || n != 70 || n != 80 || n != 19 || n != 39 || n != 49 || n != 59 || n != 79 || n != 89 || n != 90 || n != 99 || n != 93 || n != 96 || n != 29 || n != 69 || n != 32 || n != 83 || n != 86 || n != 42 || n != 14 || n != 16 || n != 24 || n != 53 || n != 28 || n != 46 || n != 68 || n != 47 || n != 64 || n != 66 || n != 72 || n != 43)
                {
                    btnArray[n].BackgroundImage = Properties.Resources.CESPED;
                    if (Convert.ToInt32(btnArray[n].Text) == bomba_explosion)
                        btnArray[n].BackgroundImage = Properties.Resources.EXPLOSION_CENTRO;
                    if (Convert.ToInt32(btnArray[n].Text) == bomba_explosion+1)
                        btnArray[n].BackgroundImage = Properties.Resources.EXPLOSION_DERECHA;
                    if (Convert.ToInt32(btnArray[n].Text) == bomba_explosion-1)
                        btnArray[n].BackgroundImage = Properties.Resources.EXPLOSION_IZQUIERDA;
                    if (Convert.ToInt32(btnArray[n].Text) == bomba_explosion+10)
                        btnArray[n].BackgroundImage = Properties.Resources.EXPLOSION_ABAJO;
                    if (Convert.ToInt32(btnArray[n].Text) == bomba_explosion-10)
                        btnArray[n].BackgroundImage = Properties.Resources.EXPLOSION_ARRIBA;
                }
                if (n == 0)
                    btnArray[n].BackgroundImage = Properties.Resources.MURO_7;
                if (n == 1 || n == 2 || n == 3 || n == 5 || n == 7 || n == 8 || n == 91 || n == 92 || n == 94 || n == 95 || n == 97 || n == 98)
                    btnArray[n].BackgroundImage = Properties.Resources.MURO_1;
                if (n == 4 || n == 6)
                    btnArray[n].BackgroundImage = Properties.Resources.MURO_8;
                if (n == 9)
                    btnArray[n].BackgroundImage = Properties.Resources.MURO_6;
                if (n == 10 || n == 20 || n == 30 || n == 40 || n == 50 || n == 60 || n == 70 || n == 80)
                    btnArray[n].BackgroundImage = Properties.Resources.MURO_3;
                if (n == 19 || n == 39 || n == 49 || n == 59 || n == 79 || n == 89)
                    btnArray[n].BackgroundImage = Properties.Resources.MURO_2;
                if (n == 90)
                    btnArray[n].BackgroundImage = Properties.Resources.MURO_22;
                if (n == 99)
                    btnArray[n].BackgroundImage = Properties.Resources.MURO_23;
                if (n == 93 || n == 96)
                    btnArray[n].BackgroundImage = Properties.Resources.MURO_17;
                if (n == 29 || n == 69)
                    btnArray[n].BackgroundImage = Properties.Resources.MURO_20;
                if (n == 83 || n == 32 || n == 86)
                    btnArray[n].BackgroundImage = Properties.Resources.MURO_14;
                if (n == 42)
                    btnArray[n].BackgroundImage = Properties.Resources.MURO_4;
                if (n == 14)
                    btnArray[n].BackgroundImage = Properties.Resources.MURO_13;
                if (n == 16 || n == 24 || n == 53)
                    btnArray[n].BackgroundImage = Properties.Resources.MURO_9;
                if (n == 28 || n == 46 || n == 68)
                    btnArray[n].BackgroundImage = Properties.Resources.MURO_10;
                if (n == 64 || n == 66 || n == 72)
                    btnArray[n].BackgroundImage = Properties.Resources.MURO_12;
                if (n == 47)
                    btnArray[n].BackgroundImage = Properties.Resources.MURO_11;
                if (n == 43)
                    btnArray[n].BackgroundImage = Properties.Resources.MURO_15;
                n++;
            }
        }

        //Desactivar el botón de cerrado
        private const int CP_NOCLOSE_BUTTON = 0x200;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams myCp = base.CreateParams;
                myCp.ClassStyle = myCp.ClassStyle | CP_NOCLOSE_BUTTON;
                return myCp;
            }
        }

        private void button1_Click(object sender, EventArgs e)  //El jugador se quiere desconectar de la partida
        {
            //Comandos para enviar donde tiene que explotar la bomba
            string mensaje = "17/" + idPartida + "/" + name;
            // Enviamos al servidor el nombre tecleado
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje); //Envio un vector de bytes
            server.Send(msg);
            this.Close();
        }
        //OTRAS COSAS
        //    if (btnArray[n + 1].Enabled == true)
        //    {
        //        btnArray[n + 1].BackgroundImage = Properties.Resources.FLECHA_DERECHA;
        //    }
        //    if (btnArray[n - 1].Enabled == true)
        //    {
        //        btnArray[n - 1].BackgroundImage = Properties.Resources.FLECHA_IZQUIERDA;
        //    }
        //    if (btnArray[n + 10].Enabled == true)
        //    {
        //        btnArray[n + 10].BackgroundImage = Properties.Resources.FLECHA_ABAJO;
        //    }
        //    if (btnArray[n - 10].Enabled == true)
        //    {
        //        btnArray[n - 10].BackgroundImage = Properties.Resources.FLECHA_ARRIBA;
        //    }
    }
}
