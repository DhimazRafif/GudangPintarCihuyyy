namespace GudangPintarGui.Utils
{
    public class StockStateContext
    {
        public IStockState GetState(int quantity, int notificationThreshold)
        {
            if (quantity == 0)
                return new HabisStockState();

            if (quantity <= notificationThreshold)
                return new MenipisStockState();

            return new AmanStockState();
        }
    }
}