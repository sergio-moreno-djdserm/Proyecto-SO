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

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        Socket server; // Declarar un objeto de la clase socket
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (consulta1.Checked)
                {
                    // Esta consulta recibe el nombre de un jugador por teclado y devuelve el listado de
                    // partidas donde ha jugado con los respectivos puntos del jugador
                    string mensaje = "1/" + nombre.Text;
                    // Enviamos al servidor el nombre tecleado
                    byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje); //Envio un vector de bytes
                    server.Send(msg);

                    //Recibimos la respuesta del servidor
                    byte[] msg2 = new byte[300]; //Tambien sera un vector de bytes la respuesta
                    server.Receive(msg2);
                    mensaje = Encoding.ASCII.GetString(msg2).Split('\0')[0]; //Cortar por final de string
                    MessageBox.Show(mensaje);
                }
                if (consulta2.Checked)
                {
                    // Esta consulta recibe el nombre de un jugador por teclado y devuelve el listado de
                    // partidas donde ha jugado con los respectivos puntos del jugador
                    string mensaje = "2/" + nombre.Text;
                    // Enviamos al servidor el nombre tecleado
                    byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje); //Envio un vector de bytes
                    server.Send(msg);

                    //Recibimos la respuesta del servidor
                    byte[] msg2 = new byte[300]; //Tambien sera un vector de bytes la respuesta
                    server.Receive(msg2);
                    mensaje = Encoding.ASCII.GetString(msg2).Split('\0')[0]; //Cortar por final de string
                    MessageBox.Show(mensaje);
                }
                if (consulta3.Checked)
                {
                    // Esta consulta recibe el nombre de un jugador por teclado y devuelve el listado de
                    // partidas donde ha jugado con los respectivos puntos del jugador
                    string mensaje = "3/" + nombre.Text;
                    // Enviamos al servidor el nombre tecleado
                    byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje); //Envio un vector de bytes
                    server.Send(msg);

                    //Recibimos la respuesta del servidor
                    byte[] msg2 = new byte[300]; //Tambien sera un vector de bytes la respuesta
                    server.Receive(msg2);
                    mensaje = Encoding.ASCII.GetString(msg2).Split('\0')[0]; //Cortar por final de string
                    MessageBox.Show(mensaje);
                }
                if (consulta4.Checked)
                {
                    // Esta consulta recibe el nombre de un jugador por teclado y devuelve el listado de
                    // partidas donde ha jugado con los respectivos puntos del jugador
                    string mensaje = "4/" + nombre.Text;
                    // Enviamos al servidor el nombre tecleado
                    byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje); //Envio un vector de bytes
                    server.Send(msg);

                    //Recibimos la respuesta del servidor
                    byte[] msg2 = new byte[300]; //Tambien sera un vector de bytes la respuesta
                    server.Receive(msg2);
                    mensaje = Encoding.ASCII.GetString(msg2).Split('\0')[0]; //Cortar por final de string
                    MessageBox.Show(mensaje);
                }
            }
            catch
            {
            }
        }

        //private void button1_Click(object sender, EventArgs e)
        //{
        //    //Creamos un IPEndPoint con el ip del servidor y puerto del servidor 
        //    //al que deseamos conectarnos
        //    IPAddress direc = IPAddress.Parse("192.168.56.102");
        //    IPEndPoint ipep = new IPEndPoint(direc, 9070);

        //    //Creamos el socket 
        //    server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        //    try
        //    {
        //        server.Connect(ipep);//Intentamos conectar el socket
        //        this.BackColor = Color.Green;
        //        MessageBox.Show("Conectado");
        //    }
        //    catch (SocketException)
        //    {
        //        //Si hay excepcion imprimimos error y salimos del programa con return 
        //        MessageBox.Show("No he podido conectar con el servidor");
        //        return;
        //    }
        //}

        private void button3_Click(object sender, EventArgs e)
        {
            //Enviar mensaje de desconexión
            string mensaje = "0/" + textnombre.Text;

            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);

            //Nos desconectamos
            this.BackColor = Color.Gray;
            server.Shutdown(SocketShutdown.Both);
            server.Close();
            Close();
        }

        private void registrar_Click(object sender, EventArgs e)
        {
            if ((textnombre.Text != "") && (textcontra.Text != ""))
            {
                //Creamos un IPEndPoint con el ip del servidor y puerto del servidor 
                //al que deseamos conectarnos
                IPAddress direc = IPAddress.Parse("192.168.56.102");
                IPEndPoint ipep = new IPEndPoint(direc, 9070);

                //Creamos el socket 
                server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                try
                {
                    server.Connect(ipep);//Intentamos conectar el socket
                }
                catch (SocketException)
                {
                    //Si hay excepcion imprimimos error y salimos del programa con return 
                    MessageBox.Show("No he podido conectar con el servidor");
                    return;
                }
                // El usuario se quiere registrar
                string mensaje = "5/" + textnombre.Text + "/" + textcontra.Text;
                // Enviamos al servidor el nombre tecleado
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje); //Envio un vector de bytes
                server.Send(msg);

                //Recibimos la respuesta del servidor
                byte[] msg2 = new byte[300]; //Tambien sera un vector de bytes la respuesta
                server.Receive(msg2);
                mensaje = Encoding.ASCII.GetString(msg2).Split('\0')[0]; //Cortar por final de string
                MessageBox.Show(mensaje);
                
                
                //Una vez regitrados nos desconectamos para evitar error en el login
                mensaje = "0/" + textnombre.Text;

                msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);

                //Nos desconectamos
                this.BackColor = Color.Gray;
                server.Shutdown(SocketShutdown.Both);
                server.Close();
            }
            else
                MessageBox.Show("No te has podido registrar, debes introducir nombre y contrasena validos.");
        }

        private void entrar_Click(object sender, EventArgs e)
        {
            if ((textnombre.Text != "") && (textcontra.Text != ""))
            {
                //Creamos un IPEndPoint con el ip del servidor y puerto del servidor 
                //al que deseamos conectarnos
                IPAddress direc = IPAddress.Parse("192.168.56.102");
                IPEndPoint ipep = new IPEndPoint(direc, 9070);

                //Creamos el socket 
                server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                try
                {
                    server.Connect(ipep);//Intentamos conectar el socket
                    this.BackColor = Color.Green;
                    MessageBox.Show("Conectado");
                }
                catch (SocketException)
                {
                    //Si hay excepcion imprimimos error y salimos del programa con return 
                    MessageBox.Show("No he podido conectar con el servidor");
                    return;
                }
                // El usuario quiere entrar
                string mensaje = "6/" + textnombre.Text + "/" + textcontra.Text;
                // Enviamos al servidor el nombre tecleado
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje); //Envio un vector de bytes
                server.Send(msg);

                //Recibimos la respuesta del servidor
                byte[] msg2 = new byte[300]; //Tambien sera un vector de bytes la respuesta
                server.Receive(msg2);
                mensaje = Encoding.ASCII.GetString(msg2).Split('\0')[0]; //Cortar por final de string
                MessageBox.Show(mensaje);
                if (mensaje == "Has entrado correctamente")
                {
                    textnombre.Text = null;
                    textcontra.Text = null;
                    textnombre.Visible = false;
                    textcontra.Visible = false;
                    label1.Visible = false;
                    label3.Visible = false;
                    entrar.Visible = false;
                    registrar.Visible = false;
                    consulta1.Visible = true;
                    consulta2.Visible = true;
                    consulta3.Visible = true;
                    consulta4.Visible = true;
                    nombre.Visible = true;
                    label2.Visible = true;
                    button3.Visible = true;
                    button2.Visible = true;
                }
            }
            else
            {
                MessageBox.Show("Introduzca el nombre y la contraseña.");
            }
        }

        private void MostrarConectados_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void muestraconectados_Click(object sender, EventArgs e)
        {
            // Rellenar datagrid
            string mensaje = "7/";
            // Enviamos al servidor el nombre tecleado
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje); //Envio un vector de bytes
            server.Send(msg);

            //Recibimos la respuesta del servidor
            byte[] msg2 = new byte[300]; //Tambien sera un vector de bytes la respuesta
            server.Receive(msg2);
            mensaje = Encoding.ASCII.GetString(msg2).Split('\0')[0]; //Cortar por final de string
            MessageBox.Show(mensaje);
        }
    }
}
