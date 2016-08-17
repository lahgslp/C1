use Fersum;

ALTER TABLE QuotationSection
 ADD SectionDescription varchar(512) NOT NULL DEFAULT '';

UPDATE QuotationSection
	SET SectionDescription = ST.Description
	FROM QuotationSection QS INNER JOIN SectionType ST ON QS.SectionTypeID = ST.SectionTypeID
