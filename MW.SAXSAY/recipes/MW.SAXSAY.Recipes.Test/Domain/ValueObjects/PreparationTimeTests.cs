using recipes.MW.SAXSAY.Recipes.Domain.ValueObjects;

namespace recipes.MW.SAXSAY.Recipes.Test.Domain.ValueObjects;

public class PeparationTimeTests
{
    [Fact]
    // Asignar 0 cuando no se pasan parámetros
    public void Set_zero_hrs_zero_mins_when_recives_empty()
    {

        // Arrange
        // Act
        var timer = PreparationTime.Set();
        // Assert
        Assert.Equal(PreparationTime.Set(0, 0), timer);
    }

    [Fact]
    // Asignar un sólo valor retorna timer con minutos
    public void Set_single_value_set_minutes()
    {
        // Arrange
        // Act
        var timer = PreparationTime.Set(30);
        // Assert
        Assert.Equal(PreparationTime.Set(0, 30), timer);
    }

    [Fact]
    // Asignar un sólo valor mayor a 59 retorna timer con horas y minutos
    public void Set_single_value_greater_59_set_hours_and_minutes()
    {
        // Arrange
        // Act
        var timer = PreparationTime.Set(90);
        // Assert
        Assert.Equal(PreparationTime.Set(1, 30), timer);
    }

    [Fact]
    // Asignar un solo valor mayor a 99 horas y 59 minutos retorna error
    public void Set_single_value_greater_5999_minutes_returns_null()
    {
        // Arrange
        // Act
        var timer = PreparationTime.Set(6000);
        // Assert
        Assert.Null(timer);
    }
    // Asignar dos valores (conjunto) mayor a 99 horas y 59 minutos retorna error
    [Fact]
    public void Set_values_greater_99_hours_59_minutes_returns_null()
    {
        // Arrange
        // Act
        var timer = PreparationTime.Set(98, 121);
        // Assert
        Assert.Null(timer);
    }
}