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
    public partial class Form1 : Form
    {
        Socket server; // Declarar un objeto de la clase socket
        Thread atender; // Declarar un objeto de la clase atender
        //Variables globales
        string name;
        string password;

        public Form1()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false; //Necesario para que los elementos de los formularios puedan ser accedidos desde threads diferentes a los que se crearon
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            HacerInvisible();
        }

        public void Conectar()
        {
            //Creamos un IPEndPoint con el ip del servidor y puerto del servidor 
            //al que deseamos conectarnos
            IPAddress direc = IPAddress.Parse("147.83.117.22");
            IPEndPoint ipep = new IPEndPoint(direc, 50055);

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
            //Poner en marcha el thread que atenderá los mensajes del servidor
            ThreadStart ts = delegate { AtenderServidor(); };
            atender = new Thread(ts);
            atender.Start();
        }

        public void Desconectar()
        {
            //Enviar mensaje de desconexión
            string mensaje = "0/" + name;

            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);

            //Nos desconectamos
            atender.Abort();
            this.BackColor = Color.Gray;
            server.Shutdown(SocketShutdown.Both);
            server.Close();
        }

        public void HacerInvisible()
        {
            consulta1.Visible = false;
            consulta2.Visible = false;
            consulta3.Visible = false;
            consulta4.Visible = false;
            nameconsulta.Visible = false;
            label2.Visible = false;
            button3.Visible = false;
            button2.Visible = false;
            MostrarConectados.Visible = false;
        }

        public void HacerVisible()
        {
            textnombre.Visible = false;
            textcontra.Visible = false;
            label1.Visible = false;
            label3.Visible = false;
            entrar.Visible = false;
            salir.Visible = false;
            registrar.Visible = false;
            consulta1.Visible = true;
            consulta2.Visible = true;
            consulta3.Visible = true;
            consulta4.Visible = true;
            nameconsulta.Visible = true;
            label2.Visible = true;
            button3.Visible = true;
            button2.Visible = true;
            MostrarConectados.Visible = true;
        }

        private void AtenderServidor()
        {
            while (true)
            {
                //Recibimos la respuesta del servidor
                byte[] msg2 = new byte[700]; //Tambien sera un vector de bytes la respuesta
                server.Receive(msg2);
                string[] trozos = Encoding.ASCII.GetString(msg2).Split('/'); //Cortar por final de string
                int codigo = Convert.ToInt32(trozos[0]);
                string mensaje;
                mensaje = trozos[1].Split('\0')[0];

                switch (codigo)
                {
                    case 1: //Registrar
                        if (mensaje == "OK")
                        {
                            MessageBox.Show("Te has registrado correctamente");
                            Desconectar();
                        }
                        else if (mensaje == "ERROR_EXISTE")
                        {
                            MessageBox.Show("El usuario ya existe");
                            Desconectar();
                        }
                        else
                        {
                            MessageBox.Show("No hay más capacidad");
                            Desconectar();
                        }
                        break;
                    case 2: //Login
                        if (mensaje == "OK")
                        {
                            name = textnombre.Text;
                            password = textcontra.Text;
                            HacerVisible();
                            this.BackColor = Color.Green;
                            MessageBox.Show("Conectado");
                        }
                        else
                        {
                            MessageBox.Show("EL usuario no esta registrado");
                            Desconectar();
                        }
                        break;
                    case 3:
                        if (mensaje != "ERROR_NO_DATOS")
                        {
                            MessageBox.Show(mensaje);
                        }
                        else
                        {
                            MessageBox.Show("No se han encontrado datos en la consulta");
                        }
                        break;
                    case 4:
                        if (mensaje != "ERROR_NO_DATOS")
                        {
                            MessageBox.Show(mensaje);
                        }
                        else
                        {
                            MessageBox.Show("No se han encontrado datos en la consulta");
                        }
                        break;
                    case 5:
                        if (mensaje != "ERROR_NO_DATOS")
                        {
                            MessageBox.Show(mensaje);
                        }
                        else
                        {
                            MessageBox.Show("No se han encontrado datos en la consulta");
                        }
                        break;
                    case 6:
                        if (mensaje != "ERROR_NO_DATOS")
                        {
                            MessageBox.Show(mensaje);
                        }
                        else
                        {
                            MessageBox.Show("No se han encontrado datos en la consulta");
                        }
                        break;
                    case 7:
                        string[] words = mensaje.Split(',');
                        MostrarConectados.Rows.Clear();
                        int i;
                        for (i = 0; i < words.Length - 1; i++)
                        {
                            words[i] = words[i + 1];
                            words[i + 1] = null;
                        }
                        foreach (var word in words)
                        {
                            int n = MostrarConectados.Rows.Add();
                            MostrarConectados.Rows[n].Cells[0].Value = word;
                        }
                        break;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (consulta1.Checked)
                {
                    // Esta consulta recibe el nombre de un jugador por teclado y devuelve el listado de
                    // partidas donde ha jugado con los respectivos puntos del jugador
                    string mensaje = "3/" + nameconsulta.Text;
                    // Enviamos al servidor el nombre tecleado
                    byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje); //Envio un vector de bytes
                    server.Send(msg);
                }
                if (consulta2.Checked)
                {
                    // Esta consulta recibe el nombre de un jugador por teclado y devuelve el listado de
                    // partidas donde ha jugado con los respectivos puntos del jugador
                    string mensaje = "4/" + nameconsulta.Text;
                    // Enviamos al servidor el nombre tecleado
                    byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje); //Envio un vector de bytes
                    server.Send(msg);
                }
                if (consulta3.Checked)
                {
                    // Esta consulta recibe el nombre de un jugador por teclado y devuelve el listado de
                    // partidas donde ha jugado con los respectivos puntos del jugador
                    string mensaje = "5/" + nameconsulta.Text;
                    // Enviamos al servidor el nombre tecleado
                    byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje); //Envio un vector de bytes
                    server.Send(msg);
                }
                if (consulta4.Checked)
                {
                    // Esta consulta recibe el nombre de un jugador por teclado y devuelve el listado de
                    // partidas donde ha jugado con los respectivos puntos del jugador
                    string mensaje = "6/" + nameconsulta.Text;
                    // Enviamos al servidor el nombre tecleado
                    byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje); //Envio un vector de bytes
                    server.Send(msg);
                }
            }
            catch
            {
            }
        }



        private void button3_Click(object sender, EventArgs e)
        {
            Desconectar();
            Close();
        }

        private void registrar_Click(object sender, EventArgs e)
        {
            if ((textnombre.Text != "") && (textcontra.Text != ""))
            {
                Conectar();
                // El usuario se quiere registrar
                string mensaje = "1/" + textnombre.Text + "/" + textcontra.Text;
                name = textnombre.Text;
                password = textcontra.Text;
                // Enviamos al servidor el nombre tecleado
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje); //Envio un vector de bytes
                server.Send(msg);
            }
            else
            {
                MessageBox.Show("No te has podido registrar, debes introducir nombre y contrasena validos.");
            }
        }

        private void entrar_Click(object sender, EventArgs e)
        {
            if ((textnombre.Text != "") && (textcontra.Text != ""))
            {
                Conectar();
                // El usuario quiere entrar
                string mensaje = "2/" + textnombre.Text + "/" + textcontra.Text;
                name = textnombre.Text;
                password = textcontra.Text;
                // Enviamos al servidor el nombre tecleado
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje); //Envio un vector de bytes
                server.Send(msg);
            }
            else
            {
                MessageBox.Show("Introduzca el nombre y la contraseña.");
            }
        }

        private void MostrarConectados_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dialog = MessageBox.Show("¿Estás seguro de cerrar el programa?","Exit",MessageBoxButtons.OK);
            if (dialog == DialogResult.OK)
            {
                //Desconectar();
                Application.Exit();
            }
            else if (dialog == DialogResult.No)
            {
                e.Cancel = true;
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

        private void button4_Click(object sender, EventArgs e)
        {
            Desconectar();
            Close();
        }
    }
}
