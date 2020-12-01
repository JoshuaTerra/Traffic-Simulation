#include <string.h>
#include <iostream>
#include <sstream>
#include <stdio.h>
#include "ChangeTraffic.h"

using std::string;

class Server 
{
public:
	Server(std::shared_ptr<ChangeTraffic> ser) : ptr_tr(move(ser)) {};

	std::string ipAddress = "127.0.0.1";
	int port = 54000;
	SOCKET clientSocket = INVALID_SOCKET;
	bool running = false;

	void setup();
	void socketServer(std::string trafficInput);

private:
	std::shared_ptr<ChangeTraffic> ptr_tr;

};