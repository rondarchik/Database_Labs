-- Requests Pull
SELECT * FROM Users;
SELECT name FROM Users;
SELECT name, email FROM Users;
SELECT * FROM Users ORDER BY name;
SELECT DISTINCT patronymic FROM Clients; --only different values
SELECT COUNT(DISTINCT country_id) FROM Cities; 
SELECT * FROM Cities WHERE country_id=2;
SELECT * FROM Cities WHERE country_id IN (1, 3, 5);
SELECT * FROM Hotels WHERE price_per_night BETWEEN 20 AND 60;
SELECT * FROM Cities WHERE city_name='Рим' AND country_id=2;
SELECT * FROM Cities WHERE city_name='Минск' OR city_name='Мармарис';
SELECT * FROM Cities WHERE NOT country_id=1;
SELECT * FROM Users ORDER BY name;
SELECT * FROM Users ORDER BY name DESC;
SELECT * FROM Clients WHERE client_address IS NOT NULL;
SELECT * FROM Clients WHERE client_address IS NULL;
SELECT MAX(total_price) FROM Tours; 
SELECT MIN(total_price) FROM Tours; 
SELECT AVG(total_price) FROM Tours; 
SELECT SUM(total_price) FROM Tours; 