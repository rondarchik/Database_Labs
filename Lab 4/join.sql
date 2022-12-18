-- имя и телефон клиента, название тура, название отеля, tour_type для тех клиентов, кто никогда не оставлял review
SELECT Clients.surname, Clients.phone, Tours.tour_name, TourTypes.type_name, Hotels.hotel_name
		FROM Clients JOIN Bookings ON Clients.id=Bookings.client_id
			  JOIN Tours ON Bookings.tour_id=Tours.id
			  JOIN TourTypes ON Tours.type_id=TourTypes.id
			  JOIN Hotels ON Tours.hotel_id=Hotels.id
		WHERE Clients.id NOT IN (SELECT client_id FROM Reviews);