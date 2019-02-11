using System;

namespace Framework.Core.Helpers
{
	public static class CalendarioHelper
	{
		public static string ObterDataAtual()
		{
			return DateTime.Now.ToShortDateString();
		}

		public static string ObterDiaAtual()
		{
			return DateTime.Now.ToShortDateString().Remove(2, 8);
		}

		public static string ObterDataFutura(double data)
		{
			return DateTime.Now.AddDays(data).ToShortDateString();
		}

		public static string ObterDiaFuturo(double dia)
		{
			string Date = DateTime.Now.AddDays(dia).ToShortDateString().Remove(2, 8);
			return Date;
		}

		public static string ObterMesFuturo(int mes)
        {
            return DateTime.Now.AddMonths(mes).ToShortDateString();
        }

        public static string ObterSemanasFuturas(double dias)
        {
            return DateTime.Now.AddDays(dias).ToShortDateString();
        }

        public static string ObterDiaMesFuturoComBarra(int dia)
        {
            string Day = DateTime.Now.AddDays(dia).ToShortDateString().Remove(5, 5);
            return Day;
        }

        public static string ObterDiaMesAnoFuturoComBarra(int dia)
        {
            string Day = DateTime.Now.AddDays(dia).ToShortDateString();
            return Day;
        }
    }
}
