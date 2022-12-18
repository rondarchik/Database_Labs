---------------------------------------------------------------------------------------------------------------------------------------

DROP TRIGGER IF EXISTS manager_registrated ON Managers;
DROP FUNCTION IF EXISTS manager_registrated_log(); 


CREATE OR REPLACE FUNCTION manager_registrated_log()
	RETURNS TRIGGER AS $$
BEGIN

	INSERT INTO Logs(user_id, action_time, action_info)
		VALUES (NEW.id, now(), format('Manager %s %s', (SELECT name FROM Users WHERE id=NEW.id), 'sign up'));
	
	RETURN NEW;

END;
$$ LANGUAGE plpgsql;

CREATE TRIGGER manager_registrated 
		BEFORE INSERT ON Managers 
			FOR EACH ROW
				EXECUTE FUNCTION manager_registrated_log();
				
-- INSERT INTO Users(name, email, password) VALUES ('Валерия', 'managerTest@gmail.com', crypt('passw123321', gen_salt('bf', 8)));
-- INSERT INTO Managers VALUES ((SELECT Users.id FROM Users WHERE Users.email='managerTest@gmail.com'));

---------------------------------------------------------------------------------------------------------------------------------------

DROP TRIGGER IF EXISTS client_registrated ON Clients;
DROP FUNCTION IF EXISTS client_registrated_log(); 


CREATE OR REPLACE FUNCTION client_registrated_log()
	RETURNS TRIGGER AS $$
BEGIN

	INSERT INTO Logs(user_id, action_time, action_info)
		VALUES (NEW.id, now(), format('Client %s %s', NEW.surname, 'sign up'));
	
	RETURN NEW;

END;
$$ LANGUAGE plpgsql;

CREATE TRIGGER client_registrated 
		BEFORE INSERT ON Clients 
			FOR EACH ROW
				EXECUTE FUNCTION client_registrated_log();
				
-- INSERT INTO Users(name, email, password) VALUES ('Григорий', 'example@gmil.com', crypt('password123', gen_salt('bf', 8)));
-- INSERT INTO Clients VALUES ((SELECT Users.id FROM Users WHERE Users.email='example@gmil.com'),
-- 		 					   'Бухта', 'Валерьевич', '+375298887766', '1998-04-11');	

---------------------------------------------------------------------------------------------------------------------------------------

DROP TRIGGER IF EXISTS review_added ON Reviews;
DROP FUNCTION IF EXISTS review_added_log(); 


CREATE OR REPLACE FUNCTION review_added_log()
	RETURNS TRIGGER AS $$

DECLARE tour_title VARCHAR(100);
DECLARE client INT;
DECLARE client_surname VARCHAR(100);

BEGIN

	SELECT tour_name FROM Tours WHERE id=NEW.tour_id INTO tour_title;
	SELECT id FROM Clients WHERE id=NEW.client_id INTO client;
	SELECT surname FROM CLIENTS WHERE id=client INTO client_surname;
	
	INSERT INTO Logs(user_id, action_time, action_info)
		VALUES (client, now(), format('Client %s %s %s', client_surname, 'add review on tour: ', tour_title));
	
	RETURN NEW;

END;
$$ LANGUAGE plpgsql;

CREATE TRIGGER review_added 
		BEFORE INSERT ON Reviews 
			FOR EACH ROW
				EXECUTE FUNCTION review_added_log();
				
-- INSERT INTO Reviews(tour_rating, client_id, tour_id, publish_date) 
-- 	VALUES (8.1, 7, 3, now());

			