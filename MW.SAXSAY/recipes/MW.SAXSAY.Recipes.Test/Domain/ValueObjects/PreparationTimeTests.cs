namespace recipes.MW.SAXSAY.Recipes.Test.Domain.ValueObjects;

public class PeparationTimeTests
{
    // Asignar un sólo valor retorna timer con minutos
    [Fact]
    public void Set_single_value_set_minutes()
    { }

    // Asignar un sólo valor mayor a 59 retorna timer con horas y minutos
    [Fact]
    public void Set_single_value_greater_59_set_hours_and_minutes()
    { }
    // Asignar un solo valor mayor a 99 horas y 59 minutos retorna error
    [Fact]
    public void Set_single_value_greater_5999_minutes_returns_error()
    { }
    // Asignar dos valores (conjunto) mayor a 99 horas y 59 minutos retorna error
    [Fact]
    public void Set_values_greater_99_hours_59_minutes_returns_error()
    { }
}