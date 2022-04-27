using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;



namespace WebCrudNotasVersãoAtualiazada.Net.Models
{
    public class AlunoDAO
    {
        string connectionString = @"Server=DESKTOP-JIFS59M\SQLEXPRESS;Database=BancoAlunoNovo;Trusted_Connection=True;";
        public List<Aluno> lisAluno()
        {
            List<Aluno> lista = new List<Aluno>();
            string sql = "select * from aluno";
            SqlConnection cn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(sql, cn);
            cn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Aluno a = new Aluno();
                a.codigo = dr.GetInt32(0);
                a.nome = dr.GetString(1);
                a.nota1 = dr.GetInt32(2);
                a.nota2 = dr.GetInt32(3);
                lista.Add(a);
            }
            cn.Close();
            return lista;
        }

        public int Agregar(Aluno a)
        {
            int res = 0;
            SqlConnection cn = new SqlConnection(connectionString);
            string sql = "insert into aluno values(@nom,@nota1,@nota2)";
            SqlCommand cmd = new SqlCommand(sql, cn);
            cmd.Parameters.AddWithValue("@nom", a.nome);
            cmd.Parameters.AddWithValue("@nota1", a.nota1);
            cmd.Parameters.AddWithValue("@nota2", a.nota2);
            cn.Open();
            res = cmd.ExecuteNonQuery();
            cn.Close();
            return res;
        }

        public Aluno ObtenerPorId(int codigo)
        {
            Aluno a = null;
            string sql = "select * from aluno where codigo = @code";
            SqlConnection cn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(sql, cn);
            cmd.Parameters.AddWithValue("@code", codigo);
            cn.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                a = new Aluno();
                a.codigo = dr.GetInt32(0);
                a.nome = dr.GetString(1);
                a.nota1 = dr.GetInt32(2);
                a.nota2 = dr.GetInt32(3);
            }
            cn.Close();
            return a;
        }

        public int Modificar(Aluno a)
        {
            int res = 0;
            SqlConnection cn = new SqlConnection(connectionString);
            string sql = "update aluno set nome = @nom, nota1 = @nota1, nota2 = @nota2 where codigo = @code";
            SqlCommand cmd = new SqlCommand(sql, cn);
            cmd.Parameters.AddWithValue("@nom", a.nome);
            cmd.Parameters.AddWithValue("@nota1", a.nota1);
            cmd.Parameters.AddWithValue("@nota2", a.nota2);
            cmd.Parameters.AddWithValue("@code", a.codigo);
            cn.Open();
            res = cmd.ExecuteNonQuery();
            cn.Close();
            return res;
        }

        public int Eliminar(int codigo)
        {
            int res = 0;
            SqlConnection cn = new SqlConnection(connectionString);
            string sql = "delete from aluno where codigo = @code";
            SqlCommand cmd = new SqlCommand(sql, cn);
            cmd.Parameters.AddWithValue("@code", codigo);
            cn.Open();
            res = cmd.ExecuteNonQuery();
            cn.Close();
            return res;
        }


    }
}


