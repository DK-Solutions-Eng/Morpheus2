using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Reflection;
using Entidades;
using DAL;

namespace BLL
{
    public abstract class BaseBLL<T> : IBLL<T> where T : class
    {
        public string table { get; set; }

        public BaseBLL(string table)
        {
            this.table = table;
        }

        public virtual T get (int? id)
        {
            DAOGeral daogeral = new DAOGeral();
            DataTable dt = daogeral.executaComRetorno("SELECT * FROM " + table + " WHERE ID = " + (id == null ? 0 : id));
            if (dt.Rows.Count > 0)
            {
                return ConvertToClass(dt.Rows[0]);
            }
            return null;
        }

        public virtual DataTable getAll(string filtro,string campopesquisa)
        {
            DAOGeral daogeral = new DAOGeral();
            DataTable dt = daogeral.executaComRetorno("SELECT * FROM " + table + (filtro != "" ? " WHERE " + campopesquisa + " LIKE '" + filtro + "%'" : "") + " ORDER BY ID");
            if (dt.Rows.Count > 0)
            {
                return dt;
            }
            return null;
        }

        public void update(T obj)
        {
            DAOGeral daogeral = new DAOGeral();
            daogeral.executaNormal(generatesUpdate(obj));
        }


        public void insert(T obj)
        {
            DAOGeral daogeral = new DAOGeral();
            daogeral.executaNormal(generatesInsert(obj));
        }

        public void delete(int? id)
        {
            DAOGeral daogeral = new DAOGeral();
            daogeral.executaComRetorno("DELETE FROM " + this.table + " WHERE ID = " + id);
        }

        private string generatesInsert(T obj)
        {
            var colunas = obj.GetType().GetProperties();
            string colunasvalues = null;
            foreach (var item in colunas)
            {
                if (item.Name.Equals("id"))
                    continue;

                if (colunasvalues != null)
                    colunasvalues += ",";

                colunasvalues += item.Name;
            }
            string query = "INSERT INTO " + this.table + " (" + colunasvalues + ") VALUES(";
            string values = null;
            foreach (var item in colunas)
            {
                if (item.Name.Equals("id"))
                    continue;

                if (values != null)
                    values += ",";

                if(item.PropertyType.Name.Equals("String") || item.GetGetMethod().ReturnTypeCustomAttributes.ToString().IndexOf("DateTime") != -1)
                {
                    if (obj.GetType().GetProperty(item.Name).GetValue(obj, null) == null)
                    {
                        values += "NULL";
                    }
                    else
                    {
                        values += "'" + obj.GetType().GetProperty(item.Name).GetValue(obj, null) + "'";
                    }
                }
                else if(item.PropertyType.Name.IndexOf("Nullable") != -1)
                {
                    values += "NULL";
                }
                else
                {
                    values += obj.GetType().GetProperty(item.Name).GetValue(obj, null);
                }
            }
            return query += values + ")";
        }

        private string generatesUpdate(T obj)
        {
            var colunas = obj.GetType().GetProperties();

            string query = "UPDATE " + this.table + " SET ";
            string values = null;
            foreach (var item in colunas)
            {
                if (item.Name.Equals("id"))
                    continue;

                if (values != null)
                    values += ",";

                if (item.PropertyType.Name.Equals("String") || item.GetGetMethod().ReturnTypeCustomAttributes.ToString().IndexOf("DateTime") != -1)
                {
                    if(obj.GetType().GetProperty(item.Name).GetValue(obj, null) == null)
                    {
                        values += item.Name + " = NULL";
                    }
                    else
                    {
                        values += item.Name + " = '" + obj.GetType().GetProperty(item.Name).GetValue(obj, null) + "'";
                    }
                }
                else if (item.PropertyType.Name.IndexOf("Nullable") != -1)
                {
                    values += item.Name + " = NULL";
                }
                else
                {
                    values += item.Name + " = " + obj.GetType().GetProperty(item.Name).GetValue(obj, null);
                }
            }
            return query += values + " WHERE ID = " + obj.GetType().GetProperty("id").GetValue(obj, null);
        }

        public virtual T ConvertToClass(DataRow row) { return null; }

    }
}
