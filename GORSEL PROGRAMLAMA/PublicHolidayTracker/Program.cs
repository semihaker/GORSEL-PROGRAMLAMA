﻿using System;

HolidayService service = new HolidayService();

Console.WriteLine("Veriler yükleniyor...");
await service.LoadData();
Console.WriteLine("Hazır!\n");

while (true)
{
    Console.WriteLine("===== PublicHolidayTracker =====");
    Console.WriteLine("1. Tatil listesini göster (yıl seçmeli)");
    Console.WriteLine("2. Tarihe göre tatil ara (gg-aa formatı)");
    Console.WriteLine("3. İsme göre tatil ara");
    Console.WriteLine("4. Tüm tatilleri 3 yıl boyunca göster (2023–2025)");
    Console.WriteLine("5. Çıkış");
    Console.Write("Seçiminiz: ");

    string? secim = Console.ReadLine();
    Console.WriteLine();

    if (secim == "1")
    {
        Console.Write("Yıl gir (2023–2025): ");
        string? yearText = Console.ReadLine();
        if (!int.TryParse(yearText, out int year))
        {
            Console.WriteLine("Yıl sayısal olmalı (örn: 2024).\n");
            continue;
        }

        var list = service.GetByYear(year);

        Console.WriteLine($"\n{year} yılı resmi tatilleri:\n");
        foreach (var h in list)
        {
            Console.WriteLine($"{h.date} - {h.localName} ({h.name})");
        }
        Console.WriteLine();
    }
    else if (secim == "2")
    {
        Console.Write("Tarih (gg-aa): ");
        string dayMonth = Console.ReadLine() ?? "";

        Console.Write("Yıl (2023–2025, boş bırak = tüm yıllarda ara): ");
        string? yearInput = Console.ReadLine();

        int? year = null;
        if (!string.IsNullOrWhiteSpace(yearInput))
        {
            if (int.TryParse(yearInput, out int parsedYear))
            {
                year = parsedYear;
            }
            else
            {
                Console.WriteLine("Yıl formatı hatalı, tüm yıllarda arama yapılacak.\n");
            }
        }

        var list = service.SearchByDate(dayMonth, year);

        Console.WriteLine("\nArama sonucu (tarihe göre):\n");
        foreach (var h in list)
        {
            Console.WriteLine($"{h.date} - {h.localName} ({h.name})");
        }
        Console.WriteLine();
    }
    else if (secim == "3")
    {
        Console.Write("Tatilde geçen isim (örn: ramazan, bayram): ");
        string name = Console.ReadLine() ?? "";

        var list = service.SearchByName(name);

        Console.WriteLine("\nArama sonucu (isme göre):\n");
        foreach (var h in list)
        {
            Console.WriteLine($"{h.date} - {h.localName} ({h.name})");
        }
        Console.WriteLine();
    }
    else if (secim == "4")
    {
        var list = service.GetAll();

        Console.WriteLine("2023–2025 tüm resmi tatiller:\n");
        foreach (var h in list)
        {
            Console.WriteLine($"{h.date} - {h.localName} ({h.name})");
        }
        Console.WriteLine();
    }
    else if (secim == "5")
    {
        break;
    }
    else
    {
        Console.WriteLine("Geçersiz seçim, tekrar deneyin.\n");
    }
}
