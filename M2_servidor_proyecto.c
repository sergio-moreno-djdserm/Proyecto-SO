#include <string.h>
#include <unistd.h>
#include <stdlib.h>
#include <sys/types.h>
#include <sys/socket.h>
#include <netinet/in.h>
#include <stdio.h>
#include <ctype.h>
#include <mysql.h>
#include <pthread.h>


//Funciones de la lista de conectados
//Lista de conectados
typedef struct {
	char nombre [20];
	int socket;
} Conectado;

typedef struct {
	Conectado conectados[300];
	int num;
} ListaConectados;


//Variables globales
//Estructura necesaria para acceso excluyente
pthread_mutex_t mutex = PTHREAD_MUTEX_INITIALIZER;

int i;
int sockets[100];

//Inicializar lista conectados
ListaConectados miListaConectados;
//Fin de variables globales


//Añadir un nuevo conectado, retorna 0 si todo OK y -1 si la lista esta llena
int Pon (ListaConectados *lista, char nombre[20], int socket) {
	if (lista->num==100)
		return -1;
	else {
		strcpy(lista->conectados[lista->num].nombre,nombre);
		lista->conectados[lista->num].socket=socket;
		lista->num=lista->num+1;
		return 0;
	}
}

//Devuelve la posicion en la lista o -1 si no está en la lista
int DamePosicion(ListaConectados *lista, char nombre[20]){
	for (int i=0;i<lista->num;i++){
		if (strcmp(lista->conectados[i].nombre,nombre) == 0)
			return i;
	}
	return -1;
}

//Devuelve el socket de un usuario, devuelve -1 si no está en la lista
int DameSocket (ListaConectados *lista, char nombre[20]){
	for (int i=0;i<lista->num;i++) {
		if (strcmp(lista->conectados[i].nombre,nombre) == 0)
			return lista->conectados[i].socket;
	}
	return -1;
}

//Retorna 0 si elimina y -1 si ese usuario no está en la lista
int Elimina (ListaConectados *lista, char nombre[20]) {
	int pos = DamePosicion(lista, nombre);
	if (pos==-1)
		return -1;
	for (int i=pos; i<lista->num-1; i++) {
		lista->conectados[i] = lista->conectados[i+1];
		strcpy(lista->conectados[i].nombre,lista->conectados[i+1].nombre);
		lista->conectados[i].socket=lista->conectados[i+1].socket;
	}
	lista->num=lista->num-1; //Restar 1 al numero de elementos de la lista
	return 0;
}

//Pone en conectados los nombres de todos los conectados separados por ","
void DameConectados (ListaConectados *lista, char conectados[700]) {
	sprintf(conectados,"%d",lista->num);
	for (int i=0; i<lista->num; i++) {
		sprintf(conectados,"%s,%s",conectados,lista->conectados[i].nombre);
	}
	printf("CONECTADOS: %s\n",conectados);
}


//Estructura para las partidas
typedef struct {
	Conectado partida_jugadores[4];	//Lista con los jugadores de la partida_jugadores
	int respuesta[4];	//Contendrá la respuesta de los jugadores, un 1 será un YES y un 0 un NO
	int num_respuesta;
	int num;
	int ID_partida;
	int activa;	//Indica si la partida se ha iniciado/creado
} Partida;

typedef struct {
	Partida ListaPartidas[100];
	int num_partidas;	//Numero de partidas en la tabla
} TablaPartidas;

//Inicializar tabla de partidas
TablaPartidas Partidas;

//Funciones para lista de partidas

//Elimina a jugadores que han rechazado la invitación de la partida a la que han sido invitados
void EliminarJugadores(TablaPartidas *tabla,int ID_partida) {
	for (int j=1;j<tabla->ListaPartidas[ID_partida].num;j++) {
		if (tabla->ListaPartidas[ID_partida].respuesta[j]==0) {
			for (int i=j;i<tabla->ListaPartidas[ID_partida].num-1;i++) {
				tabla->ListaPartidas[ID_partida].partida_jugadores[i]=tabla->ListaPartidas[ID_partida].partida_jugadores[i+1];
			}
			tabla->ListaPartidas[ID_partida].num--;
		}
	}
}

//Esta funcion va a incluir la respuesta de peticion a la partida
int IncluyeRespuesta(TablaPartidas *tabla, int respuesta, int ID_partida, char nombre[50]) {
	int i=0;
	int encontrado=0;
	while (encontrado==0) {
		if (strcmp(tabla->ListaPartidas[ID_partida].partida_jugadores[i].nombre,nombre)==0)
			encontrado=1;
		else
			i++;
	}
	tabla->ListaPartidas[ID_partida].respuesta[i]=respuesta;
	tabla->ListaPartidas[ID_partida].num_respuesta++;
	return tabla->ListaPartidas[ID_partida].num_respuesta;
}

//Crear partida y devolver el numero de jugadores en la partida
int CrearPartida(ListaConectados *lista, char jugadores[500], TablaPartidas *tabla) {
	char *p=strtok(jugadores,",");
	int pos;
	Partida partida;
	partida.num=0;
	partida.activa=0;
	while (p!=NULL) {
		pos=DamePosicion(lista,p);
		printf("Te doy la posicion: %d\n",pos);
		if (pos!=-1) {
			partida.partida_jugadores[partida.num]=lista->conectados[pos];
			partida.num=partida.num+1;
		}
		p=strtok(NULL,",");
	}
	if (partida.num>=2) {	//Poner la partida en la tabla de Partidas
		partida.ID_partida=tabla->num_partidas;
		tabla->ListaPartidas[tabla->num_partidas]=partida;
		tabla->ListaPartidas[tabla->num_partidas].num_respuesta=0;
		tabla->num_partidas=tabla->num_partidas+1;
		printf("Partida %d ha sido creada\n",partida.ID_partida);
		if (tabla->num_partidas==100)
			tabla->num_partidas=0;
	}
	printf("Numero de jugadores en la partida: %d\n",partida.num);
	return partida.num;	//Numero de jugadores en la partida
}

void DameSocketParticipantes(TablaPartidas *tabla, int ID_partida, char sockets[100]) {
	for(int i=0;i>tabla->ListaPartidas[ID_partida].num;i++){
		sprintf(sockets,"%s,%s",sockets,tabla->ListaPartidas[ID_partida].partida_jugadores[i].socket);
	}
}

void Invitar(char jugadores[500], int sock_conn) {
	char notificacion[700];
	char *jugadores_copy[500];
	strcpy(jugadores_copy,jugadores);
	printf("Estoy dentro de invitar y quiero invitar a: %s\n",jugadores_copy);
	int num_jugadores=CrearPartida(&miListaConectados,jugadores,&Partidas);
	printf("En invitar, el numero de jugadores es: %d\n",num_jugadores);
	if (num_jugadores<2) {
		strcpy(notificacion,"8/0/NO");
		write(sock_conn,notificacion,strlen(notificacion));
	}
	else {
		sprintf(notificacion,"8/0/%d,%s",Partidas.num_partidas-1,jugadores_copy);
		for (int i=1;i<num_jugadores;i++) {
			write(Partidas.ListaPartidas[Partidas.num_partidas-1].partida_jugadores[i].socket,notificacion,strlen(notificacion));
		}
	}
}

void RespuestaInvitacion(char respuesta[500]) {
	char notificacion[700];
	printf("Respuesta %s\n",respuesta);
	char *p=strtok(respuesta,",");
	int ID_partida=atoi(p);
	printf("ID %d\n",ID_partida);
	p=strtok(NULL,",");
	char jugador[50];
	strcpy(jugador,p);	//Recoger el nombre del primer jugador
	p=strtok(NULL,",");
	if (strcmp(p,"YES")==0)
		respuesta=1;
	else
		respuesta=0;
	printf("ID partida %d jugador %s respuesta %d\n",ID_partida,jugador,respuesta);
	int res=IncluyeRespuesta(&Partidas,respuesta,ID_partida,jugador);
	
	if (res==Partidas.ListaPartidas[ID_partida].num-1) {
		Partidas.ListaPartidas[ID_partida].activa=1;
		EliminarJugadores(&Partidas,ID_partida);
		printf("RES: %d\n",Partidas.ListaPartidas[ID_partida].num-1);
		printf("NUMERO DE JUGADORES EN LA PARTIDA: %d\n",Partidas.ListaPartidas[ID_partida].num);
		if (Partidas.ListaPartidas[ID_partida].num>1) {
			sprintf(notificacion,"9/0/YES,%d-%d",ID_partida,Partidas.ListaPartidas[ID_partida].num);
			for(int i=0;i<Partidas.ListaPartidas[ID_partida].num;i++){
				sprintf(notificacion,"%s,%s",notificacion,Partidas.ListaPartidas[ID_partida].partida_jugadores[i].nombre);
			}
			for (int i=0; i<Partidas.ListaPartidas[ID_partida].num;i++) {
				write(Partidas.ListaPartidas[ID_partida].partida_jugadores[i].socket,notificacion,strlen(notificacion));
			}
			printf("NOTIFICACION A RESPUESTA INVITAR: %s\n",notificacion);
		}
		else {
			sprintf(notificacion,"9/0/NO,%d",ID_partida);
			write(Partidas.ListaPartidas[ID_partida].partida_jugadores[0].socket,notificacion, strlen(notificacion));
			printf("NOTIFICACION A RESPUESTA INVITAR: %s\n",notificacion);
		}
	}
}


//Funcion para actualizar la lista de conectados cada vez que hay una modificación
void Conectados() {
	char notificacion[700];
	char gente_conectada[700];
	DameConectados(&miListaConectados,gente_conectada);
	sprintf(notificacion,"7/0/%s",gente_conectada);
	for (int j=0; j<miListaConectados.num; j++) {
		printf("NOTIFICACION: %s\n",notificacion);
		write(miListaConectados.conectados[j].socket,notificacion,strlen(notificacion));
	}
	printf("ESTOY DANDO CONECTADOS AL CLIENTE\n");
}

//Funcion para registro del cliente
int Registrar(char nombre[50], char contrasena[50], char respuesta[700], MYSQL *conn, int sock_conn) {
	MYSQL_RES *resultado;
	MYSQL_ROW row;
	char consulta[700];
	sprintf(consulta,"INSERT INTO JUGADOR VALUES (NULL,'%s','%s',NULL)",nombre,contrasena);
	int err = mysql_query(conn,consulta);
	if (err!=0) {
		printf("El usuario ya existe\n");
		strcpy(respuesta,"1/0/ERROR_EXISTE");
		return 1;
	}
	else {
		pthread_mutex_lock(&mutex);
		int res = Pon (&miListaConectados,nombre,sock_conn);
		pthread_mutex_unlock(&mutex);
		if (res==-1) {
			printf("No caben más usuarios\n");
			strcpy(respuesta,"1/0/ERROR_CAPACIDAD");
			return 1;
		}
		else{
			printf ("Te has registrado\n");	
			strcpy(respuesta,"1/0/OK");
			return 0;
		}
	}
}

//Funcion para loguearse si estás en la base de datos
int Login (char nombre[50], char contrasena[50], char respuesta[700], MYSQL *conn, int sock_conn) {
	//Comprobar si el nombre y la contrasena son correctos
	MYSQL_RES *resultado;
	MYSQL_ROW row;
	char consulta[700];
	
	sprintf (consulta,"SELECT JUGADOR.NOMBRE FROM JUGADOR WHERE JUGADOR.NOMBRE = '%s' AND JUGADOR.CONTRASENA ='%s';",nombre,contrasena);
	int err = mysql_query(conn, consulta);
	if (err!=0){
		printf ("Error al consultar la base de datos %u %s\n", mysql_errno(conn), mysql_error(conn));
		exit (1);
	}
	resultado = mysql_store_result(conn);
	row = mysql_fetch_row(resultado);
	if (row == NULL) {
		//Si está vacio, el usuario no se ha registrado
		printf("Usuario no registrado\n");
		strcpy(respuesta,"2/0/ERROR_NO_REGISTRADO");
	}
	else {		
		pthread_mutex_lock(&mutex);
		int res = Pon(&miListaConectados,nombre,sock_conn);
		strcpy(respuesta,"2/0/OK");
		pthread_mutex_unlock(&mutex);
		return 0;
	}
}

//Funciones de consultas
/*Esta consulta recibe el nombre de un jugador por teclado y devuelve el listado de
partidas donde ha jugado con los respectivos puntos del jugador*/
void  DameConsulta1(char respuesta[700], char nombre[50], MYSQL *conn) {
	MYSQL_RES *resultado;
	MYSQL_ROW row;
	char consulta[700];
	sprintf(consulta,"SELECT * FROM (DATOS,JUGADOR) WHERE JUGADOR.NOMBRE='%s' AND JUGADOR.ID=DATOS.ID_J",nombre);
	int err = mysql_query(conn, consulta);
	if (err!=0){
		printf ("Error al consultar la base de datos %u %s\n", mysql_errno(conn), mysql_error(conn));
		exit (1);
	}
	// Recoger el resultado de la consulta
	resultado = mysql_store_result(conn);
	row = mysql_fetch_row(resultado);
	if (row == NULL) {
		strcpy(respuesta,"3/0/ERROR_NO_DATOS");
		printf("No se han obtenido datos en la primera consulta\n");
	}
	else
	{
		strcpy(respuesta,"3/0/");
		while (row != NULL)
		{
			sprintf(respuesta,"%sID PARTIDA:%s, PUNTUACION:%s\n",respuesta, row[0], row[2]);
			row = mysql_fetch_row (resultado);
		}
		printf("CONSULTA 1 RESPUESTA: %s",respuesta);
	}
}

/*Esta consulta coge la ID de la partida, la duración y el ganador, de las partidas en las cuales
jugó la persona que se entra por teclado*/
void  DameConsulta2(char respuesta[700], char nombre[50], MYSQL *conn) {
	MYSQL_RES *resultado;
	MYSQL_ROW row;
	char consulta[700];
	sprintf(consulta,"SELECT * FROM (PARTIDA,JUGADOR,DATOS) WHERE JUGADOR.NOMBRE='%s' AND JUGADOR.ID=DATOS.ID_J AND DATOS.ID_P=PARTIDA.ID",nombre); 
	int err=mysql_query (conn, consulta);
	if (err!=0){
		printf ("Error al consultar la base de datos %u %s\n", mysql_errno(conn), mysql_error(conn));
		exit (1);
	}
	// Recoger el resultado de la consulta
	resultado = mysql_store_result(conn);
	row = mysql_fetch_row(resultado);
	if (row == NULL) {
		strcpy(respuesta,"4/0/ERROR_NO_DATOS");
		printf("No se han obtenido datos en la primera consulta\n");
	}
	else {
		strcpy(respuesta,"4/0/");
		while (row != NULL)
		{
			sprintf(respuesta,"%sID PARTIDA:%s, DURACION:%s, GANADOR:%s\n",respuesta, row[0], row[3], row[4]);
			row = mysql_fetch_row (resultado);
		}
	}
	printf("CONSULTA 2 RESPUESTA: %s",respuesta);
}

//Programa que consulta la base de datos y calcula el tiempo total jugado de un jugador pasado como parametro
void  DameConsulta3(char respuesta[700], char nombre[50], MYSQL *conn) {
	MYSQL_RES *resultado;
	MYSQL_ROW row;
	char consulta[700];
	int contador=0;
	int fila;
	sprintf(consulta,"SELECT PARTIDA.DURACION FROM (PARTIDA,JUGADOR,DATOS) WHERE JUGADOR.NOMBRE='%s' AND JUGADOR.ID=DATOS.ID_J AND DATOS.ID_P=PARTIDA.ID",nombre);
	int err = mysql_query(conn, consulta);
	if (err!=0){
		printf ("Error al consultar la base de datos %u %s\n", mysql_errno(conn), mysql_error(conn));
		exit (1);
	}
	// Recoger el resultado de la consulta
	resultado = mysql_store_result(conn);
	row = mysql_fetch_row(resultado);
	if (row == NULL) {
		strcpy(respuesta,"5/0/ERROR_NO_DATOS");
		printf("No se han obtenido datos en la primera consulta\n");
	}
	else {
		while (row != NULL)
		{
			fila = atoi(row[0]);
			contador = contador+fila;
			// Obtenemos la siguiente fila
			row = mysql_fetch_row (resultado);
		}
		sprintf(respuesta,"5/0/JUGADOR: %s, MINUTOS JUGADOS: %d", nombre, contador);
	}
	printf("CONSULTA 3 RESPUESTA: %s",respuesta);
}

//Da el numero de partidas que ganó una persona con el nombre "..."
void  DameConsulta4(char respuesta[700], char nombre[50], MYSQL *conn) {
	MYSQL_RES *resultado;
	MYSQL_ROW row;
	char consulta[700];
	int counter=0;
	int linea;
	sprintf(consulta,"SELECT JUGADOR.ID FROM (JUGADOR,PARTIDA,DATOS) WHERE JUGADOR.NOMBRE='%s' AND JUGADOR.ID=DATOS.ID_J AND DATOS.ID_P=PARTIDA.ID AND PARTIDA.GANADOR='%s'",nombre,nombre);
	int err = mysql_query(conn, consulta);
	if (err!=0){
		printf ("Error al consultar la base de datos %u %s\n", mysql_errno(conn), mysql_error(conn));
		exit (1);
	}
	resultado = mysql_store_result(conn);
	row = mysql_fetch_row(resultado);
	if (row == NULL)
	{
		strcpy(respuesta,"6/0/ERROR_NO_DATOS");
		printf("No se han obtenido datos en la primera consulta\n");
	}
	else
	{
		while (row != NULL) {
			counter = counter + 1;
			row = mysql_fetch_row (resultado);
		}
		sprintf(respuesta,"6/0/%s HA GANADO %i PARTIDAS",nombre,counter);
	}
	printf("CONSULTA 4 RESPUESTA: %s",respuesta);
}

//Función Versión 5, para rellenar mensajes en el chat
void MensajesChat(char mensaje[700], int idPartida) {
	printf("Respuestade chat - %s\n",mensaje);
	char notificacion[700];
	sprintf(notificacion,"10/%d/%s",idPartida,mensaje);
	for (int i=0; i<Partidas.ListaPartidas[idPartida].num;i++) {
		write(Partidas.ListaPartidas[idPartida].partida_jugadores[i].socket,notificacion,strlen(notificacion));
	}
}

void *AtenderCliente(void *socket)
{
	int sock_conn;
	int *s;
	s=(int *) socket;
	sock_conn= *s;
	
	char peticion[700];
	char respuesta[700];
	int ret;
	char nombre[50];
	char contrasena[50];
	char nombre_consulta[50];
	
	//Operaciones para conectarase a la base de datos del juego
	MYSQL *conn;
	int err;
	//Almacenar resultados de consultas
	MYSQL_RES *resultado;
	MYSQL_ROW row;
	//Creamos conexion al servidor MYSQL
	conn = mysql_init(NULL);
	if (conn==NULL)
	{
		printf ("Error al crear la conexion con la base de datos: %u %s\n",
				mysql_errno(conn), mysql_error(conn));
		exit (1);
	}
	//Inicializar la conexion
	conn = mysql_real_connect (conn, "shiva2.upc.es","root","mysql","M2_datos_juego",0, NULL, 0);
	if (conn==NULL)
	{
		printf ("Error al inicializar la conexion con la base de datos: %u %s\n",mysql_errno(conn), mysql_error(conn));
		exit (1);
	}
	
	//Bucle de atencion al cliente
	int terminar=0;
	while (terminar==0)
	{
		//Ahora recibimos su nombre, que dejamos en buff peticion
		ret=read(sock_conn,peticion,sizeof(peticion));
		printf ("Recibido\n");
		
		//Tenemos que anadirle la marca de fin de string 
		//Para que no escriba lo que hay despues en el buffer
		peticion[ret]='\0';
		
		//Escribimos el nombre en la consola
		
		printf("PETICION: %s\n",peticion);
		
		//Saber que nos piden, que peticion
		char *p = strtok(peticion,"/"); //Coge el buff y corta por donde hay una barra
		int codigo =  atoi (p);
		int num_form;
		printf("%d\n",codigo);
		
		if (codigo==0) {
/*			p = strtok(NULL,"/");*/
/*			strcpy(nombre,p);*/
			printf("NOMBRE A ELIMINAR: %s\n",nombre);
			pthread_mutex_lock(&mutex);	//No me interrumpas
			Elimina(&miListaConectados,nombre);
			pthread_mutex_unlock(&mutex); //Ya puedes interrumpir
			Conectados();
			printf("RESULTADO DE CONECTADOS TERMINAR");
			terminar=1;
		}
		else {
			p=strtok(NULL,"/");
			num_form=atoi(p);
			if ((codigo==3) || (codigo==4) || (codigo==5) || (codigo==6)) {
				p = strtok(NULL,"/");
				strcpy(nombre_consulta,p);
				printf("NAME: %s\n",nombre_consulta);
			}
			
			if ((codigo==1) || (codigo==2))
			{
				p = strtok( NULL,"/");
				strcpy(nombre,p); // Copiar nombre
				p = strtok(NULL,"/");
				strcpy(contrasena,p);
				printf("CODE: %d, NAME: %s, PASSWORD: %s\n",codigo,nombre,contrasena);
			}
			
			printf("El codigo es: %d\n",codigo);

			if (codigo==1) {	//El usuario se quiere registrar
				printf("CODE: %d, NAME: %s, PASSWORD: %s\n",codigo,nombre,contrasena);
				Registrar(nombre,contrasena,respuesta,conn,sock_conn);
			}
			
			else if (codigo==2) //EL usuario se quiere loguear
			{
				int resultado_login = Login(nombre,contrasena,respuesta,conn,sock_conn);
				if (resultado_login == 0) {
					printf("RESULTADO DE CONECTADOS LOGIN\n");
					Conectados();
				}
			}
			
			else if (codigo==3) {
				DameConsulta1(respuesta,nombre_consulta,conn);
			}
			
			else if (codigo==4) {
				DameConsulta2(respuesta,nombre_consulta,conn);
			}
			
			else if (codigo==5) {
				DameConsulta3(respuesta,nombre_consulta,conn);
			}
			
			else if (codigo==6) {
				DameConsulta4(respuesta,nombre_consulta,conn);
			}
			
/*			else if (codigo==7) {*/
/*				char misConectados[700];*/
/*				DameConectados(&miListaConectados,misConectados);*/
/*				strcpy(respuesta,"7/");*/
/*				sprintf(respuesta,"%s%s",respuesta,misConectados);*/
/*			}*/
			
			//Cuando se invita a jugar
			else if (codigo==7) {
				char InvitadosJuego[500];
				p=strtok(NULL,"/");
				strcpy(InvitadosJuego,p);
				Invitar(InvitadosJuego,sock_conn);
			}
			
			//Recibir la respuesta
			else if (codigo==8) {
				p=strtok(NULL,"/");
				printf("Respuesta a la invitacion de jugar: %s\n",p);
				RespuestaInvitacion(p);
			}
			
			else if (codigo==9) {
				p=strtok(NULL,"/");
				MensajesChat(p,num_form);
			}
			
			if ((codigo!=0) && (codigo!=7) && (codigo!=8) && (codigo!=9)) {
				write(sock_conn,respuesta,strlen(respuesta));
				printf("RESPUESTA SI CODIGO != 0 o 7 o 8 o 9: %s\n",respuesta);
			}
		}
	}
	// Se acaba el servicio para este cliente
	close(sock_conn);
}

int main(int argc, char *argv[])
{
	int sock_conn, sock_listen, ret;
	int puerto=50055;
	struct sockaddr_in serv_adr;
	
	char peticion[700];
	char respuesta[700];
	
	miListaConectados.num=0;
	
	//INICIALITZACIONS
	//Obrim el socket (Escucha, el servidor espera una conexiÃ³n)
	if ((sock_listen = socket(AF_INET, SOCK_STREAM, 0)) < 0)
		printf("Error creando socket");
	//Fem el bind al port
	
	
	memset(&serv_adr, 0, sizeof(serv_adr)); // Inicialitza a zero serv_addr
	serv_adr.sin_family = AF_INET;
	
	//Asocia el socket a cualquiera de las IP de la maquina. 
	//htonl formatea el numero que recibe al formato necesario
	serv_adr.sin_addr.s_addr = htonl(INADDR_ANY);
	//Escucharemos en el port
	serv_adr.sin_port = htons(puerto);
	if (bind(sock_listen, (struct sockaddr *) &serv_adr, sizeof(serv_adr)) < 0)
		printf ("Error al bind");
	if (listen(sock_listen, 4) < 0) // Hasta 4 peticiones pueden estar en espera
		printf("Error en el listen");
	
	pthread_t thread[100];
	
	for(;;i++){
		printf ("Escuchando\n");
		
		sock_conn = accept(sock_listen, NULL, NULL); //Esperar la conexion hasta recibir
		printf ("He recibido conexion\n");
		//sock_conn es el socket que usaremos para este cliente
		
		sockets[i]=sock_conn;
		
		//Creamos el thread y le decimos que tiene que hacer
		pthread_create (&thread[i],NULL,AtenderCliente,&sockets[i]);
	}
}

