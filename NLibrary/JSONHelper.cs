﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Web.Script.Serialization;
using System.Web.Script;
using System.Data;
using Newtonsoft.Json;
namespace NLibrary
{
    public class JosnHelper
    {
        public bool FormatJsonOutput = true;
        /// <summary>
        /// 生成Json格式
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        
        public static string GetJson<T>(T obj)
        {
            DataContractJsonSerializer json = new DataContractJsonSerializer(obj.GetType());
            using (MemoryStream stream = new MemoryStream())
            {
                json.WriteObject(stream, obj);
                string szJson = Encoding.UTF8.GetString(stream.ToArray()); return szJson;
            }
        }

        /// <summary>
        /// 获取Json的Model
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="szJson"></param>
        /// <returns></returns>
        public static T ParseFromJson<T>(string szJson)
        {
            T obj = Activator.CreateInstance<T>();
            using (MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(szJson)))
            {
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(obj.GetType());
                return (T)serializer.ReadObject(ms);
            }
        }

        //extension for 

        public string Serialize(object value)
        {
            Type type = value.GetType();

            Newtonsoft.Json.JsonSerializer json = new Newtonsoft.Json.JsonSerializer();

            json.NullValueHandling = NullValueHandling.Ignore;

            json.ObjectCreationHandling = Newtonsoft.Json.ObjectCreationHandling.Replace;
            json.MissingMemberHandling = Newtonsoft.Json.MissingMemberHandling.Ignore;
            json.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;

            if (type == typeof(DataRow))
                json.Converters.Add(new DataRowConverter());
            else if (type == typeof(DataTable))
                json.Converters.Add(new DataTableConverter());
            else if (type == typeof(DataSet))
                json.Converters.Add(new DataSetConverter());

            StringWriter sw = new StringWriter();
            Newtonsoft.Json.JsonTextWriter writer = new JsonTextWriter(sw);
            if (this.FormatJsonOutput)
                writer.Formatting = Formatting.Indented;
            else
                writer.Formatting = Formatting.None;

            writer.QuoteChar = '"';
            json.Serialize(writer, value);

            string output = sw.ToString();
            writer.Close();
            sw.Close();

            return output;
        }
      
        public object Deserialize(string jsonText, Type valueType)
        {
            Newtonsoft.Json.JsonSerializer json = new Newtonsoft.Json.JsonSerializer();

            json.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
            json.ObjectCreationHandling = Newtonsoft.Json.ObjectCreationHandling.Replace;
            json.MissingMemberHandling = Newtonsoft.Json.MissingMemberHandling.Ignore;
            json.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;

            StringReader sr = new StringReader(jsonText);
            Newtonsoft.Json.JsonTextReader reader = new JsonTextReader(sr);
            object result = json.Deserialize(reader, valueType);
            reader.Close();

            return result;
        }


    }

    #region datasettojson

    /// <summary>
    /// Converts a <see cref="DataRow"/> object to and from JSON.
    /// </summary>
    public class DataRowConverter : JsonConverter
    {
        /// <summary>
        /// Writes the JSON representation of the object.
        /// </summary>
        /// <param name="writer">The <see cref="JsonWriter"/> to write to.</param>
        /// <param name="value">The value.</param>
        public override void WriteJson(JsonWriter writer, object dataRow,JsonSerializer se)
        {
            DataRow row = dataRow as DataRow;

            // *** HACK: need to use root serializer to write the column value
            //     should be fixed in next ver of JSON.NET with writer.Serialize(object)
            JsonSerializer ser = new JsonSerializer();

            writer.WriteStartObject();
            foreach (DataColumn column in row.Table.Columns)
            {
                writer.WritePropertyName(column.ColumnName);
                ser.Serialize(writer, row[column]);
            }
            writer.WriteEndObject();
        }

        /// <summary>
        /// Determines whether this instance can convert the specified value type.
        /// </summary>
        /// <param name="valueType">Type of the value.</param>
        /// <returns>
        ///     <c>true</c> if this instance can convert the specified value type; otherwise, <c>false</c>.
        /// </returns>
        public override bool CanConvert(Type valueType)
        {
            return typeof(DataRow).IsAssignableFrom(valueType);
        }

        /// <summary>
        /// Reads the JSON representation of the object.
        /// </summary>
        /// <param name="reader">The <see cref="JsonReader"/> to read from.</param>
        /// <param name="objectType">Type of the object.</param>
        /// <returns>The object value.</returns>
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }


    /// <summary>
    /// Converts a DataTable to JSON. Note no support for deserialization
    /// </summary>
    public class DataTableConverter : JsonConverter
    {
        /// <summary>
        /// Writes the JSON representation of the object.
        /// </summary>
        /// <param name="writer">The <see cref="JsonWriter"/> to write to.</param>
        /// <param name="value">The value.</param>
        public override void WriteJson(JsonWriter writer, object dataTable, JsonSerializer serializer)
        {
            DataTable table = dataTable as DataTable;
            DataRowConverter converter = new DataRowConverter();

            writer.WriteStartObject();

            writer.WritePropertyName("Rows");
            writer.WriteStartArray();

            foreach (DataRow row in table.Rows)
            {
                converter.WriteJson(writer, row,serializer);
            }

            writer.WriteEndArray();
            writer.WriteEndObject();
        }

        /// <summary>
        /// Determines whether this instance can convert the specified value type.
        /// </summary>
        /// <param name="valueType">Type of the value.</param>
        /// <returns>
        ///     <c>true</c> if this instance can convert the specified value type; otherwise, <c>false</c>.
        /// </returns>
        public override bool CanConvert(Type valueType)
        {
            return typeof(DataTable).IsAssignableFrom(valueType);
        }

        /// <summary>
        /// Reads the JSON representation of the object.
        /// </summary>
        /// <param name="reader">The <see cref="JsonReader"/> to read from.</param>
        /// <param name="objectType">Type of the object.</param>
        /// <returns>The object value.</returns>
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }

    /// <summary>
    /// Converts a <see cref="DataSet"/> object to JSON. No support for reading.
    /// </summary>
    public class DataSetConverter : JsonConverter
    {
        /// <summary>
        /// Writes the JSON representation of the object.
        /// </summary>
        /// <param name="writer">The <see cref="JsonWriter"/> to write to.</param>
        /// <param name="value">The value.</param>
        public override void WriteJson(JsonWriter writer, object dataset, JsonSerializer jer)
        {
            DataSet dataSet = dataset as DataSet;

            DataTableConverter converter = new DataTableConverter();

            writer.WriteStartObject();

            writer.WritePropertyName("Tables");
            writer.WriteStartArray();

            foreach (DataTable table in dataSet.Tables)
            {
                converter.WriteJson(writer, table,jer);
            }
            writer.WriteEndArray();
            writer.WriteEndObject();
        }

        /// <summary>
        /// Determines whether this instance can convert the specified value type.
        /// </summary>
        /// <param name="valueType">Type of the value.</param>
        /// <returns>
        ///     <c>true</c> if this instance can convert the specified value type; otherwise, <c>false</c>.
        /// </returns>
        public override bool CanConvert(Type valueType)
        {
            return typeof(DataSet).IsAssignableFrom(valueType);
        }

        /// <summary>
        /// Reads the JSON representation of the object.
        /// </summary>
        /// <param name="reader">The <see cref="JsonReader"/> to read from.</param>
        /// <param name="objectType">Type of the object.</param>
        /// <returns>The object value.</returns>
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
    #endregion
}





