use SaigonRideDB
DELETE FROM OtpVerifications;
DBCC CHECKIDENT ('OtpVerifications', RESEED, 0);

DELETE FROM Users;
DBCC CHECKIDENT ('Users', RESEED, 0);

SELECT * FROM Users
SELECT * FROM OtpVerifications
SELECT * FROM WalletTransactions
SELECT * FROM Rentals
SELECT * FROM Stations
SELECT * FROM Vehicles

DELETE FROM OtpVerifications;
DELETE FROM Stations;
DELETE FROM Vehicles;
DELETE FROM Rentals;

UPDATE Rentals SET Status = 'Completed' WHERE Id = 36
UPDATE Users SET Balance = 0 WHERE id = 2

DELETE FROM Users
WHERE Role = 'User'


DELETE FROM Users
WHERE Role = 'User' AND Email like 'Trannguyennvt09870987@gmail.com'

DELETE FROM Rentals WHERE Id = 7 
DELETE FROM WalletTransactions
