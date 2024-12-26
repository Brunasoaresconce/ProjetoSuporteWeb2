using ProjetoSuporteWeb.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoSuporteWeb.Data
{
    interface IGenericDAO
    {
        int Gravar(string vsql, PGConexaoBDSuporte pConexao);

        int Excluir(string vsql, PGConexaoBDSuporte pConexao);

        int Editar(string vsql, PGConexaoBDSuporte pConexao);

        int Executar_Procedure(string vsql, PGConexaoBDSuporte pConexao);
    }
}
