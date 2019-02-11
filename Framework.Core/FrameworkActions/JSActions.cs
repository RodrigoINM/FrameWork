using Framework.Core.Interfaces;
using OpenQA.Selenium;

namespace Framework.Core.FrameworkActions
{
    public static class JsActions
    {
		/// <summary>
		/// Executa o script fornecido na página atual.
		/// </summary>
		/// <param name="browser"></param>
		/// <param name="script"></param>
		public static void JavaScript<T>(T browser, string script) where T : IBrowser
		{
			IJavaScriptExecutor js = (IJavaScriptExecutor)browser.ObterDriver();
			string title = (string)js.ExecuteScript(script);
		}
	}
}
