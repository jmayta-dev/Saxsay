namespace MW.SAXSAY.Shared.Contracts;

public interface IBuilder<out T> : IBuilder
{
    T Build();
}

public interface IBuilder
{ }