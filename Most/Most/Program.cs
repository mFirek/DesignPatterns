using System;

public interface ITelewizor
{
    int Kanal { get; set; }

    void Wlacz();
    void Wylacz();
    void ZmienKanal(int kanal);
    void GetKanal();
}


public class TvLg : ITelewizor
{
    public TvLg()
    {
        Kanal = 1;
    }

    public int Kanal { get; set; }

    public void Wlacz()
    {
        Console.WriteLine("Telewizor LG - włączam się.");
    }

    public void Wylacz()
    {
        Console.WriteLine("Telewizor LG - wyłączam się.");
    }

    public void ZmienKanal(int kanal)
    {
        Console.WriteLine($"Telewizor LG - zmieniam kanał: {kanal}");
        Kanal = kanal;
    }

    public void GetKanal()
    {
        Console.WriteLine();
        Console.WriteLine($"Sprawdź kanał - bieżący kanał: {Kanal}");
        Console.WriteLine();
    }
}


public class TvXiaomi : ITelewizor
{
    public TvXiaomi()
    {
        Kanal = 1;
    }

    public int Kanal { get; set; }

    public void Wlacz()
    {
        Console.WriteLine("Telewizor Xiaomi - włączam się.");
    }

    public void Wylacz()
    {
        Console.WriteLine("Telewizor Xiaomi - wyłączam się.");
    }

    public void ZmienKanal(int kanal)
    {
        Console.WriteLine($"Telewizor Xiaomi - zmieniam kanał: {kanal}");
        Kanal = kanal;
    }

    public void GetKanal()
    {
        Console.WriteLine();
        Console.WriteLine($"Sprawdź kanał - bieżący kanał: {Kanal}");
        Console.WriteLine();
    }
}


public abstract class PilotAbstrakcyjny
{
    private ITelewizor tv;

    public PilotAbstrakcyjny(ITelewizor tv)
    {
        this.tv = tv;
    }

    public void Wlacz()
    {
        tv.Wlacz();
    }

    public void Wylacz()
    {
        tv.Wylacz();
    }

    public void ZmienKanal(int kanal)
    {
        tv.ZmienKanal(kanal);
    }
}


public class PilotHarmony : PilotAbstrakcyjny
{
    public PilotHarmony(ITelewizor tv) : base(tv)
    {
    }

    public void DoWlacz()
    {
        Console.WriteLine("Pilot Harmony - włącz telewizor...");
        Wlacz();
    }

    public void DoWylacz()
    {
        Console.WriteLine("Pilot Harmony - wyłącz telewizor...");
        Wylacz();
    }

    public void DoZmienKanal(int kanal)
    {
        Console.WriteLine("Pilot Harmony - zmienia kanał...");
        ZmienKanal(kanal);
    }
}

public class PilotLg : PilotAbstrakcyjny
{
    public PilotLg(ITelewizor tv) : base(tv)
    {
    }

    public void DoWlacz()
    {
        Console.WriteLine("Pilot LG - włącz telewizor...");
        Wlacz();
    }

    public void DoWylacz()
    {
        Console.WriteLine("Pilot LG - wyłącz telewizor...");
        Wylacz();
    }

    public void DoZmienKanal(int kanal)
    {
        Console.WriteLine("Pilot LG - zmienia kanał...");
        ZmienKanal(kanal);
    }
}


class MainClass
{
    public static void Main(string[] args)
    {
        ITelewizor tv = new TvLg();
        PilotHarmony pilotHarmony = new PilotHarmony(tv);
        PilotLg pilotLg = new PilotLg(tv);

        pilotHarmony.DoWlacz();
        tv.GetKanal();
        pilotLg.DoZmienKanal(100);
        tv.GetKanal();
        pilotHarmony.DoWylacz();
    }
}