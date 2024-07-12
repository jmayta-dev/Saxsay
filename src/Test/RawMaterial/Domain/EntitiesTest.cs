using DomainEntities = MW.SAXSAY.RawMaterial.Domain.Entities;

namespace MW.SAXSAY.Test.RawMaterial.Domain;

public class EntitiesTest
{
    [Fact]
    public void Cannot_build_without_name()
    {
        // Arrange
        var builder = DomainEntities.RawMaterial.Builder.Empty();
        // Act

        // Assert
        Assert.ThrowsAsync<InvalidOperationException>(() => Task.Run(() => builder.Build()));
    }

    [Fact]
    public void Raw_material_id_auto_fill()
    {
        // Arrange
        var builder = DomainEntities.RawMaterial.Builder.Empty();
        // Act
        var rawMaterial = builder.WithName("test").Build();
        // Assert
        Assert.False(string.IsNullOrWhiteSpace(rawMaterial.Id));
    }

    [Fact]
    public void Raw_material_can_fill_fluently()
    {
        // Arrange
        var builder = DomainEntities.RawMaterial.Builder.Empty();
        // Act
        var rawMaterial = builder.WithName("Test").Build();
        // Assert
        Assert.False(string.IsNullOrWhiteSpace(rawMaterial.Name));
    }
}