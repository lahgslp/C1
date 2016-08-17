IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID('[dbo].[Fersum_Upd_CustomerContact]') AND type in ('P'))
BEGIN
	DROP PROCEDURE [dbo].[Fersum_Upd_CustomerContact]
END

GO

CREATE PROCEDURE [dbo].[Fersum_Upd_CustomerContact]
	@QuotationID int
AS
BEGIN
	
	UPDATE Quotation SET CustomerContactID = null WHERE QuotationID = @QuotationID;

END

GO
