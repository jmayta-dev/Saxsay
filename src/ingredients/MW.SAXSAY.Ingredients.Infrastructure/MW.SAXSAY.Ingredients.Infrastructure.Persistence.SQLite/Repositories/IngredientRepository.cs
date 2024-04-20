
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

    public Task<IEnumerable<Ingredient>> GetAllAsync(
        CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
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
        var affectedRows = await command.ExecuteNonQueryAsync(cancellationToken);
        if (affectedRows > 0)
        {
            string subQuery = "SELECT last_insert_rowid()";
            using SqliteCommand subCommand = CreateCommand(subQuery);
            subCommand.CommandType = CommandType.Text;
            var result = await subCommand.ExecuteScalarAsync(cancellationToken);
            if (long.TryParse(result?.ToString(), out long newId))
            {
                newIngredientId = new IngredientId(newId);
            }
        }
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