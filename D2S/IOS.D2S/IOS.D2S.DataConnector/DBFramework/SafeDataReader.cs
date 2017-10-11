using System;
using System.Data;

namespace IOS.D2S.DataConnector.DBFramework
{
    
    public enum DataTypes:int 
    {
        DateTime,
       Boolean,
        Byte,
        Char,
        Decimal,
        Double,
        Int16,
        Int32,
        Int64,
        SByte,
        Single,
        String,
        UInt16,
        UInt32,
        UInt64
    }
		public class SafeDataReader : IDataReader
		{
			
			
			private IDataReader _dataReader;
			
			
			public IDataReader DataReader
			{
				get
				{
					return _dataReader;
				}
				set
				{
					_dataReader = value;
				}
			}
			
			public SafeDataReader(IDataReader dataReader)
			{
				_dataReader = dataReader;
			}
			
			public int GetNumber(string name)
			{
				return GetNumber(GetOrdinal(name));
			}
			
			public int GetNumber(int i)
			{
				System.Type tp = _dataReader.GetFieldType(i);
				if (tp.FullName == typeof(System.Int16).FullName)
				{
					return Convert.ToInt32(GetInt16(i));
				}
				else if (tp.FullName == typeof(System.Int32).FullName)
				{
					return GetInt32(i);
				}
				else if (tp.FullName == typeof(System.Int64).FullName)
				{
					return Convert.ToInt32(GetInt64(i));
				}
				else if (tp.FullName == typeof(System.Decimal).FullName)
				{
					return Convert.ToInt32(GetDecimal(i));
				}
				return 0;
			}
			
			
			public void Close()
			{
				_dataReader.Close();
			}
			
			public int Depth
			{
				get
				{
					return _dataReader.Depth;
				}
			}
			
			public System.Data.DataTable GetSchemaTable()
			{
				return _dataReader.GetSchemaTable();
			}
			
			public bool IsClosed
			{
				get
				{
					return _dataReader.IsClosed;
				}
			}
			
			public bool NextResult()
			{
				return _dataReader.NextResult();
			}
			
			public bool Read()
			{
				return _dataReader.Read();
			}
			
			public int RecordsAffected
			{
				get
				{
					return _dataReader.RecordsAffected;
				}
			}
			
			public int FieldCount
			{
				get
				{
					return _dataReader.FieldCount;
				}
			}
			
			
			public bool GetBoolean(string name)
			{
				return GetBoolean(GetOrdinal(name));
			}
			
			public bool GetBoolean(int i)
			{
				if (_dataReader.IsDBNull(i))
				{
					return false;
				}
				else
				{
					return _dataReader.GetBoolean(i);
				}
			}
			
			
			public byte GetByte(string name)
			{
				return GetByte(GetOrdinal(name));
			}
			
			public byte GetByte(int i)
			{
				if (_dataReader.IsDBNull(i))
				{
					return 0;
				}
				else
				{
					return _dataReader.GetByte(i);
				}
				
			}
			
			public long GetBytes(string name, long fieldOffset, byte[] buffer, int bufferoffset, int length)
			{
				return GetBytes(GetOrdinal(name), fieldOffset, buffer, bufferoffset, length);
			}
			
			public long GetBytes(int i, long fieldOffset, byte[] buffer, int bufferoffset, int length)
			{
				if (_dataReader.IsDBNull(i))
				{
					return 0;
				}
				else
				{
					return _dataReader.GetBytes(i, fieldOffset, buffer, bufferoffset, length);
				}
			}
			
			
			public char GetChar(string name)
			{
				GetChar(GetOrdinal(name));
				return System.Convert.ToChar(0);
			}
			
			
			public char GetChar(int i)
			{
				if (_dataReader.IsDBNull(i))
				{
					return char.MinValue;
				}
				else
				{
					
					char[] myChar = new char[2];
					_dataReader.GetChars(i, 0, myChar, 0, 1);
					return System.Convert.ToChar(myChar.GetValue(0));
				}
			}
			
			public long GetChars(string name, long fieldoffset, char[] buffer, int bufferoffset, int length)
			{
				GetChars(GetOrdinal(name), fieldoffset, buffer, bufferoffset, length);
				return 0;
			}
			
			public long GetChars(int i, long fieldoffset, char[] buffer, int bufferoffset, int length)
			{
				if (_dataReader.IsDBNull(i))
				{
					return 0;
				}
				else
				{
					return _dataReader.GetChars(i, fieldoffset, buffer, bufferoffset, length);
				}
			}
			
			
			public System.Data.IDataReader GetData(string name)
			{
				return GetData(GetOrdinal(name));
			}
			
			public System.Data.IDataReader GetData(int i)
			{
				return _dataReader.GetData(i);
			}
			
			public string GetDataTypeName(string name)
			{
				return GetDataTypeName(GetOrdinal(name));
			}
			
			public string GetDataTypeName(int i)
			{
				return _dataReader.GetDataTypeName(i);
			}
			
			
			public DateTime GetDateTime(string name)
			{
				return GetDateTime(GetOrdinal(name));
			}
			
			public DateTime GetDateTime(int i)
			{
				if (_dataReader.IsDBNull(i))
				{
					return DateTime.MinValue;
				}
				else
				{
					return _dataReader.GetDateTime(i);
				}
			}
			
			public decimal GetDecimal(string name)
			{
				
				return 0;
			}
			
			public decimal GetDecimal(int i)
			{
				if (_dataReader.IsDBNull(i))
				{
					return 0;
				}
				else
				{
					return _dataReader.GetDecimal(i);
				}
			}
			
			
			public double GetDouble(string name)
			{
				return GetDouble(GetOrdinal(name));
				
			}
			public double GetDouble(int i)
			{
				if (_dataReader.IsDBNull(i))
				{
					return 0;
				}
				else
				{
					return _dataReader.GetDouble(i);
				}
			}
			
			public System.Type GetFieldType(string name)
			{
				return GetFieldType(GetOrdinal(name));
			}
			
			public System.Type GetFieldType(int i)
			{
				return _dataReader.GetFieldType(i);
			}
			
			public float GetFloat(int i)
			{
				if (_dataReader.IsDBNull(i))
				{
					return 0;
				}
				else
				{
					return _dataReader.GetFloat(i);
				}
			}
			
			public System.Guid GetGuid(int i)
			{
				if (_dataReader.IsDBNull(i))
				{
					return Guid.Empty;
				}
				else
				{
					return _dataReader.GetGuid(i);
				}
			}
			
			public short GetInt16(int i)
			{
				if (_dataReader.IsDBNull(i))
				{
					return 0;
				}
				else
				{
					return _dataReader.GetInt16(i);
				}
			}
			
			public int GetInt32(int i)
			{
				if (_dataReader.IsDBNull(i))
				{
					return 0;
				}
				else
				{
					return _dataReader.GetInt32(i);
				}
			}
			
			public long GetInt64(int i)
			{
				
				return 0;
			}
			
			public string GetName(int i)
			{
				return _dataReader.GetName(i);
			}
			
			public int GetOrdinal(string name)
			{
				return _dataReader.GetOrdinal(name);
			}
			
			public string GetString(int i)
			{
				if (_dataReader.IsDBNull(i))
				{
					return string.Empty;
				}
				else
				{
					return _dataReader.GetString(i);
				}
			}
			
			public object GetValue(int i)
			{
				if (_dataReader.IsDBNull(i))
				{
					return null;
				}
				else
				{
					return _dataReader.GetValue(i);
				}
			}
			
			public int GetValues(object[] values)
			{
				return _dataReader.GetValues(values);
			}
			
			public bool IsDBNull(int i)
			{
				return _dataReader.IsDBNull(i);
			}
			
			public object this[int i]
			{
				get
				{
					if (_dataReader.IsDBNull(i))
					{
						return null;
					}
					else
					{
						return _dataReader[i];
					}
					
				}
			}

            public object this[string name]
            {
                get
                {
                    if (_dataReader.IsDBNull(GetOrdinal(name)))
                    {
                        return null;
                    }
                    else
                    {
                        return _dataReader[GetOrdinal(name)];
                    }
                }
            }


            public object this[string name, DataTypes dtypes]
            {
                get
                {
                    if (_dataReader.IsDBNull(GetOrdinal(name)))
                    {
                        switch (dtypes)
                        {
                            case DataTypes.DateTime:
                                return GetDateTime(GetOrdinal(name));
                              

                            case DataTypes.Boolean:
                                return GetBoolean(GetOrdinal(name));
                            
                            case DataTypes.Byte:
                                return GetByte(GetOrdinal(name));
                              
                            case DataTypes.Char:
                                return GetChar(GetOrdinal(name));
                              
                            case DataTypes.Decimal:
                                return GetDecimal(GetOrdinal(name));
                               
                            case DataTypes.Double:
                                return GetDouble(GetOrdinal(name));
                                 
                            case DataTypes.Int16:
                                return GetInt16(GetOrdinal(name));
                                
                            case DataTypes.Int32:
                                return GetInt32(GetOrdinal(name));
                                 
                            case DataTypes.Int64:
                                return GetInt64(GetOrdinal(name));
                              
                            case DataTypes.SByte:
                                return GetInt64(GetOrdinal(name));
                               
                            case DataTypes.Single:
                                return GetDouble(GetOrdinal(name));
                                 
                            case DataTypes.String:
                                return GetString(GetOrdinal(name));
                            
                            case DataTypes.UInt16:
                                return GetInt16(GetOrdinal(name));
                              
                            case DataTypes.UInt32:
                                return GetInt16(GetOrdinal(name));
                            
                            case DataTypes.UInt64:
                                return GetInt16(GetOrdinal(name));
                            
                            default:
                                return GetData(GetOrdinal(name));
                               

                        }


                    }
                    else
                    {
                        return _dataReader[GetOrdinal(name)];
                    }

                }
            }
			
			private bool disposedValue = false; // To detect redundant calls
			
			// IDisposable
			protected virtual void Dispose(bool disposing)
			{
				if (! this.disposedValue)
				{
					if (disposing)
					{
						// TODO: free unmanaged resources when explicitly called
					}
					
					// TODO: free shared unmanaged resources
				}
				this.disposedValue = true;
			}
			
			#region " IDisposable Support "
			// This code added by Visual Basic to correctly implement the disposable pattern.
			public void Dispose()
			{
				// Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
				Dispose(true);
				GC.SuppressFinalize(this);
			}
			#endregion
			
			
		}
	
}
