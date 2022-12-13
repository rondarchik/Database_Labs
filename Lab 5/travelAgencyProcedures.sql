CREATE OR REPLACE PROCEDURE manager_registration(
		_email VARCHAR(100),
		_password VARCHAR(100),
		_name VARCHAR(100)
) AS $$
BEGIN 

	INSERT INTO Users(name, email, password)
		VALUES (_name, _email, crypt(_password, gen_salt('bf', 8)));
		
	INSERT INTO Managers VALUES ((SELECT Users.id FROM Users WHERE Users.email=_email));
								
END;
$$ LANGUAGE plpgsql; -- PL/pgSQL - процедурный язык SQL	

-- CALL managerRegistration('managerTest@gmail.com', '12345678', 'Наталья');


CREATE OR REPLACE PROCEDURE client_registration(
		_email VARCHAR(100),
		_password VARCHAR(100),
		_name VARCHAR(100),
		_surname VARCHAR(100),
		_patronymic VARCHAR(100),
		_phone VARCHAR(17),
		_birthday DATE
) AS $$
BEGIN 

	INSERT INTO Users(name, email, password)
		VALUES (_name, _email, crypt(_password, gen_salt('bf', 8)));
		
	INSERT INTO Clients VALUES ((SELECT Users.id FROM Users WHERE Users.email=_email),
								_surname, _patronymic, _phone, _birthday);
								
END;
$$ LANGUAGE plpgsql;
 
-- CALL clientRegistration('example@gmil.com', 'password123', 'Григорий',
-- 					   'Бухта', 'Валерьевич', '+375298887766', '1998-04-11');	


CREATE OR REPLACE FUNCTION get_tour_price_in_hotel(
		hotel_id INT,
		start_date DATE,
		end_date DATE
) RETURNS NUMERIC(10, 2) AS $$

DECLARE days INT;
DECLARE price NUMERIC(10, 2);

BEGIN

	SELECT (end_date::DATE - start_date::DATE) INTO days;
	SELECT price_per_night FROM Hotels WHERE id=hotel_id INTO price;

	RETURN days * price;
	
END;
$$ LANGUAGE plpgsql;


CREATE OR REPLACE PROCEDURE add_tour(
		_start DATE,
		_end DATE,
		_type VARCHAR(100),
		_hotel VARCHAR(100)
) AS $$

DECLARE hotel_id INT;

BEGIN 

	SELECT id FROM Hotels WHERE hotel_name=_hotel INTO hotel_id;

	INSERT INTO Tours(start_date, end_date, type_id, hotel_id, total_price)
		VALUES (
			_start, 
			_end, 
			(SELECT id FROM TourTypes WHERE type_name=_type),
			hotel_id,
			get_tour_price_in_hotel(hotel_id, _start, _end)
		);
								
END;
$$ LANGUAGE plpgsql;

--CALL addTour('2023-01-03', '2023-01-08', 'Экскурсионный', 'Apartaments Gran Vall');