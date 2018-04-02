using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Entidades;
using DAL;

namespace BLL
{
    public class ItensReceitaBLL : BaseBLL<ItensReceita>
    {
        public ItensReceitaBLL(string table) : base(table)
        {
        }

        public void ordenaSequencia(int id_receita)
        {
            DAOGeral daogeral = new DAOGeral();
            daogeral.executaComRetorno("UPDATE ItensReceita"
                                        + " SET sequencia = x.teste"
                                        + " FROM("
                                              + " select ROW_NUMBER() OVER(ORDER BY id ASC) AS teste, id_receita, id from ItensReceita where id_receita = " + id_receita
                                              + " ) x"
                                        + " where ItensReceita.id_receita = x.id_receita"
                                        + " and ItensReceita.id = x.id");
        }

        public void deleteCustomReceita(int id_receita)
        {
            DAOGeral daogeral = new DAOGeral();
            daogeral.executaComRetorno("DELETE FROM " + this.table + " WHERE ID_RECEITA = " + id_receita);
        }

        public void updateCustomMoveAcimaSequencia(int sequencia, int id)
        {
            DAOGeral daogeral = new DAOGeral();
            daogeral.executaComRetorno("UPDATE " + this.table + " SET SEQUENCIA = " + sequencia + " WHERE SEQUENCIA = " + (sequencia + 1));
            daogeral = new DAOGeral();
            daogeral.executaComRetorno("UPDATE " + this.table + " SET SEQUENCIA = " + (sequencia + 1) + " WHERE ID = " + id);
        }

        public void updateCustomMoveAbaixoSequencia(int sequencia, int id)
        {
            DAOGeral daogeral = new DAOGeral();
            daogeral.executaComRetorno("UPDATE " + this.table + " SET SEQUENCIA = " + sequencia + " WHERE SEQUENCIA = " + (sequencia - 1));
            daogeral = new DAOGeral();
            daogeral.executaComRetorno("UPDATE " + this.table + " SET SEQUENCIA = " + (sequencia - 1) + " WHERE ID = " + id);
        }

        public DataTable getCustomReceita(int? id_receita)
        {
            DAOGeral daogeral = new DAOGeral();
            DataTable dt = daogeral.executaComRetorno("SELECT sequencia as SEQUÊNCIA,objetivo as OBJETIVO,CASE WHEN objetivo = 'Peso' THEN valor + ' kg' ELSE valor END as VALOR, CASE WHEN objetivo = 'Peso' THEN corte + ' kg' ELSE corte END as CORTE,acao as AÇÃO,parametro1 as PARAMETRO,CAST(rele.codigo as varchar) + '-' + rele.nome as RELE,tipo_limite as [TIPO_LIMITE],CASE WHEN tipo_limite = 'Peso' THEN valor_limite + ' kg' ELSE valor_limite END as [VALOR_LIMITE],itens.id as ID FROM " + table + " itens"
                + " LEFT JOIN Rele rele on itens.parametro2 = CAST(rele.id as varchar)"
                + " WHERE ID_RECEITA = " + (id_receita == null ? 0 : id_receita) + " ORDER BY SEQUÊNCIA");
            if (dt.Rows.Count > 0)
            {
                return dt;
            }
            return null;
        }

        public DataTable getItensReceita(int? id_receita)
        {
            DAOGeral daogeral = new DAOGeral();
            DataTable dt = daogeral.executaComRetorno("SELECT itens.*,rele.codigo as codigo_rele,rele.nome as nome_rele,tiporele.id as id_tiporele,tiporele.nome as nome_tiporele FROM " + table + " itens"
                + " LEFT JOIN Rele rele on itens.parametro2 = CAST(rele.id as varchar)"
                + " LEFT JOIN TipoRele tiporele on rele.tipo = TipoRele.id"
                + " WHERE ID_RECEITA = " + (id_receita == null ? 0 : id_receita) + " ORDER BY itens.sequencia");
            if (dt.Rows.Count > 0)
            {
                return dt;
            }
            return null;
        }


        public byte deParaObjetivo(string objetivo)
        {
            switch (Common.Util.RemoveCaracteresEspeciais(objetivo.ToUpper(),false,true))
            {
                case "PESO":
                    return 0x01;
                case "TEMPO":
                    return 0x02;
                default:
                    return 0x03;
            }
        }

        public byte deParaAcao(string acao)
        {
            switch (Common.Util.RemoveCaracteresEspeciais(acao.ToUpper(),false,true))
            {
                case "ATIVAR":
                    return 0x01;
                case "DESATIVAR":
                    return 0x02;
                default: //funcao
                    return 0x03;
            }
        }

        public byte deParaParametro1(string parametro1)
        {
            switch (Common.Util.RemoveCaracteresEspeciais(parametro1.ToUpper(),false,true))
            {
                case "SAIDA":
                    return 0x01;
                case "ZERO":
                    return 0x02;
                default: //tara
                    return 0x03;
            }
        }

        public byte deParaTipoRele(string tiporele)
        {
            switch (Common.Util.RemoveCaracteresEspeciais(tiporele.ToUpper(),false,true))
            {
                case "PRODUTO":
                    return 0x01;
                default: //funcao
                    return 0x02;
            }
        }

        public byte deParaTipoLimite(string tipolimite)
        {
            switch (Common.Util.RemoveCaracteresEspeciais(tipolimite.ToUpper(),false,true))
            {
                case "PESO":
                    return 0x01;
                case "TEMPO":
                    return 0x02;
                default: //nenhum
                    return 0x03;
            }
        }

        public byte pegaCasasDecimais(string valor)
        {
            if (string.IsNullOrEmpty(valor))
            {
                return 0;
            }

            //numero de casas
            string[] valorquebrado = valor.Split(',');
            if (valorquebrado.Length == 1)
            {
                return 0;
            }
            else
            {
                return Convert.ToByte(valorquebrado[1].Length);
            }


        }

        public int primeiroValor(int valortotal)
        {
            // divide pelo numero maximo de um byte
            return Convert.ToInt32((valortotal / 65536));
        }

        public int segundoValor(int valortotal, int varprimeirovalor)
        {
            int resultado = valortotal - (65536 * varprimeirovalor);
            //calculo valor 2
            return resultado / 256;
        }

        public int sobraSegundoValor(int valortotal, int varprimeirovalor)
        {
            return valortotal - (65536 * varprimeirovalor);
            //calculo valor 2
        }

        public int terceiroValor(int valortotal, int varsegundovalor)
        {
            return sobraSegundoValor(valortotal, primeiroValor(valortotal)) - (256 * varsegundovalor);
        }

        public override ItensReceita ConvertToClass(DataRow row)
        {
            ItensReceita obj = new ItensReceita();
            obj.id = Convert.ToInt32(row["id"].ToString());
            obj.id_receita = Convert.ToInt32(row["id_receita"].ToString());
            obj.objetivo = row["objetivo"].ToString();
            obj.valor = row["valor"].ToString();
            obj.corte = row["corte"].ToString();
            obj.acao = row["acao"].ToString();
            obj.parametro1 = row["parametro1"].ToString();
            obj.parametro2 = row["parametro2"].ToString();
            obj.tipo_limite = row["tipo_limite"].ToString();
            obj.valor_limite = row["valor_limite"].ToString();
            obj.sequencia = Convert.ToInt32(row["sequencia"].ToString());
            if (row["dateinsert"].ToString() == "")
            {
                obj.dateinsert = null;
            }
            else
            {
                obj.dateinsert = Convert.ToDateTime(row["dateinsert"].ToString());
            }
            if (row["dateupdate"].ToString() == "")
            {
                obj.dateupdate = null;
            }
            else
            {
                obj.dateupdate = Convert.ToDateTime(row["dateupdate"].ToString());
            }
            return obj;
        }
    }
}
