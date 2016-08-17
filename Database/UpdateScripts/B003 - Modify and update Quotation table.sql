use Fersum;

ALTER TABLE Quotation
	ADD InvoiceMethodDescription varchar(256) NOT NULL DEFAULT '';
