using System;
using Microsoft.CodeAnalysis.Scripting.Hosting;

namespace AvaloniaApplication3.Struct;

public struct Biodata
{
    public string NIK { get; }
    public string nama { get; }
    public string tempat_lahir { get; }
    public string tanggal_lahir { get; }
    public string jenis_kelamin { get; }
    public string golongan_darah { get; }
    public string alamat { get; }
    public string agama { get; }
    public string status_perkawinan { get; }
    public string pekerjaan { get; }
    public string kewarganegaraan { get; }
    
    public Biodata(string NIK, string nama, string tempat_lahir, string tanggal_lahir, string jenis_kelamin, string golongan_darah, string alamat, string agama, string status_perkawinan, string pekerjaan, string kewarganegaraan)
    {
        this.NIK = NIK;
        this.nama = nama;
        this.tempat_lahir = tempat_lahir;
        this.tanggal_lahir = tanggal_lahir;
        this.jenis_kelamin = jenis_kelamin;
        this.golongan_darah = golongan_darah;
        this.alamat = alamat;
        this.agama = agama;
        this.status_perkawinan = status_perkawinan;
        this.pekerjaan = pekerjaan;
        this.kewarganegaraan = kewarganegaraan;
    }

    public void Print()
    {
        Console.WriteLine("NIK: " + NIK);
        Console.WriteLine("Nama: " + nama);
        Console.WriteLine("Tempat Lahir: " + tempat_lahir);
        Console.WriteLine("Tanggal Lahir: " + tanggal_lahir);
        Console.WriteLine("Jenis Kelamin: " + jenis_kelamin);
        Console.WriteLine("Golongan Darah: " + golongan_darah);
        Console.WriteLine("Alamat: " + alamat);
        Console.WriteLine("Agama: " + agama);
        Console.WriteLine("Status Perkawinan: " + status_perkawinan);
        Console.WriteLine("Pekerjaan: " + pekerjaan);
        Console.WriteLine("Kewarganegaraan: " + kewarganegaraan);
    }
    
}