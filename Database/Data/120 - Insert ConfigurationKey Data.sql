DELETE FROM [ConfigurationKey];

DBCC CHECKIDENT ([ConfigurationKey], RESEED, 0);

INSERT INTO ConfigurationKey(Name, Value, Active, Creator, Created) VALUES ('FontName', 'Verdana', 'A', 'admin', GETDATE());
INSERT INTO ConfigurationKey(Name, Value, Active, Creator, Created) VALUES ('NetworkFolder', 'C:\Users\Usuario\Documents\tmp', 'A', 'admin', GETDATE());
INSERT INTO ConfigurationKey(Name, Value, Active, Creator, Created) VALUES ('DefaultGreetingsMessage', 'Anexo cotización solicitada', 'A', 'admin', GETDATE());
INSERT INTO ConfigurationKey(Name, Value, Active, Creator, Created) VALUES ('AdminUser', 'admin', 'A', 'admin', GETDATE());
INSERT INTO ConfigurationKey(Name, Value, Active, Creator, Created) VALUES ('DefaultCompanyID', '1', 'A', 'admin', GETDATE());
INSERT INTO ConfigurationKey(Name, Value, Active, Creator, Created) VALUES ('FakeUser', '_a_a_a_', 'A', 'admin', GETDATE());

SELECT * FROM [ConfigurationKey];