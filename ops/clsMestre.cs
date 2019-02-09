using System;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Text.RegularExpressions;
using System.Net.NetworkInformation;
using System.Data;
using System.Windows.Forms;

namespace OPS
{
    class clsMestre
    {
        //Funções de conexão do banco --------------------------------------------------------------------
        string conexao = ConfigurationManager.ConnectionStrings["conexao"].ToString();

        //Função para testar conexão
        public bool TestarConexao()
        {
            MySqlConnection cnn = new MySqlConnection(conexao);
            bool retorno = false;

            try
            {
                //Abrindo conexão
                cnn.Open();
                //Se der certo retorna verdadeiro
                retorno = true;
            }
            catch (Exception ex)
            {
                //Retorno falso por causa do erro
                retorno = false;
            }
            finally
            {
                //Fechar conexão
                cnn.Close();
            }

            return retorno;
        }

        //Executar query
        public bool executarQuery(string sql)
        {
            //Instanciando conexao
            MySqlConnection cnn = new MySqlConnection(conexao);
            //Instanciando comando que irá executar no banco
            MySqlCommand comando = new MySqlCommand(sql, cnn);
            try
            {
                //Abrindo conexão
                comando.Connection.Open();
                //Executando query
                comando.ExecuteNonQuery();
                //Fechando conexão
                comando.Connection.Close();
                return true;

            }
            catch
            {
                //Fechando conexão
                comando.Connection.Close();
                return false;
            }

        }

        //Função para encher tabela
        public DataTable SelectTabela(string sql)
        {
            //Variavel de retorno
            DataTable dt = new DataTable();
            //Instanciando conexao
            MySqlConnection cnn = new MySqlConnection(conexao);
            //Instanciando comando que irá executar no banco
            MySqlCommand comando = new MySqlCommand(sql, cnn);

            try
            {
                //Abrindo conexão
                comando.Connection.Open();
                //Executando query
                MySqlDataReader dtr = comando.ExecuteReader();
                dt.Load(dtr);
                //Fechando conexão
                dtr.Close();
                comando.Connection.Close();

            }
            catch (Exception ex)
            {
                //Fechando conexão
                comando.Connection.Close();
                MessageBox.Show("Erro: " + ex.Message, "Erro");
            }


            return dt;
        }

        //Funçao para validar registro (Se já está cadastrado ou não)
        public bool ValidarRegistro(string tabela, string campo, string parametro)
        {
            //Instanciando conexao
            MySqlConnection cnn = new MySqlConnection(conexao);
            //Montando query
            string sql = "SELECT " + campo + " FROM " + tabela + " WHERE " + campo + " = '" + parametro + "';";
            //Instanciando comando que irá executar no banco
            MySqlCommand comando = new MySqlCommand(sql, cnn);

            try
            {
                //Abrindo conexão
                comando.Connection.Open();
                //Executando query
                MySqlDataReader dtr = comando.ExecuteReader();

                //Verificando retorno
                if (dtr.HasRows)
                {
                    //Fechando conexão
                    dtr.Close();
                    comando.Connection.Close();
                    return true;
                }
                else
                {
                    //Fechando conexão
                    dtr.Close();
                    comando.Connection.Close();
                    return false;
                }
            }
            catch (Exception ex)
            {
                //Fechando conexão
                comando.Connection.Close();
                MessageBox.Show("Erro: " + ex.Message, "Erro");
                return false;
            }
        }

        //Função para limpar caracteres
        public string ConverteTexto(OpcaoTexto opcao, string texto)
        {
            //Verificando se a váriavel esta vazia
            if (texto.Replace(" ", "") == "" || texto.Replace(" ", "") == string.Empty)
            {
                texto = "";
            }

            //Removendo caracteres
            if (texto != "")
            {
                texto = texto.Trim();
                texto = texto.Replace("£", "");
                texto = texto.Replace("¨", "");
                texto = texto.Replace("¬", "");
                texto = texto.Replace("§", "");
                texto = texto.Replace("~", "");
                texto = texto.Replace("^", "");
                texto = texto.Replace("'", "");
                texto = texto.Replace("\n", "");
                texto = texto.Replace("\r", "");

                //Verificando a formatação que o texto deve voltar
                if (opcao == OpcaoTexto.Maiuscula) { texto.ToLower(); }
                if (opcao == OpcaoTexto.Minuscula) { texto.ToUpper(); }
                texto = texto.Trim();
            }

            return texto;
        }

        //Função para deixar apenas números
        public string ApenasNumeros(string texto)
        {
            string resultado = string.Empty;

            // Função para deixar apenas números
            Regex objRegex = new Regex(@"[^\d]");
            resultado = objRegex.Replace(texto, "");

            return resultado;
        }

        //Gerar chaves
        public string GerarSenha(OpcaoChave opcao)
        {
            //Declarando variaveis
            int tamanho_Chave = 0;
            int[] numeros = new int[10];
            string[] letras = new string[26];
            string chave = "";
            Random rdn = new Random();
            //Atribuindo números de zero a nove
            for (int cont = 0; cont <= 9; cont++)
            {
                numeros[cont] = cont;
            }
            //Atribuindo letras de A a Z
            letras[0] = "A";
            letras[1] = "B";
            letras[2] = "C";
            letras[3] = "D";
            letras[4] = "E";
            letras[5] = "F";
            letras[6] = "G";
            letras[7] = "H";
            letras[8] = "I";
            letras[9] = "J";
            letras[10] = "K";
            letras[11] = "L";
            letras[12] = "M";
            letras[13] = "N";
            letras[14] = "O";
            letras[15] = "P";
            letras[16] = "Q";
            letras[17] = "R";
            letras[18] = "S";
            letras[19] = "T";
            letras[20] = "U";
            letras[21] = "V";
            letras[22] = "X";
            letras[23] = "W";
            letras[24] = "Y";
            letras[25] = "Z";

            //Determinando o tamanho da chave
            if (opcao == OpcaoChave.Grande) { tamanho_Chave = 16; };
            if (opcao == OpcaoChave.Media) { tamanho_Chave = 8; };
            if (opcao == OpcaoChave.Pequena) { tamanho_Chave = 4; };

            //Montando chave
            for (int i = 0; i <= tamanho_Chave; i++)
            {
                chave += numeros[rdn.Next(10)];
                chave += letras[rdn.Next(26)];
            }

            return chave;
        }

        //Ping para testar rede
        public bool Ping(string endereco)
        {
            //Instanciando classe de ping
            Ping p = new Ping();
            PingReply pr;

            //Executando ping
            pr = p.Send(endereco);

            if (pr.Status == IPStatus.Success)
            {
                //Com resposta
                return true;
            }
            else
            {
                //Sem resposta
                return false;
            }
        }

        // Enum para funções -----------------------------------------------------------------------------------------------------------------

        //Formatação de texto
        public enum OpcaoTexto { Maiuscula, Minuscula, Normal };

        //Criação de chaves
        public enum OpcaoChave { Pequena, Media, Grande };
    }
}
