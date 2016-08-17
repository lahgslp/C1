use Fersum;

ALTER TABLE Users
 ADD NotifyToEmail varchar(100) NOT NULL DEFAULT '';

UPDATE Users
	SET NotifyToEmail = 'cfenton@fersum.com'
	WHERE ShortName <> 'cfenton';

