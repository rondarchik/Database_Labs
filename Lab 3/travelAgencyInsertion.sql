-- INSERT rows to tables

-- crypt('password', gen_salt('bf', 8)) - encrypt the password
-- gen_salt() - generate random salt for us
-- 'bf' - blowfish algorithm (Max Password Length: 72, Adaptive - yes, Salt Bits - 128, Output Length - 60)

CREATE EXTENSION IF NOT EXISTS pgcrypto;

INSERT INTO Users(name, email, password) VALUES 
				 ('Викитория', 'admin1@mail.com', crypt('passwordAdmin', gen_salt('bf', 8))),
				 ('Николас', 'manager1@mail.ru', crypt('passwordM1', gen_salt('bf', 8))),
				 ('Александер', 'manager2@mail.ru', crypt('passwordM2', gen_salt('bf', 8))),
				 ('Стефания', 'client1@mail.ru', crypt('passwordCl1', gen_salt('bf', 8))),
				 ('Екатерина', 'client2@mail.ru', crypt('passwordCl2', gen_salt('bf', 8))),
				 ('Всеволод', 'client3@mail.ru', crypt('passwordCl3', gen_salt('bf', 8))),
				 ('Агафья', 'client4@mail.ru', crypt('passwordCl4', gen_salt('bf', 8))),
				 ('Добрыня', 'client5@mail.ru', crypt('passwordCl5', gen_salt('bf', 8))),
				 ('Алексий', 'client6@mail.ru', crypt('passwordCl6', gen_salt('bf', 8)));

INSERT INTO Admins VALUES ((SELECT Users.id FROM Users WHERE Users.email='admin1@mail.com'));

INSERT INTO Managers VALUES ((SELECT Users.id FROM Users WHERE Users.email='manager1@mail.ru')),
 							((SELECT Users.id FROM Users WHERE Users.email='manager2@mail.ru'));

INSERT INTO Clients VALUES ((SELECT Users.id FROM Users WHERE Users.email='client1@mail.ru'),
					'Пень', 'Александровна', '+375251112233', '2000-12-01', NULL),
						
						   ((SELECT Users.id FROM Users WHERE Users.email='client2@mail.ru'),
					'Дворник', 'Александровна', '375 33 299 00 66', '2002-02-20', 'г.Минск, ул.Леонида Беды, д.4к1'),
	
						   ((SELECT Users.id FROM Users WHERE Users.email='client3@mail.ru'),
					'Сацута', 'Иванович', '+375291142233', '2005-11-01', NULL),
						
						   ((SELECT Users.id FROM Users WHERE Users.email='client4@mail.ru'),
					'Белая', 'Ильинична', '+375339998811', '1991-09-21', NULL),

						   ((SELECT Users.id FROM Users WHERE Users.email='client5@mail.ru'),
					'Богатырь', 'Никитич', '+375296667777', '1972-12-31', NULL),

						   ((SELECT Users.id FROM Users WHERE Users.email='client6@mail.ru'),
					'Святой', 'Сергеевич', '+375252522525', '1999-11-11', NULL);
						
INSERT INTO Countries(country_name) VALUES 
                     ('Турция'), ('Италия'), ('Китай'), ('Испания'), ('Греция'), ('Египет'), ('Грузия'), ('Беларусь');

INSERT INTO Cities(city_name, country_id) VALUES 
				  ('Мармарис', (SELECT id FROM Countries WHERE country_name='Турция')),
				  ('Стамбул', (SELECT id FROM Countries WHERE country_name='Турция')),
				  ('Анталья', (SELECT id FROM Countries WHERE country_name='Турция')),
				  ('Рим', (SELECT id FROM Countries WHERE country_name='Италия')),
				  ('Шанхай', (SELECT id FROM Countries WHERE country_name='Китай')),
				  ('Пекин', (SELECT id FROM Countries WHERE country_name='Китай')),
				  ('Барселона', (SELECT id FROM Countries WHERE country_name='Испания')),
				  ('Ла-Молина', (SELECT id FROM Countries WHERE country_name='Испания')),
				  ('Шарм-эль-Шейх', (SELECT id FROM Countries WHERE country_name='Египет')),
				  ('Афины', (SELECT id FROM Countries WHERE country_name='Греция')),
				  ('Тбилиси', (SELECT id FROM Countries WHERE country_name='Грузия')),
				  ('Батуми', (SELECT id FROM Countries WHERE country_name='Грузия')),
				  ('Минск', (SELECT id FROM Countries WHERE country_name='Беларусь'));

INSERT INTO CreditCards(card_number, client_id) VALUES 
					   ('1234-1111-9999-0000', (SELECT id FROM Clients WHERE surname='Дворник')),
					   ('6666-7777-5555-4444', (SELECT id FROM Clients WHERE surname='Дворник')),
					   ('4444-3333-2222-1111', (SELECT id FROM Clients WHERE surname='Богатырь')),
					   ('0000-1111-9999-0000', (SELECT id FROM Clients WHERE surname='Белая'));

INSERT INTO Hotels(hotel_name, hotel_rating, city_id, price_per_night) VALUES 
				  ('Club House Roma', 8.1, (SELECT id FROM Cities WHERE city_name='Рим'), 73),
				  ('Aurasia Beach Hotel', 8.0, (SELECT id FROM Cities WHERE city_name='Мармарис'), 55),
				  ('Magnova Vitality Boutique Hotel', 9.2, (SELECT id FROM Cities WHERE city_name='Стамбул'), 113),
				  ('Taksim Fidan Residence Deluxe', 7.7, (SELECT id FROM Cities WHERE city_name='Стамбул'), 49),
				  ('Lily Town Boutique Hotel', 8.6, (SELECT id FROM Cities WHERE city_name='Анталья'), 25),  
				  ('Campanile Shanghai Bund Hotel', 8.8, (SELECT id FROM Cities WHERE city_name='Шанхай'), 56),
				  ('Happy Dragon.Backpackers Hostel', 7.2, (SELECT id FROM Cities WHERE city_name='Пекин'), 23), 
				  ('Room Mate Gerard', 8.9, (SELECT id FROM Cities WHERE city_name='Барселона'), 137),
				  ('Apartaments Gran Vall', 9.2, (SELECT id FROM Cities WHERE city_name='Ла-Молина'), 157), 
				  ('Coral Beach Resort Montazah (Ex. Rotana)', 7.4, (SELECT id FROM Cities WHERE city_name='Шарм-эль-Шейх'), 44),
				  ('The Duke Boutique Suites', 8.4, (SELECT id FROM Cities WHERE city_name='Афины'), 91),
				  ('Tamarisi Old Tbilisi', 8.4, (SELECT id FROM Cities WHERE city_name='Тбилиси'), 49), 
				  ('Green Yard Hotel', 9.2, (SELECT id FROM Cities WHERE city_name='Батуми'), 22),
				  ('Санаторий Сосны', 9.2, (SELECT id FROM Cities WHERE city_name='Минск'), 70);
	
INSERT INTO TourTypes(type_name) VALUES 
					 ('Экскурсионный'), ('Оздоровительный'), ('Горнолыжный'), ('Отдых на море'), ('Горящие путевки');

INSERT INTO Tours(tour_name, start_date, end_date, type_id, hotel_id, total_price) VALUES 
				 ('Какое-то название 1', '2023-03-20', '2023-03-24', 
				  (SELECT id FROM TourTypes WHERE type_name='Экскурсионный'),
				  (SELECT id FROM Hotels WHERE hotel_name='Club House Roma'),
				  ((SELECT price_per_night FROM Hotels WHERE hotel_name='Club House Roma')*4)),
				  
				 ('Какое-то название 2', '2023-02-12', '2023-02-25', 
				  (SELECT id FROM TourTypes WHERE type_name='Оздоровительный'),
				  (SELECT id FROM Hotels WHERE hotel_name='Санаторий Сосны'),
				  ((SELECT price_per_night FROM Hotels WHERE hotel_name='Санаторий Сосны')*13)),
				  
				 ('Какое-то название 3', '2023-04-20', '2023-04-26', 
				  (SELECT id FROM TourTypes WHERE type_name='Экскурсионный'),
				  (SELECT id FROM Hotels WHERE hotel_name='The Duke Boutique Suites'),
				  ((SELECT price_per_night FROM Hotels WHERE hotel_name='The Duke Boutique Suites')*6)),
				  
				 ('Какое-то название 4', '2023-06-13', '2023-06-20', 
				  (SELECT id FROM TourTypes WHERE type_name='Отдых на море'),
				  (SELECT id FROM Hotels WHERE hotel_name='The Duke Boutique Suites'),
				  ((SELECT price_per_night FROM Hotels WHERE hotel_name='The Duke Boutique Suites')*7)),
				  
				 ('Какое-то название 5', '2022-12-20', '2022-12-27', 
				  (SELECT id FROM TourTypes WHERE type_name='Горящие путевки'),
				  (SELECT id FROM Hotels WHERE hotel_name='Taksim Fidan Residence Deluxe'),
				  ((SELECT price_per_night FROM Hotels WHERE hotel_name='Taksim Fidan Residence Deluxe')*7)),
				  
				 ('Какое-то название 6', '2023-01-16', '2023-01-21', 
				  (SELECT id FROM TourTypes WHERE type_name='Горнолыжный'),
				  (SELECT id FROM Hotels WHERE hotel_name='Apartaments Gran Vall'),
				  ((SELECT price_per_night FROM Hotels WHERE hotel_name='Apartaments Gran Vall')*5));
						
INSERT INTO Bookings(client_id, manager_id, tour_id, status) VALUES
					((SELECT id FROM Clients WHERE surname='Дворник'), 2, 1, true),
					((SELECT id FROM Clients WHERE surname='Святой'), 2, 3, false),
					((SELECT id FROM Clients WHERE surname='Богатырь'), 3, 5, true);
					
INSERT INTO TourOrdering(booking_id, credit_card_id, total_price) VALUES
					    (1, 2, (SELECT total_price FROM Tours WHERE id=1) + 300),
						(3, 3, (SELECT total_price FROM Tours WHERE id=1) + 100);
						
INSERT INTO Reviews(tour_rating, review, client_id, tour_id, publish_date)  VALUES
				   (7.7, NULL, (SELECT id FROM Clients WHERE surname='Дворник'), 2, '2022-06-29'),
				   (9.1, 'потрясающе!', (SELECT id FROM Clients WHERE surname='Сацута'), 4, '2022-02-19'),
				   (8.0, NULL, (SELECT id FROM Clients WHERE surname='Пень'), 3, '2022-10-09'),
				   (5.3, NULL, (SELECT id FROM Clients WHERE surname='Белая'), 6, '2022-11-13');