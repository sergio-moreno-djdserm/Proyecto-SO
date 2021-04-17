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

//Lista de conectados
typedef struct {
	char nombre [20];
	int socket;
} Conectado;

typedef struct {
	Conectado conectados[100];
	int num;
} ListaConectados;

//Funciones de la lista de conectados VERSION 2
//Añadir un nuevo conectado, retorna 0 si todo OK y -1 si la lista esta llena
int Pon (ListaConectados *lista, char nombre[20], int socket) {
	if (lista->num==100)
		return -1;
	else {
		strcpy(lista->conectados[lista->num].nombre,nombre);
		lista->conectados[lista->num].socket=socket;
		lista->num++;
		return 0;
	}
}

//Devuelve la posicion en la lista o -1 si no está en la lista
int DamePosicion (ListaConectados *lista, char nombre[20]) {
	int i=0;
	int encontrado=0;
	while ((i<lista->num) && !encontrado) {
		if (strcmp(lista->conectados[i].nombre,nombre)==0)
			encontrado=1;
		if (!encontrado)
			i=i+1;
	}
	if (encontrado)
		return i;
	else
		return -1;
}

//Retorna 0 si elimina y -1 si ese usuario no está en la lista
int Elimina (ListaConectados *lista, char nombre[20]) {
	int pos = DamePosicion(lista, nombre);
	if (pos==-1)
		return -1;
	else {
		int i;
		for (i=pos; i<lista->num-1; i++) {
			lista->conectados[i] = lista->conectados[i+1];
			strcpy(lista->conectados[i].nombre,lista->conectados[i+1].nombre);
			lista->conectados[i].socket=lista->conectados[i+1].socket;
		}
		lista->num--; //Restar 1 al numero de elementos de la lista
		return 0;
	}
}

//Pone en conectados los nombres de todos los conectados separados por ","
void DameConectados (ListaConectados *lista, char conectados[300]) {
	sprintf(conectados,"%d",lista->num);
	int i;
	for (i=0; i<lista->num; i++) {
		sprintf(conectados,"%s,%s",conectados,lista->conectados[i].nombre);
	}
}

int main(int argc, char *argv[])
{
	int sock_conn, sock_listen, ret;
	struct sockaddr_in serv_adr;
	char peticion[700];
	char respuesta[700];
	// INICIALITZACIONS
	// Obrim el socket (Escucha, el servidor espera una conexión)
	if ((sock_listen = socket(AF_INET, SOCK_STREAM, 0)) < 0)
		printf("Error creando socket");
	// Fem el bind al port
	
	//Inicializar lista conectados
	ListaConectados miListaConectados;
	miListaConectados.num=0;
	char misConectados[300];
	
	memset(&serv_adr, 0, sizeof(serv_adr)); // Inicialitza a zero serv_addr
	serv_adr.sin_family = AF_INET;
	
	// Asocia el socket a cualquiera de las IP de la máquina. 
	// htonl formatea el numero que recibe al formato necesario
	serv_adr.sin_addr.s_addr = htonl(INADDR_ANY);
	// Escucharemos en el port 9050
	serv_adr.sin_port = htons(9070);
	if (bind(sock_listen, (struct sockaddr *) &serv_adr, sizeof(serv_adr)) < 0)
		printf ("Error al bind");
	if (listen(sock_listen, 20) < 0) // Hasta 3 peticiones pueden estar en espera
		printf("Error en el listen");
	
	int i;
	for(;;){
		printf ("Escuchando\n");
		
		sock_conn = accept(sock_listen, NULL, NULL); // Esperar la conexión hasta recibir
		printf ("He recibido conexión\n");
		// sock_conn es el socket que usaremos para este cliente
		
		// Conectarse con la base de datos
		MYSQL *conn;
		int err;
		// Almacenar resultados de consultas
		MYSQL_RES *resultado;
		MYSQL_ROW row;
		// Creamos conexión al servidor MYSQL
		conn = mysql_init(NULL);
		if (conn==NULL)
		{
			printf ("Error al crear la conexión: %u %s\n",
					mysql_errno(conn), mysql_error(conn));
			exit (1);
		}
		// Inicializar la conexión
		conn = mysql_real_connect (conn, "localhost","root", "mysql",
								   "datos_juego",0, NULL, 0);
		if (conn==NULL)
		{
			printf ("Error al inicializar la conexión: %u %s\n",
					mysql_errno(conn), mysql_error(conn));
			exit (1);
		}
		
		//Bucle de atención al cliente
		int terminar=0;
		while (terminar==0)
		{
			// Ahora recibimos su nombre, que dejamos en buff peticion
			ret=read(sock_conn,peticion,sizeof(peticion));
			printf ("Recibido\n");
			
			// Tenemos que añadirle la marca de fin de string 
			// Para que no escriba lo que hay despues en el buffer
			peticion[ret]='\0';
			
			//Escribimos el nombre en la consola
			
			printf ("Se ha conectado: %s\n",peticion);
			
			// Saber que nos piden, que petición
			char *p = strtok(peticion, "/"); // Coge el buff y corta por donde hay una barra
			int codigo =  atoi (p);
			char nombre[20];
			char consulta[500];
			char contrasena[50];
			char consulta2[500];
			
			for(i=0;i<strlen(consulta);i++) {
				consulta[i]=NULL;
			}
			if (codigo!=0)
			{
				if ((codigo==1) || (codigo==2) || (codigo==3) || (codigo==4))
				{
					p = strtok( NULL, "/");
					strcpy (nombre, p); // Copiar nombre
					printf ("Codigo: %d, Nombre: %s\n", codigo, nombre);
				}
				if ((codigo==5) || (codigo==6))
				{
					p = strtok( NULL, "/");
					strcpy (nombre, p); // Copiar nombre
					p = strtok(NULL,"/");
					strcpy (contrasena,p);
					printf ("Codigo: %d, Nombre: %s, Contraseña: %s\n", codigo, nombre, contrasena);
				}
			}
			
			if (codigo==0) {
/*				p = strtok( NULL, "/");*/
/*				strcpy (nombre, p); */// Copiar nombre
				Elimina(&miListaConectados,nombre);
				terminar=1;
			}
				
			/*Esta consulta recibe el nombre de un jugador por teclado y devuelve el listado de
			partidas donde ha jugado con los respectivos puntos del jugador*/
			else if (codigo==1)
			{
				for(i=0;i<strlen(respuesta);i++) {
					respuesta[i]=NULL;
				}
				strcpy(consulta,"SELECT * FROM (DATOS,JUGADOR) WHERE JUGADOR.NOMBRE='");
				strcat(consulta,nombre);
				strcat(consulta, "'AND JUGADOR.ID=DATOS.ID_J");
				err=mysql_query (conn, consulta);
				if (err!=0)
				{
					strcpy(respuesta,"Error al consultar la base de datos");
					printf ("Error al consultar datos de la base %u %s\n",
							mysql_errno(conn), mysql_error(conn));
					exit (1);
				}
				// Recoger el resultado de la consulta
				resultado = mysql_store_result (conn);
				row = mysql_fetch_row (resultado);
				if (row == NULL) {
					strcpy(respuesta,"No se han obtenido datos en la consulta");
					printf ("No se han obtenido datos en la consulta\n");
				}
				else
				{
					printf("\n");
					printf("El listado de partidas de %s con sus respectivos puntos es:\n",nombre);
					printf("\n");
				}
				while (row !=NULL)
				{
					sprintf(respuesta,"%sLa ID de la partida es:%s, y su puntuacion:%s\n",respuesta, row[0], row[2]);
					row = mysql_fetch_row (resultado);
				}
			}
			
			/*Esta consulta coge la ID de la partida, la duración y el ganador, de las partidas en las cuales
			jugó la persona que se entra por teclado*/
			else if (codigo==2)
			{
				for(i=0;i<strlen(respuesta);i++) {
					respuesta[i]=NULL;
				}
				strcpy(consulta,"SELECT * FROM (PARTIDA,JUGADOR,DATOS) WHERE JUGADOR.NOMBRE='");
				strcat(consulta,nombre);
				strcat(consulta, "'AND JUGADOR.ID=DATOS.ID_J AND DATOS.ID_P=PARTIDA.ID");
				err=mysql_query (conn, consulta);
				if (err!=0)
				{
					strcpy(respuesta,"Error al consultar la base de datos");
					printf ("Error al consultar datos de la base %u %s\n",
							mysql_errno(conn), mysql_error(conn));
					exit (1);
				}
				// Recoger el resultado de la consulta
				resultado = mysql_store_result (conn);
				row = mysql_fetch_row (resultado);
				if (row == NULL) {
					strcpy(respuesta,"No se han obtenido datos en la consulta");
					printf ("No se han obtenido datos en la consulta\n");
				}
				else
					printf("\n");
				printf("El listado de partidas de %s con sus respectivos puntos es:\n",nombre);
				printf("\n");
				while (row !=NULL)
				{
					sprintf(respuesta,"%sLa ID de la partida es:%s, su duracion:%s, y el ganador:%s\n",respuesta, row[0], row[3], row[4]);
					row = mysql_fetch_row (resultado);
				}
			}
			
			//Programa que consulta la base de datos y calcula el tiempo total jugado de un jugador pasado como parametro
			else if (codigo==3)
			{
				for(i=0;i<strlen(respuesta);i++) {
					respuesta[i]=NULL;
				}
				strcpy (consulta,"SELECT PARTIDA.DURACION FROM (PARTIDA,JUGADOR,DATOS) WHERE JUGADOR.NOMBRE ='");
				strcat (consulta, nombre);
				strcat (consulta,"'AND JUGADOR.ID = DATOS.ID_J AND DATOS.ID_P = PARTIDA.ID");
				err=mysql_query (conn, consulta);
				if (err!=0)
				{
					strcpy(respuesta,"Error al consultar la base de datos");
					printf ("Error al consultar datos de la base %u %s\n",
							mysql_errno(conn), mysql_error(conn));
					exit (1);
				}
				int contador=0;
				int fila;
				// Recoger el resultado de la consulta
				resultado = mysql_store_result (conn);
				row = mysql_fetch_row (resultado);
				if (row == NULL) {
					strcpy(respuesta,"No se han obtenido datos en la consulta");
					printf ("No se han obtenido datos en la consulta\n");
				}
				else
					printf("\n");
				printf("El listado de partidas de %s con sus respectivos puntos es:\n",nombre);
				printf("\n");
				while (row !=NULL)
				{
					fila= atoi(row[0]);
					contador = contador+fila;
					// Obtenemos la siguiente fila
					row = mysql_fetch_row (resultado);
				}
				sprintf(respuesta,"El jugador: %s ha jugado durante: %i minutos",nombre, contador);
			}
			
			// Da el numero de partidas que ganó una persona con el nombre "..."
			else if (codigo==4)
			{
				for(i=0;i<strlen(respuesta);i++) {
					respuesta[i]=NULL;
				}
				strcpy (consulta, "SELECT JUGADOR.ID FROM (JUGADOR,PARTIDA,DATOS) WHERE JUGADOR.NOMBRE ='");
				strcat (consulta, nombre);
				strcat (consulta,"'AND JUGADOR.ID = DATOS.ID_J AND DATOS.ID_P = PARTIDA.ID AND PARTIDA.GANADOR ='");
				strcat (consulta, nombre);
				strcat (consulta,"'");
				
				err=mysql_query (conn, consulta);
				if (err!=0) {
					strcpy(respuesta,"Error al consultar la base de datos");
					printf ("Error al consultar datos de la base %u %s\n",mysql_errno(conn), mysql_error(conn));
					exit (1);
				}
				resultado = mysql_store_result (conn);
				row = mysql_fetch_row (resultado);
				int counter=0;
				int linea;
				if (row == NULL)
				{
					strcpy(respuesta,"No se han obtenido datos en la consulta");
					printf ("No se ha podido obtener datos de la consulta\n");
				}
				else
				{
					while (row !=NULL) {
						counter = counter + 1;
						row = mysql_fetch_row (resultado);
					}
				sprintf(respuesta,"%s ha ganado %i partidas",nombre,counter);
				}
			}
			
			//Para que el usuario se registre
			else if (codigo==5)
			{
				for(i=0;i<strlen(respuesta);i++) {
					respuesta[i]=NULL;
				}
				strcpy(consulta,"SELECT * FROM JUGADOR");
				err=mysql_query (conn, consulta);
				if (err!=0)
				{
					strcpy(respuesta,"Ha habido un error en el proceso");
					printf ("1.Error al consultar datos de la base %u %s\n",
							mysql_errno(conn), mysql_error(conn));
				}
				int contador=1; // Contar jugadores
				//Recoger el resultado de la consulta
				resultado = mysql_store_result (conn);
				row = mysql_fetch_row (resultado);
				if (row == NULL) {
					strcpy(respuesta,"Ha habido un error en el proceso");
					printf ("2.No se han obtenido datos en la consulta\n");
				}
				while (row !=NULL)
				{
					contador = contador+1;
					//Obtenemos la siguiente fila
					row = mysql_fetch_row (resultado);
				}
				printf("%d\n",contador);
				sprintf(consulta2,"INSERT INTO JUGADOR VALUES(%d,'%s','%s',NULL)",contador,nombre,contrasena);
				err=mysql_query (conn, consulta2);
				if (err!=0)
				{
					strcpy(respuesta,"El usuario ya ha sido registrado");
					printf ("3.Error al consultar datos de la base %u %s\n",mysql_errno(conn), mysql_error(conn));
				}
				else
					strcpy(respuesta,"El usuario se ha registrado correctamente");
			}
			
			else if (codigo==6)
			{
				for(i=0;i<strlen(respuesta);i++) {
					respuesta[i]=NULL;
				}
				printf("%s %s\n",nombre,contrasena);
				sprintf(consulta,"SELECT * FROM JUGADOR WHERE JUGADOR.NOMBRE='%s' AND JUGADOR.CONTRASENA='%s'",nombre,contrasena);
				err=mysql_query (conn, consulta);
				if (err!=0)
				{
					strcpy(respuesta,"Ha habido un error en el proceso");
					printf ("Ha habido un error en el proceso %u %s\n",mysql_errno(conn), mysql_error(conn));
				}
				resultado = mysql_store_result (conn);
				row = mysql_fetch_row (resultado);
				if (row == NULL) {
					strcpy(respuesta,"El usuario no esta registrado");
					printf ("El usuario no esta registrado\n");
				}
				else
					strcpy(respuesta,"Has entrado correctamente");
					
					Pon(&miListaConectados,nombre,miListaConectados.num);
					
					printf("CONECTADOS: %d",miListaConectados.num);
			}
			
			else if (codigo==7) {
				for(i=0;i<strlen(respuesta);i++) {
					respuesta[i]=NULL;
				}
				DameConectados(&miListaConectados,misConectados);
				strcpy(respuesta,misConectados);
			}
			
			if (codigo!=0)
			{
				printf ("Respuesta: %s\n", respuesta);
				// Y lo enviamos
				write (sock_conn,respuesta, strlen(respuesta));
			}
		}
		// Se acabó el servicio para este cliente
		close(sock_conn);
		mysql_close (conn);
	}
}


