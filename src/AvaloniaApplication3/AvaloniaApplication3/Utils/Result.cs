using System;
using Avalonia.Media.Imaging;
namespace AvaloniaApplication3.Utils;

public class Result
{
    public static People _people = new People(
        nik: "1234567890",
        nama: "John Doe", tempat_lahir: "Jakarta", tanggal_lahir: "1 Januari 2000",
        jenis_kelamin: "Laki-laki", golongan_darah: "A", alamat: "Jalan Jalan",
        agama: "Islam", status_perkawinan: "Belum Kawin", pekerjaan: "PNS",
        kewarganegaraan: "Indonesia");

    public static Bitmap _image;
    
    public static TimeSpan timeDiff;
    
    public static int percentage;
    public Bitmap Image { get; set; }
    public string Text { get; set; }
    public People People { get; set; }

    public static bool foundByAlgorithm = false;
    
    public Result(Bitmap image, string text, People people)
    {
        Image = image;
        Text = text;
        People = people;
    }
    
    public Result(Bitmap image, string text)
    {
        Image = image;
        Text = text;
    }
    
    public Result(string text)
    {
        Text = text;
    }
    
    public static void createNewPeople(People people)
    {
        _people = people;
    }

    public static void setName(String nama)
    {
        _people.Nama = nama;
    }
    
    public static void setPercentage(int percentage)
    {
        Result.percentage = percentage;
    }

    public static void print()
    {
        Console.WriteLine("Nama: " + _people.Nama);
        Console.WriteLine("Tempat Lahir: " + _people.TempatLahir);
        Console.WriteLine("Tanggal Lahir: " + _people.TanggalLahir);
    }
}