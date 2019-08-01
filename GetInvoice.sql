USE Chinook

GO

CREATE PROCEDURE GetInvoice(@InvoiceId int)
AS 
BEGIN

SELECT * FROM dbo.Invoice WHERE InvoiceId = @InvoiceId

SELECT * FROM dbo.InvoiceLine WHERE InvoiceId = @InvoiceId

END

GO

EXEC dbo.GetInvoice @InvoiceId = 2