namespace ServiceAccountingUI.BaseModels
{
    public enum ErrorCode : int
    {
        None = 0,
        Unknown = 1,
        ConnectionLost = 100,
        OutlierReading = 200
    }
}
