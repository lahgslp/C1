namespace Cotizaciones.Enums
{
    public enum StatusBarElements
    {
        QuotationID,
        Description,
        StatusMessage,
        CurrentUser
    }
    public enum QuotationStatusType
    {
        Incomplete = 1,
        Complete = 2,
        Finished = 3,
        Sold = 4,
        FinishedExternal = 5,
        FinishedAndSent = 6
    }
}