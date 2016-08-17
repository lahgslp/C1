ALTER TABLE Company ADD LogoSize varchar (20);

UPDATE Company
SET LogoSize = '3.0cm'
WHERE CompanyID = 1;

UPDATE Company
SET LogoSize = '1.5cm'
WHERE CompanyID = 2;

SELECT * FROM Company;

--ALTER TABLE Company DROP COLUMN LogoSize;