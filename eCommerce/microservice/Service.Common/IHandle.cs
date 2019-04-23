namespace Service.Common
{
    public interface IHandle<in T> where T : Event
    {
    }
}
