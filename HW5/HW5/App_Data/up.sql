-- Requests Table
CREATE TABLE dbo.Requests
(
	CustomerID INT NOT NULL,
	DateOfBirth DATE NOT NULL,
	FullName NVARCHAR(128) NOT NULL,
	StreetAddress NVARCHAR(128) NOT NULL,
	City NVARCHAR(32) NOT NULL,
	State NVARCHAR(32) NOT NULL,
	ZipCode INT NOT NULL,
	County NVARCHAR(32) NOT NULL,
	CONSTRAINT [PK_dbo.Requests] PRIMARY KEY CLUSTERED (CustomerID ASC)
);

INSERT INTO dbo.Requests (CustomerID, DateOfBirth, FullName, StreetAddress, City, State, ZipCode, County) VALUES
	(1, '1980-01-01', 'Joe Johnson', '115 5th Ave', 'Portland', 'OR', 97209, 'Multnomah'),
	(2, '1995-12-17', 'Maddy Hawkins', '525 Eola Dr NW', 'Salem', 'OR', 97304, 'Marion'),
	(3, '1969-10-15', 'Heidi Ostler', '1900 Flying Squirrel Way', 'Salem', 'OR', 97304, 'Marion'),
	(4, '1994-01-29', 'Nicole Grimm', '1159 Kingwood Dr NW', 'Salem', 'OR', 97304, 'Marion'),
	(5, '1963-04-20', 'Richard Matthews', '991 S 5th St', 'Jefferson', 'OR', 97352, 'Marion');

GO