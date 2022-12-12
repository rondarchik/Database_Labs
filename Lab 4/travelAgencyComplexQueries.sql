-- Выборка туров в Турцию и Италию со стоимостью меньше 600 
SELECT * FROM Tours WHERE total_price<600 AND hotel_id IN (
	SELECT id FROM Hotels WHERE city_id IN (
		SELECT id FROM Cities WHERE country_id IN (
			SELECT id FROM Countries WHERE country_name='Италия' OR country_name='Турция'))); 

-- Выбирает все бронирования с информацией о клиенте и статусом брони
SELECT Bookings.id, Clients.surname, Bookings.Status FROM Bookings 
	INNER JOIN Clients ON Bookings.client_id=Clients.id;

-- Возвращает отсортированные в алфавитном порядке фамилии всех клиентов и их бронирования
SELECT Clients.surname, Bookings.id FROM Clients 
	LEFT JOIN Bookings ON Clients.id=Bookings.client_id ORDER BY Clients.surname;
-- Возвращает 6 записей (столько клиентов представлено в бд) несмотря на то, 
		--что в таблице бронирований только 3 записи (некоторые ячейки имеют значение null)
/*
-- Возвращает тоже самое, что и предыдущий столбец, за исключением порядка следования столбцов	
SELECT Bookings.id, CLients.surname FROM Bookings 
	RIGHT JOIN Clients ON Bookings.client_id=Clients.id ORDER BY Clients.surname;*/


/*
-- Следующие запросы возвращают одно и тоже (3 записи), только за исключением порядка следования столбцов

SELECT Bookings.id, CLients.surname FROM Bookings 
	LEFT JOIN Clients ON Bookings.client_id=Clients.id ORDER BY Clients.surname;

SELECT Clients.surname, Bookings.id FROM Clients 
	RIGHT JOIN Bookings ON Clients.id=Bookings.client_id ORDER BY Clients.surname;*/	
	
-- Возвращает всех клиентов с фамилией, начинающейся на 'C' и все бронирования	
SELECT Bookings.id, CLients.surname FROM Bookings 
	FULL JOIN Clients ON Bookings.client_id=Clients.id WHERE surname LIKE 'С%';
	
-- Возвращает всех клиентов с одинаковым отчеством	
SELECT A.surname AS surname1, B.surname AS surname2, A.patronymic FROM Clients A, Clients B
	WHERE A.id <> B.id AND A.patronymic = B.patronymic;


--SELECT COUNT(id) FROM Countries; - 8
--SELECT COUNT(id) FROM Cities; - 13
SELECT * FROM Countries, Cities;	--Аналогично: SELECT * FROM Countries CROSS JOIN Cities	


SELECT client_id FROM Bookings
	UNION
		SELECT id FROM Clients;
		
SELECT client_id FROM Bookings
	UNION ALL
		SELECT id FROM Clients;
		
-- Возвращает количество отелей в каждом городе		
SELECT COUNT(hotel_name), city_id 
	FROM Hotels GROUP BY city_id;
	
SELECT COUNT(hotel_name), city_id 
	FROM Hotels GROUP BY city_id HAVING COUNT(hotel_name) > 1;	

-- Перечисляет клиентов, у которых одобрено бронирование
SELECT surname FROM Clients WHERE EXISTS (
	SELECT status FROM Bookings WHERE Bookings.client_id=Clients.id AND status=true);

SELECT surname, birthday,
	CASE
		WHEN date_part('year', age(birthday)) > 18 THEN 'Взрослый'
		WHEN date_part('year', age(birthday)) < 18 THEN 'Малой'
		ELSE '18'
	END AS age_text
FROM Clients;

--??? EXPLAIN SELECT * FROM Clients WHERE patronymic='Александровна';