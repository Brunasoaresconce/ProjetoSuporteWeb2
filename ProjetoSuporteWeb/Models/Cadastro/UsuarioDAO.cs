using Npgsql;
using ProjetoSuporteWeb.Data;

namespace ProjetoSuporteWeb.Models.Cadastro
{
    public class UsuarioDAO : ControllerBD<Usuario>
    {
        private string tableName = "usuario";

        private Usuario cDados;

        public UsuarioDAO() { }

        public UsuarioDAO(Usuario pDados)
        {
            cDados = pDados;
        }
        public Usuario Get_Usuario(string pUser, string pSenha)
        {
            Usuario ret = new Usuario();
            string vsenha = "";

            string vsql = "select * from usuario where nm_usuario = '" + pUser.ToUpper() + "'";

            PGConexaoBDSuporte pGConexaoBDSuporte = new PGConexaoBDSuporte();
            NpgsqlDataReader r = Get_Consulta_Geral(vsql, pGConexaoBDSuporte);

            if (r != null)
            {
                if (r.HasRows)
                {
                    r.Read();

                    #region id
                    if (!r.IsDBNull(r.GetOrdinal("id")))
                    {
                        ret.id = r.GetInt32(r.GetOrdinal("id"));
                    }
                    else
                    {
                        ret.id = -1;
                    }
                    #endregion

                    #region nm_usuario
                    if (!r.IsDBNull(r.GetOrdinal("nm_usuario")))
                    {
                        ret.nm_usuario = r.GetString(r.GetOrdinal("nm_usuario"));
                    }
                    else
                    {
                        ret.nm_usuario = "  ";
                    }
                    #endregion

                    #region senha
                    if (!r.IsDBNull(r.GetOrdinal("senha")))
                    {
                        ret.senha = r.GetString(r.GetOrdinal("senha"));
                    }
                    else
                    {
                        ret.senha = "  ";
                    }
                    #endregion

                    if (pSenha.Equals(ret.senha))
                    {
                        ret.senha = pSenha;
                    }
                }
            }
            r.Close();
            pGConexaoBDSuporte.Fechar();

            return ret;
        }


        public Usuario Get_Consulta(string vsql)
        {
            Usuario ret = new Usuario();
            PGConexaoBDSuporte pGConexaoBDSuporte = new PGConexaoBDSuporte();
            NpgsqlDataReader r = Get_Consulta_Key(vsql, pGConexaoBDSuporte);
            if (r != null)
            {
                if (r.HasRows)
                {
                    r.Read();
                    #region id
                    if (r.IsDBNull(r.GetOrdinal("id")) == false)
                    {
                        ret.id = r.GetInt32(r.GetOrdinal("id"));
                    }
                    else
                    {
                        ret.id = -1;
                    }
                    #endregion

                    #region nm_usuario
                    if (r.IsDBNull(r.GetOrdinal("nm_usuario")) == false)
                    {
                        ret.nm_usuario = r.GetString(r.GetOrdinal("nm_usuario"));
                    }
                    else
                    {
                        ret.nm_usuario = "  ";
                    }
                    #endregion

                    #region senha
                    if (r.IsDBNull(r.GetOrdinal("senha")) == false)
                    {
                        ret.senha = r.GetString(r.GetOrdinal("senha"));
                    }
                    else
                    {
                        ret.senha = "  ";
                    }
                    #endregion


                }
            }
            r.Close();
            pGConexaoBDSuporte.Fechar();
            return ret;
        }
    }
}
