using Eq2Grau.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Drawing;

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
        /// Portal de entrada dos pedidos feitos � consola 
        /// M�todo para calcular as ra�zes de uma equa��o de 2� grau
        /// </summary>
        /// <param name="A">par�metro do x^2</param>
        /// <param name="B">par�metro do x</param>
        /// <param name="C">par�mtro independente</param>
        /// <returns></returns>

        public IActionResult Index(string A, string B, string C)
        {
            /* ALGORITMO:
             * 1- ler par�metros A, B, C
             * 2- validar se se pode fazer opera��es com eles
             *  2.1- t�m de ser n�meros
             *  2.2- A != 0
             * 3- se posso calcular,
             *  3.1- determinar as ra�zes
             *      x1=( -b +/- (sqrt(b^2 -4ac))/(2a)
             *      3.1.1- calcular o delta: b^2-4ac
             *      3.1.2- se delta > 0, h� 2 ra�zes reais distintas 
             *                          x1 e x2
             *             se delta = 0, h� 2 ra�zes reais distintas 
             *                          x1 = x2
             *             se delta < 0, h� 2 ra�zes complexas conjugadas
             *                          x1 = -b/(2a) + sqrt(-delta/(2a) i
             *                          x2 = -b/(2a) - sqrt(-delta/(2a) i
             *  3.2- enviar a resposta para o cliente
             *  se n�o posso calcular (else)
             *      enviar mensagens de erro para o cliente (else)
             */

            double a = double.Parse(A);
            double b = double.Parse(B);
            double c = double.Parse(C);

            if (double.IsNaN(a) || double.IsNaN(b) || double.IsNaN(c))
            {
                Console.WriteLine("Erro: Os valores inseridos n�o s�o n�meros v�lidos.");
                return null;
            }

            else if (a != 0)
            {
                Console.WriteLine("Erro: A equa��o n�o � de 2� Grau.");
                return null;
            }

            // Calcule o delta
            double delta = b * b - 4 * a * c;

            // Determinar as ra�zes
            double x1, x2;

            if (delta > 0)
            {
                // H� 2 ra�zes reais distintas
                x1 = (-b + Math.Sqrt(delta)) / (2 * a);
                x2 = (-b - Math.Sqrt(delta)) / (2 * a);
                return Ok($"As ra�zes s�o: x1 = {x1} e x2 = {x2}");
            }
            else if (delta == 0)
            {
                // H� 2 ra�zes reais iguais
                x1 = -b / (2 * a);
                return Ok($"A raiz �: x = {x1}");
            }
            else
            {
                // H� 2 ra�zes complexas conjugadas
                double parteReal = -b / (2 * a);
                double parteImaginaria = Math.Sqrt(-delta) / (2 * a);
                return Ok($"As ra�zes s�o: x1 = {parteReal} + {parteImaginaria}i e x2 = {parteReal} - {parteImaginaria}i");
            }

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
