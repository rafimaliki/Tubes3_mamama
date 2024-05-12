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
    
    public void createNewPeople(string nik, string nama, string tempat_lahir, string tanggal_lahir, string jenis_kelamin, string golongan_darah, string alamat, string agama, string status_perkawinan, string pekerjaan, string kewarganegaraan)
    {
        People = new People(nik, nama, tempat_lahir, tanggal_lahir, jenis_kelamin, golongan_darah, alamat, agama, status_perkawinan, pekerjaan, kewarganegaraan);
    }
}