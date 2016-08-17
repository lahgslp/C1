use Fersum;

UPDATE [SectionType]
	SET [Description] = 'Tuber�a de acero al carb�n, Costura Longitudinal soldada por resistencia el�ctrica de alta frecuencia inducida (ERW-HFI), Calidad API 5L Gr. B PSL 1, Extremos biselados a 30 grados.'
	WHERE [ShortName] = 'ERW';

UPDATE [SectionType]
	SET [Description] = 'Tuber�a de acero al carb�n, Costura Longitudinal soldada por proceso de Doble Arco Sumergido (LSAW). Calidad API 5L Gr. B PSL 1, Extremos Biselados a 30 grados. Largos a 12 metros +/- 100 mm.'
	WHERE [ShortName] = 'DSAW';

UPDATE [SectionType]
	SET [ShortName] = 'LSAW'
	WHERE [ShortName] = 'DSAW';

UPDATE [SectionType]
	SET [Description] = 'Tuber�a de acero al carb�n, Costura Helicoidal soldada por proceso de Doble Arco Sumergido (SSAW), Calidad API 5L Grado B PSL 1, Extremos Biselados a 30 grados. Largos a 12 metros +/- 100 mm.'
	WHERE [ShortName] = 'SSAW';


SELECT * FROM [SectionType];
