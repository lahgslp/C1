use Fersum2019;

BEGIN TRANSACTION

DELETE FROM [dbo].[QuotationSectionDetail];
DELETE FROM [dbo].[QuotationSection];
DELETE FROM [dbo].[QuotationAttachment];
DELETE FROM [dbo].[Quotation];

DELETE FROM [dbo].[CustomerContact];
DELETE FROM [dbo].[Customer];

COMMIT TRANSACTION

GO

DBCC CHECKIDENT ('Quotation', RESEED, 50000);  
GO
--sp_help Quotation
