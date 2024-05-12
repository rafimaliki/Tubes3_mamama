namespace AvaloniaApplication3.Struct;

public struct SidikJari
{
    public string berkas_citra { get; }
    public string nama { get; }
    
    public SidikJari(string berkas_citra, string nama)
    {
        this.berkas_citra = berkas_citra;
        this.nama = nama;
    }
}