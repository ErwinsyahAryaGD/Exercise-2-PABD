using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;


namespace Exercise_2_PABD
{
    class Program
    {
        static void Main(string[] args)
        {
            new Program().CreateTable();
        }

        public void CreateTable()
        {
            SqlConnection con = null;
            try
            {
                con = new SqlConnection("data source=ERWINSYAH;database=ProdiTI;Integrated Security = TRUE");
                con.Open();

                SqlCommand cm = new SqlCommand("create table Pemilik(ID_pemilik char(4) primary key,Nama_pemilik varchar(30),Alamat varchar(50),No_Telp char(12) CONSTRAINT chk_phone CHECK (No_Telp like '[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]')", con);
                cm.ExecuteNonQuery();
                SqlCommand cn = new SqlCommand("Create table Penyewa(ID_penyewa char(3) primary key,Nama varchar(30),Alamat varchar(50),No_Telp char(12) CONSTRAINT chp_phone CHECK (No_Telp like '[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]')", con);
                cm.ExecuteNonQuery();
                SqlCommand co = new SqlCommand("Create table Transaksi (ID_transaksi char(4) primary key,Harga_perbulan char(30),Harga_pertahun char(30),waktu_lama_sewa varchar(20),Total_Harga char(30),Alamat varchar(50),Tanggal_Transaksi date);", con);
                cm.ExecuteNonQuery();
                SqlCommand cp = new SqlCommand("Create table penyewa_transaksi(ID_penyewa_transaksi char(5) not null,ID_penyewa char(3) not null foreign key references penyewa(ID_penyewa),ID_transaksi char (4)not null foreign key references transaksi(ID_transaksi))", con);
                cm.ExecuteNonQuery();
                SqlCommand cq = new SqlCommand("create table pemiliki_penyewa(ID_pemiliki_penyewa char(5) not null,ID_pemilik char(4) not null foreign key references pemilik(ID_pemilik),ID_penyewa char(3) not null foreign key references penyewa(ID_penyewa));", con);
                cm.ExecuteNonQuery();

                Console.WriteLine("Semua Tabel sukses dibuat!");
                Console.ReadKey();
            }
            catch (Exception e)
            {
                Console.WriteLine("Oops, sepertinya ada yang salah. " + e);
                Console.ReadKey();
            }
            finally
            {
                con.Close();
            }



        }
    }
}