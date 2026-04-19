use SaigonRideDB
DELETE FROM OtpVerifications;
DBCC CHECKIDENT ('OtpVerifications', RESEED, 0);

DELETE FROM Users;
DBCC CHECKIDENT ('Users', RESEED, 0);

SELECT * FROM Users
SELECT * FROM OtpVerifications
SELECT * FROM WalletTransactions

DELETE FROM OtpVerifications;
DELETE FROM Stations;
DELETE FROM Vehicles;

DELETE FROM Users
WHERE Role = 'User'