DELETE FROM [SectionType];

DBCC CHECKIDENT ([SectionType], RESEED, 0);

INSERT INTO [dbo].[SectionType] ([ShortName],[Description],[Active],[Creator],[Created]) VALUES('TSCB','Tubería de acero al carbón, sin costura (TSC), especificaciones ASTM A106 Grado "B" y/o ASTM A53 Grado "B" Tipo "S" y/o API 5L Grado "B/X42", calidad conducción. A partir de 2 pulgadas de diámetro nominal los extremos son biselados a 30 grados','A','admin',GETDATE());
INSERT INTO [dbo].[SectionType] ([ShortName],[Description],[Active],[Creator],[Created]) VALUES('TSCX52','Tubería de acero al carbón, sin costura (TSC), especificación API 5L X-52 PSL 1, calidad conducción, extremos biselados a 30 grados','A','admin',GETDATE());
INSERT INTO [dbo].[SectionType] ([ShortName],[Description],[Active],[Creator],[Created]) VALUES('ERW','Tubería de acero al carbón, con costura longitudinal soldada por resistencia eléctrica de alta frecuencia inducida (ERW-HFI), especificación API 5L Grado "B" PSL 1, extremos biselados a 30 grados','A','admin',GETDATE());
INSERT INTO [dbo].[SectionType] ([ShortName],[Description],[Active],[Creator],[Created]) VALUES('LSAW','Tubería de acero al carbón, con costura longitudinal soldada por proceso de doble arco sumergido (LSAW-DSAW), especificaciones API 5L Grado "B" PSL 1 y/o ASTM A139 Grado "B", extremos biselados a 30 grados. Largos dobles a 12 metros +/- 200 mm','A','admin',GETDATE());
INSERT INTO [dbo].[SectionType] ([ShortName],[Description],[Active],[Creator],[Created]) VALUES('SSAW','Tubería de acero al carbón, con costura helicoidal soldada por proceso de doble arco sumergido (SSAW), especificaciones API 5L Grado "B" PSL 1 y/o ASTM A139 Grado "B", extremos biselados a 30 grados. Largos dobles a 12 metros +/- 200 mm','A','admin',GETDATE());
INSERT INTO [dbo].[SectionType] ([ShortName],[Description],[Active],[Creator],[Created]) VALUES('EDITABLE','','A','admin',GETDATE());

SELECT * FROM [SectionType];