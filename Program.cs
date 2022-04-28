4using System;

namespace CalculatorConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Aplikasi Calculator";

            int choice = 0;
            double a = 0;
            double b = 0;

            while (true)
            {
                choice = Menu();
                Console.WriteLine();
                // cek error -> input harus merupakan angka
                try
                {
                    Console.Write("Inputkan nilai a = ");
                    a = Convert.ToDouble(Console.ReadLine());
                    Console.Write("Inputkan nilai b = ");
                    b = Convert.ToDouble(Console.ReadLine());
                    break;
                }
                catch (Exception)
                {
                    Console.WriteLine();
                    Console.Write("Masukkan bilangan bulat atau pecahan. Tekan sembarang key untuk mengulang...");
                    Console.ReadLine();
                }
            }

            Console.WriteLine();
            // pengoperasian bilangan berdasarkan pilihan
            switch (choice)
            {
                case 1:
                    Console.WriteLine("Hasil Penambahan {0} + {1} = {2}",
                    FormatBracket(a), FormatBracket(b), Penambahan(a, b));
                    break;
                case 2:
                    Console.WriteLine("Hasil Pengurangan {0} - {1} = {2}",
                    FormatBracket(a), FormatBracket(b), Pengurangan(a, b));
                    break;
                case 3:
                    Console.WriteLine("Hasil Perkalian {0} x {1} = {2}",
                    FormatBracket(a), FormatBracket(b), Perkalian(a, b));
                    break;
                case 4:
                    Console.WriteLine("Hasil Pembagian {0} / {1} = {2}",
                    FormatBracket(a), FormatBracket(b), Pembagian(a, b));
                    break;
            }

            Console.WriteLine();
            Console.Write("Tekan sembarang key untuk keluar...");
            Console.ReadLine();
        }

        // fungsi pilihan menu
        static int Menu()
        {
            int choice = 0;
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Pilih menu calculator:\n");
                Console.WriteLine("1. Penambahan\n2. Pengurangan\n3. Perkalian\n4. Pembagian\n");
                Console.Write("Input nomor menu [1..4]: ");
                // cek error -> input harus merupakan angka
                try
                {
                    choice = Convert.ToInt16(Console.ReadLine());
                    // custom exeption -> angka harus dalam interval 1 <= x <= 4
                    if (choice < 1 || choice > 4)
                        throw new ArithmeticException();
                    else
                        break;
                }
                catch (Exception)
                {
                    Console.WriteLine();
                    Console.Write("Pilihan tidak ada. Tekan sembarang key untuk mengulang...");
                    Console.ReadLine();
                }
            }
            return choice;
        }

        // fungsi operasi
        static double Penambahan(double a, double b)
        {
            return a + b;
        }
        static double Pengurangan(double a, double b)
        {
            return a - b;
        }
        static double Perkalian(double a, double b)
        {
            return a * b;
        }
        static double Pembagian(double a, double b)
        {
            return a / b;
        }

        // fungsi untuk menambahkan tanda kurung apabila nilai operand negatif
        static string FormatBracket(double x)
        {
            string y = Convert.ToString(x);
            return x < 0 ? ('(' + y + ')') : y;
        }
    }
}
