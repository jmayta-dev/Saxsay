
using System.Data;
using System.Runtime.CompilerServices;
using Microsoft.Data.Sqlite;
using MW.SAXSAY.Ingredients.Domain.Entities;
using MW.SAXSAY.Ingredients.Domain.Interfaces;
using MW.SAXSAY.Ingredients.Domain.ValueObjects;

namespace MW.SAXSAY.Ingredients.Infrastructure.Persistence.SQLite.Resitories;

public class IngredientRepository : Repository, IIngredientRepository
{
    #region Properties & Variables
    //
    // private
    //
    //
    // public
    //
    #endregion

    #region Constructor
    public IngredientRepository(
        SqliteConnection connection,
        SqliteTransaction transaction) : base(connection, transaction)
    {
    }
    #endregion

    #region Methods
    public Task<Ingredient> GetAsync(CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<Ingredient> GetBySpecificationAsync(
        object specification, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Ingredient>> GetAllAsync(
        CancellationToken cancellationToken = default)
    {
        List<Ingredient> ingredients = new();
        string query =
        @"
            SELECT Id, Description, IsActive
            FROM ingredient_Ingredient;
        ";
        SqliteCommand command = CreateCommand(query);
        command.CommandType = CommandType.Text;
        var reader = await command.ExecuteReaderAsync(cancellationToken);
        if (reader.HasRows)
        {
            while (await reader.ReadAsync(cancellationToken))
            {
                Ingredient.IngredientBuilder ingredientBuilder = new();
                var ingredientId = new IngredientId(reader.GetInt64(reader.GetOrdinal("Id")));
                ingredientBuilder.WithIngredientId(ingredientId);
                ingredientBuilder.WithDescription(reader.GetString(reader.GetOrdinal("Description")));
                ingredientBuilder.WithStatusActive(reader.GetBoolean(reader.GetOrdinal("IsActive")));
                var ingredient = ingredientBuilder.Build();

                ingredients.Add(ingredient);
            }
        }
        return ingredients;
    }

    public async Task<IngredientId?> RegisterAsync(
        Ingredient ingredient, CancellationToken cancellationToken = default)
    {
        IngredientId? newIngredientId = default;
        string query =
        @"
            INSERT INTO ingredient_Ingredient
            (   Description,    IsActive    )
            VALUES
            (   @Description,   @IsActive   );

            SELECT last_insert_rowid();
        ";
        SqliteCommand command = CreateCommand(query);
        command.CommandType = CommandType.Text;
        command.Parameters.Add(new SqliteParameter
        {
            ParameterName = "@IsActive",
            SqliteType = SqliteType.Integer,
            Value = ingredient.IsActive
        });
        command.Parameters.Add(new SqliteParameter
        {
            ParameterName = "@Description",
            SqliteType = SqliteType.Text,
            Value = ingredient.Description
        });

        var result = await command.ExecuteScalarAsync(cancellationToken);
        if (long.TryParse(result?.ToString(), out long newId))
            newIngredientId = new IngredientId(newId);
        return newIngredientId;
    }

    public Task BulkRegisterAsync(
        IEnumerable<Ingredient> ingredientCollection,
        CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
    #endregion

}