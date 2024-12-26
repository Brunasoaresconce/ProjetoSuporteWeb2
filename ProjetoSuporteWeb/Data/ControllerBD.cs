using Npgsql;
using ProjetoSuporteWeb.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ProjetoSuporteWeb.Data
{
    public class ControllerBD<T> : IGenericDAO
    {


        public int Gravar(string vsql, PGConexaoBDSuporte pConexao)
        {
            int iret = -1;
            Inicia();

            try
            {
                //iret = this.conexao.ExecutaSql(vsql, this.conexao.IniciaTransacao()).ExecuteNonQuery();
                iret = pConexao.ExecutaSql(vsql, pConexao.IniciaTransacao()).ExecuteNonQuery();
                if (iret >= 0)
                {
                    //this.conexao.Commit();
                    pConexao.Commit();
                    iret = 1;
                }
                else
                {
                    //this.conexao.RoolBack();
                    pConexao.RoolBack();
                    iret = -1;
                }

                pConexao.Fechar();
            }
            catch (NpgsqlException)
            {
                Console.WriteLine("Erro : " + vsql);
                pConexao.Fechar();
            }

            return iret;
        }


        public int Executar_Procedure(string vsql, PGConexaoBDSuporte pConexao)
        {
            Inicia();
            int iret = 1;

            //this.conexao.ExecutaSql(vsql).ExecuteReader();
            pConexao.ExecutaSql(vsql).ExecuteReader();


            pConexao.Fechar();

            return iret;
        }

        public int Excluir(string vsql, PGConexaoBDSuporte pConexao)
        {

            int iret = -1;
            Inicia();

            try
            {
                iret = pConexao.ExecutaSql(vsql, pConexao.IniciaTransacao()).ExecuteNonQuery();
                if (iret >= 0)
                {
                    pConexao.Commit();
                    iret = 1;
                }
                else
                {
                    pConexao.RoolBack();
                    iret = -1;
                }

                pConexao.Fechar();
            }
            catch (NpgsqlException)
            {
                Console.WriteLine("Erro : " + vsql);
                pConexao.Fechar();
            }

            return iret;
        }

        public int Editar(string vsql, PGConexaoBDSuporte pConexao)
        {
            int iret = -1;
            Inicia();

            try
            {
                iret = pConexao.ExecutaSql(vsql, pConexao.IniciaTransacao()).ExecuteNonQuery();
                if (iret >= 0)
                {
                    pConexao.Commit();
                    iret = 1;
                }
                else
                {
                    pConexao.RoolBack();
                    iret = -1;
                }

                pConexao.Fechar();
            }
            catch (NpgsqlException)
            {
                Console.WriteLine("Erro : " + vsql);
                pConexao.Fechar();
            }

            return iret;
        }

        public T FindByID(T id)
        {
            return id;
        }

        private void Inicia()
        {

            // this.conexao = new PGConexaoBDSaude();
            // this.conexao.Conectar();
        }



        public DataView GetDadosDV(string vsql, string vTabela, PGConexaoBDSuporte pConexao)
        {
            Inicia();

            DataSet ds = new DataSet();
            pConexao.Get_Adpter(vsql, vTabela, ds);
            DataView dv = ds.Tables[0].DefaultView;
            pConexao.Fechar();
            return dv;

        }


        public NpgsqlDataReader Get_Consulta_Key(string vsql, PGConexaoBDSuporte pConexao)
        {
            Inicia();
            NpgsqlDataReader r = pConexao.ExecutaSql(vsql).ExecuteReader(CommandBehavior.SingleRow);
            return r;
        }

        public NpgsqlDataReader Get_Consulta_Geral(string vsql, PGConexaoBDSuporte pConexao)
        {
            Inicia();
            NpgsqlDataReader r = pConexao.ExecutaSql(vsql).ExecuteReader();
            return r;
        }


        public DataSet GetDadosDataSet(string vsql, string vTabela, PGConexaoBDSuporte pConexao)
        {
            Inicia();

            DataSet ds = new DataSet();
            pConexao.Get_Adpter(vsql, vTabela, ds);
            // this.conexao.Fechar();
            return ds.Tables[0].DataSet;

        }
    }
}