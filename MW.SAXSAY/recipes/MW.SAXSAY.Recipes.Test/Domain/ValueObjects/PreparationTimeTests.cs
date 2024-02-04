using recipes.MW.SAXSAY.Recipes.Domain.ValueObjects;

namespace recipes.MW.SAXSAY.Recipes.Test.Domain.ValueObjects;

public class PeparationTimeTests
{
    [Fact]
    // Asignar 0 cuando no se pasan parámetros
    public void Set_zero_hrs_zero_mins_when_recives_empty()
    {

        // Arrange
        PreparationTime? expected = PreparationTime.Set(0, 0);
        // Act
        PreparationTime? sut = PreparationTime.Set();
        // Assert
        Assert.Equal(expected, sut);
    }

    [Fact]
    // Asignar un sólo valor retorna timer con minutos
    public void Set_single_value_set_minutes()
    {
        // Arrange
        PreparationTime? expected = PreparationTime.Set(0, 30);
        // Act
        PreparationTime? sut = PreparationTime.Set(30);
        // Assert
        Assert.Equal(expected, sut);
    }

    [Fact]
    // Asignar un sólo valor mayor a 59 retorna timer con horas y minutos
    public void Set_single_value_greater_59_set_hours_and_minutes()
    {
        // Arrange
        PreparationTime? expected = PreparationTime.Set(1, 30);
        // Act
        PreparationTime? sut = PreparationTime.Set(90);
        // Assert
        Assert.Equal(expected, sut);
    }

    [Fact]
    // Asignar un solo valor mayor a 99 horas y 59 minutos retorna nulo
    public void Set_single_value_greater_5999_minutes_returns_null()
    {
        // Arrange
        // Act
        PreparationTime? sut = PreparationTime.Set(6000);
        // Assert
        Assert.Null(sut);
    }
    [Fact]
    // Asignar valores mayor a 99 horas y 59 minutos retorna nulo
    public void Set_values_greater_99_hours_59_minutes_returns_null()
    {
        // Arrange
        // Act
        PreparationTime? sut = PreparationTime.Set(98, 121);
        // Assert
        Assert.Null(sut);
    }
}