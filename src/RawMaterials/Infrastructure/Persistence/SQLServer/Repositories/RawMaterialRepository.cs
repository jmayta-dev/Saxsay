using Microsoft.Data.SqlClient;
using MW.SAXSAY.RawMaterials.Application.Contracts;
using MW.SAXSAY.RawMaterials.Application.DTO;
using MW.SAXSAY.RawMaterials.Domain.Entities;
using MW.SAXSAY.Shared.Persistence;
using System.Data;

namespace MW.SAXSAY.RawMaterials.Persistence.SQLServer.Repositories;

public class RawMaterialRepository : IRawMaterialRepository
{
    #region Properties & Variables
    private readonly SqlConnection _connection;
    private readonly SqlTransaction? _transaction;
    #endregion

    #region Constructor
    /// <summary>
    /// Initializes a new instance of the <see cref="RawMaterialRepository"/> class.
    /// </summary>
    /// <param name="connection"></param>
    public RawMaterialRepository(SqlConnection connection)
    {
        // connection must be not-null and opened
        ArgumentNullException.ThrowIfNull(connection);
        if (connection.State == ConnectionState.Closed)
            throw new InvalidOperationException("Connection is closed");

        _connection = connection;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="RawMaterialRepository"/> class.
    /// Usually used for updating or insertion purposes.
    /// </summary>
    /// <param name="connection">The <see cref="SqlConnection"/> instance to use.</param>
    /// <param name="transaction"></param>
    public RawMaterialRepository(SqlConnection connection, SqlTransaction transaction)
        : this(connection)
    {
        ArgumentNullException.ThrowIfNull(transaction, nameof(transaction));
        _transaction = transaction;
    }
    #endregion

    #region Methods
    //
    // public
    //

    public async Task<bool> DeleteRawMaterial(
          string rawMaterialId,
          CancellationToken cancellationToken = default)
    {
        ValidateTransactionInstance();

        sbyte returnedValue;
        string sp = "rawmaterials.usp_RemoveRawMaterial";

        using SqlCommand command = new(sp, _connection, _transaction);
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.Add(new SqlParameter
        {
            ParameterName = "@id",
            Size = 24,
            SqlDbType = SqlDbType.Char,
            Value = rawMaterialId
        });
        returnedValue = Convert.ToSByte(
            await command.ExecuteScalarAsync(cancellationToken));

        if (returnedValue != 0)
        { return false; }
        else
        { return true; }
    }

    public async Task<IEnumerable<GetRawMaterialDTO>> GetAllAsync(
        CancellationToken cancellationToken = default)
    {
        var result = new List<GetRawMaterialDTO>();
        string sp = "rawmaterials.usp_GetAllRawMaterials";

        using SqlCommand command = new(sp, _connection, _transaction);
        command.CommandType = CommandType.StoredProcedure;

        using SqlDataReader reader = await command.ExecuteReaderAsync(cancellationToken);
        while (await reader.ReadAsync(cancellationToken))
        {
            var rawMaterial = new GetRawMaterialDTO
            {
                Id = reader.GetString(reader.GetOrdinal("Id")),
                Name = reader.GetString(reader.GetOrdinal("Name")),
                UNSPSC = reader.GetString(reader.GetOrdinal("UNSPSC")),
                UNSPSCDescription = reader.GetString(reader.GetOrdinal("UNSPSCDescription")),
                CreatedAt = reader.GetDateTimeOffset(reader.GetOrdinal("CreatedAt")),
                UpdatedAt = reader.GetDateTimeOffset(reader.GetOrdinal("UpdatedAt")),
                IsEnabled = reader.GetBoolean(reader.GetOrdinal("IsEnabled"))
            };
            result.Add(rawMaterial);
        }

        return result;
    }

    public async Task<IEnumerable<GetRawMaterialDTO>> GetByFilterAsync(
          string queryString
        , CancellationToken cancellationToken = default)
    {
        var result = new List<GetRawMaterialDTO>();
        string sp = "rawmaterials.usp_GetRawMaterialsByFilter";

        using SqlCommand command = new(sp, _connection, _transaction);
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.Add(new SqlParameter
        {
            ParameterName = "@queryString",
            Size = 255,
            SqlDbType = SqlDbType.NVarChar,
            Value = queryString
        });

        using SqlDataReader reader = await command.ExecuteReaderAsync(cancellationToken);
        while (await reader.ReadAsync(cancellationToken))
        {
            var rawMaterial = new GetRawMaterialDTO
            {
                Id = reader.GetString(reader.GetOrdinal("Id")),
                Name = reader.GetString(reader.GetOrdinal("Name")),
                UNSPSC = reader.GetString(reader.GetOrdinal("UNSPSC")),
                UNSPSCDescription = reader.GetString(reader.GetOrdinal("UNSPSCDescription")),
                CreatedAt = reader.GetDateTimeOffset(reader.GetOrdinal("CreatedAt")),
                UpdatedAt = reader.GetDateTimeOffset(reader.GetOrdinal("UpdatedAt")),
                IsEnabled = reader.GetBoolean(reader.GetOrdinal("IsEnabled"))
            };
            result.Add(rawMaterial);
        }

        return result;
    }

    public async Task<bool> InsertRawMaterial(
          RawMaterial rawMaterial, CancellationToken cancellationToken = default)
    {
        ValidateTransactionInstance();
        sbyte returnedValue;
        string sp = "rawmaterials.usp_InsertRawMaterial";

        using SqlCommand command = new(sp, _connection, _transaction);
        command.CommandType = CommandType.StoredProcedure;

        // parameters
        command.Parameters.Add(SqlParameterBuilder.Empty().Build(
            "@id", SqlDbType.Char, 24, rawMaterial.Id));

        command.Parameters.Add(SqlParameterBuilder.Empty().Build(
            "@name", SqlDbType.NVarChar, 255, rawMaterial.Name));

        command.Parameters.Add(SqlParameterBuilder.Empty().Build(
            "@unspsc", SqlDbType.Char, 11, rawMaterial.UNSPSC));

        command.Parameters.Add(SqlParameterBuilder.Empty().Build(
            "@unspscDescription", SqlDbType.NVarChar, 400, rawMaterial.UNSPSCDescription));

        command.Parameters.Add(SqlParameterBuilder.Empty().Build(
            "@createdAt", SqlDbType.DateTimeOffset, rawMaterial.CreatedAt));

        command.Parameters.Add(SqlParameterBuilder.Empty().Build(
            "@updatedAt", SqlDbType.DateTimeOffset, rawMaterial.UpdatedAt));

        command.Parameters.Add(SqlParameterBuilder.Empty().Build(
            "@isEnabled", SqlDbType.Bit, rawMaterial.IsEnabled));

        returnedValue = Convert.ToSByte(await command.ExecuteScalarAsync(cancellationToken));
        if (returnedValue == 0)
        { return true; }
        else
        { return false; }
    }

    public async Task<bool> UpdateRawMaterial(
          RawMaterial rawMaterial
        , CancellationToken cancellationToken = default)
    {
        ValidateTransactionInstance();
        sbyte returnedValue;
        string sp = "rawmaterials.usp_UpdateRawMaterial";

        using SqlCommand command = new(sp, _connection, _transaction);
        command.CommandType = CommandType.StoredProcedure;

        // parameters
        command.Parameters.Add(SqlParameterBuilder.Empty().Build(
            "@id", SqlDbType.Char, 24, rawMaterial.Id));

        command.Parameters.Add(SqlParameterBuilder.Empty().Build(
            "@name", SqlDbType.NVarChar, 255, rawMaterial.Name));

        command.Parameters.Add(SqlParameterBuilder.Empty().Build(
            "@unspsc", SqlDbType.Char, 11, rawMaterial.UNSPSC));

        command.Parameters.Add(SqlParameterBuilder.Empty().Build(
            "@unspscDescription", SqlDbType.NVarChar, 400, rawMaterial.UNSPSCDescription));

        command.Parameters.Add(SqlParameterBuilder.Empty().Build(
            "@updatedAt", SqlDbType.DateTimeOffset, rawMaterial.UpdatedAt));

        command.Parameters.Add(SqlParameterBuilder.Empty().Build(
            "@isEnabled", SqlDbType.Bit, rawMaterial.IsEnabled));

        returnedValue = Convert.ToSByte(await command.ExecuteScalarAsync(cancellationToken));
        if (returnedValue == 0)
        { return true; }
        else
        { return false; }
    }
    //
    // private
    //
    private void ValidateTransactionInstance()
    {
        if (_transaction == null)
            throw new InvalidOperationException(
                "Transaction is required for transactional operations.");
    }
    #endregion
}