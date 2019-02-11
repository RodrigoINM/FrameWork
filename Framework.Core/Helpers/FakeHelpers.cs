using System;
using System.Drawing;
using static System.Net.Mime.MediaTypeNames;

namespace Framework.Core.Helpers
{
    public static class FakeHelpers
    {

            // Faker CPF
            public static string GerarCpf()
            {
                int soma = 0, resto = 0;
                int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
                int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

                Random rnd = new Random();
                string semente = rnd.Next(100000000, 999999999).ToString();

                for (int i = 0; i < 9; i++)
                    soma += int.Parse(semente[i].ToString()) * multiplicador1[i];

                resto = soma % 11;
                if (resto < 2)
                    resto = 0;
                else
                    resto = 11 - resto;

                semente = semente + resto;
                soma = 0;

                for (int i = 0; i < 10; i++)
                    soma += int.Parse(semente[i].ToString()) * multiplicador2[i];

                resto = soma % 11;

                if (resto < 2)
                    resto = 0;
                else
                    resto = 11 - resto;

                semente = semente + resto;
                return semente;
            }


            // Faker Name
            public static string FirstName()
             {
                var first = Faker.Name.FirstName();
                return first;
             }

            public static string LastName()
            {
                var last = Faker.Name.LastName();
                return last;
            }

            public static string FullName()
            {
                var full = Faker.Name.FullName();
                return full;
            }

            
            // Faker Number
            public static int RandomNumber(int qtd)
            {
                var randomNumber = Faker.Number.RandomNumber(qtd);
				return randomNumber;
            }

        public static string RandomNumberStr()
        {
            var randomNumber = Faker.Number.RandomNumber();
            var randomNumberStr = randomNumber.ToString();
            return randomNumberStr;
        }
    }
}
