USE Fersum;

IF NOT EXISTS (SELECT 1 FROM DeliveryType WHERE ShortName = 'LABManzanillo')
BEGIN
	INSERT INTO [dbo].[DeliveryType] ([ShortName],[Description],[Active],[Creator],[Created]) VALUES('LABManzanillo','LAB Manzanillo + IVA','A','admin',GETDATE());
END
