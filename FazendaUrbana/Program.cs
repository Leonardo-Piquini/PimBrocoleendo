using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace FazendaUrbana
{
    internal class Program
    {
        static void Main(string[] args)
        {

                        //TROCAR O SERVER ESPECIFICADO NO DATA SOURCE DEPENDENDO DO LAB
            string StringConexao = @"Data Source=LAB3M92;Initial Catalog=BROCOLEENGOS;
            Integrated Security=True;Encrypt=False;";

            string consulta = @"SELECT F.NOME_FUNC, AP.DS_ACAO, DS_MATERIAL, AP.DT_ACAO, DS_QUADRANTE
                                FROM ACAO_PRODUCAO AP
                                INNER JOIN FUNCIONARIO F ON F.ID_FUNC = AP.ID_FUNC
                                LEFT JOIN MATERIA_PRIMA M ON M.ID_MATERIAL = AP.ID_MATERIAL
                                INNER JOIN PRODUCAO P ON P.ID_PRODUCAO = AP.ID_PRODUCAO
                                INNER JOIN LOCALIZACAO_LOTE LL ON P.ID_LOCALIZACAO_LOTE = LL.ID_LOCALIZACAO_LOTE
                                ORDER BY NOME_FUNC";
            using (SqlConnection conexao = new SqlConnection(StringConexao))
            {
                SqlCommand command = new SqlCommand(consulta, conexao);

                conexao.Open();
                using (SqlDataReader tabelinha = command.ExecuteReader())
                {
                    while (tabelinha.Read())
                    {
                        Console.WriteLine($"    Funcionario: {tabelinha["NOME_FUNC"]}, Ação: {tabelinha["DS_ACAO"]}");
                        Console.WriteLine($"    Quadrante:{tabelinha["DS_QUADRANTE"]}, Data: {tabelinha["DT_ACAO"].ToString().Substring(0, 10)}");
                        Console.WriteLine("-----------------------------------------");
                    }
                    Console.ReadLine();
                }
            }
            // Console.Write(result);
        }
    }
}

