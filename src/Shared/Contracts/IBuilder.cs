namespace MW.SAXSAY.Shared.Contracts;

public interface IBuilder<out T>
{
    T Build();
}