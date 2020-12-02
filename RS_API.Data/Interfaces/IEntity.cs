namespace RS_API.Data.Interfaces
{
    public interface IEntity<T>
    {
        T Id { get; set; }
    }
}
