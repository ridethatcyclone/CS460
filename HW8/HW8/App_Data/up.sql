CREATE TABLE dbo.Artists (
	ArtistID INT IDENTITY(1,1) NOT NULL,
	Name NVARCHAR(50) NOT NULL,
	BirthDate NVARCHAR(10) NOT NULL,
	BirthCity NVARCHAR(128) NOT NULL,
	
	CONSTRAINT[PK_dbo.Artists] PRIMARY KEY CLUSTERED (ArtistID ASC)
);

CREATE TABLE dbo.ArtWorks (
	ArtworkID INT IDENTITY(1,1) NOT NULL,
	Title NVARCHAR(128) NOT NULL,
	ArtistID INT NOT NULL,
	
	CONSTRAINT[PK_dbo.ArtWorks] PRIMARY KEY CLUSTERED (ArtworkID ASC),
	CONSTRAINT[FK_dbo.ArtWorks] FOREIGN KEY (ArtistID) REFERENCES Artists(ArtistID)
		ON DELETE CASCADE
		ON UPDATE CASCADE
);

CREATE TABLE dbo.Genres (
	GenreID INT IDENTITY(1,1) NOT NULL,
	Name NVARCHAR(64),

	CONSTRAINT[PK_dbo.Genres] PRIMARY KEY CLUSTERED (GenreID ASC)
);

CREATE TABLE dbo.Classifications (
	ClassificationID INT IDENTITY(1,1) NOT NULL,
	ArtworkID INT NOT NULL,
	GenreID INT NOT NULL,

	CONSTRAINT[PK_dbo.Classifications] PRIMARY KEY CLUSTERED (ClassificationID ASC),
	CONSTRAINT[FK1_dbo.Classifications] FOREIGN KEY (ArtworkID) REFERENCES ArtWorks(ArtworkID)
		ON DELETE CASCADE
		ON UPDATE CASCADE,
	CONSTRAINT[FK2_dbo.Classifications] FOREIGN KEY (GenreID) REFERENCES Genres(GenreID)
		ON DELETE CASCADE
		ON UPDATE CASCADE
);

INSERT INTO dbo.Artists(Name, BirthDate, BirthCity) VALUES
	('M C Escher', '1898-06-17', 'Leeuwarden, Netherlands'),
	('Leonardo Da Vinci', '1519-05-02', 'Vinci, Italy'),
	('Hatip Mehmed Efendi', '1680-11-18', 'Unknown'),
	('Salvador Dali', '1904-05-11', 'Figueres, Spain')

INSERT INTO dbo.ArtWorks(Title, ArtistID) VALUES
	('Circle Limit III', 1),
	('Twon Tree', 1),
	('Mona Lisa', 2),
	('The Vitruvian Man', 2),
	('Ebru', 3),
	('Honey Is Sweeter Than Blood', 4)

INSERT INTO dbo.Genres(Name) VALUES
	('Tesselation'),
	('Surrealism'),
	('Portrait'),
	('Renaissance')

INSERT INTO dbo.Classifications(ArtworkID, GenreID) VALUES
	(1, 1),
	(2, 1),
	(2, 2),
	(3, 3),
	(3, 4),
	(4, 4),
	(5, 1),
	(6, 2)

GO