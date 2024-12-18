namespace Domiki.Web.Business
{
    public interface ICalculator
    {
        void CheckInit();
        void Insert(CalculateInfo cData);
        void Remove(int playerId, long objectId, CalculateTypes type);
    }
}