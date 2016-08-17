DECLARE @TempSection TABLE
(
	SectionTypeID int,
	ShortName varchar(20)
);

INSERT INTO @TempSection(SectionTypeID, ShortName) VALUES(1, 'ECW');
INSERT INTO @TempSection(SectionTypeID, ShortName) VALUES(2, 'DFS');
INSERT INTO @TempSection(SectionTypeID, ShortName) VALUES(3, 'DDS');
INSERT INTO @TempSection(SectionTypeID, ShortName) VALUES(4, 'TYU');
INSERT INTO @TempSection(SectionTypeID, ShortName) VALUES(5, 'OIT');

DECLARE @SelectedPipes TABLE
(
	SelectedPipeID int,
	PipeSpecificationID int
);

INSERT INTO @SelectedPipes(SelectedPipeID, PipeSpecificationID) VALUES (1, 9);
INSERT INTO @SelectedPipes(SelectedPipeID, PipeSpecificationID) VALUES (2, 10);
INSERT INTO @SelectedPipes(SelectedPipeID, PipeSpecificationID) VALUES (3, 11);
INSERT INTO @SelectedPipes(SelectedPipeID, PipeSpecificationID) VALUES (4, 12);
INSERT INTO @SelectedPipes(SelectedPipeID, PipeSpecificationID) VALUES (5, 31);
INSERT INTO @SelectedPipes(SelectedPipeID, PipeSpecificationID) VALUES (6, 32);
INSERT INTO @SelectedPipes(SelectedPipeID, PipeSpecificationID) VALUES (7, 33);
INSERT INTO @SelectedPipes(SelectedPipeID, PipeSpecificationID) VALUES (8, 34);
INSERT INTO @SelectedPipes(SelectedPipeID, PipeSpecificationID) VALUES (9, 35);
INSERT INTO @SelectedPipes(SelectedPipeID, PipeSpecificationID) VALUES (10, 36);

DECLARE @SelectedPipeSection TABLE
(
	SelectedPipeID int,
	SectionTypeID int
);

INSERT INTO @SelectedPipeSection(SelectedPipeID, SectionTypeID) VALUES(1,1);
INSERT INTO @SelectedPipeSection(SelectedPipeID, SectionTypeID) VALUES(1,2);
INSERT INTO @SelectedPipeSection(SelectedPipeID, SectionTypeID) VALUES(2,1);
INSERT INTO @SelectedPipeSection(SelectedPipeID, SectionTypeID) VALUES(2,3);
INSERT INTO @SelectedPipeSection(SelectedPipeID, SectionTypeID) VALUES(3,1);
INSERT INTO @SelectedPipeSection(SelectedPipeID, SectionTypeID) VALUES(3,4);
INSERT INTO @SelectedPipeSection(SelectedPipeID, SectionTypeID) VALUES(4,1);
INSERT INTO @SelectedPipeSection(SelectedPipeID, SectionTypeID) VALUES(4,5);
INSERT INTO @SelectedPipeSection(SelectedPipeID, SectionTypeID) VALUES(5,1);
INSERT INTO @SelectedPipeSection(SelectedPipeID, SectionTypeID) VALUES(5,2);
INSERT INTO @SelectedPipeSection(SelectedPipeID, SectionTypeID) VALUES(6,1);
INSERT INTO @SelectedPipeSection(SelectedPipeID, SectionTypeID) VALUES(6,3);
INSERT INTO @SelectedPipeSection(SelectedPipeID, SectionTypeID) VALUES(7,1);
INSERT INTO @SelectedPipeSection(SelectedPipeID, SectionTypeID) VALUES(7,4);
INSERT INTO @SelectedPipeSection(SelectedPipeID, SectionTypeID) VALUES(8,1);
INSERT INTO @SelectedPipeSection(SelectedPipeID, SectionTypeID) VALUES(8,5);
INSERT INTO @SelectedPipeSection(SelectedPipeID, SectionTypeID) VALUES(9,1);
INSERT INTO @SelectedPipeSection(SelectedPipeID, SectionTypeID) VALUES(9,2);
INSERT INTO @SelectedPipeSection(SelectedPipeID, SectionTypeID) VALUES(10,1);
INSERT INTO @SelectedPipeSection(SelectedPipeID, SectionTypeID) VALUES(10,3);

--SELECT * FROM @TempSection;
--SELECT * FROM @SelectedPipes;
--SELECT * FROM @SelectedPipeSection;

SELECT SPS.SelectedPipeID, SP.PipeSpecificationID, PS.PipeSpecificationID, PS.PipeDiameterTypeID, SPS.SectionTypeID, ST1.ShortName
FROM @SelectedPipeSection SPS
	INNER JOIN @SelectedPipes SP ON SPS.SelectedPipeID=SP.SelectedPipeID
	INNER JOIN PipeSpecification PS ON SP.PipeSpecificationID=PS.PipeSpecificationID
	INNER JOIN PipeDiameterType PDT ON PS.PipeDiameterTypeID=PDT.PipeDiameterTypeID
	LEFT JOIN @TempSection ST1 ON SPS.SectionTypeID = ST1.SectionTypeID AND ST1.SectionTypeID = 1
;

/*
SELECT * FROM v_PipeSpecification WHERE ShortName IN ('3/8', '1 1/4');

SELECT PipeSpecificationID FROM PipeSpecification PS INNER JOIN PipeDiameterType PDT ON PS.PipeDiameterTypeID=PDT.PipeDiameterTypeID AND PDT.ShortName IN ('3/8', '1 1/4');
SELECT * FROM PipeSpecification PS INNER JOIN PipeDiameterType PDT ON PS.PipeDiameterTypeID=PDT.PipeDiameterTypeID AND PDT.ShortName IN ('3/8', '1 1/4');

WHERE PipeSpecificationID = 1;
--sp_helptext v_PipeSpecification;
*/