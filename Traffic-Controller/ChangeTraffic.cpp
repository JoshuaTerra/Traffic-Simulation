#include "ChangeTraffic.h"

std::string ChangeTraffic::change_traffic_order(int order)
{
	std::string traffic;
	//rechtdoor noord - zuid, oost - west bus 
	if (order == 1)
	{
		traffic = "{\"A1-1\":1,\"A1-2\":1,\"A1-3\":0,\"B1-1\":1,\"B1-2\":1,\"F1-1\":0,\"F1-2\":0,\"V1-1\":0,\"V1-2\":0,\"V1-3\":0,\"V1-4\":0,\"A2-1\":1,\"A2-2\":1,\"A2-3\":0,\"A2-4\":0,\"F2-1\":0,\"F2-2\":0,\"V2-1\":0,\"V2-2\":0,\"V2-3\":0,\"V2-4\":0,\"A3-1\":0,\"A3-2\":0,\"A3-3\":0,\"A3-4\":0,\"A4-1\":0,\"A4-2\":0,\"A4-3\":0,\"A4-4\":0,\"B4-1\":1,\"F4-1\":0,\"F4-2\":0,\"V4-1\":0,\"V4-2\":0,\"V4-3\":0,\"V4-4\":0,\"A5-1\":0,\"A5-2\":0,\"A5-3\":1,\"A5-4\":1,\"F5-1\":0,\"F5-2\":0,\"V5-1\":0,\"V5-2\":0,\"V5-3\":0,\"V5-4\":0,\"A6-1\":1,\"A6-2\":1,\"A6-3\":0,\"A6-4\":0}";
	}
	//rechtdoor en rechtsaf noord - zuid auto 
	else if (order == 2) {
		traffic = "{\"A1-1\":1,\"A1-2\":1,\"A1-3\":1,\"B1-1\":0,\"B1-2\":0,\"F1-1\":0,\"F1-2\":0,\"V1-1\":0,\"V1-2\":0,\"V1-3\":0,\"V1-4\":0,\"A2-1\":1,\"A2-2\":1,\"A2-3\":0,\"A2-4\":0,\"F2-1\":0,\"F2-2\":0,\"V2-1\":0,\"V2-2\":0,\"V2-3\":0,\"V2-4\":0,\"A3-1\":0,\"A3-2\":0,\"A3-3\":0,\"A3-4\":0,\"A4-1\":1,\"A4-2\":1,\"A4-3\":1,\"A4-4\":1,\"B4-1\":0,\"F4-1\":0,\"F4-2\":0,\"V4-1\":0,\"V4-2\":0,\"V4-3\":0,\"V4-4\":0,\"A5-1\":0,\"A5-2\":0,\"A5-3\":1,\"A5-4\":1,\"F5-1\":0,\"F5-2\":0,\"V5-1\":0,\"V5-2\":0,\"V5-3\":0,\"V5-4\":0,\"A6-1\":0,\"A6-2\":0,\"A6-3\":0,\"A6-4\":0}";
	}
	//rechtdoor en rechtsaf oost - west auto 
	else if (order == 3) {
		traffic = "{\"A1-1\":0,\"A1-2\":0,\"A1-3\":0,\"B1-1\":0,\"B1-2\":0,\"F1-1\":0,\"F1-2\":0,\"V1-1\":0,\"V1-2\":0,\"V1-3\":0,\"V1-4\":0,\"A2-1\":1,\"A2-2\":1,\"A2-3\":1,\"A2-4\":1,\"F2-1\":0,\"F2-2\":0,\"V2-1\":0,\"V2-2\":0,\"V2-3\":0,\"V2-4\":0,\"A3-1\":0,\"A3-2\":0,\"A3-3\":1,\"A3-4\":1,\"A4-1\":0,\"A4-2\":0,\"A4-3\":0,\"A4-4\":0,\"B4-1\":0,\"F4-1\":0,\"F4-2\":0,\"V4-1\":0,\"V4-2\":0,\"V4-3\":0,\"V4-4\":0,\"A5-1\":1,\"A5-2\":1,\"A5-3\":1,\"A5-4\":1,\"F5-1\":0,\"F5-2\":0,\"V5-1\":0,\"V5-2\":0,\"V5-3\":0,\"V5-4\":0,\"A6-1\":1,\"A6-2\":1,\"A6-3\":0,\"A6-4\":0}";
	}
	//linksaf noord - west en oost - zuid auto
	else if (order == 4) {
		traffic = "{\"A1-1\":1,\"A1-2\":1,\"A1-3\":0,\"B1-1\":0,\"B1-2\":0,\"F1-1\":0,\"F1-2\":0,\"V1-1\":0,\"V1-2\":0,\"V1-3\":0,\"V1-4\":0,\"A2-1\":0,\"A2-2\":0,\"A2-3\":0,\"A2-4\":0,\"F2-1\":0,\"F2-2\":0,\"V2-1\":0,\"V2-2\":0,\"V2-3\":0,\"V2-4\":0,\"A3-1\":1,\"A3-2\":1,\"A3-3\":1,\"A3-4\":1,\"A4-1\":0,\"A4-2\":0,\"A4-3\":1,\"A4-4\":1,\"B4-1\":0,\"F4-1\":0,\"F4-2\":0,\"V4-1\":0,\"V4-2\":0,\"V4-3\":0,\"V4-4\":0,\"A5-1\":0,\"A5-2\":0,\"A5-3\":0,\"A5-4\":0,\"F5-1\":0,\"F5-2\":0,\"V5-1\":0,\"V5-2\":0,\"V5-3\":0,\"V5-4\":0,\"A6-1\":1,\"A6-2\":1,\"A6-3\":1,\"A6-4\":1}";
	}
	//linksaf noord - oost en zuid - west auto 
	else if (order == 5) {
		traffic = "{\"A1-1\":1,\"A1-2\":1,\"A1-3\":1,\"B1-1\":0,\"B1-2\":0,\"F1-1\":0,\"F1-2\":0,\"V1-1\":0,\"V1-2\":0,\"V1-3\":0,\"V1-4\":0,\"A2-1\":0,\"A2-2\":0,\"A2-3\":0,\"A2-4\":0,\"F2-1\":0,\"F2-2\":0,\"V2-1\":0,\"V2-2\":0,\"V2-3\":0,\"V2-4\":0,\"A3-1\":0,\"A3-2\":0,\"A3-3\":0,\"A3-4\":0,\"A4-1\":1,\"A4-2\":1,\"A4-3\":1,\"A4-4\":1,\"B4-1\":0,\"F4-1\":0,\"F4-2\":0,\"V4-1\":0,\"V4-2\":0,\"V4-3\":0,\"V4-4\":0,\"A5-1\":0,\"A5-2\":0,\"A5-3\":1,\"A5-4\":1,\"F5-1\":0,\"F5-2\":0,\"V5-1\":0,\"V5-2\":0,\"V5-3\":0,\"V5-4\":0,\"A6-1\":0,\"A6-2\":0,\"A6-3\":0,\"A6-4\":0}";
	}
	//fietsverkeer en voetgangersverkeer 
	else if (order == 6) {
		traffic = "{\"A1-1\":0,\"A1-2\":0,\"A1-3\":0,\"B1-1\":0,\"B1-2\":0,\"F1-1\":1,\"F1-2\":1,\"V1-1\":1,\"V1-2\":1,\"V1-3\":1,\"V1-4\":1,\"A2-1\":0,\"A2-2\":0,\"A2-3\":0,\"A2-4\":0,\"F2-1\":1,\"F2-2\":1,\"V2-1\":1,\"V2-2\":1,\"V2-3\":1,\"V2-4\":1,\"A3-1\":0,\"A3-2\":0,\"A3-3\":0,\"A3-4\":0,\"A4-1\":0,\"A4-2\":0,\"A4-3\":0,\"A4-4\":0,\"B4-1\":0,\"F4-1\":1,\"F4-2\":1,\"V4-1\":1,\"V4-2\":1,\"V4-3\":1,\"V4-4\":1,\"A5-1\":0,\"A5-2\":0,\"A5-3\":0,\"A5-4\":0,\"F5-1\":1,\"F5-2\":1,\"V5-1\":1,\"V5-2\":1,\"V5-3\":1,\"V5-4\":1,\"A6-1\":0,\"A6-2\":0,\"A6-3\":0,\"A6-4\":0}";
	}
	//default all orange
	else {
		traffic = "{\"A1-1\":2,\"A1-2\":2,\"A1-3\":2,\"B1-1\":2,\"B1-2\":2,\"F1-1\":2,\"F1-2\":2,\"V1-1\":2,\"V1-2\":2,\"V1-3\":2,\"V1-4\":2,\"A2-1\":2,\"A2-2\":2,\"A2-3\":2,\"A2-4\":2,\"F2-1\":2,\"F2-2\":2,\"V2-1\":2,\"V2-2\":2,\"V2-3\":2,\"V2-4\":2,\"A3-1\":2,\"A3-2\":2,\"A3-3\":2,\"A3-4\":2,\"A4-1\":2,\"A4-2\":2,\"A4-3\":2,\"A4-4\":2,\"B4-1\":2,\"F4-1\":2,\"F4-2\":2,\"V4-1\":2,\"V4-2\":2,\"V4-3\":2,\"V4-4\":2,\"A5-1\":2,\"A5-2\":2,\"A5-3\":2,\"A5-4\":2,\"F5-1\":2,\"F5-2\":2,\"V5-1\":2,\"V5-2\":2,\"V5-3\":2,\"V5-4\":2,\"A6-1\":2,\"A6-2\":2,\"A6-3\":2,\"A6-4\":2}";
	}
	return traffic;
}