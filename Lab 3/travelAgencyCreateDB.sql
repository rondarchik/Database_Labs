-- DROP tables
DROP SCHEMA public CASCADE;
CREATE SCHEMA public;

-- CREATE tables
CREATE TABLE IF NOT EXISTS Users
(
	id INT NOT NULL GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
	name VARCHAR(100) NOT NULL,
	email VARCHAR(100) NOT NULL UNIQUE,
	password VARCHAR(100) NOT NULL
);

CREATE TABLE IF NOT EXISTS Clients
(
	id INT NOT NULL PRIMARY KEY REFERENCES Users(id),
    surname VARCHAR(100) NOT NULL,
    patronymic VARCHAR(100) NOT NULL,
    phone VARCHAR(17) NOT NULL, 
    birthday DATE NOT NULL,
    client_address VARCHAR(255) NULL
);

CREATE TABLE IF NOT EXISTS Managers
(
	id INT NOT NULL PRIMARY KEY REFERENCES Users(id)
);

CREATE TABLE IF NOT EXISTS Admins
(
	id INT NOT NULL PRIMARY KEY REFERENCES Users(id)
);

CREATE TABLE IF NOT EXISTS Countries
(
	id INT NOT NULL GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
	country_name VARCHAR(100) NOT NULL
);

CREATE TABLE IF NOT EXISTS Cities
(
	id INT NOT NULL GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
	city_name VARCHAR(100) NOT NULL,
	country_id INT NOT NULL,
	
	CONSTRAINT FK_City_Country FOREIGN KEY (country_id) REFERENCES Countries(id)
);

CREATE TABLE IF NOT EXISTS Hotels
(
	id INT NOT NULL GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
	hotel_name VARCHAR(100) NOT NULL,
	hotel_rating NUMERIC(3, 1) NOT NULL,
	city_id INT NOT NULL,
	price_per_night NUMERIC(10, 2) NOT NULL,
	hotel_address VARCHAR(255) NULL,
	
	CONSTRAINT positive_price CHECK (price_per_night > 0),
	
	CONSTRAINT FK_Hotels_City FOREIGN KEY (city_id) REFERENCES Cities(id)
);

CREATE TABLE IF NOT EXISTS TourTypes
(
	id INT NOT NULL GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
	type_name VARCHAR(100) NOT NULL
);

CREATE TABLE IF NOT EXISTS Tours
(
	id INT NOT NULL GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
	tour_name VARCHAR(100) NOT NULL,
	start_date DATE NOT NULL,
	end_date DATE NOT NULL,
	type_id INT NOT NULL,
	hotel_id INT NOT NULL,
	total_price NUMERIC(10, 2) NOT NULL,
	
	CONSTRAINT positive_price CHECK (total_price > 0),
	
	CONSTRAINT FK_Tour_Type FOREIGN KEY (type_id) REFERENCES TourTypes(id),
	CONSTRAINT FK_Tour_Hotel FOREIGN KEY (hotel_id) REFERENCES Hotels(id)
);

CREATE TABLE IF NOT EXISTS Bookings
(
	id INT NOT NULL GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
	client_id INT NOT NULL,
	manager_id INT NOT NULL,
	tour_id INT NOT NULL,
	status BOOLEAN NOT NULL,
	
	CONSTRAINT FK_Booking_Client FOREIGN KEY (client_id) REFERENCES Clients(id),
	CONSTRAINT FK_Booking_Manager FOREIGN KEY (manager_id) REFERENCES Managers(id),
	CONSTRAINT FK_Booking_Tour FOREIGN KEY (tour_id) REFERENCES Tours(id)
);

CREATE TABLE IF NOT EXISTS CreditCards
(
	id INT NOT NULL GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
	card_number VARCHAR(23) NOT NULL UNIQUE, --Max: XXXX-XXXX-XXXX-XXXX
	client_id INT NOT NULL,
	
	CONSTRAINT FK_Card_Client FOREIGN KEY (client_id) REFERENCES Clients(id)
);

CREATE TABLE IF NOT EXISTS TourOrdering
(
	id INT NOT NULL GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
	booking_id INT NOT NULL,
	credit_card_id INT NOT NULL,
	total_price NUMERIC(10, 2) NOT NULL,
	
	CONSTRAINT positive_price CHECK (total_price > 0),
	
	CONSTRAINT FK_Ordering_Booking FOREIGN KEY (booking_id) REFERENCES Bookings(id),
	CONSTRAINT FK_Ordering_Card FOREIGN KEY (credit_card_id) REFERENCES CreditCards(id)	
);

CREATE TABLE IF NOT EXISTS Reviews
(
	id INT NOT NULL GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
	tour_rating NUMERIC(3, 1) NOT NULL,
	review VARCHAR(500) NULL,
	client_id INT NOT NULL,
	tour_id INT NOT NULL,
	publish_date DATE NOT NULL,
	
	CONSTRAINT FK_Review_Client FOREIGN KEY (client_id) REFERENCES Clients(id),
	CONSTRAINT FK_Review_Tour FOREIGN KEY (tour_id) REFERENCES Tours(id)
);

CREATE TABLE IF NOT EXISTS Logs
(
	id INT NOT NULL GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
	user_id INT NOT NULL,
	action_time TIMESTAMP NOT NULL,
	action_info VARCHAR(100) NOT NULL,
	
	CONSTRAINT FK_Log_User FOREIGN KEY (user_id) REFERENCES Users(id)
);