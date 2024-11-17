using Microsoft.Data.SqlClient;
using System.Data;

namespace MW.SAXSAY.Shared.Persistence;

public sealed class SqlParameterBuilder
{
    #region Properties & Variables
    private int _size = 0;
    private object? _value;
    private ParameterDirection _direction = ParameterDirection.Input;
    private SqlDbType _sqlDbType;
    private string _name = string.Empty;
    #endregion

    #region Constructor
    private SqlParameterBuilder() { }
    #endregion

    #region Methods
    public SqlParameter Build()
    {
        return new SqlParameter
        {
            Direction = _direction,
            ParameterName = _name,
            SqlDbType = _sqlDbType,
            Size = _size,
            Value = _value
        };
    }

    public SqlParameter Build(
        string name,
        SqlDbType sqlDbType,
        object? value,
        ParameterDirection direction = ParameterDirection.Input)
    {
        _direction = direction;
        _name = name;
        _sqlDbType = sqlDbType;
        _value = value;

        return new SqlParameter
        {
            Direction = _direction,
            ParameterName = _name,
            SqlDbType = _sqlDbType,
            Value = _value
        };
    }

    public SqlParameter Build(
        string name,
        SqlDbType sqlDbType,
        int size,
        object? value,
        ParameterDirection direction = ParameterDirection.Input)
    {
        _size = size;
        return Build(name, sqlDbType, value, direction);
    }

    public static SqlParameterBuilder Empty()
    {
        return new SqlParameterBuilder();
    }

    public SqlParameterBuilder WithName(string parameterName)
    {
        _name = parameterName;
        return this;
    }

    public SqlParameterBuilder WithSize(int size)
    {
        _size = size;
        return this;
    }

    public SqlParameterBuilder WithSqlDbType(SqlDbType sqlDbType)
    {
        _sqlDbType = sqlDbType;
        return this;
    }

    public SqlParameterBuilder WithValue(object? value)
    {
        _value = value;
        return this;
    }

    public SqlParameterBuilder WithDirection(ParameterDirection direction)
    {
        _direction = direction;
        return this;
    }
    #endregion
}
