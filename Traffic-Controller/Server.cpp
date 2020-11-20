#include <iostream>
#include <sstream>
#include <stdio.h> 
#include <string.h> 
#include <stdlib.h> 
#include <ctime>
#include <WS2tcpip.h>
#include "Server.h"
#pragma comment(lib, "ws2_32.lib")
#include <sys/types.h>

using namespace std;

void Server::setup()
{

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
	server.sin_port = htons(port);
	server.sin_addr.S_un.S_addr = INADDR_ANY;
	inet_pton(AF_INET, ipAddress.c_str(), &server.sin_addr); //pton

	bind(listening, (sockaddr*)&server, sizeof(server));

	// Tell winsock the socket is listening
	listen(listening, SOMAXCONN);

	// Wait for connection
	int clientSize = sizeof(server);

	SOCKET ClientSocket = accept(listening, (sockaddr*)&server, &clientSize);
	if (ClientSocket == INVALID_SOCKET) {
		cerr << "Failed" << endl;
		return;
	}
	else {
		cerr << "Connected" << endl;
	}

	clientSocket = ClientSocket;
}

void Server::socketServer(std::string trafficInput)
{
	std::string length = std::to_string(trafficInput.length());
	std::string header = length + ":";
	std::string package = header + trafficInput;
	const char* Input = package.c_str();
	std::string ti = trafficInput;

	// Send and receive data
	char buf[4096];

	do
	{

		int size = strlen(Input);
		if (size > 0)
		{

			// Send the text
			int sendResult = 0;
			if (true) {
				sendResult = send(clientSocket, Input, size, 0);
			}

			if (sendResult != SOCKET_ERROR)
				//if (sendResult == -1)
			{

				// Wait for response
				/*ZeroMemory(buf, 4096);

				int bytesReceived = recv(clientSocket, buf, 4096, 0);
				if (bytesReceived > 0)
				{
					cout << "Socket buffer!\n";
				}*/
			}
			else {
				cerr << "Socket error!\n";
				cerr << WSAGetLastError;
			}
		}

	} while (ti.size() < 0);

	/*closesocket(clientSocket);
	WSACleanup();*/
}