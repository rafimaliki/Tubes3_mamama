using AvaloniaApplication3.Utils;

namespace AvaloniaApplication3.Utils;

using System;
using System.Collections.Generic;
using static AvaloniaApplication3.Algorithm.MyRegex;

using MySqlConnector;

using AvaloniaApplication3.Struct;
using Avalonia.Controls;

public class Database
{
    public static List<People> BIODATA = new List<People>();
    public static List<SidikJari> SIDIK_JARI = new List<SidikJari>();
    
    public static void Load()
    {   
        string password = "";
 
        if (Environment.GetEnvironmentVariable("DB_PASSWORD") != null)
        {
            password = Environment.GetEnvironmentVariable("DB_PASSWORD");
        }
        string connStr = $"Server=localhost;Database=tubes3;User=root;Password={password}";
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
            SidikJari sidikJari = new SidikJari(ImageConverter.ImgPathToString(reader["berkas_citra"].ToString()), reader["nama"].ToString());
            SIDIK_JARI.Add(sidikJari);
        }
        Console.WriteLine("SidikJari loaded! (" + SIDIK_JARI.Count + ")");
    }
}