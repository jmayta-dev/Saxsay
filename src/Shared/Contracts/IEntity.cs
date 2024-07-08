namespace MW.SAXSAY.Shared.Contracts;

public interface IEntity
{

}

public interface IEntity<out T>
{
    T? Id { get; }
}