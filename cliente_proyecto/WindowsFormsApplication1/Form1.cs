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

        string[] jugadores = new string[3]; //Añadir la lista de invitados
        int num_seleccionados = 0;  //Contar cuantos invitados
        //int num_conectados;

        List<Form2> Forms = new List<Form2>();
        int[] partidas = new int[100];  //Relacionar los form con la ID de la partida

        delegate void DelegadoParaEscribir();
        delegate void DelegadoParaRellenar(string []mensaje);

        public Form1()
        {
            InitializeComponent();
            //CheckForIllegalCrossThreadCalls = false; //Necesario para que los elementos de los formularios puedan ser accedidos desde threads diferentes a los que se crearon
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            HacerInvisible();
        }

        public void AbrirForm2(int id)
        {
            partidas[id] = Forms.Count();
            Form2 f2 = new Form2(id,server,name);
            Forms.Add(f2);
            f2.ShowDialog();
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
            string mensaje = "0/0/" + name;

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
            Invitar.Visible = false;
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
            Invitar.Visible = true;
            MostrarConectados.Visible = true;
            this.BackColor = Color.Green;
        }

        public void DarNombreContra()
        {
            name = textnombre.Text;
            password = textcontra.Text;
        }

        public void RellenaListaConectados(string []words)
        {
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
                int idPartida = Convert.ToInt32(trozos[1]);
                string mensaje;
                mensaje = trozos[2].Split('\0')[0];
                //MessageBox.Show(Convert.ToString(codigo));

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
                            DelegadoParaEscribir delegado = new DelegadoParaEscribir(DarNombreContra);
                            this.Invoke(delegado, new object[] {});
                            DelegadoParaEscribir delegado2 = new DelegadoParaEscribir(HacerVisible);
                            this.Invoke(delegado2, new object[] { });
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
                        DelegadoParaRellenar delegado3 = new DelegadoParaRellenar(RellenaListaConectados);
                        this.Invoke(delegado3, new object[] {words});
                        break;
                    case 8:
                        if (mensaje == "NO")
                            MessageBox.Show("No se ha podido crear la partida, estas en la FRIENDZONE");
                        else
                        {
                            string[] partida = mensaje.Split(',');
                            string pregunta = "Quieres unirte a una partida con " + partida[1];

                            DialogResult resultado = MessageBox.Show(pregunta,"Nueva partida",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                            if (resultado == DialogResult.Yes)
                                mensaje = "8/0/" + partida[0] + "," + name + ",YES";
                            else
                                mensaje = "8/0/" + partida[0] + "," + name + ",NO";
                            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                            server.Send(msg);
                        }
                        break;
                    case 9:
                        //MessageBox.Show("Estoy dentro del caso 9");
                        trozos = mensaje.Split('-');
                        string [] auxiliar = trozos[0].Split(',');
                        //MessageBox.Show(Convert.ToString(aux[0]));
                        if (auxiliar[0] == "YES")
                        {
                            idPartida = Convert.ToInt32(auxiliar[1]);
                            ThreadStart ts = delegate { AbrirForm2(idPartida); };
                            Thread atender = new Thread(ts);
                            atender.Start();
                        }
                        else
                            MessageBox.Show("Estas en la FRIENDZONE");
                        break;
                    case 10:
                        Forms[partidas[idPartida]].RellenaChat(mensaje);
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
                    string mensaje = "3/0/" + nameconsulta.Text;
                    // Enviamos al servidor el nombre tecleado
                    byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje); //Envio un vector de bytes
                    server.Send(msg);
                }
                if (consulta2.Checked)
                {
                    // Esta consulta recibe el nombre de un jugador por teclado y devuelve el listado de
                    // partidas donde ha jugado con los respectivos puntos del jugador
                    string mensaje = "4/0/" + nameconsulta.Text;
                    // Enviamos al servidor el nombre tecleado
                    byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje); //Envio un vector de bytes
                    server.Send(msg);
                }
                if (consulta3.Checked)
                {
                    // Esta consulta recibe el nombre de un jugador por teclado y devuelve el listado de
                    // partidas donde ha jugado con los respectivos puntos del jugador
                    string mensaje = "5/0/" + nameconsulta.Text;
                    // Enviamos al servidor el nombre tecleado
                    byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje); //Envio un vector de bytes
                    server.Send(msg);
                }
                if (consulta4.Checked)
                {
                    // Esta consulta recibe el nombre de un jugador por teclado y devuelve el listado de
                    // partidas donde ha jugado con los respectivos puntos del jugador
                    string mensaje = "6/0/" + nameconsulta.Text;
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
                string mensaje = "1/0/" + textnombre.Text + "/" + textcontra.Text;
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
                string mensaje = "2/0/" + textnombre.Text + "/" + textcontra.Text;
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
            if (MostrarConectados.CurrentCell.Value != null)
            {
                string selecionado = MostrarConectados.CurrentCell.Value.ToString(); //Recoge el nombre de la celda
                MessageBox.Show(selecionado);
                if (selecionado != name) //Solo permitimos selecionar las que no son el propio usuario
                {
                    if (num_seleccionados == 3)
                        MessageBox.Show("Has alcanzado el máximo permitido de jugadores");

                    else if ((selecionado != jugadores[0]) && (selecionado != jugadores[1]) && (selecionado != jugadores[2])) //Si aun no la hemos selecionado la añadimos
                    {
                        jugadores[num_seleccionados] = selecionado;
                        num_seleccionados++;
                    }
                    else //Deselecionamos al jugador
                    {
                        bool encontrado = false;
                        for (int i = 0; i < num_seleccionados; i++)
                        {
                            if (jugadores[i] == selecionado)
                                encontrado = true;
                            if (encontrado)
                                jugadores[i] = jugadores[i + 1];
                        }
                        num_seleccionados--;
                    }
                    selecionado = "";
                    for (int i = 0; i < num_seleccionados; i++)
                        selecionado = selecionado + jugadores[i] + ",";
                }
            }
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
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void Invitar_Click(object sender, EventArgs e)
        {
            // Enviamos al servidor el nombre del usuario más sus invitados
            string mensaje = "7/0/" + name + ",";
            if (num_seleccionados > 0)
            {
                for (int i = 0; i < num_seleccionados; i++)
                {
                    mensaje = mensaje + jugadores[i] + ",";
                }
                //MessageBox.Show(mensaje);
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);
            }
            else
                MessageBox.Show("Debes de seleccionar a un jugador");

            //Limpiamos el vector de jugadores
            num_seleccionados = 0;
            for (int i = 0; i < 3; i++)
                jugadores[i] = "";
        }
    }
}
