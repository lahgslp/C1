DELETE FROM [Company];

DBCC CHECKIDENT ([Company], RESEED, 0);

INSERT INTO Company(CompanyName, CompanyFullName, CompanyCity, LogoFilePath, LogoSize, Active, Creator, Created) VALUES ('Fersum', 'FERSUM, SA de CV', 'San Pedro Garza García, Nuevo León, México', 'FERSUM logo.bmp', '3.0cm', 'A', 'admin', GETDATE());
INSERT INTO Company(CompanyName, CompanyFullName, CompanyCity, LogoFilePath, LogoSize, Active, Creator, Created) VALUES ('Ayante', 'AYANTE, SA de CV', 'San Pedro Garza García, Nuevo León, México', 'AYANTE logo.bmp', '3.0cm', 'A', 'admin', GETDATE());
INSERT INTO Company(CompanyName, CompanyFullName, CompanyCity, LogoFilePath, LogoSize, Active, Creator, Created) VALUES ('Indefinida', 'INDEFINIDA', 'San Pedro Garza García, Nuevo León, México', 'Indefinida logo.bmp', '3.0cm', 'A', 'admin', GETDATE());

SELECT * FROM [Company];
