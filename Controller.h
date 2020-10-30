#include <string.h>
#include <iostream>
#include <sstream>
#include <stdio.h> 

using std::string;

class Controller
{
public:
	int send_light_data();
	string change_traffic_order(int order);
	void socket_server(const char* Input);
	string Replace(string str, const string& oldStr, const string& newStr);
};

