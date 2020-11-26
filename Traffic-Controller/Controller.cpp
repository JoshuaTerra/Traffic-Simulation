#include <iostream>
#include <sstream>
#include <stdio.h> 
#include <string.h> 
#include <stdlib.h> 
#include <ctime>
#include <WS2tcpip.h>
#include "Controller.h"
#include "Server.h"
#include "ChangeTraffic.h"
#pragma comment(lib, "ws2_32.lib")
#include <sys/types.h>

using namespace std;

int main()
{
	std::shared_ptr<ChangeTraffic> tr(new ChangeTraffic);
	std::shared_ptr<Server> ser(new Server(tr));

	ser->setup();

	int order = 1;
	const char* traffic;
	const char* header;
	const char* package;
	int modorder;

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
			string traffic = tr->change_traffic_order(modorder);
			ser->socketServer(traffic); //package every 4 seconds
			// cout << "Data sent: " << traffic << endl;
		}
		//continuous order
		order++;
	}
	tr.reset();
}




