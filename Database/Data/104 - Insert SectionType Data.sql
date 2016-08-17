DELETE FROM [SectionType];

DBCC CHECKIDENT ([SectionType], RESEED, 0);

INSERT INTO [dbo].[SectionType] ([ShortName],[Description],[Active],[Creator],[Created]) VALUES('TSCB','Tuber�a de acero al carb�n, sin costura (TSC), especificaciones ASTM A106 Grado "B" y/o ASTM A53 Grado "B" Tipo "S" y/o API 5L Grado "B/X42", calidad conducci�n. A partir de 2 pulgadas de di�metro nominal los extremos son biselados a 30 grados','A','admin',GETDATE());
INSERT INTO [dbo].[SectionType] ([ShortName],[Description],[Active],[Creator],[Created]) VALUES('TSCX52','Tuber�a de acero al carb�n, sin costura (TSC), especificaci�n API 5L X-52 PSL 1, calidad conducci�n, extremos biselados a 30 grados','A','admin',GETDATE());
INSERT INTO [dbo].[SectionType] ([ShortName],[Description],[Active],[Creator],[Created]) VALUES('ERW','Tuber�a de acero al carb�n, con costura longitudinal soldada por resistencia el�ctrica de alta frecuencia inducida (ERW-HFI), especificaci�n API 5L Grado "B" PSL 1, extremos biselados a 30 grados','A','admin',GETDATE());
INSERT INTO [dbo].[SectionType] ([ShortName],[Description],[Active],[Creator],[Created]) VALUES('LSAW','Tuber�a de acero al carb�n, con costura longitudinal soldada por proceso de doble arco sumergido (LSAW-DSAW), especificaciones API 5L Grado "B" PSL 1 y/o ASTM A139 Grado "B", extremos biselados a 30 grados. Largos dobles a 12 metros +/- 200 mm','A','admin',GETDATE());
INSERT INTO [dbo].[SectionType] ([ShortName],[Description],[Active],[Creator],[Created]) VALUES('SSAW','Tuber�a de acero al carb�n, con costura helicoidal soldada por proceso de doble arco sumergido (SSAW), especificaciones API 5L Grado "B" PSL 1 y/o ASTM A139 Grado "B", extremos biselados a 30 grados. Largos dobles a 12 metros +/- 200 mm','A','admin',GETDATE());
INSERT INTO [dbo].[SectionType] ([ShortName],[Description],[Active],[Creator],[Created]) VALUES('EDITABLE','','A','admin',GETDATE());

SELECT * FROM [SectionType];