using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace BLL
{
    interface IBLL<T> where T : class
    {
        string table { get; set; }
        DataTable getAll(string filtro, string campopesquisa);
        T get(int? id);

        void update(T obj);
        void insert(T obj);
        void delete(int? id);

    }
}
