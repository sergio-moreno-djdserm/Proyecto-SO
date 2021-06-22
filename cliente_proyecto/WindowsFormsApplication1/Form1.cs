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
        delegate void DelegadorParaEcribirRepuesta(string mensaje);

        private void Mensaje_Respuesta(string respuesta)
        {
            label7.Text=respuesta;
        }

        public Form1()
        {
            InitializeComponent();
            //CheckForIllegalCrossThreadCalls = false; //Necesario para que los elementos de los formularios puedan ser accedidos desde threads diferentes a los que se crearon
        }

        private void Form1_Load(object sender, EventArgs e) 
        {
            groupBox1.BackgroundImage = Properties.Resources.PRINCIPAL;
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

        public void HacerInvisible() //Vuelve invisible ciertos elementos una vez que el usuario inicia sesión
        {
            consulta1.Visible = false;
            consulta2.Visible = false;
            consulta3.Visible = false;
            consulta4.Visible = false;
            nameconsulta.Visible = false;
            label2.Visible = false;
            button3.Visible = false;
            button2.Visible = false;
            label4.Visible = false;
            Invitar.Visible = false;
            consulta5.Visible = false;
            consulta6.Visible = false;
            consulta7.Visible = false;
            label5.Visible = false;
            label6.Visible = false;
            fechai.Visible = false;
            fechaf.Visible = false;
            MostrarConectados.Visible = false;
            label7.Visible = false;
            panel1.Visible = false;
            button4.Visible = false;
        }

        public void HacerVisible() ////Vuelve visible ciertos elementos una vez que el usuario inicia sesión
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
            label4.Visible = true;
            darbaja.Visible = false;
            consulta5.Visible = true;
            consulta6.Visible = true;
            consulta7.Visible = true;
            label5.Visible = true;
            label6.Visible = true;
            fechai.Visible = true;
            fechaf.Visible = true;
            label7.Visible = true;
            panel1.Visible = true;
            groupBox1.BackgroundImage = Properties.Resources.PANELES_CON_FONDO_2;
            MostrarConectados.Visible = true;
            button4.Visible = true;
            this.BackColor = Color.Green;
        }

        public void DarNombreContra()
        {
            name = textnombre.Text;
            password = textcontra.Text;
        }

        public void RellenaListaConectados(string []words) //Rellena la lista de conectados con los usuarios que estan actualmente conectados y rellena el DataGridView.
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

        private void AtenderServidor() //Funcion que esta constantemente a la espera de recibir un mensaje del servidor.
        {
            while (true)
            {
                //Recibimos la respuesta del servidor.
                byte[] msg2 = new byte[1500]; //Tambien sera un vector de bytes la respuesta.
                server.Receive(msg2);
                string[] trozos = Encoding.ASCII.GetString(msg2).Split('/'); //Cortar por final de string.
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
                            this.Invoke(new DelegadorParaEcribirRepuesta(Mensaje_Respuesta), new object[] { "~ CONECTADO ~" });
                        }
                        else if (mensaje == "YASESION")
                        {
                            MessageBox.Show("El usuario ya tiene una sesión iniciada");
                            atender.Abort();
                            this.BackColor = Color.Gray;
                            server.Shutdown(SocketShutdown.Both);
                            server.Close();
                        }
                        else
                        {
                            MessageBox.Show("El usuario no está registrado");
                        }
                        break;
                    case 3: //No se han encontrados los datos introducidos por el ususario en la consulta.
                        if (mensaje != "ERROR_NO_DATOS")
                        {
                            this.Invoke(new DelegadorParaEcribirRepuesta(Mensaje_Respuesta), new object[] { mensaje });
                        }
                        else
                        {
                            label7.Text="No se han encontrado datos en la consulta";
                        }
                        break;
                    case 4: //No se han encontrados los datos introducidos por el ususario en la consulta.
                        if (mensaje != "ERROR_NO_DATOS")
                        {
                            this.Invoke(new DelegadorParaEcribirRepuesta(Mensaje_Respuesta), new object[] { mensaje });
                        }
                        else
                        {
                            this.Invoke(new DelegadorParaEcribirRepuesta(Mensaje_Respuesta), new object[] { "No se han encontrado datos en la consulta" });
                        }
                        break;
                    case 5: //No se han encontrados los datos introducidos por el ususario en la consulta.
                        if (mensaje != "ERROR_NO_DATOS")
                        {
                            this.Invoke(new DelegadorParaEcribirRepuesta(Mensaje_Respuesta), new object[] { mensaje });
                        }
                        else
                        {
                            this.Invoke(new DelegadorParaEcribirRepuesta(Mensaje_Respuesta), new object[] { "No se han encontrado datos en la consulta" });
                        }
                        break;
                    case 6: //No se han encontrados los datos introducidos por el ususario en la consulta.
                        if (mensaje != "ERROR_NO_DATOS")
                        {
                            this.Invoke(new DelegadorParaEcribirRepuesta(Mensaje_Respuesta), new object[] { mensaje });
                        }
                        else
                        {
                            this.Invoke(new DelegadorParaEcribirRepuesta(Mensaje_Respuesta), new object[] { "No se han encontrado datos en la consulta" });
                        }
                        break;
                    case 7: //Invoca la funcion RellenarListaConectados y le pasa como parametros los nombres de los conectados.
                        string[] words = mensaje.Split(',');
                        DelegadoParaRellenar delegado3 = new DelegadoParaRellenar(RellenaListaConectados);
                        this.Invoke(delegado3, new object[] {words});
                        break;
                    case 8: //Al recibir la invitacion de alguien, puedes rechazarla, enviando un mensaje notificandolo,o bien acceptarla y empezar una partida con quien te invito y los demás jugadores que tambien accepten.
                        if (mensaje == "NO")
                            this.Invoke(new DelegadorParaEcribirRepuesta(Mensaje_Respuesta), new object[] { "No se ha podido crear la partida, estas en la FRIENDZONE" });
                        else
                        {
                            string[] partida = mensaje.Split(',');
                            string pregunta = "Quieres unirte a una partida con " + partida[1];

                            DialogResult resultado = MessageBox.Show(pregunta, "Nueva partida", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (resultado == DialogResult.Yes)
                                mensaje = "8/0/" + partida[0] + "," + name + ",YES";
                            else
                                mensaje = "8/0/" + partida[0] + "," + name + ",NO";
                            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                            server.Send(msg);
                        }
                        break;
                    case 9: //Todos los invitados han rechazado tu invitación, por lo tanto no puedes  jugar con nadie. Estas solo.
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
                            this.Invoke(new DelegadorParaEcribirRepuesta(Mensaje_Respuesta), new object[] { "Estas en la FRIENDZONE" });
                        break;
                    case 10:    //Hace funcionar el chat
                        Forms[partidas[idPartida]].RellenaChat(mensaje);
                        break;
                    case 11:    //Darse de baja
                        if (mensaje == "OK")
                        {
                            MessageBox.Show("Te has dado de baja correctamente");
                            Desconectar();
                        }
                        else if (mensaje == "ERROR_AL_ELIMINAR")
                        {
                            MessageBox.Show("Ha sucedido un error en el proceso");
                            Desconectar();
                        }
                        else
                        {
                            MessageBox.Show("El usuario no esta registrado");
                            Desconectar();
                        }
                        break;
                    case 12:    //Dibuja las posiciones de los jugadores.
                        Forms[partidas[idPartida]].DibujaPosiciones(mensaje);
                        break;
                    case 13:    //Recibir mensaje del servidor diciendo si ha ganado, o ha perdido etc
                        Forms[partidas[idPartida]].NotificarCambios(mensaje);
                        break;
                    case 14: //Notificacion de errores en las consultas.
                        if (mensaje != "ERROR_NO_DATOS")
                        {
                            this.Invoke(new DelegadorParaEcribirRepuesta(Mensaje_Respuesta), new object[] { mensaje });
                        }
                        else
                        {
                            this.Invoke(new DelegadorParaEcribirRepuesta(Mensaje_Respuesta), new object[] { "No se han encontrado datos en la consulta" });
                        }
                        break;
                    case 15:    //Notificacion de errores en las consultas.
                        if (mensaje != "ERROR_NO_DATOS")
                        {
                            this.Invoke(new DelegadorParaEcribirRepuesta(Mensaje_Respuesta), new object[] { mensaje });
                        }
                        else
                        {
                            this.Invoke(new DelegadorParaEcribirRepuesta(Mensaje_Respuesta), new object[] { "No se han encontrado datos en la consulta" });
                        }
                        break;
                    case 16:    //Notificacion de errores en las consultas.
                        if (mensaje != "ERROR_NO_DATOS")
                        {
                            this.Invoke(new DelegadorParaEcribirRepuesta(Mensaje_Respuesta), new object[] { mensaje });
                        }
                        else
                        {
                            this.Invoke(new DelegadorParaEcribirRepuesta(Mensaje_Respuesta), new object[] { "No se han encontrado datos en la consulta" });
                        }
                        break;
                    case 17:    //Recibir mensaje del servidor diciendo si ha ganado, o ha perdido etc
                        Forms[partidas[idPartida]].NotificarCambios2(mensaje);
                        break;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e) //Envia la consulta seleccionada por el usuario y los datos introducidos por este, devolviendo la respuesta.
        {
            try
            {
                if (nameconsulta.Text != "")
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
                    if (consulta6.Checked)
                    {
                        string mensaje = "14/0/" + nameconsulta.Text;
                        // Enviamos al servidor el nombre tecleado
                        byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje); //Envio un vector de bytes
                        server.Send(msg);
                    }
                }
                if ((consulta1.Checked || consulta2.Checked || consulta3.Checked || consulta4.Checked || consulta6.Checked) && (nameconsulta.Text == ""))
                {
                    label7.Text="Añade un nombre";
                }
                if (consulta5.Checked)
                {
                    string mensaje = "13/0";
                    // Enviamos al servidor el nombre tecleado
                    byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje); //Envio un vector de bytes
                    server.Send(msg);
                }
                if ((fechaf.Text != "") && (fechai.Text != ""))
                {
                    string[] trozosi = fechai.Text.Split('/');
                    string[] trozosf = fechaf.Text.Split('/');
                    if ((trozosi.Length == 3) && (trozosf.Length == 3))
                    {
                        if (consulta7.Checked)
                        {
                            string mensaje = "15/0/" + fechai + "/" + fechaf;
                            // Enviamos al servidor el nombre tecleado
                            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje); //Envio un vector de bytes
                            server.Send(msg);
                        }
                    }
                    else
                    {
                        label7.Text="Por favor añada correctamente con el formato pedido";
                    }
                }
            }
            catch
            {
            }
        }



        private void button3_Click(object sender, EventArgs e) //Desconecta al usurario del servidor, invocando la funcion Desconectar.
        {
            Desconectar();
            Close();
        }

        private void registrar_Click(object sender, EventArgs e) //Resgistra en la base de datos el nombre y su contraseña relacionada, siempre que no exista ya otro usuario con el mismo nombre.
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

        private void entrar_Click(object sender, EventArgs e) //Una vez introducidos el nombre y la contraseña, los compara con la base de datos. Si coinciden te deja entrar, si no, lo notifica.
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

        private void MostrarConectados_CellContentClick(object sender, DataGridViewCellEventArgs e) //Al hacer click en una de las celdas del DataGridView, se selecciona al usuario que despues se invitará pulsandp otro boton. Pulsando en el mismo otra vez, se deselecciona.
        {
            if (MostrarConectados.CurrentCell.Value != null)
            {
                string selecionado = MostrarConectados.CurrentCell.Value.ToString(); //Recoge el nombre de la celda
                MessageBox.Show(selecionado);
                if (selecionado != name) //Solo permitimos selecionar las que no son el propio usuario
                {
                    if (num_seleccionados == 3)
                        label7.Text="Has alcanzado el máximo permitido de jugadores";

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

        private void Form1_FormClosing(object sender, FormClosingEventArgs e) //Muestra mensaje de seguridad antes de cerrar el form. Si dice que si, se cierr, si no, no lo cierra.

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

        private void Invitar_Click(object sender, EventArgs e) //Invita a los jugadores seleccionados a jugar una nueva partida
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
                label7.Text="Debes de seleccionar a un jugador";

            //Limpiamos el vector de jugadores
            num_seleccionados = 0;
            for (int i = 0; i < 3; i++)
                jugadores[i] = "";
        }

        private void darbaja_Click(object sender, EventArgs e) //Elimina de la base de datos la contraseña y el nombre de usuario introduccidos por teclado, simpre que este existan.
        {
            if ((textnombre.Text != "") && (textcontra.Text != ""))
            {
                Conectar();
                // El usuario se quiere dar de baja
                string mensaje = "10/0/" + textnombre.Text + "/" + textcontra.Text;
                name = textnombre.Text;
                password = textcontra.Text;
                // Enviamos al servidor el nombre tecleado
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje); //Envio un vector de bytes
                server.Send(msg);
            }
            else
            {
                MessageBox.Show("No te has podido dar de baja, debes introducir nombre y contrasena validos.");
            }
        }

        //Instrucciones
        private void button4_Click_1(object sender, EventArgs e)
        {
            Form5 f5 = new Form5();
            f5.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
