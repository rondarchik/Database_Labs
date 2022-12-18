-- INSERT rows to tables

-- 'password' - encrypt the password
-- gen_salt() - generate random salt for us
-- 'bf' - blowfish algorithm (Max Password Length: 72, Adaptive - yes, Salt Bits - 128, Output Length - 60)

CREATE EXTENSION IF NOT EXISTS pgcrypto;

INSERT INTO Users(name, email, password) VALUES 
				 ('Victoriya', 'admin1@mail.com', 'passwordAdmin'),
				 ('Nikolas', 'manager1@mail.ru', 'passwordM1'),
				 ('Alex', 'manager2@mail.ru', 'passwordM2'),
				 ('Stefania', 'client1@mail.ru', 'passwordCl1'),
				 ('Katya', 'client2@mail.ru', 'passwordCl2'),
				 ('Vasya', 'client3@mail.ru', 'passwordCl3'),
				 ('NameTest', 'client4@mail.ru', 'passwordCl4'),
				 ('Dobryna', 'client5@mail.ru', 'passwordCl5'),
				 ('Alexiiii', 'client6@mail.ru', 'passwordCl6');

INSERT INTO Admins VALUES ((SELECT Users.id FROM Users WHERE Users.email='admin1@mail.com'));

INSERT INTO Managers VALUES ((SELECT Users.id FROM Users WHERE Users.email='manager1@mail.ru')),
 							((SELECT Users.id FROM Users WHERE Users.email='manager2@mail.ru'));

INSERT INTO Clients VALUES ((SELECT Users.id FROM Users WHERE Users.email='client1@mail.ru'),
					'S1', 'P1', '+375251112233', '2000-12-01'),
						
						   ((SELECT Users.id FROM Users WHERE Users.email='client2@mail.ru'),
					'S2', 'P1', '375 33 299 00 66', '2002-02-20'),
	
						   ((SELECT Users.id FROM Users WHERE Users.email='client3@mail.ru'),
					'S3', 'P2', '+375291142233', '2005-11-01'),
						
						   ((SELECT Users.id FROM Users WHERE Users.email='client4@mail.ru'),
					'S4', 'P3', '+375339998811', '1991-09-21'),

						   ((SELECT Users.id FROM Users WHERE Users.email='client5@mail.ru'),
					'S5', 'P4', '+375296667777', '1972-12-31'),

						   ((SELECT Users.id FROM Users WHERE Users.email='client6@mail.ru'),
					'S6', 'P5', '+375252522525', '1999-11-11');
						
INSERT INTO Countries(country_name) VALUES 
                     ('Turkey'), ('Italy'), ('China'), ('Spain'), ('Greece'), ('Egypt'), ('Georgia'), ('Belarus');

INSERT INTO Cities(city_name, country_id) VALUES 
				  ('Marmaris', (SELECT id FROM Countries WHERE country_name='Turkey')),
				  ('Istanbul', (SELECT id FROM Countries WHERE country_name='Turkey')),
				  ('Antaia', (SELECT id FROM Countries WHERE country_name='Turkey')),
				  ('Roma', (SELECT id FROM Countries WHERE country_name='Italy')),
				  ('Shanghai', (SELECT id FROM Countries WHERE country_name='China')),
				  ('Beijing', (SELECT id FROM Countries WHERE country_name='China')),
				  ('Barselona', (SELECT id FROM Countries WHERE country_name='Spain')),
				  ('La Molina', (SELECT id FROM Countries WHERE country_name='Spain')),
				  ('Shqrm El Sheikh', (SELECT id FROM Countries WHERE country_name='Egypt')),
				  ('Athynes', (SELECT id FROM Countries WHERE country_name='Greece')),
				  ('Tbilisi', (SELECT id FROM Countries WHERE country_name='Georgia')),
				  ('Batumi', (SELECT id FROM Countries WHERE country_name='Georgia')),
				  ('Minsk', (SELECT id FROM Countries WHERE country_name='Belarus'));

INSERT INTO CreditCards(card_number, client_id) VALUES 
					   ('1234-1111-9999-0000', (SELECT id FROM Clients WHERE surname='S2')),
					   ('6666-7777-5555-4444', (SELECT id FROM Clients WHERE surname='S2')),
					   ('4444-3333-2222-1111', (SELECT id FROM Clients WHERE surname='S5')),
					   ('0000-1111-9999-0000', (SELECT id FROM Clients WHERE surname='S4'));

INSERT INTO Hotels(hotel_name, hotel_rating, city_id, price_per_night) VALUES 
				  ('Club House Roma', 8.1, (SELECT id FROM Cities WHERE city_name='Roma'), 73),
				  ('Aurasia Beach Hotel', 8.0, (SELECT id FROM Cities WHERE city_name='Marmaris'), 55),
				  ('Magnova Vitality Boutique Hotel', 9.2, (SELECT id FROM Cities WHERE city_name='Istanbul'), 113),
				  ('Taksim Fidan Residence Deluxe', 7.7, (SELECT id FROM Cities WHERE city_name='Istanbul'), 49),
				  ('Lily Town Boutique Hotel', 8.6, (SELECT id FROM Cities WHERE city_name='Antaia'), 25),  
				  ('Campanile Shanghai Bund Hotel', 8.8, (SELECT id FROM Cities WHERE city_name='Shanghai'), 56),
				  ('Happy Dragon.Backpackers Hostel', 7.2, (SELECT id FROM Cities WHERE city_name='Beijing'), 23), 
				  ('Room Mate Gerard', 8.9, (SELECT id FROM Cities WHERE city_name='Barselona'), 137),
				  ('Apartaments Gran Vall', 9.2, (SELECT id FROM Cities WHERE city_name='La Molina'), 157), 
				  ('Coral Beach Resort Montazah (Ex. Rotana)', 7.4, (SELECT id FROM Cities WHERE city_name='Shqrm El Sheikh'), 44),
				  ('The Duke Boutique Suites', 8.4, (SELECT id FROM Cities WHERE city_name='Athynes'), 91),
				  ('Tamarisi Old Tbilisi', 8.4, (SELECT id FROM Cities WHERE city_name='Tbilisi'), 49), 
				  ('Green Yard Hotel', 9.2, (SELECT id FROM Cities WHERE city_name='Batumi'), 22),
				  ('SANATORIY SOSNY', 9.2, (SELECT id FROM Cities WHERE city_name='Minsk'), 70);
	
INSERT INTO TourTypes(type_name) VALUES 
					 ('Tourism'), ('Wellness'), ('Ski'), ('Sea'), ('Sales');

INSERT INTO Tours(tour_name, start_date, end_date, type_id, hotel_id, total_price) VALUES 
				 ('Name 1', '2023-03-20', '2023-03-24', 
				  (SELECT id FROM TourTypes WHERE type_name='Tourism'),
				  (SELECT id FROM Hotels WHERE hotel_name='Club House Roma'),
				  ((SELECT price_per_night FROM Hotels WHERE hotel_name='Club House Roma')*4)),
				  
				 ('Name 2', '2023-02-12', '2023-02-25', 
				  (SELECT id FROM TourTypes WHERE type_name='Wellness'),
				  (SELECT id FROM Hotels WHERE hotel_name='SANATORIY SOSNY'),
				  ((SELECT price_per_night FROM Hotels WHERE hotel_name='SANATORIY SOSNY')*13)),
				  
				 ('Name 3', '2023-04-20', '2023-04-26', 
				  (SELECT id FROM TourTypes WHERE type_name='Tourism'),
				  (SELECT id FROM Hotels WHERE hotel_name='The Duke Boutique Suites'),
				  ((SELECT price_per_night FROM Hotels WHERE hotel_name='The Duke Boutique Suites')*6)),
				  
				 ('Name 4', '2023-06-13', '2023-06-20', 
				  (SELECT id FROM TourTypes WHERE type_name='Sea'),
				  (SELECT id FROM Hotels WHERE hotel_name='The Duke Boutique Suites'),
				  ((SELECT price_per_night FROM Hotels WHERE hotel_name='The Duke Boutique Suites')*7)),
				  
				 ('Name 5', '2022-12-20', '2022-12-27', 
				  (SELECT id FROM TourTypes WHERE type_name='Sales'),
				  (SELECT id FROM Hotels WHERE hotel_name='Taksim Fidan Residence Deluxe'),
				  ((SELECT price_per_night FROM Hotels WHERE hotel_name='Taksim Fidan Residence Deluxe')*7)),
				  
				 ('Name 6', '2023-01-16', '2023-01-21', 
				  (SELECT id FROM TourTypes WHERE type_name='Ski'),
				  (SELECT id FROM Hotels WHERE hotel_name='Apartaments Gran Vall'),
				  ((SELECT price_per_night FROM Hotels WHERE hotel_name='Apartaments Gran Vall')*5));
						
INSERT INTO Bookings(client_id, manager_id, tour_id, status) VALUES
					((SELECT id FROM Clients WHERE surname='S2'), 2, 1, true),
					((SELECT id FROM Clients WHERE surname='S6'), 2, 3, false),
					((SELECT id FROM Clients WHERE surname='S5'), 3, 5, true);
					
INSERT INTO TourOrdering(booking_id, credit_card_id, total_price) VALUES
					    (1, 2, (SELECT total_price FROM Tours WHERE id=1) + 300),
						(3, 3, (SELECT total_price FROM Tours WHERE id=1) + 100);
						
INSERT INTO Reviews(tour_rating, review, client_id, tour_id, publish_date)  VALUES
				   (7.7, NULL, (SELECT id FROM Clients WHERE surname='S2'), 2, '2022-06-29'),
				   (9.1, 'cool!', (SELECT id FROM Clients WHERE surname='S3'), 4, '2022-02-19'),
				   (8.0, NULL, (SELECT id FROM Clients WHERE surname='S1'), 3, '2022-10-09'),
				   (5.3, NULL, (SELECT id FROM Clients WHERE surname='S4'), 6, '2022-11-13');