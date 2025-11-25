using System;

internal class Program
{
    static async Task Main()
    {
        HolidayService service = new HolidayService();

        Console.WriteLine("Veriler yükleniyor...");
        await service.LoadData();
        Console.WriteLine("Hazır!\n");

        while (true)
        {
            Console.WriteLine("===== PublicHolidayTracker =====");
            Console.WriteLine("1. Tatil listesini göster (yıl seçmeli)");
            Console.WriteLine("2. Tarihe göre tatil ara (gg-aa)");
           Console.WriteLine("3. İsme göre tatil ara");
            Console.WriteLine("4. Tüm tatilleri 3 yıl boyunca göster");
            Console.WriteLine("5. Çıkış");
            Console.Write("Seçiminiz: ");

            string secim = Console.ReadLine();

            if (secim == "1")
            {
                Console.Write("Yıl gir: ");
                int year = int.Parse(Console.ReadLine());
                var list = service.GetByYear(year);
                foreach (var h in list)
                    Console.WriteLine($"{h.date} - {h.localName}");
                Console.WriteLine();
            }
            else if (secim == "2")
            {
                Console.Write("Tarih (gg-aa): ");
                string d = Console.ReadLine();
                var list = service.SearchByDate(d);
                foreach (var h in list)
                    Console.WriteLine($"{h.date} - {h.localName}");
                Console.WriteLine();
            }
            else if (secim == "3")
            {
                Console.Write("İsim: ");
                string n = Console.ReadLine();
                var list = service.SearchByName(n);
                foreach (var h in list)
                    Console.WriteLine($"{h.date} - {h.localName}");
                Console.WriteLine();
            }
            else if (secim == "4")
            {
                var list = service.GetAll();
                foreach (var h in list)
                    Console.WriteLine($"{h.date} - {h.localName}");
                Console.WriteLine();
            }
            else if (secim == "5")
            {
                break;
            }
        }
    }
}
