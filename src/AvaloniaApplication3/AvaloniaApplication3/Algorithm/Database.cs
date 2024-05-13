using AvaloniaApplication3.Utils;

namespace AvaloniaApplication3.Algorithm;

using System;
using System.Collections.Generic;
using static AvaloniaApplication3.Algorithm.MyRegex;

using MySqlConnector;

using AvaloniaApplication3.Struct;

public class Database
{
    public static List<People> BIODATA = new List<People>();
    public static List<SidikJari> SIDIK_JARI = new List<SidikJari>();
    
    public static void Load()
    {
        string connStr = "Server=localhost;Database=tubes3alay;User=root;Password=password";
        using var cn = new MySqlConnection(connStr);
        cn.Open();

        LoadBiodata(cn);
        LoadSidikJari(cn);
    }

    private static void LoadBiodata(MySqlConnection cn)
    {   
        Console.WriteLine("Loading Biodata...");
        BIODATA.Clear();
        
        string query = "SELECT * FROM biodata";
        using var cmd = new MySqlCommand(query, cn);
        using var reader = cmd.ExecuteReader();
        
        while (reader.Read())
        {   
            People biodata = new People(reader["NIK"].ToString(), reader["nama"].ToString(), reader["tempat_lahir"].ToString(), reader["tanggal_lahir"].ToString(), reader["jenis_kelamin"].ToString(), reader["golongan_darah"].ToString(), reader["alamat"].ToString(), reader["agama"].ToString(), reader["status_perkawinan"].ToString(), reader["pekerjaan"].ToString(), reader["kewarganegaraan"].ToString());
            BIODATA.Add(biodata);
            
            // Console.WriteLine("\nNo: " + BIODATA.Count);
            // biodata.Print();
        }
        
        Console.WriteLine("Biodata loaded! (" + BIODATA.Count + ")");
    }
    
    private static void LoadSidikJari(MySqlConnection cn)
    {   
        Console.WriteLine("Loading SidikJari...");
        SIDIK_JARI.Clear();
        
        string query = "SELECT * FROM sidik_jari";
        using var cmd = new MySqlCommand(query, cn);
        using var reader = cmd.ExecuteReader();
        
        while (reader.Read())
        {   
            SidikJari sidikJari = new SidikJari(reader["berkas_citra"].ToString(), reader["nama"].ToString());
            SIDIK_JARI.Add(sidikJari);

            // String newNama = sidikJari.nama + "jjjj";
            //
            // if (MyRegex.match(sidikJari.nama,newNama))
            // {
            //     Console.WriteLine("Match!");
            // }
            // else
            // {
            //     Console.WriteLine("Not Match!");
            // }
            
            // Console.WriteLine("\nNo: " + SIDIK_JARI.Count);
            // Console.WriteLine("Nama: " + sidikJari.nama);
        }
        Console.WriteLine("SidikJari loaded! (" + SIDIK_JARI.Count + ")");
        // Console.WriteLine("Citra1: " + SIDIK_JARI[0].berkas_citra);
        // Console.WriteLine("Citra6000: " + SIDIK_JARI[5999].berkas_citra);
    }
}