using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Security;
using System.Net.Sockets;
using System.IO;
/*
namespace ServerLibrary
{
    /// <summary>
    /// Klasa MyTcpServer posiadająca metodę inicjalizującą działanie serwera
    /// </summary>
    
    public class MyServer
    {
        /// <summary>
        ///  Metoda inicjalizująca i obslugująca działanie serwera
        /// </summary>
        /// <remarks>
        ///  Metoda zawiera pętle, która pobiera tekst od klienta, edytuje go i zwraca edytowany tekst
        /// </remarks>
        public static void Server()
        {

            /// Tworzenie serwera na porcie 2048
            int port = 2048;
            IPAddress adres = IPAddress.Parse("127.0.0.1");
            TcpListener server = new TcpListener(adres, port);

            /// Rozpoczęcie nasłuchiwania
            server.Start();

            /// Akceptacja oczekującego żądania połączenia od klienta
            Console.Write("Oczekiwanie na polaczenie... \n");
            TcpClient client = server.AcceptTcpClient();
            NetworkStream stream = client.GetStream();
            Console.WriteLine("Polaczono! \n");


            /// Definiowanie kontenera danych typu array do przechowywania wpisanych przez klienta danych
            Byte[] bytes = new Byte[2048];

            /// Komunikat dla klienta
            Byte[] sendBytes = Encoding.UTF8.GetBytes("Wpisz tekst, ktory serwer ma edytowac:\n");
            stream.Write(sendBytes, 0, sendBytes.Length);

            ///<summary>
            /// Definiowanie pętli do nasłuchiwania i pobierania danych od klienta  do kontenera(tablicy)
            ///</summary>

            while (true)
            {
                /// Pobieranie tekstu od klienta i zapisywanie ciągu znaków do tablicy
                int dlugosc = stream.Read(bytes, 0, 2048);

                /// Konwertowanie tablicy na string
                string text = System.Text.Encoding.UTF8.GetString(bytes, 0, dlugosc);

                /// <summary>
                /// Zamiana wielkich liter na małe i małych na wielkie w podanym w kliencie stringu
                /// </summary>
                /// <example>
                /// Input: Ala Ma koTA KOT ma ALE
                /// Output: aLA mA KOta kot MA ale
                /// </example>
                var converted = text.Select(x => char.IsUpper(x) ? char.ToLower(x) : char.ToUpper(x));
                var result = new string(converted.ToArray());
                for (int i = 0; i < text.Length; i++)
                {
                    if (char.IsUpper(text[i]))
                    {
                        result += char.ToLower(text[i]);
                    }
                    else result += char.ToUpper(text[i]);
                }

                /// Konwersja string na array i wyświetlanie tekstu
                byte[] buffer = System.Text.Encoding.UTF8.GetBytes(result);
                stream.Write(buffer, 0, buffer.Length);
            }

        }
    }
}
*/