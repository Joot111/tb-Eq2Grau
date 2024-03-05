using Eq2Grau.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Eq2Grau.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Portal de entrada dos pedidos feitos à consola 
        /// Método para calcular as raízes de uma equação de 2º grau
        /// </summary>
        /// <param name="A">parâmetro do x^2</param>
        /// <param name="B">parâmetro do x</param>
        /// <param name="C">parâmtro independente</param>
        /// <returns></returns>

        public IActionResult Index(string A, string B, string C)
        {
            /* ALGORITMO:
             * 1- ler parâmetros A, B, C
             * 2- validar se se pode fazer operações com eles
             *  2.1- têm de ser números
             *  2.2- A != 0
             * 3- se posso calcular,
             *  3.1- determinar as raízes
             *      x1=( -b +/- (sqrt(b^2 -4ac))/(2a)
             *      3.1.1- calcular o delta: b^2-4ac
             *      3.1.2- se delta > 0, há 2 raízes reais distintas 
             *                          x1 e x2
             *             se delta = 0, há 2 raízes reais distintas 
             *                          x1 = x2
             *             se delta < 0, há 2 raízes complexas conjugadas
             *                          x1 = -b/(2a) + sqrt(-delta/(2a) i
             *                          x2 = -b/(2a) - sqrt(-delta/(2a) i
             *  3.2- enviar a resposta para o cliente
             *  se não posso calcular (else)
             *      enviar mensagens de erro para o cliente (else)
             */

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
