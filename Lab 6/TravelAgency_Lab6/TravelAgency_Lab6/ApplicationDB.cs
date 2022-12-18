using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Devart.Data;
using Devart.Data.PostgreSql;
using System.Threading.Tasks;
using static System.Windows.Forms.AxHost;
using System.Xml.Linq;
using System.Windows.Forms;
using System.Data;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Collections;
using System.Security.Cryptography;
using System.ComponentModel;

namespace TravelAgency_Lab6
{
    public class ApplicationDB
    {
        private readonly string host = "localhost";
        private readonly string port = "5432";
        private readonly string database = "travelAgency";
        private readonly string userId = "postgres";
        private readonly string initSchema = "public";
        private readonly string password = "password";

        private string connectionString;
        private PgSqlConnection connection;

        public ApplicationDB()
        {
            connectionString = $"User Id={userId};Host={host};Database={database};Port={port};Initial Schema={initSchema};password={password};";
            connection = new PgSqlConnection();
            connection.ConnectionString = connectionString;
        }

        private void OpenConnection()
        {
            if (connection.State == System.Data.ConnectionState.Closed)
                connection.Open();
        }

        private void CloseConnection()
        {
            if (connection.State == System.Data.ConnectionState.Open)
                connection.Close();
        }

        #region queries

        public bool IsUserExists(string email, string password)
        {
            OpenConnection();

            string query = $"SELECT * FROM Users WHERE email={email} AND password={password}";

            PgSqlCommand command = new PgSqlCommand(query, connection);
            PgSqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                CloseConnection();
                return true;
            }

            CloseConnection();
            return false;
        }

        public int GetUserId(string email, string password)
        {
            OpenConnection();

            int id = 0;
            string query = $"SELECT id FROM Users WHERE email='{email}' AND password='{password}'";

            PgSqlCommand command = new PgSqlCommand(query, connection);
            PgSqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                id = Convert.ToInt32(reader["id"]);
            }

            CloseConnection();
            return id;
        }

        public string GetUserName(int id)
        {
            OpenConnection();

            string name = "";
            string query = $"SELECT name FROM Users WHERE id={id}";

            PgSqlCommand command = new PgSqlCommand(query, connection);
            PgSqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                name = reader["name"].ToString();
            }

            CloseConnection();
            return name;
        }

        public int GetIDByName(string name)
        {
            OpenConnection();

            int id = 0;
            string query = $"SELECT id FROM Users WHERE name='{name}'";

            PgSqlCommand command = new PgSqlCommand(query, connection);
            PgSqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                id = Convert.ToInt32(reader["id"]);
            }

            CloseConnection();
            return id;
        }

        public List<string> GetManagersName()
        {
            OpenConnection();

            List<string> names = new List<string>();
            string query = $"SELECT Users.name FROM Users JOIN Managers ON Managers.id=Users.id " +
                $"WHERE EXISTS(SELECT id FROM Managers)";

            PgSqlCommand command = new PgSqlCommand(query, connection);
            PgSqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                names.Add(reader["name"].ToString());
            }

            CloseConnection();
            return names;
        }

        public List<string> GetUserInfo(int id)
        {
            OpenConnection();

            List<string> list = new List<string>();
            string query = $"SELECT * FROM Users WHERE id={id}";

            PgSqlCommand command = new PgSqlCommand(query, connection);
            PgSqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                list.Add(reader["name"].ToString());
                list.Add(reader["email"].ToString());
                list.Add(reader["password"].ToString());
            }

            CloseConnection();
            return list;

        }

        public List<string> GetClientInfo(int id)
        {
            List<string> list = new List<string>();
            var userInfo = GetUserInfo(id);
            list.Add(userInfo[0]);
            list.Add(userInfo[1]);
            list.Add(userInfo[2]);

            OpenConnection();

            string query = $"SELECT * FROM Clients WHERE id={id}";

            PgSqlCommand command = new PgSqlCommand(query, connection);
            PgSqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                list.Add(reader["surname"].ToString());
                list.Add(reader["patronymic"].ToString());
                list.Add(reader["phone"].ToString());
                list.Add(reader["birthday"].ToString());
            }

            CloseConnection();
            return list;
        }

        public bool UserIsClient(int id)
        {
            OpenConnection();

            string query = $"SELECT surname FROM Clients WHERE EXISTS(SELECT id FROM Clients WHERE id={id})";

            PgSqlCommand command = new PgSqlCommand(query, connection);
            PgSqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                CloseConnection();
                return true;
            }

            CloseConnection();
            return false;
        }

        public bool UserIsManager(int id)
        {
            OpenConnection();

            string query = $"SELECT id FROM Managers WHERE EXISTS(SELECT id FROM Managers WHERE id={id})";

            PgSqlCommand command = new PgSqlCommand(query, connection);
            PgSqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                CloseConnection();
                return true;
            }

            CloseConnection();
            return false;
        }

        public bool UserIsAdmin(int id)
        {
            OpenConnection();

            string query = $"SELECT id FROM Admins WHERE EXISTS(SELECT id FROM Admins WHERE id={id})";

            PgSqlCommand command = new PgSqlCommand(query, connection);
            PgSqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                CloseConnection();
                return true;
            }

            CloseConnection();
            return false;
        }

        public int AddUser(string name, string email, string password)
        {
            OpenConnection();

            string query = $"INSERT INTO Users(name, email, password) VALUES('{name}', '{email}', '{password}')";

            PgSqlCommand command = new PgSqlCommand(query, connection);
            command.ExecuteNonQuery();

            int id = GetUserId(email, password);

            CloseConnection();
            return id;
        }

        public void EditUser(int id, string name, string email, string password)
        {
            OpenConnection();

            string query = $"UPDATE Users SET name='{name}', email='{email}', password='{password}' WHERE id={id}";

            PgSqlCommand command = new PgSqlCommand(query, connection);
            command.ExecuteNonQuery();

            CloseConnection();
        }

        public void DeleteManager(int id)
        {
            OpenConnection();

            string query = $"DELETE FROM Managers WHERE id={id}";


            PgSqlCommand command = new PgSqlCommand(query, connection);
            command.ExecuteNonQuery();

            CloseConnection();
        }

        public void DeleteClient(int id)
        {
            OpenConnection();

            string query = $"DELETE FROM Clients WHERE id={id}";


            PgSqlCommand command = new PgSqlCommand(query, connection);
            command.ExecuteNonQuery();

            CloseConnection();
        }

        public void DeleteUser(int id)
        {
            if (UserIsManager(id))
                DeleteManager(id);
            else if (UserIsClient(id))
                DeleteClient(id);

            OpenConnection();

            string query = $"DELETE FROM Users WHERE id={id}";


            PgSqlCommand command = new PgSqlCommand(query, connection);
            command.ExecuteNonQuery();

            CloseConnection();
        }

        public DataSet GetFilterUsers(int id)
        {
            OpenConnection();

            string query = "SELECT Clients.id, Clients.surname, Bookings.id, Bookings.status " +
                "FROM Bookings JOIN Clients ON Bookings.client_id=Clients.id " +
                "JOIN Managers ON Bookings.manager_id=Managers.id " +
                $"WHERE Managers.id={id} AND Bookings.status=false AND Clients.id IN (SELECT client_id FROM CreditCards)";

            PgSqlDataAdapter dataAdapter = new PgSqlDataAdapter(query, connection);
            DataSet data = new DataSet();

            dataAdapter.Fill(data);

            CloseConnection();

            return data;
        }

        public DataSet GetAllrUsers()
        {
            OpenConnection();

            string query = "SELECT Clients.id, Clients.surname, Bookings.id, Bookings.status " +
                "FROM Bookings JOIN Clients ON Bookings.client_id=Clients.id ";
                

            PgSqlDataAdapter dataAdapter = new PgSqlDataAdapter(query, connection);
            DataSet data = new DataSet();

            dataAdapter.Fill(data);

            CloseConnection();

            return data;
        }

        public int AddClient(string name, string email, string password,
            string surname, string patronymic, string phone, string bithday)
        {

            int id = AddUser(name, email, password);

            OpenConnection();

            string query = $"INSERT INTO Clients VALUES('{id}', '{surname}', '{patronymic}', '{phone}', '{bithday}')";

            PgSqlCommand command = new PgSqlCommand(query, connection);
            command.ExecuteNonQuery();

            CloseConnection();
            return id;
        }

        public void UpdateUserInfo(int id, string name, string email, string password)
        {
            OpenConnection();

            string query = $"UPDATE Users SET name='{name}', email='{email}', password='{password}' WHERE id={id}";
            PgSqlCommand command = new PgSqlCommand(query, connection);
            command.ExecuteNonQuery();

            CloseConnection();
        }

        public void UpdateClientInfo(int id, string name, string email, string password,
            string surname, string patronymic, string phone, string bithday)
        {
            UpdateUserInfo(id, name, email, password);

            OpenConnection();

            string query = $"UPDATE Clients SET surname='{surname}', patronymic='{patronymic}', phone='{phone}', " +
                $"birthday='{bithday}' WHERE id={id}";
            PgSqlCommand command = new PgSqlCommand(query, connection);
            command.ExecuteNonQuery();

            CloseConnection();
        }

        public int AddManager(string name, string email, string password)
        {
            int id = AddUser(name, email, password);

            OpenConnection();

            string query = $"INSERT INTO Managers VALUES('{id}')";

            PgSqlCommand command = new PgSqlCommand(query, connection);
            command.ExecuteNonQuery();

            CloseConnection();
            return id;
        }

        public DataSet GetToursInfo()
        {
            OpenConnection();

            string query = $"SELECT Tours.tour_name, Tours.start_date, Tours.end_date, Tours.total_price, TourTypes.type_name, Hotels.hotel_name, Cities.city_name, Countries.country_name " +
                $"FROM Tours JOIN TourTypes ON Tours.type_id=TourTypes.id " +
                $"JOIN Hotels ON Tours.hotel_id=Hotels.id " +
                $"JOIN Cities ON Hotels.city_id=Cities.id " +
                $"JOIN Countries ON Cities.country_id=Countries.id";

            PgSqlDataAdapter dataAdapter = new PgSqlDataAdapter(query, connection);
            DataSet data = new DataSet();

            dataAdapter.Fill(data);
            
            CloseConnection();

            return data;

        }

        public void AddTour(string name, string start, string end, int type_id, int hotel_id)
        {
            OpenConnection();

            string query = $"INSERT INTO Tours(tour_name, start_date, end_date, type_id, hotel_id, total_price) VALUES (" +
                $"'{name}', '{start}', '{end}', {type_id}, {hotel_id}, " +
                $"((SELECT price_per_night FROM Hotels WHERE id={hotel_id})*{(Convert.ToDateTime(end) - Convert.ToDateTime(start)).TotalDays}))";

            PgSqlCommand command = new PgSqlCommand(query, connection);
            command.ExecuteNonQuery();

            CloseConnection();
        }

        public int GetTourIdByName(string name)
        {
            OpenConnection();

            int id = 0;
            string query = $"SELECT id FROM Tours WHERE tour_name='{name}'";

            PgSqlCommand command = new PgSqlCommand(query, connection);
            PgSqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                id = Convert.ToInt32(reader["id"]);
            }

            CloseConnection();
            return id;
        }

        public int GetHotelIdByName(string name)
        {
            OpenConnection();

            int id = 0;
            string query = $"SELECT id FROM Hotels WHERE hotel_name='{name}'";

            PgSqlCommand command = new PgSqlCommand(query, connection);
            PgSqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                id = Convert.ToInt32(reader["id"]);
            }

            CloseConnection();
            return id;
        }

        public int GetTypeIdByName(string name)
        {
            OpenConnection();

            int id = 0;
            string query = $"SELECT id FROM TourTypes WHERE type_name='{name}'";

            PgSqlCommand command = new PgSqlCommand(query, connection);
            PgSqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                id = Convert.ToInt32(reader["id"]);
            }

            CloseConnection();
            return id;
        }

        public void EditTour(int id, string name, string start, string end, int type_id, int hotel_id)
        {
            OpenConnection();

            string query = $"UPDATE Tours SET tour_name='{name}', start_date='{start}', end_date='{end}', type_id={type_id}, hotel_id={hotel_id}, " +
                $"total_price=((SELECT price_per_night FROM Hotels WHERE id={hotel_id})*({(Convert.ToDateTime(end) - Convert.ToDateTime(start)).TotalDays})) WHERE id={id}";

            PgSqlCommand command = new PgSqlCommand(query, connection);
            command.ExecuteNonQuery();

            CloseConnection();
        }

        public void DeleteTour(int id)
        {
            OpenConnection();

            string query = $"DELETE FROM Tours WHERE id={id}";

            PgSqlCommand command = new PgSqlCommand(query, connection);
            command.ExecuteNonQuery();

            CloseConnection();
        }

        public List<string> GetToursInfo(int id)
        {
            OpenConnection();

            List<string> list = new List<string>();
            string query = $"SELECT * FROM Tours WHERE id={id}";

            PgSqlCommand command = new PgSqlCommand(query, connection);
            PgSqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                list.Add(reader["tour_name"].ToString());
                list.Add(reader["start_date"].ToString());
                list.Add(reader["end_date"].ToString());
                list.Add(reader["type_id"].ToString());
                list.Add(reader["hotel_id"].ToString());
            }

            CloseConnection();
            return list;
        }

        public DataSet GetClientBookings(int id)
        {
            OpenConnection();

            string query = "SELECT Users.name, Bookings.id, Bookings.status, Tours.tour_name, Tours.start_date, Tours.end_date, Tours.total_price " +
                "FROM Users JOIN Managers ON Managers.id=Users.id " +
                "JOIN Bookings ON Managers.id=Bookings.manager_id " +
                "JOIN Tours ON Bookings.tour_id=Tours.id " +
                $"WHERE Bookings.client_id={id}";

            PgSqlDataAdapter dataAdapter = new PgSqlDataAdapter(query, connection);
            DataSet data = new DataSet();

            dataAdapter.Fill(data);

            CloseConnection();

            return data;
        }

        public DataSet GetUsers()
        {
            OpenConnection();

            string query = "SELECT * FROM Users WHERE id>1";

            PgSqlDataAdapter dataAdapter = new PgSqlDataAdapter(query, connection);
            DataSet data = new DataSet();

            dataAdapter.Fill(data);

            CloseConnection();

            return data;
        }

        public int GetToursCount()
        {
            OpenConnection();

            int count = 0;
            string query = "SELECT COUNT(tour_name) FROM Tours";

            PgSqlCommand command = new PgSqlCommand(query, connection);
            PgSqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
                count = Convert.ToInt32(reader["count"]);

            return count;

        }

        public List<string> GetToursNames()
        {
            OpenConnection();

            List<string> names = new List<string>();
            string query = "SELECT tour_name FROM Tours";

            PgSqlCommand command = new PgSqlCommand(query, connection);
            PgSqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                names.Add(reader["tour_name"].ToString());
            }

            CloseConnection();
            return names;
        }

        public List<string> GetHotels()
        {
            OpenConnection();

            List<string> names = new List<string>();
            string query = "SELECT hotel_name FROM Hotels";

            PgSqlCommand command = new PgSqlCommand(query, connection);
            PgSqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                names.Add(reader["hotel_name"].ToString());
            }

            CloseConnection();
            return names;
        }

        public List<string> GetTypes()
        {
            OpenConnection();

            List<string> names = new List<string>();
            string query = "SELECT type_name FROM TourTypes";

            PgSqlCommand command = new PgSqlCommand(query, connection);
            PgSqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                names.Add(reader["type_name"].ToString());
            }

            CloseConnection();
            return names;
        }

        public void AddReview(int client_id, int rating, int tour_id, string review = null)
        {
            OpenConnection();

            string query = $"INSERT INTO Reviews(tour_rating, review, client_id, tour_id, publish_date)  VALUES" +
                $"({rating}, '{review}', {client_id}, {tour_id}, '{DateTime.Now}')";

            PgSqlCommand command = new PgSqlCommand(query, connection);
            command.ExecuteNonQuery();

            CloseConnection();
        }

        public void AddCreditCard(int id, string cardNumber)
        {
            OpenConnection();

            string query = $"INSERT INTO CreditCards(card_number, client_id) VALUES('{cardNumber}', {id})";

            PgSqlCommand command = new PgSqlCommand(query, connection);
            command.ExecuteNonQuery();

            CloseConnection();
        }

        public void AddBooking(int client_id, int tour_id, int manager_id)
        {
            OpenConnection();

            string query = $"INSERT INTO Bookings(client_id, manager_id, tour_id, status) VALUES" +
                $"({client_id}, {manager_id}, {tour_id}, {false})";

            PgSqlCommand command = new PgSqlCommand(query, connection);
            command.ExecuteNonQuery();

            CloseConnection();
        }

        public void DeleteBooking(int id)
        {
            OpenConnection();

            string query = $"DELETE FROM Bookings WHERE id={id}";

            PgSqlCommand command = new PgSqlCommand(query, connection);
            command.ExecuteNonQuery();

            CloseConnection();
        }

        public List<int> GetBookingsId(int client_id)
        {
            OpenConnection();

            List<int> bookings = new List<int>();
            string query = $"SELECT id FROM Bookings WHERE Bookings.client_id={client_id}";

            PgSqlCommand command = new PgSqlCommand(query, connection);
            PgSqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                bookings.Add(Convert.ToInt32(reader["id"]));
            }

            CloseConnection();
            return bookings;

        }

        public List<int> GetUsersId(int id)
        {
            OpenConnection();

            List<int> users = new List<int>();
            string query = $"SELECT id FROM Users WHERE Users.id<>{id}";

            PgSqlCommand command = new PgSqlCommand(query, connection);
            PgSqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                users.Add(Convert.ToInt32(reader["id"]));
            }

            CloseConnection();
            return users;

        }

        #endregion

    }
}
