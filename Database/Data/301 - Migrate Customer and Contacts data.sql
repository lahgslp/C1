USE FersumCurrent

DECLARE @TmpCustomer TABLE
(
	CustomerID int,
	ShortName varchar(20),
	Description varchar(100),
	Creator varchar(20),
	Created datetime
);

DECLARE @TmpCustomerContact TABLE
(
	CustomerID int,
	ContactName varchar(100),
	Email varchar(50),
	Creator varchar(20),
	Created datetime
);

INSERT INTO @TmpCustomer
SELECT CustomerID, ShortName, Description, Creator, Created FROM Customer

INSERT INTO @TmpCustomerContact
SELECT CustomerID, ContactName, Email, Creator, Created FROM CustomerContact

USE FersumDev01

BEGIN TRANSACTION

	DELETE FROM [CustomerContact];
	DELETE FROM [dbo].[Customer];

	DBCC CHECKIDENT ([CustomerContact], RESEED, 1);
	DBCC CHECKIDENT ([Customer], RESEED, 1);

	DECLARE @OldCustomerID int;
	DECLARE @NewCustomerID int;
	DECLARE CustomersCursor CURSOR FOR SELECT CustomerID FROM @TmpCustomer

	OPEN CustomersCursor

	FETCH NEXT FROM CustomersCursor INTO @OldCustomerID
	WHILE @@FETCH_STATUS = 0
	BEGIN
		--Insert Customer row
		INSERT INTO Customer(ShortName, Description, Active, Creator, Created)
		SELECT ShortName, Description, 'A', Creator, Created FROM @TmpCustomer WHERE CustomerID = @OldCustomerID;
		SET @NewCustomerID = @@IDENTITY;
		--Insert CustomerContact rows
		INSERT INTO CustomerContact(ContactName, Email, CustomerID, Active, Creator, Created)
		SELECT ContactName, Email, @NewCustomerID, 'A', Creator, Created FROM @TmpCustomerContact WHERE CustomerID = @OldCustomerID;

		FETCH NEXT FROM CustomersCursor INTO @OldCustomerID
	END
	CLOSE CustomersCursor
	DEALLOCATE CustomersCursor

	SELECT * FROM Customer
	SELECT * FROM CustomerContact

COMMIT TRANSACTION
