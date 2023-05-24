using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTicketSalesSystem
{
    public class Route
    {
        public int id;
        public string departure_point;
        public string departure_point_airport;
        public string arrival_point;
        public string arrival_point_airport;
        public List<Flight> flights;
    }
}
