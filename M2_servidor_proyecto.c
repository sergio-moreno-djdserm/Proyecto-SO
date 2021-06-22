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
#include <time.h>


//Funciones de la lista de conectados
//Estructuras de Lista de conectados
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
int sockets[];

//Inicializar lista conectados
ListaConectados miListaConectados;
//Fin de variables globales que hacen referencia a la Lista de Conectados


//Función para añadir un nuevo conectado, retorna 0 si todo OK y -1 si la lista esta llena y -2 si ya hay alguien con el mismo nombre
int Pon (ListaConectados *lista, char nombre[20], int socket) {
	if (lista->num==100)
		return -1;	//Lista está llena
	for (int j=0; j<lista->num;j++){
		if (strcmp(lista->conectados[j].nombre,nombre)==0)
			return -2;	//Alguien con el mismo nombre
	}
	strcpy(lista->conectados[lista->num].nombre,nombre);
	lista->conectados[lista->num].socket=socket;
	lista->num=lista->num+1;
	return 0;	//Se ha realizado correctamente
}

//Funcin que devuelve la posicion en la lista o -1 si no está en la lista
int DamePosicion(ListaConectados *lista, char nombre[20]){
	for (int i=0;i<lista->num;i++){
		if (strcmp(lista->conectados[i].nombre,nombre) == 0)
			return i;	//Devolver posición
	}
	return -1;	//Devuelve -1 ya que no se ha encontrado
}

//Función que devuelve el socket de un usuario, devuelve -1 si no está en la lista
int DameSocket (ListaConectados *lista, char nombre[20]){
	for (int i=0;i<lista->num;i++) {
		if (strcmp(lista->conectados[i].nombre,nombre) == 0)
			return lista->conectados[i].socket;	//Devolver socket del usuario
	}
	return -1;	//Devuelve -1 ya que no se ha encontrado en la lista
}

//Función que elimina a alguien (hay que dar un nombre) de la lista de conectados, retorna 0 si elimina y -1 si ese usuario no está en la lista
int Elimina (ListaConectados *lista, char nombre[20]) {
	int pos = DamePosicion(lista, nombre);
	if (pos==-1)
		return -1;	//Si no ha encontrado a la persona, retorna -1
	for (int i=pos; i<lista->num-1; i++) {
		lista->conectados[i] = lista->conectados[i+1];
		strcpy(lista->conectados[i].nombre,lista->conectados[i+1].nombre);
		lista->conectados[i].socket=lista->conectados[i+1].socket;
	}
	lista->num=lista->num-1; //Restar 1 al numero de elementos de la lista
	return 0;	//Retorna 0 si se ha eliminado correctamente
}

//Función que pone en conectados los nombres de todos los conectados separados por "," y devuelve en un char los nombres de los conectados
void DameConectados (ListaConectados *lista, char conectados[700]) {
	sprintf(conectados,"%d",lista->num);
	for (int i=0; i<lista->num; i++) {
		sprintf(conectados,"%s,%s",conectados,lista->conectados[i].nombre);
	}
	printf("CONECTADOS: %s\n",conectados);
}


//Estructuras para las partidas
typedef struct {
	Conectado partida_jugadores[4];	//Lista con los jugadores de la partida_jugadores
	Conectado copia_partida_jugadores[4]; //Lista con la copia de jugadores (estructura auxiliar)
	int respuesta[4];	//Contendrá la respuesta de los jugadores, un 1 será un YES y un 0 un NO si aceptan o rechazan la partida
	int num_respuesta;
	int puntos[4];	//En este vector se va a recopilar la puntuacion de cada uno de los jugadores
	int posiciones[4];	//Aquí se verán donde están las posiciones dentro del mapa de cada uno de los jugadores
	int num;	//Numero de jugadores que hay en una partida
	int num_auxiliar; //Numero de jugadores original de una partida
	int ID_partida;	//Numero de id de partida
	int afectadoPorBOMBA[4]; //1 si está afectado por la bomba de cualquier jugador, 0 si no
	int posicionesBOMBAS[4];	//Saber donde se han tirado las bombas de los players
	int tiempo_segundos_inicio;	//A partir de aqui son parametros de inicio de partida
	char fechahora_partida[150];	//Fecha y hora en la que se inicio una partida
	char solofecha[100];	//Fecha de inicio de una partdia
	char solohora[100];	//Hora de inicio de una partida
	char solofechafin[100];	//Fecha de inicio de una partdia
	char solohorafin[100];	//Hora de inicio de una partida
	int tiempo_segundos_final;	//A partir de aqui son parametros de inicio de partida
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
				tabla->ListaPartidas[ID_partida].copia_partida_jugadores[i]=tabla->ListaPartidas[ID_partida].copia_partida_jugadores[i+1];
			}
			tabla->ListaPartidas[ID_partida].num--;
			tabla->ListaPartidas[ID_partida].num_auxiliar--;
		}
	}
}

//Esta funcion va a incluir la respuesta de peticion a la partida
int IncluyeRespuesta(TablaPartidas *tabla, int respuesta, int ID_partida, char nombre[50]) {
	int i=0;
	int encontrado=0;
	while (encontrado==0) {
		if (strcmp(tabla->ListaPartidas[ID_partida].partida_jugadores[i].nombre,nombre)==0)	//Buscar el jugador en el vector de partida donde se ha pedido que se una
			encontrado=1;
		else
			i++;
	}
	tabla->ListaPartidas[ID_partida].respuesta[i]=respuesta;
	tabla->ListaPartidas[ID_partida].num_respuesta++;
	return tabla->ListaPartidas[ID_partida].num_respuesta;
}

//Funcion que crea la partida y devuelve el numero de jugadores en ella
int CrearPartida(ListaConectados *lista, char jugadores[500], TablaPartidas *tabla) {
	char *p=strtok(jugadores,",");
	int pos;
	Partida partida;	//Inicializar/crear la partida
	partida.num=0;
	partida.num_auxiliar=0;
	partida.activa=0;
	while (p!=NULL) {
		pos=DamePosicion(lista,p);
		printf("Te doy la posicion: %d\n",pos);
		if (pos!=-1) {	//Añadir los jugadores en la partida
			partida.partida_jugadores[partida.num]=lista->conectados[pos];
			partida.copia_partida_jugadores[partida.num]=lista->conectados[pos];
			partida.num=partida.num+1;
			partida.num_auxiliar=partida.num_auxiliar+1;
		}
		p=strtok(NULL,",");
	}
	if (partida.num>=2) {	//Si el numero de jugadores que hay en una partida es mayor a 2. Poner la partida en la tabla de Partidas
		partida.ID_partida=tabla->num_partidas;
		tabla->ListaPartidas[tabla->num_partidas]=partida;
		tabla->ListaPartidas[tabla->num_partidas].num_respuesta=0;
		tabla->num_partidas=tabla->num_partidas+1;
		printf("Partida %d ha sido creada\n",partida.ID_partida);
		if (tabla->num_partidas==100)
			tabla->num_partidas=0;
	}
	printf("Numero de jugadores en la partida: %d\n",partida.num);
	for (int i=0; i<partida.num_auxiliar; i++) {
		printf("Jugadores que iniciaron la partida al principio: %s\n",tabla->ListaPartidas[partida.ID_partida].partida_jugadores[i].nombre);
	}
	return partida.num;	//Numero de jugadores en la partida
}

//Funcion que devuelve los sockets de los participantes en un char
void DameSocketParticipantes(TablaPartidas *tabla, int ID_partida, char sockets[]) {
	for(int i=0;i>tabla->ListaPartidas[ID_partida].num;i++){
		sprintf(sockets,"%s,%s",sockets,tabla->ListaPartidas[ID_partida].partida_jugadores[i].socket);
	}
}

//Funcion que si cumple las condiciones para crear una partida, se añade en la lista la partida y se enviará un mensaje a los jugadores, preguntando si se quieren unir
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
	else {	//Se enviará la invitacion a aquellos jugadores a los cuales hayas querido invitar
		sprintf(notificacion,"8/0/%d,%s",Partidas.num_partidas-1,jugadores_copy);
		for (int i=1;i<num_jugadores;i++) {
			write(Partidas.ListaPartidas[Partidas.num_partidas-1].partida_jugadores[i].socket,notificacion,strlen(notificacion));
		}
	}
}

//Esta funcion recoge las respuestas a las invitaciones y enviará un mensaje para que se inicie la partida si se cumplen los criterios
void RespuestaInvitacion(char respuesta[500], MYSQL *conn) {
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
	
	if (res==Partidas.ListaPartidas[ID_partida].num-1) {	//Si hay alguien que acepta la partida, esta se activa y se podrá iniciar con las personas que hayan aceptado la invitación
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
			//Asignar tiempo inicial de una partida
			AsignarTiempoInicio(&Partidas,ID_partida);
			printf("ASIGNO TIEMPO DE PARTIDA: %s\n",Partidas.ListaPartidas[ID_partida].fechahora_partida);
			printf("NOTIFICACION A RESPUESTA INVITAR: %s\n",notificacion);
		}
		else {	//Si nadie ha aceptado la partida, se enviará una respuesta indicando que no se puede iniciar ya que el jugador está en la FRIENDZONE
			sprintf(notificacion,"9/0/NO,%d",ID_partida);
			write(Partidas.ListaPartidas[ID_partida].partida_jugadores[0].socket,notificacion, strlen(notificacion));
			printf("NOTIFICACION A RESPUESTA INVITAR: %s\n",notificacion);
		}
	}
}

//Funcion para actualizar la lista de conectados cada vez que hay una modificación y enviara una notificacion a todos los jugadores conectados
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

//Funcion para registro del cliente retorna 1 si hay algun tipo de error y 0 si te has registrado
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
		else{	//Cliente se registra correctamente
			printf ("Te has registrado\n");	
			strcpy(respuesta,"1/0/OK");
			return 0;
		}
	}
}

//Funcion para darse de baja del sistema, retorna 0 si se ha dado de baja correctamente
int DarseDeBaja(char nombre[50], char contrasena[50], char respuesta[700], MYSQL *conn, int sock_conn) {
	MYSQL_RES *resultado;
	MYSQL_ROW row;
	char consulta[700];
	sprintf(consulta,"DELETE FROM JUGADOR WHERE JUGADOR.NOMBRE='%s' AND JUGADOR.CONTRASENA='%s'",nombre,contrasena);
	int err = mysql_query(conn,consulta);
	if (err!=0){
		printf ("Error al consultar la base de datos %u %s\n", mysql_errno(conn), mysql_error(conn));
		exit (1);
	}
	resultado = mysql_store_result(conn);
	pthread_mutex_lock(&mutex);
	int res = Elimina (&miListaConectados, nombre);
	pthread_mutex_unlock(&mutex);
	printf ("Usuario eliminado\n");	
	strcpy(respuesta,"11/0/OK");
	return 0;	//Se ha dado de baja correctamente
}

//Funcion para loguearse si ya estás registrado. No deja loguearse si ya tienes una sesion iniciada.
//Retorna 0 si se ha dado de baja y retorna -1 si el usuario ya se habia logueado
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
		strcpy(respuesta,"2/0/ERROR_NO_REGISTRADO");	//El usuario no esta registrado, no se puede loguear
	}
	else {		
		pthread_mutex_lock(&mutex);
		int res = DamePosicion(&miListaConectados,nombre);
		pthread_mutex_unlock(&mutex);
		if (res==-1) { //No está en la lista, lo añadimos
			pthread_mutex_lock(&mutex);
			int res = Pon(&miListaConectados,nombre,sock_conn);
			pthread_mutex_unlock(&mutex);
			strcpy(respuesta,"2/0/OK");
			return 0;	//Se puede loguear, todo es correcto
		}
		else {
			strcpy(respuesta,"2/0/YASESION");
			return -1;	//Ya tiene una sesion iniciada, por lo tanto no se podra loguear
		}
	}
}

//Funciones de consultas
/*Esta consulta recibe el nombre de un jugador por teclado y devuelve el listado de
partidas donde ha jugado con los respectivos puntos del jugador*/
void  DameConsulta1(char respuesta[2000], char nombre[50], MYSQL *conn) {
	MYSQL_RES *resultado;
	MYSQL_ROW row;
	char consulta[2000];
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
			sprintf(respuesta,"%sPartida %s, %s consiguio %s puntos\n",respuesta, row[0], nombre, row[2]);
			row = mysql_fetch_row (resultado);
		}
		printf("CONSULTA 1 RESPUESTA: %s",respuesta);
	}
}

/*Esta consulta coge la ID de la partida, la duración y el ganador, de las partidas en las cuales
jugó la persona que se entra por teclado*/
void  DameConsulta2(char respuesta[2000], char nombre[50], MYSQL *conn) {
	MYSQL_RES *resultado;
	MYSQL_ROW row;
	char consulta[2000];
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
			sprintf(respuesta,"%sPartida %s, duro %s minutos y gano %s\n",respuesta, row[0], row[3], row[4]);
			row = mysql_fetch_row (resultado);
		}
	}
	printf("CONSULTA 2 RESPUESTA: %s",respuesta);
}

//Programa que consulta la base de datos y calcula el tiempo total jugado de un jugador pasado como parametro
void  DameConsulta3(char respuesta[2000], char nombre[50], MYSQL *conn) {
	MYSQL_RES *resultado;
	MYSQL_ROW row;
	char consulta[2000];
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
		sprintf(respuesta,"5/0/%s ha jugado %d minutos", nombre, contador);
	}
	printf("CONSULTA 3 RESPUESTA: %s",respuesta);
}

//Da el numero de partidas que ganó una persona con el nombre "..." que se entra como parametro
void  DameConsulta4(char respuesta[2000], char nombre[50], MYSQL *conn) {
	MYSQL_RES *resultado;
	MYSQL_ROW row;
	char consulta[2000];
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
		sprintf(respuesta,"6/0/%s ha ganado %i partidas",nombre,counter);
	}
	printf("CONSULTA 4 RESPUESTA: %s",respuesta);
}

//Funcion que devuelve el listado de jugadores con los que ya he jugado alguna partida
void  DameConsulta5(char respuesta[2000], char nombre[50], MYSQL *conn) {
	MYSQL_RES *resultado;
	MYSQL_ROW row;
	char consulta[2000];
	int counter=0;
	int linea;
	sprintf(consulta,"SELECT DISTINCT JUGADOR.NOMBRE FROM (JUGADOR,DATOS) WHERE JUGADOR.ID=DATOS.ID_J AND DATOS.ID_P IN (SELECT DATOS.ID_P FROM (DATOS,JUGADOR) WHERE JUGADOR.NOMBRE='%s' AND JUGADOR.ID=DATOS.ID_J) AND JUGADOR.NOMBRE!='%s'",nombre,nombre);
	int err = mysql_query(conn, consulta);
	if (err!=0){
		printf ("Error al consultar la base de datos %u %s\n", mysql_errno(conn), mysql_error(conn));
		exit (1);
	}
	resultado = mysql_store_result(conn);
	row = mysql_fetch_row(resultado);
	if (row == NULL)
	{
		strcpy(respuesta,"14/0/ERROR_NO_DATOS");
		printf("No se han obtenido datos en la primera consulta\n");
	}
	else
	{
		strcpy(respuesta, "14/0/");
			while (row != NULL) {
				sprintf(respuesta,"%sJugador con el que ya he jugado: %s\n",respuesta, row[0]);
				row = mysql_fetch_row (resultado);
		}
			
	}
	printf("CONSULTA 5 RESPUESTA: %s",respuesta);
}

//Resultados de las partidas que jugue con un player
void  DameConsulta6(char respuesta[2000],char nombre_consulta[50], char nombre[50], MYSQL *conn) {
	MYSQL_RES *resultado;
	MYSQL_ROW row;
	char consulta[2000];
	int counter=0;
	int linea;
	sprintf(consulta,"SELECT DISTINCT PARTIDA.ID,PARTIDA.FECHA,PARTIDA.HORA,PARTIDA.DURACION,PARTIDA.GANADOR FROM(PARTIDA,DATOS,JUGADOR) WHERE DATOS.ID_P IN (SELECT DATOS.ID_P FROM(DATOS,JUGADOR) WHERE JUGADOR.ID=DATOS.ID_J AND JUGADOR.NOMBRE='%s') AND PARTIDA.ID= DATOS.ID_P AND JUGADOR.NOMBRE='%s' AND DATOS.ID_J=JUGADOR.ID ",nombre_consulta,nombre);
	int err = mysql_query(conn, consulta);
	if (err!=0){
		printf ("Error al consultar la base de datos %u %s\n", mysql_errno(conn), mysql_error(conn));
		exit (1);
	}
	resultado = mysql_store_result(conn);
	row = mysql_fetch_row(resultado);
	if (row == NULL)
	{
		strcpy(respuesta,"15/0/ERROR_NO_DATOS");
		printf("No se han obtenido datos en la primera consulta\n");
	}
	else {
		strcpy(respuesta,"15/0/");
		while (row != NULL)
		{
			sprintf(respuesta,"%sPartida %s, se inicio el %s a las %s. Duro %s minutos y gano %s\n",respuesta, row[0], row[1], row[2], row[3], row[4]);
			row = mysql_fetch_row (resultado);
		}
	}
	printf("CONSULTA 6 RESPUESTA: %s",respuesta);
}

//Consulta que devuelve el listado de partidas jugadas en un periodo de tiempo dado
void  DameConsulta7(char respuesta[2000], char nombre[50], int fechai, int fechaf, MYSQL *conn) {
	MYSQL_RES *resultado;
	MYSQL_ROW row;
	char consulta[2000];
	int counter=0;
	int linea;
	sprintf(consulta,"SELECT PARTIDA.ID, PARTIDA.FECHA FROM (PARTIDA)");
	int err = mysql_query(conn, consulta);
	if (err!=0){
		printf ("Error al consultar la base de datos %u %s\n", mysql_errno(conn), mysql_error(conn));
		exit (1);
	}
	resultado = mysql_store_result(conn);
	row = mysql_fetch_row(resultado);
	if (row == NULL)
	{
		strcpy(respuesta,"16/0/ERROR_NO_DATOS");
		printf("No se han obtenido datos en la primera consulta\n");
	}
	else
	{
		strcpy(respuesta,"16/0/");
		while (row != NULL) {
			char *n=strtok(row[1],"-");
			int fechadia= atoi(n);
			n = strtok(NULL,"-");
			int fechames= atoi(n);
			n = strtok(NULL,"-");
			int fechano=atoi(n);
			int fechapartida = fechadia+(fechames*30)+(fechano*365);
			if ((fechapartida>=fechai) && ( fechapartida<=fechaf)){
				sprintf(respuesta,"%sPartida %s, se inicio el %d-%d-%d\n",respuesta,row[0],fechadia,fechames,fechano);
			}				
			row = mysql_fetch_row (resultado);
		}
	}
	printf("CONSULTA 7 RESPUESTA: %s",respuesta);
}

//Función Versión 5, envia a todos los jugadores (una notificacion) el mensaje de chat que ha puesto un jugador
void MensajesChat(char mensaje[700], int idPartida) {
	printf("Respuesta de chat - %s\n",mensaje);
	char notificacion[700];
	sprintf(notificacion,"10/%d/%s",idPartida,mensaje);
	for (int i=0; i<Partidas.ListaPartidas[idPartida].num;i++) {
		write(Partidas.ListaPartidas[idPartida].partida_jugadores[i].socket,notificacion,strlen(notificacion));
	}
}

//Funciones para la version final
//La primera funcion asignará la posicion donde se encuentra el jugador
void AsignarPosicion(TablaPartidas *tabla, int posicion, int ID_partida, char nombre[50]) {
	//Ahora guardamos la posicion del jugador
	int i=0;
	int encontrado=0;
	while (encontrado==0) {
		if (strcmp(tabla->ListaPartidas[ID_partida].partida_jugadores[i].nombre,nombre)==0)	//Buscar el jugador en el vector de partida
			encontrado=1;	//Una vez encuentro al jugador le asigno la posicion
		else
			i++;
	}
	tabla->ListaPartidas[ID_partida].posiciones[i]=posicion;
}

//Funcion que enviará a los jugadores de una partdia donde están colocadas las bombas (notificacion), de esta manera se podran pintar en el mapa
void EnviarJugadoresBombas(TablaPartidas *tabla, int ID_partida)
{
	char notificacion[700];
	sprintf(notificacion,"12/%d/",ID_partida);
	for(int i=0;i<tabla->ListaPartidas[ID_partida].num;i++){
		sprintf(notificacion,"%s%d-%d,",notificacion,tabla->ListaPartidas[ID_partida].posiciones[i],tabla->ListaPartidas[ID_partida].posicionesBOMBAS[i]);
	}
	printf("Notificacion de asignación de posicion - %s\n",notificacion);
	for (int i=0; i<tabla->ListaPartidas[ID_partida].num;i++) {
		write(tabla->ListaPartidas[ID_partida].partida_jugadores[i].socket,notificacion,strlen(notificacion));
	}
	//Se enviará un mensaje parecido al siguiente: 12/idPartida/23-3,9-56,6-2,34-0
}

//Funcion que devuelve la posicion en la lista o -1 si no está en la lista o no está afectado 
int DamePosicionDeAfectado(TablaPartidas *tabla, int ID_partida){
	int encontrado=0;
	int i=0;
	while ((i<tabla->ListaPartidas[ID_partida].num) && (encontrado==0)) {
		if (tabla->ListaPartidas[ID_partida].afectadoPorBOMBA[i]==1) {
			encontrado=1;
		}
		else {
			i++;
		}
	}
	if (encontrado==1) {
		printf("Devuelvo la posicion del afectado: %d\n",i);
		return i;	//Devuelve posicion del afectado
	}
	else {
		return -1;	//No ha sido afectado por la bomba
	}
}
//Funcion que solo elimina al jugador afectado por la bomba de la partida
void EliminaAfectado(TablaPartidas *tabla, int ID_partida) {
	int posj = DamePosicionDeAfectado(&Partidas,ID_partida);
	if (posj==-1) {
		printf("No hay nadie para eliminar de la partida\n");
	}
	else {
		printf("Estoy intentando eliminar de la partida al jugador situado en: %d\n",posj);
		printf("Quien es el de esta posicion: %d\n",tabla->ListaPartidas[ID_partida].posiciones[posj]);
		for (int i=posj; i<tabla->ListaPartidas[ID_partida].num-1; i++) {
			tabla->ListaPartidas[ID_partida].partida_jugadores[i]=tabla->ListaPartidas[ID_partida].partida_jugadores[i+1];
			tabla->ListaPartidas[ID_partida].respuesta[i]=tabla->ListaPartidas[ID_partida].respuesta[i+1];
			tabla->ListaPartidas[ID_partida].posiciones[i]=tabla->ListaPartidas[ID_partida].posiciones[i+1];
			tabla->ListaPartidas[ID_partida].afectadoPorBOMBA[i]=tabla->ListaPartidas[ID_partida].afectadoPorBOMBA[i+1];
			tabla->ListaPartidas[ID_partida].posicionesBOMBAS[i]=tabla->ListaPartidas[ID_partida].posicionesBOMBAS[i+1];
		}
		tabla->ListaPartidas[ID_partida].num=tabla->ListaPartidas[ID_partida].num-1; //Restar 1 al numero de elementos de la lista
	}
}

//Function to add delay, sirve para mostrar la explosion durante un tiempo y que no desaparezca de forma instantanea
void delay(int number_of_seconds)
{
	int milli_seconds = 1000*number_of_seconds;
	clock_t start_time = clock();
	while (clock() < start_time + milli_seconds)
		;
}

//Funcin que devuelve la posicion en la lista o -1 si no está en la lista
int DamePosicionParaPuntuar(TablaPartidas *lista, int ID_partida, char nombre[20]){
	for (int i=0;i<lista->ListaPartidas[ID_partida].num_auxiliar;i++){
		if (strcmp(lista->ListaPartidas[ID_partida].copia_partida_jugadores[i].nombre,nombre) == 0)
			return i;	//Devolver posición
	}
	return -1;	//Devuelve -1 ya que no se ha encontrado
}

//Funcion para añadir a la base, informacion de una partida
void  Insertar_Partida_SQL(int ultima_ID, char fecha[50], char hora[50], MYSQL *conn, TablaPartidas *tabla, int ID_partida, char ganador[50], int duracion) {
	MYSQL_RES *resultado;
	MYSQL_ROW row;
	char consulta[700];
	int id_nueva=ultima_ID+1;
	sprintf(consulta,"INSERT INTO PARTIDA VALUES (%d,'%s','%s',%d,'%s');",id_nueva,fecha,hora,duracion,ganador);
	int err = mysql_query(conn, consulta);
	if (err!=0){
		printf ("Error al insertar la partida en la base de datos %u %s\n", mysql_errno(conn), mysql_error(conn));
		exit (1);
	}
	else
	{
		printf("Se han insertado correctamente los valores iniciales de la partida\n");
	}
	for (int i=0; i<tabla->ListaPartidas[ID_partida].num_auxiliar; i++) {
		char consulta2[700];
		sprintf(consulta2, "SELECT JUGADOR.ID FROM JUGADOR WHERE JUGADOR.NOMBRE='%s'",tabla->ListaPartidas[ID_partida].copia_partida_jugadores[i].nombre);
		err = mysql_query(conn, consulta2);
		//Recoger la ID del jugador
		resultado = mysql_store_result(conn);
		row = mysql_fetch_row(resultado);
		int id_player = atoi(row[0]);
		if (err!=0){
			printf ("Error al consultar ID player en la base de datos %u %s\n", mysql_errno(conn), mysql_error(conn));
			exit (1);
		}
		else
		{
			printf("Se han consultado correctamente la ID player en DATOS\n");
		}
		char consulta3[700];
		sprintf(consulta3,"INSERT INTO DATOS VALUES (%d,%d,%d);",id_nueva,id_player,tabla->ListaPartidas[ID_partida].puntos[i]);
		err = mysql_query(conn, consulta3);
		if (err!=0){
			printf ("Error al insertar datos en la base de datos %u %s\n", mysql_errno(conn), mysql_error(conn));
			exit (1);
		}
		else
		{
			printf("Se han insertado correctamente los valores iniciales en DATOS\n");
		}
	}
}

//Esta función recibirá la posicion desde donde se ha lanzado una bomba, todos los jugadores, incluyendo el que la lanza perderán la partida si les alcanza
//Se entran como parametros, la tabla (para saber la pos. de los players, la posicion donde se ha colocado la bomba
//la ID de partida, y el nombre del jugador que ha colocado la bomba
void RecibirBomba(TablaPartidas *tabla, int posicionBOMBA, int ID_partida, char nombre[50], MYSQL *conn) {
	char notificacionMUERTE[700];
	sprintf(notificacionMUERTE,"13/%d/Has MUERTO,%d",ID_partida,posicionBOMBA);
	char notificacionGANADOR[700];
	sprintf(notificacionGANADOR,"13/%d/Has GANADO,%d",ID_partida,posicionBOMBA);
	char notificacionNOCAMBIO[700];
	sprintf(notificacionNOCAMBIO,"13/%d/No CAMBIO,%d",ID_partida,posicionBOMBA);
	//En caso de que nadie muera, no se enviará nada
	for(int i=0;i<tabla->ListaPartidas[ID_partida].num;i++){	//Marcar a los jugadores que han sido afectados por la bomba
		if ((tabla->ListaPartidas[ID_partida].posiciones[i]==posicionBOMBA) || ((tabla->ListaPartidas[ID_partida].posiciones[i]+1)==posicionBOMBA) || ((tabla->ListaPartidas[ID_partida].posiciones[i]-1)==posicionBOMBA) || ((tabla->ListaPartidas[ID_partida].posiciones[i]+10)==posicionBOMBA) || ((tabla->ListaPartidas[ID_partida].posiciones[i]-10)==posicionBOMBA)) {
			//Se pondra al jugador como que la bomba le ha afectado
			tabla->ListaPartidas[ID_partida].afectadoPorBOMBA[i]=1;
		}
		if (strcmp(tabla->ListaPartidas[ID_partida].partida_jugadores[i].nombre,nombre)==0) {
			tabla->ListaPartidas[ID_partida].afectadoPorBOMBA[i]=0; //No le afecta su propia bomba
		}
	}
	
	int num_gente_afectada=0;
	//Notificar a los jugadores que han muerto
	printf("El numero de jugadores en la partida es: %d\n",tabla->ListaPartidas[ID_partida].num);
	for(int i=0;i<tabla->ListaPartidas[ID_partida].num;i++){
		printf("El afectado por bomba es: %d\n",tabla->ListaPartidas[ID_partida].afectadoPorBOMBA[i]);
		if (tabla->ListaPartidas[ID_partida].afectadoPorBOMBA[i]==1) {
			num_gente_afectada=num_gente_afectada+1;
			write(tabla->ListaPartidas[ID_partida].partida_jugadores[i].socket,notificacionMUERTE,strlen(notificacionMUERTE));
		}
	}
	
	//Sistema de puntuacion, por cada persona que se mata, 100 puntos
	int indice_puntuacion = DamePosicionParaPuntuar(&Partidas, ID_partida, nombre);
	printf("En que posicion de la lista se encuentra el jugador que mata: %d\n",indice_puntuacion);
	tabla->ListaPartidas[ID_partida].puntos[indice_puntuacion]=tabla->ListaPartidas[ID_partida].puntos[indice_puntuacion]+100*num_gente_afectada;
	for (int i=0; i<tabla->ListaPartidas[ID_partida].num_auxiliar; i++) {
		printf("Puntos que llevo al tirar esta bomba: %d \n",tabla->ListaPartidas[ID_partida].puntos[i]);
	}
	
	//Eliminar a los jugadores que han muerto
	for (int i=0; i<tabla->ListaPartidas[ID_partida].num;i++) {
		EliminaAfectado(&Partidas,ID_partida);
	}
	for (int i=0; i<tabla->ListaPartidas[ID_partida].num; i++) {
		printf("Resultado: %d\n",tabla->ListaPartidas[ID_partida].posiciones[i]);
	}
	
	printf("Estoy dentro de recibir bomba y quedan %d jugador/es en la partida\n",tabla->ListaPartidas[ID_partida].num);
	
	if (tabla->ListaPartidas[ID_partida].num==1) //Queda un ganador, la partida queda como finalizada y se desactiva y se notifica al ganador
	{
		for (int i=0; i<tabla->ListaPartidas[ID_partida].num_auxiliar;i++) {
			printf("Jugadores que iniciaron la partida al principio: %s\n",tabla->ListaPartidas[ID_partida].copia_partida_jugadores[i].nombre);
		}
		for(int i=0;i<tabla->ListaPartidas[ID_partida].num;i++) {
			write(tabla->ListaPartidas[ID_partida].partida_jugadores[i].socket,notificacionGANADOR,strlen(notificacionGANADOR));
		}
		AsignarTiempoFinal(&Partidas,ID_partida);
		int duracion=((tabla->ListaPartidas[ID_partida].tiempo_segundos_final)-(tabla->ListaPartidas[ID_partida].tiempo_segundos_inicio))/60;
		printf("Duracion total de la partida: %d\n",duracion);
		
		char ganador[50];
		strcpy(ganador,tabla->ListaPartidas[ID_partida].partida_jugadores[0].nombre);
		printf("El ganador de la partida es %s\n",ganador);
		//Insertar en la base de datos los resultados de las Partidas
		int ultima_ID_partida = DameConsultaID_ULTIMA_PARTIDA(conn);
		Insertar_Partida_SQL(ultima_ID_partida, tabla->ListaPartidas[ID_partida].solofecha, tabla->ListaPartidas[ID_partida].solohora, conn, &Partidas, ID_partida, ganador, duracion);
	}
	else {
		//Nadie ha sufrido daños o hay 2 o más jugadores en la partida, le enviaremos un mensaje que indique la posicion de la bomba
		for(int i=0;i<tabla->ListaPartidas[ID_partida].num;i++) {
			write(tabla->ListaPartidas[ID_partida].partida_jugadores[i].socket,notificacionNOCAMBIO,strlen(notificacionNOCAMBIO));
		}
	}
	//Si no es ninguna de estas opciones, no pasará nada
	AsignarBomba(&Partidas,0,ID_partida,nombre);
	for (i=0; i<250; i++) {
		delay(1);
	}
	//Pasado un cierto tiempo envio otra vez la actualizacion de donde se encuentran los jug. y bomb. para poder pintar en el mapa
	EnviarJugadoresBombas(&Partidas, ID_partida);
}

//Funcion que elimina a un jugador que se sale de la partida (lo elimina de la partida donde juega)
void JugadorDesconectarPartida(TablaPartidas *tabla, int ID_partida, char nombre[50], MYSQL *conn) {
	int encontrado=0;
	int i=0;
	
	char notificacionGANADOR[700];	//Es posible que un jugador abandone la partida, y deje al otro solo, entonces este será el ganador
	sprintf(notificacionGANADOR,"17/%d/Has GANADO",ID_partida);
	
	while (i<tabla->ListaPartidas[ID_partida].num && encontrado==0) {
		if (strcmp(tabla->ListaPartidas[ID_partida].partida_jugadores[i].nombre,nombre)==0) {
			encontrado=1;
		}
		else 
			i++;
	}
	if (encontrado==1) {
		for (int j=i; j<tabla->ListaPartidas[ID_partida].num-1; j++) {
			tabla->ListaPartidas[ID_partida].partida_jugadores[j]=tabla->ListaPartidas[ID_partida].partida_jugadores[j+1];
			tabla->ListaPartidas[ID_partida].respuesta[j]=tabla->ListaPartidas[ID_partida].respuesta[j+1];
			tabla->ListaPartidas[ID_partida].posiciones[j]=tabla->ListaPartidas[ID_partida].posiciones[j+1];
			tabla->ListaPartidas[ID_partida].afectadoPorBOMBA[j]=tabla->ListaPartidas[ID_partida].afectadoPorBOMBA[j+1];
			tabla->ListaPartidas[ID_partida].posicionesBOMBAS[j]=tabla->ListaPartidas[ID_partida].posicionesBOMBAS[j+1];
		}
		tabla->ListaPartidas[ID_partida].num=tabla->ListaPartidas[ID_partida].num-1;
	}
	
	//Enviar a los jugadores restantes la posicion de los jugadores y bombas para asi poder pintar en el mapa
	EnviarJugadoresBombas(&Partidas, ID_partida);
	
	if (tabla->ListaPartidas[ID_partida].num==1) //Queda un ganador, la partida queda como finalizada y se desactiva y se envia una notificacion al ganador
	{
		for (int i=0; i<tabla->ListaPartidas[ID_partida].num_auxiliar;i++) {
			printf("Jugadores que iniciaron la partida al principio: %s\n",tabla->ListaPartidas[ID_partida].copia_partida_jugadores[i].nombre);
		}
		for(int i=0;i<tabla->ListaPartidas[ID_partida].num;i++) {
			write(tabla->ListaPartidas[ID_partida].partida_jugadores[i].socket,notificacionGANADOR,strlen(notificacionGANADOR));
		}
		AsignarTiempoFinal(&Partidas,ID_partida);
		int duracion=((tabla->ListaPartidas[ID_partida].tiempo_segundos_final)-(tabla->ListaPartidas[ID_partida].tiempo_segundos_inicio))/60;
		printf("Duracion total de la partida: %d\n",duracion);
		
		char ganador[50];
		strcpy(ganador,tabla->ListaPartidas[ID_partida].partida_jugadores[0].nombre);
		printf("El ganador de la partida es %s\n",ganador);
		//Insertar en la base de datos los resultados de las Partidas
		int ultima_ID_partida = DameConsultaID_ULTIMA_PARTIDA(conn);
		Insertar_Partida_SQL(ultima_ID_partida, tabla->ListaPartidas[ID_partida].solofecha, tabla->ListaPartidas[ID_partida].solohora, conn, &Partidas, ID_partida, ganador, duracion);
	}
}

//Esta funcion asignará la posicion donde se encuentra la bomba que ha tirado el jugador
void AsignarBomba(TablaPartidas *tabla, int posicionBOMBA, int ID_partida, char nombre[50]) {
	//Ahora guardamos la posicion en la que se encuentra la bomba
	int i=0;
	int encontrado=0;
	while (encontrado==0) {
		if (strcmp(tabla->ListaPartidas[ID_partida].partida_jugadores[i].nombre,nombre)==0)	//Buscar el jugador en el vector de partida
			encontrado=1;	//Una vez encuentro al jugador le asigno la posicion de la bomba
		else
			i++;
	}
	tabla->ListaPartidas[ID_partida].posicionesBOMBAS[i]=posicionBOMBA;
}

//Asginar a la partida el tiempo y fecha en que se inicio la misma
void AsignarTiempoInicio(TablaPartidas *tabla, int ID_partida) {
	time_t tiempo = time(0);
	struct tm *tlocal = localtime(&tiempo);
	char output[150];
	strftime(output,150,"%d-%m-%y %H:%M:%S", tlocal);	//Indicar fecha de inicio junto la hora
	strcpy(tabla->ListaPartidas[ID_partida].fechahora_partida,output);
	char hora[100]; char min[100]; char seg[100];
	strftime(hora,150,"%H",tlocal);
	strftime(min,150,"%M",tlocal);
	strftime(seg,150,"%S",tlocal);
	tabla->ListaPartidas[ID_partida].tiempo_segundos_inicio=atoi(hora)*3600+atoi(min)*60+atoi(seg); //Nos servirá para saber la duracion
	char output2[100];
	strftime(output2,100,"%d-%m-%y",tlocal);
	strcpy(tabla->ListaPartidas[ID_partida].solofecha,output2);
	printf("SOLO INDICIO FECHA: %s\n",output2);
	char output3[100];
	strftime(output3,100,"%H:%M:%S",tlocal);
	strcpy(tabla->ListaPartidas[ID_partida].solohora,output3);
	printf("SOLO INDICIO HORA: %s\n",output3);
}

//Asginar a la partida el tiempo y fecha en que se inicio la misma
void AsignarTiempoFinal(TablaPartidas *tabla, int ID_partida) {
	time_t tiempo = time(0);
	struct tm *tlocal = localtime(&tiempo);
	char output[150];
	strftime(output,150,"%d-%m-%y %H:%M:%S", tlocal);	//Indicar fecha de inicio junto la hora
	char hora[100]; char min[100]; char seg[100];
	strftime(hora,150,"%H",tlocal);
	strftime(min,150,"%M",tlocal);
	strftime(seg,150,"%S",tlocal);
	tabla->ListaPartidas[ID_partida].tiempo_segundos_final=atoi(hora)*3600+atoi(min)*60+atoi(seg); //Nos servirá para saber la duracion
	char output2[100];
	strftime(output2,100,"%d-%m-%y",tlocal);
	strcpy(tabla->ListaPartidas[ID_partida].solofechafin,output2);
	printf("SOLO INDICIO FECHA FINAL: %s\n",output2);
	char output3[100];
	strftime(output3,100,"%H:%M:%S",tlocal);
	strcpy(tabla->ListaPartidas[ID_partida].solohorafin,output3);
	printf("SOLO INDICIO HORA FINAL: %s\n",output3);
}

//Consultar ID de la ultima partida que alguien jugo
int DameConsultaID_ULTIMA_PARTIDA(MYSQL *conn) {
	MYSQL_RES *resultado;
	MYSQL_ROW row;
	char consulta[700];
	sprintf(consulta,"SELECT MAX(ID) FROM PARTIDA");
	int err = mysql_query(conn, consulta);
	if (err!=0){
		printf ("Error al consultar la base de datos %u %s\n", mysql_errno(conn), mysql_error(conn));
		exit (1);
	}
	// Recoger el resultado de la consulta
	resultado = mysql_store_result(conn);
	row = mysql_fetch_row(resultado);
	if (row == NULL) {
		printf("Ha habido un error\n");
	}
	else
	{
		printf("CONSULTA ULTIMA PARTIDA: %s\n",row[0]);
		return atoi(row[0]);
	}
}

//Funcion que atiende al cliente infinitamente hasta que se desconecta
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
		
		if (codigo==0) { //El jugador se desconecta
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
			num_form=atoi(p);	//El num form corresponde a la id de la partida
			if ((codigo==3) || (codigo==4) || (codigo==5) || (codigo==6) || (codigo==14)) {
				p = strtok(NULL,"/");
				strcpy(nombre_consulta,p);
				printf("NAME: %s\n",nombre_consulta);
			}
			
			if ((codigo==1) || (codigo==2) || (codigo==10))
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
				if (resultado_login == -1) {
					printf("Termino de atender al cliente\n");
					terminar=1;
				}
			}
			
			else if (codigo==3) { //Consulta 1 (explicacion donde se encuentra la funcion)
				DameConsulta1(respuesta,nombre_consulta,conn);
			}
			
			else if (codigo==4) { //Consulta 2 (explicacion donde se encuentra la funcion)
				DameConsulta2(respuesta,nombre_consulta,conn);
			}
			
			else if (codigo==5) { //Consulta 3 (explicacion donde se encuentra la funcion)
				DameConsulta3(respuesta,nombre_consulta,conn);
			}
			
			else if (codigo==6) { //Consulta 4 (explicacion donde se encuentra la funcion)
				DameConsulta4(respuesta,nombre_consulta,conn);
			}
			
			//Cuando se invita a jugar
			else if (codigo==7) {
				char InvitadosJuego[500];
				p=strtok(NULL,"/");
				strcpy(InvitadosJuego,p);
				Invitar(InvitadosJuego,sock_conn);
			}
			
			//Recibir la respuesta de un jugador diciendo si acepta o no jugar la partida
			else if (codigo==8) {
				p=strtok(NULL,"/");
				printf("Respuesta a la invitacion de jugar: %s\n",p);
				RespuestaInvitacion(p,conn);
			}
			
			else if (codigo==9) { //Recibir un mensaje de chat de algun jugador
				p=strtok(NULL,"/");
				MensajesChat(p,num_form);
			}
			
			else if (codigo==10) { //Recibir que un jugador quiere darse de baja del sistema
				DarseDeBaja(nombre,contrasena,respuesta,conn,sock_conn);
			}
			
			else if (codigo==11) {	//Recibir un cambio de posicion y actualizar
				//Aqui recibiremos el num_form (idPartida) y tendremos que trocear el nombre y la posicion de la persona que pide servicio
				//mensaje=11/ID_partida/nombre,posicion
				p=strtok(NULL,",");
				char nombre11[20];
				strcpy(nombre11,p);
				p=strtok(NULL,",");
				int posicion_actual;
				posicion_actual=atoi(p);
				printf("%s se encuentra en el boton %d\n",nombre11,posicion_actual);
				pthread_mutex_lock(&mutex);
				AsignarPosicion(&Partidas,posicion_actual,num_form,nombre11);
				pthread_mutex_unlock(&mutex);
				//Aquí va la funcion para añadirle la posicion al jugador
				//En una función tendremos que mirar donde esta el jugador colocado en ListaPartidas[idPartida].partida_jugadores[i] (es decir mirar su socket o el nombre y asignarle la posicion
				//Una vez que nos asigna la posicion, envia un mensaje/notificacion a todos los clientes, actualizando la posicion en la que me encuentro
				EnviarJugadoresBombas(&Partidas, num_form);
			}
			
			else if (codigo==12) {
				//Aqui recibiremos el mensaje de que se ha explotado una bomba
				//mensaje=12/ID_partida/nombre12,posicionBOMBA
				//Llamaremos a la funcion RecibirBomba(&Partidas,posicionBOMBA,num_form,nombre12)
				//A los jugadores que han muerto se les notificará que para ellos ha finalizado la Partida
				//Para el resto de jugadores: si alguien ha matado a alguno este recibira puntos, sino, la partida continua
				//La partida continua hasta que solo quede un jugador, sino, se indicara que el ultimo jugador es el ganador y finalizara la partida
				p=strtok(NULL,",");
				char nombre12[20];
				strcpy(nombre12,p);
				p=strtok(NULL,",");
				int posicionBOMBA;
				posicionBOMBA=atoi(p);
				printf("%s tira una bomba en el boton %d\n",nombre12,posicionBOMBA);
				pthread_mutex_lock(&mutex);
				RecibirBomba(&Partidas,posicionBOMBA,num_form,nombre12,conn);
				pthread_mutex_unlock(&mutex);
			}
			
			else if (codigo==13) { //Consulta 5 (explicacion donde se encuentra la funcion)
				DameConsulta5(respuesta,nombre,conn);
			}
			
			else if (codigo==14) { //Consulta 6 (explicacion donde se encuentra la funcion)
				DameConsulta6(respuesta,nombre_consulta,nombre,conn);
			}
			
			else if (codigo==15) { //Consulta 7 (explicacion donde se encuentra la funcion), consultar partidas jugadas entre un periodo dado
				p = strtok(NULL,"/");
				int diai=atoi(p);
				p=strtok(NULL,"/");
				int mesi=atoi(p);
				p=strtok(NULL,"/");
				int anoi=atoi(p);
				p=strtok(NULL,"/");
				int diaf=atoi(p);
				p=strtok(NULL,"/");
				int mesf=atoi(p);
				p=strtok(NULL,"/");
				int anof=atoi(p);
				int fechai = diai + mesi*30+anoi*365;
				int fechaf = diaf + mesf*30+anof*365;
				DameConsulta7(respuesta,nombre,fechai,fechaf,conn);
			}
			
			else if (codigo==16) {	//Esta función más que nada nos servirá para notificar a todos los clientes donde se ha tirado una bomba y así poder pintarlas en el mapa
				p=strtok(NULL,",");
				char nombre16[20];
				strcpy(nombre16,p);
				p=strtok(NULL,",");
				int posicionBOMBA16;
				posicionBOMBA16=atoi(p);
				printf("%s tira una bomba en el boton %d\n",nombre16,posicionBOMBA16);
				pthread_mutex_lock(&mutex);
				AsignarBomba(&Partidas,posicionBOMBA16,num_form,nombre16);
				pthread_mutex_unlock(&mutex);
				EnviarJugadoresBombas(&Partidas, num_form);
			}
			
			else if (codigo==17) {	//Recibo que un jugador se quiere desconectar de una partida
				p=strtok(NULL,"/");
				char nombre17[20];
				strcpy(nombre17,p);
				pthread_mutex_lock(&mutex);
				JugadorDesconectarPartida(&Partidas,num_form,nombre17,conn);
				pthread_mutex_unlock(&mutex);
			}
			
			if ((codigo!=0) && (codigo!=17) && (codigo!=7) && (codigo!=8) && (codigo!=9) && (codigo!=11) && (codigo!=12) && (codigo!=16)) {
				write(sock_conn,respuesta,strlen(respuesta));
				printf("RESPUESTA SI CODIGO != 0 o 7 o 8 o 9 o 11 o 12 o 16: %s\n",respuesta);
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
	
	pthread_t thread;
	
	for(;;i++){
		printf ("Escuchando\n");
		
		sock_conn = accept(sock_listen, NULL, NULL); //Esperar la conexion hasta recibir
		printf ("He recibido conexion\n");
		//sock_conn es el socket que usaremos para este cliente
		
		sockets[i]=sock_conn;
		
		//Creamos el thread y le decimos que tiene que hacer
		pthread_create (&thread,NULL,AtenderCliente,&sockets[i]);
	}
}

