using System;
using Avalonia.Media.Imaging;

namespace AvaloniaApplication3.Utils;

public class People
{
    private string _nik;
    private string _nama;
    private string _tempat_lahir;
    private string _tanggal_lahir;
    private string _jenis_kelamin;
    private string _gologan_darah;
    private string _alamat;
    private string _agama;
    private string _status_perkawinan;
    private string _pekerjaan;
    private string _kewarganegaraan;
    
    public People(string nik, string nama, string tempat_lahir, string tanggal_lahir, string jenis_kelamin, string golongan_darah, string alamat, string agama, string status_perkawinan, string pekerjaan, string kewarganegaraan)
    {
        _nik = nik;
        _nama = nama;
        _tempat_lahir = tempat_lahir;
        _tanggal_lahir = tanggal_lahir;
        _jenis_kelamin = jenis_kelamin;
        _gologan_darah = golongan_darah;
        _alamat = alamat;
        _agama = agama;
        _status_perkawinan = status_perkawinan;
        _pekerjaan = pekerjaan;
        _kewarganegaraan = kewarganegaraan;
    }
    
    public string Nama
    {
        get => _nama;
        set => _nama = value;
    }
    
    public string TempatLahir
    {
        get => _tempat_lahir;
        set => _tempat_lahir = value;
    }
    
    public string TanggalLahir
    {
        get => _tanggal_lahir;
        set => _tanggal_lahir = value;
    }
    
    public string JenisKelamin
    {
        get => _jenis_kelamin;
        set => _jenis_kelamin = value;
    }
    
    public string GolonganDarah
    {
        get => _gologan_darah;
        set => _gologan_darah = value;
    }
    
    public string Alamat
    {
        get => _alamat;
        set => _alamat = value;
    }
    
    public string Agama
    {
        get => _agama;
        set => _agama = value;
    }
    
    public string StatusPerkawinan
    {
        get => _status_perkawinan;
        set => _status_perkawinan = value;
    }
    
    public string Pekerjaan
    {
        get => _pekerjaan;
        set => _pekerjaan = value;
    }
    
    public string Kewarganegaraan
    {
        get => _kewarganegaraan;
        set => _kewarganegaraan = value;
    }
    
    public string Nik => _nik;
    
    public override string ToString()
    {
        return $"NIK: {_nik}\n" +
                $"Nama: {Nama}\n" +
               $"Tempat Lahir: {TempatLahir}\n" +
               $"Tanggal Lahir: {TanggalLahir}\n" +
               $"Jenis Kelamin: {JenisKelamin}\n" +
               $"Golongan Darah: {GolonganDarah}\n" +
               $"Alamat: {Alamat}\n" +
               $"Agama: {Agama}\n" +
               $"Status Perkawinan: {StatusPerkawinan}\n" +
               $"Pekerjaan: {Pekerjaan}\n" +
               $"Kewarganegaraan: {Kewarganegaraan}";
    }
    
    public void print ()
    {
        Console.WriteLine("NIK :" + _nik);
        Console.WriteLine("Nama :" + _nama);
        Console.WriteLine("Tempat Lahir :" + _tempat_lahir);
        Console.WriteLine("Tanggal Lahir :" + _tanggal_lahir);
        Console.WriteLine("Jenis Kelamin :" + _jenis_kelamin);
        Console.WriteLine("Golongan Darah :" + _gologan_darah);
        Console.WriteLine("Alamat :" + _alamat);
        Console.WriteLine("Agama :" + _agama);
        Console.WriteLine("Status Perkawinan :" + _status_perkawinan);
        Console.WriteLine("Pekerjaan :" + _pekerjaan);
        Console.WriteLine("Kewarganegaraan :" + _kewarganegaraan);
    }
}