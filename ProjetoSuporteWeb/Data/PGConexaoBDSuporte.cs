using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Xml;

namespace ProjetoSuporteWeb.Data
{
    public class PGConexaoBDSuporte
    {
        NpgsqlConnection conPG;
        NpgsqlCommand npComando;
        NpgsqlTransaction pgTransacao;
        NpgsqlDataAdapter pgAdpter;

        public PGConexaoBDSuporte()
        {
            this.Conectar();
        }

        public void Conectar()
        {
            if (this.Conectado().Equals(false))
            {
                NpgsqlConnectionStringBuilder pgCSB = new NpgsqlConnectionStringBuilder();

                XmlDocument doc = new XmlDocument();
                doc.Load(@"C:\Global\ProjetoSuporteWeb\conf_banco.xml");
                XmlNode no = doc.SelectSingleNode("banco");
                pgCSB.Host = no.ChildNodes.Item(0).InnerText;
                pgCSB.Database = no.ChildNodes.Item(1).InnerText;
                pgCSB.Port = 5432;
                pgCSB.Username = "ADM";
                pgCSB.Password = "235689F";

                pgCSB.Pooling = true;
                pgCSB.MinPoolSize = 1;
                pgCSB.MaxPoolSize = 20;
                pgCSB.ConnectionLifetime = 15;

                pgCSB.Timeout = 1024;
                //pgCSB.WriteBufferSize = 8192;
                pgCSB.ReadBufferSize = 16384;//8192;


                // pgCSB.Pooling = false;

                this.conPG = new NpgsqlConnection(pgCSB.ConnectionString);
                this.conPG.Open();
            }
        }

        public void Fechar()
        {
            this.conPG.Close();
        }

        public bool Conectado()
        {
            bool vret = false;
            if (this.conPG != null)
            {
                if (this.conPG.State == ConnectionState.Open)
                {
                    vret = true;
                }
            }

            return vret;
        }

        public NpgsqlCommand ExecutaSql(string p)
        {
            this.npComando = new NpgsqlCommand(p, this.conPG);
            return this.npComando;
        }

        public NpgsqlCommand ExecutaSql(string p, NpgsqlTransaction pgTransaction)
        {
            this.npComando = new NpgsqlCommand(p, this.conPG, pgTransaction);
            return this.npComando;
        }

        public string ToString { get; set; }

        public NpgsqlConnection getConPG()
        {
            return this.conPG;
        }

        public NpgsqlTransaction IniciaTransacao()
        {
            pgTransacao = this.conPG.BeginTransaction();
            return pgTransacao;
        }

        public void Commit()
        {
            this.pgTransacao.Commit();
        }

        public void RoolBack()
        {
            this.pgTransacao.Rollback();
        }

        public NpgsqlDataAdapter Get_Adpter(string vsql, string vTabela, DataSet ds)
        {
            pgAdpter = new NpgsqlDataAdapter(vsql, this.getConPG());
            pgAdpter.Fill(ds, vTabela);
            return pgAdpter;
        }
    }
}