#include <iostream>
#include <sstream>
#include <stdio.h> 
#include <string.h> 
#include <stdlib.h> 
#include <ctime>
#include <WS2tcpip.h>
#include "Controller.h"
#pragma comment(lib, "ws2_32.lib")
#include <sys/types.h>

using namespace std;

int main() 
{
	Controller controller;
	controller.send_light_data();
}

int Controller::send_light_data() {
	int order = 1;
	const char* traffic;
	const char* header;
	const char* package;
	int modorder;

	// https://stackoverflow.com/questions/10807681/loop-every-10-second

	//timing
	double time_counter = 0;
	clock_t this_time = clock();
	clock_t last_time = this_time;
	const int NUM_SECONDS = 4;

	//run clock
	while (true)
	{
		this_time = clock();
		time_counter += (double)(this_time - last_time);
		last_time = this_time;


		if (time_counter > (double)(NUM_SECONDS * CLOCKS_PER_SEC))
		{
			time_counter -= (double)(NUM_SECONDS * CLOCKS_PER_SEC);
			modorder = (order % 6) + 1; // current order
			string traffic = change_traffic_order(modorder);
			string length = to_string(traffic.length());
			string header = length + ":";
			string package = header + traffic;
			const char* input = package.c_str();
			socket_server(input); //package every 4 seconds
		}
		//continuous order
		order++;
		cout << last_time << endl;
	}
}


string Controller::change_traffic_order(int order)
{
	string traffic;
	//rechtdoor noord - zuid, oost - west bus 
	if (order == 1)
	{
		traffic = "{'A1-1':1,'A1-2':1,'A1-3':0,'B1-1':1,'B1-2':1,'F1-1':0,'F1-2':0,'V1-1':0,'V1-2':0,'V1-3':0,'V1-4':0,'A2-1':1,'A2-2':1,'A2-3':0,'A2-4':0,'F2-1':0,'F2-2':0,'V2-1':0,'V2-2':0,'V2-3':0,'V2-4':0,'A3-1':0,'A3-2':0,'A3-3':0,'A3-4':0,'A4-1':0,'A4-2':0,'A4-3':0,'A4-4':0,'B4-1':1,'F4-1':0,'F4-2':0,'V4-1':0,'V4-2':0,'V4-3':0,'V4-4':0,'A5-1':0,'A5-2':0,'A5-3':1,'A5-4':1,'F5-1':0,'F5-2':0,'V5-1':0,'V5-2':0,'V5-3':0,'V5-4':0,'A6-1':1,'A6-2':1,'A6-3':0,'A6-4':0}";
	}
	//rechtdoor en rechtsaf noord - zuid auto 
	else if (order == 2) {
		traffic = "{'A1-1':1,'A1-2':1,'A1-3':1,'B1-1':0,'B1-2':0,'F1-1':0,'F1-2':0,'V1-1':0,'V1-2':0,'V1-3':0,'V1-4':0,'A2-1':1,'A2-2':1,'A2-3':0,'A2-4':0,'F2-1':0,'F2-2':0,'V2-1':0,'V2-2':0,'V2-3':0,'V2-4':0,'A3-1':0,'A3-2':0,'A3-3':0,'A3-4':0,'A4-1':1,'A4-2':1,'A4-3':1,'A4-4':1,'B4-1':0,'F4-1':0,'F4-2':0,'V4-1':0,'V4-2':0,'V4-3':0,'V4-4':0,'A5-1':0,'A5-2':0,'A5-3':1,'A5-4':1,'F5-1':0,'F5-2':0,'V5-1':0,'V5-2':0,'V5-3':0,'V5-4':0,'A6-1':0,'A6-2':0,'A6-3':0,'A6-4':0}";
	}
	//rechtdoor en rechtsaf oost - west auto 
	else if (order == 3) {
		traffic = "{'A1-1':0,'A1-2':0,'A1-3':0,'B1-1':0,'B1-2':0,'F1-1':0,'F1-2':0,'V1-1':0,'V1-2':0,'V1-3':0,'V1-4':0,'A2-1':1,'A2-2':1,'A2-3':1,'A2-4':1,'F2-1':0,'F2-2':0,'V2-1':0,'V2-2':0,'V2-3':0,'V2-4':0,'A3-1':0,'A3-2':0,'A3-3':1,'A3-4':1,'A4-1':0,'A4-2':0,'A4-3':0,'A4-4':0,'B4-1':0,'F4-1':0,'F4-2':0,'V4-1':0,'V4-2':0,'V4-3':0,'V4-4':0,'A5-1':1,'A5-2':1,'A5-3':1,'A5-4':1,'F5-1':0,'F5-2':0,'V5-1':0,'V5-2':0,'V5-3':0,'V5-4':0,'A6-1':1,'A6-2':1,'A6-3':0,'A6-4':0}";
	}
	//linksaf noord - west en oost - zuid auto
	else if (order == 4) {
		traffic = "{'A1-1':1,'A1-2':1,'A1-3':0,'B1-1':0,'B1-2':0,'F1-1':0,'F1-2':0,'V1-1':0,'V1-2':0,'V1-3':0,'V1-4':0,'A2-1':0,'A2-2':0,'A2-3':0,'A2-4':0,'F2-1':0,'F2-2':0,'V2-1':0,'V2-2':0,'V2-3':0,'V2-4':0,'A3-1':1,'A3-2':1,'A3-3':1,'A3-4':1,'A4-1':0,'A4-2':0,'A4-3':1,'A4-4':1,'B4-1':0,'F4-1':0,'F4-2':0,'V4-1':0,'V4-2':0,'V4-3':0,'V4-4':0,'A5-1':0,'A5-2':0,'A5-3':0,'A5-4':0,'F5-1':0,'F5-2':0,'V5-1':0,'V5-2':0,'V5-3':0,'V5-4':0,'A6-1':1,'A6-2':1,'A6-3':1,'A6-4':1}";
	}
	//linksaf noord - oost en zuid - west auto 
	else if (order == 5) {
		traffic = "{'A1-1':1,'A1-2':1,'A1-3':1,'B1-1':0,'B1-2':0,'F1-1':0,'F1-2':0,'V1-1':0,'V1-2':0,'V1-3':0,'V1-4':0,'A2-1':0,'A2-2':0,'A2-3':0,'A2-4':0,'F2-1':0,'F2-2':0,'V2-1':0,'V2-2':0,'V2-3':0,'V2-4':0,'A3-1':0,'A3-2':0,'A3-3':0,'A3-4':0,'A4-1':1,'A4-2':1,'A4-3':1,'A4-4':1,'B4-1':0,'F4-1':0,'F4-2':0,'V4-1':0,'V4-2':0,'V4-3':0,'V4-4':0,'A5-1':0,'A5-2':0,'A5-3':1,'A5-4':1,'F5-1':0,'F5-2':0,'V5-1':0,'V5-2':0,'V5-3':0,'V5-4':0,'A6-1':0,'A6-2':0,'A6-3':0,'A6-4':0}";
	}
	//fietsverkeer en voetgangersverkeer 
	else if (order == 6) {
		traffic = "{'A1-1':0,'A1-2':0,'A1-3':0,'B1-1':0,'B1-2':0,'F1-1':1,'F1-2':1,'V1-1':1,'V1-2':1,'V1-3':1,'V1-4':1,'A2-1':0,'A2-2':0,'A2-3':0,'A2-4':0,'F2-1':1,'F2-2':1,'V2-1':1,'V2-2':1,'V2-3':1,'V2-4':1,'A3-1':0,'A3-2':0,'A3-3':0,'A3-4':0,'A4-1':0,'A4-2':0,'A4-3':0,'A4-4':0,'B4-1':0,'F4-1':1,'F4-2':1,'V4-1':1,'V4-2':1,'V4-3':1,'V4-4':1,'A5-1':0,'A5-2':0,'A5-3':0,'A5-4':0,'F5-1':1,'F5-2':1,'V5-1':1,'V5-2':1,'V5-3':1,'V5-4':1,'A6-1':0,'A6-2':0,'A6-3':0,'A6-4':0}";
	}
	//default all orange
	else {
		traffic = "{'A1-1':2,'A1-2':2,'A1-3':2,'B1-1':2,'B1-2':2,'F1-1':2,'F1-2':2,'V1-1':2,'V1-2':2,'V1-3':2,'V1-4':2,'A2-1':2,'A2-2':2,'A2-3':2,'A2-4':2,'F2-1':2,'F2-2':2,'V2-1':2,'V2-2':2,'V2-3':2,'V2-4':2,'A3-1':2,'A3-2':2,'A3-3':2,'A3-4':2,'A4-1':2,'A4-2':2,'A4-3':2,'A4-4':2,'B4-1':2,'F4-1':2,'F4-2':2,'V4-1':2,'V4-2':2,'V4-3':2,'V4-4':2,'A5-1':2,'A5-2':2,'A5-3':2,'A5-4':2,'F5-1':2,'F5-2':2,'V5-1':2,'V5-2':2,'V5-3':2,'V5-4':2,'A6-1':2,'A6-2':2,'A6-3':2,'A6-4':2}";
	}
	return traffic;
}

string Controller::Replace(string str, const string& oldStr, const string& newStr)
{

	size_t index = str.find(oldStr);
	while (index != str.npos)
	{
		str = str.substr(0, index) +
			newStr + str.substr(index + oldStr.size());
		index = str.find(oldStr, index + newStr.size());
	}
	return str;
}

void Controller::socket_server(const char* Input)
{
	string ipAddress = "127.0.0.1";

	std::string i = Input;

	// https://www.youtube.com/watch?v=WDn-htpBlnU
	// Init winsock
	WSADATA wsData;
	WORD ver = MAKEWORD(2, 2);

	int wsOk = WSAStartup(ver, &wsData);
	if (wsOk != 0) {
		cerr << "Can't initialize winsock!" << endl;
		return;
	}
	
	// Create socket
	SOCKET listening = socket(AF_INET, SOCK_STREAM, IPPROTO_TCP);
	if (listening == INVALID_SOCKET) {
		cerr << "Can't create socket!" << endl;
		return;
	}

	// bind
	sockaddr_in server;
	server.sin_family = AF_INET;
	server.sin_port = htons(54000);
	server.sin_addr.S_un.S_addr = INADDR_ANY;
	inet_pton(AF_INET, ipAddress.c_str(), &server.sin_addr); //pton

	bind(listening, (sockaddr*)&server, sizeof(server));

	// Tell winsock the socket is listening
	listen(listening, SOMAXCONN);

	// Wait for connection
	int clientSize = sizeof(server);

	SOCKET clientSocket = accept(listening, (sockaddr*)&server, &clientSize);
	if (clientSocket == INVALID_SOCKET) {
		cerr << "Failed" << endl;
		return;
	}

	// Send and receive data
	char buf[4096];
	int size;
	do
	{
		
		size = strlen(Input);
		if (size > 0)		
		{
		
			// Send the text
			int sendResult = send(clientSocket, Input, size, 0);

			if (sendResult != SOCKET_ERROR)
				//if (sendResult == -1)
			{
				// Wait for response
				ZeroMemory(buf, 4096);
				
				int bytesReceived = recv(clientSocket, buf, 4096, 0);
				if (bytesReceived > 0)
				{
					cout << "Socket buffer!\n";
				}
			}
			else {
				cerr << "Socket error!\n";
				cerr << WSAGetLastError;
			}
			
		}

	} while (i.size() > 0);

	closesocket(clientSocket);
	WSACleanup();
}
