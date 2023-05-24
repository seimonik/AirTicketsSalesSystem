using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTicketSalesSystem
{
    public class AdultTicket
    {
        public int id;
        public string Surname;
        public string Name;
        public string Patronymic;
        public string Sex;
        public string Birthdate;
        public string Numberpassport;
        public string Pointpassport;
        public string Email;
        public string Phone;

        public int id_route;
        public string departure_point;
        public string departure_point_airport;
        public string arrival_point;
        public string arrival_point_airport;

        public int id_flight;
        public string date_departure;
        public string time_departure;
        public string date_of_arrival;
        public string time_of_arrival;
        public string flight_number;
        public int price;
    }
}
