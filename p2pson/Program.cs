using System;
using System.Threading;

namespace p2pson
{
    class Program
    {
        static void Main(string[] args)
        {
            Kutuphane kh = new Kutuphane();
            double lot = 0;
            double fiyat = 0;
            int nonce = 0;
            int dongu = 100;
            for (int i = 1; i <= dongu; i++)
            {
                if (i % 2 == 1)
                {
                    try
                    {
                        nonce += 1;
                        fiyat = kh.IslemHesaplaFiyat(0.0005);
                        lot = kh.IslemHesaplaLot();
                        string bodyAl = kh.Body("buy", lot, fiyat, nonce);
                        if (fiyat == 0)
                            Console.WriteLine("Aralık daraldı");
                        else
                            kh.IslemAc(bodyAl);
                    }
                    catch
                    {
                        Console.WriteLine("1. Hata Oluştu...");
                    }
                }
                if (i % 2 == 0)
                {
                    try
                    {
                        nonce += 1;
                        string bodySat = kh.Body("sell", lot, fiyat, nonce);
                        if (fiyat == 0)
                            Console.WriteLine("Aralık daraldı");
                        else
                            kh.IslemAc(bodySat);

                        Console.WriteLine();
                        var rand = new Random();
                        Thread.Sleep(rand.Next(60, 100) * 1000);
                    }
                    catch
                    {
                        Console.WriteLine("2. Hata Oluştu...");
                    }
                }
                if (i == dongu)
                {
                    Console.WriteLine("İşlem tamamlandı.");
                    nonce = 0;
                    i = 0;
                }
            }
        }
    }
}