using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using OnlineShopping.Models.Sınıflar;
using Sharpchain.Model;

namespace Sharpchain
{
    class Program : Faturalar
    {
        private static object sırala;


        static void Main(string[] args)
        {

            Faturalar faturalars = new Faturalar();
            faturalars.faturaID = Convert.ToInt32(sırala);
            Console.Title = "# BlokChain Amca #";

            const int difficulty = 1;
            List<IBlock> MinedBlock = new List<IBlock>();

            SqlCommand com = new SqlCommand();
            SqlDataReader dataReader;
            SqlConnection con = new SqlConnection("data source=LAPTOP-7M06I3FK\\SQLEXPRESS;initial catalog=dbTicarii;integrated security=True;");
            int[] array = new int[4];
            
            con.Open();
            com.Connection = con;
            int k = 0;
            com.CommandText = "SELECT faturaID FROM Faturalars";
            dataReader = com.ExecuteReader();
            while (dataReader.Read())
            {

                faturalars.faturaID = Convert.ToInt32(dataReader["faturaID"]);
                array[k] = faturalars.faturaID;
                k++;

            }
            con.Close();

            var blockchain = new Blockchain.Blockchain(difficulty);

            for (int i = 0; i <= faturalars.faturaID; i++)
            {
                
                try
                {


                   
                    IBlock minedBlock = blockchain.Mine($" {array[i]}");
                    MinedBlock.Add(minedBlock);
                    
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                
            }

            //MinedBlock[2].Data = "20";
            foreach (IBlock block in blockchain)
            {
                

                Console.WriteLine("Time : " + block.TimeStamp.ToString() + "\n" + "Index : " + block.Index + "\n" + "Nonce : " + block.Nonce + "\n" + "Data : " + block.Data + "\n" + "Hash : " + block.Hash + "\n" + "Previous Hash : " + block.PrevHash + "\n");
                
            }
            for (int i=0;i<MinedBlock.Count-1;i++)
            {
                //int a = 2;
                Console.WriteLine(Blockchain.BlockchainExtension.IsValidNextBlock(MinedBlock[i],MinedBlock[i+1],difficulty));
            }

            Console.Read();
        }
    }
}