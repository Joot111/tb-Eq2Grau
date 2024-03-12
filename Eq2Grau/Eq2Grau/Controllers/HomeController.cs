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
             *    2.1- têm de ser números
             *    2.2- A != 0
             * 3- se posso calcular,
             *    3.1- determinar as raízes
             *         x=(-b +/- sqrt(b^2-4ac))/2/a
             *         3.1.1- calcular o delta: b^2-4ac
             *         3.1.2- se delta > 0, há 2 raízes reais distintas
             *                              x1 e x2
             *                se delta = 0, há 2 raízes reais iguais
             *                              x1=x2
             *                se delta < 0, há duas raízes complexas conjugadas
             *                              x1 = -b/(2a) + sqrt(-delta)/(2a) i
             *                              x2 = -b/(2a) - sqrt(-delta)/(2a) i
             *   3.2- enviar a resposta para o cliente
             * se não posso calcular (else)
             *    enviar mensagem de erro para o cliente (browser)
             */

            // vars. auxiliares
            double auxA = 0, auxB = 0, auxC = 0;
            // A ViewBag apenas pode ser escrita do Controller para o Index nunca ao contrário
            ViewBag.Mensagem = "Os parâmetros A, B e C são de preenchimento obrigatórios.";

            // 1.
            if (string.IsNullOrWhiteSpace(A) || string.IsNullOrWhiteSpace(B) || string.IsNullOrWhiteSpace(C))
            {
                // enviar mensagem para o utilizador


                // devolver controlo à View
                return View();
            }

            // 1.
            if (!double.TryParse(A, out auxA))
            {
                // o A não é número.
                // enviar mensagem para o utilizador

                ViewBag.Mensagem = "O parâmetro A não é um número.";
                // devolver controlo à View
                return View();
            }

            // 1.
            if (!double.TryParse(B, out auxB))
            {
                // o B não é número.
                // enviar mensagem para o utilizador
                ViewBag.Mensagem = "O parâmetro B não é um número.";

                // devolver controlo à View
                return View();
            }

            // 1.
            if (!double.TryParse(C, out auxC))
            {
                // o C não é número.
                // enviar mensagem para o utilizador
                ViewBag.Mensagem = "O parâmetro C não é um número.";

                // devolver controlo à View
                return View();
            }


            // 2.
            if (auxA == 0)
            {
                // o A é ZERO.
                // enviar mensagem para o utilizador
                ViewBag.Mensagem = "O parâmetro A não pode ser (zero).";

                // devolver controlo à View
                return View();
            }


            // 3.
            double delta = Math.Pow(auxB, 2) - 4 * auxC;
            // 3.1
            if (delta > 0)
            {
                string x1 = Math.Round((-auxB + Math.Sqrt(delta)) / 2 / auxA, 2) + "";
                string x2 = Math.Round((-auxB - Math.Sqrt(delta)) / 2 / auxA, 2) + "";
                // enviar mensagem para o utilizador
                ViewBag.Mensagem = "A equação tem duas raízes reias distintas.";
                ViewBag.x1 = x1;
                ViewBag.x2 = x1;

                // devolver controlo à View
                return View();
            }

            if (delta == 0)
            {
                string x = Math.Round(-auxB / 2 / auxA, 2) + "";

                // enviar mensagem para o utilizador
                ViewBag.Mensagem = "A equação tem duas raízes reias iguais.";
                ViewBag.x1 = x;
                ViewBag.x2 = x;

                // devolver controlo à View
                return View();
            }

            if (delta < 0)
            {
                string x1 = Math.Round((-auxB) / 2 / auxA, 2) + " + " + Math.Round(Math.Sqrt(-delta) / 2 / auxA, 2) + " i";
                string x2 = Math.Round((-auxB) / 2 / auxA, 2) + " - " + Math.Round(Math.Sqrt(-delta) / 2 / auxA, 2) + " i";
                // enviar mensagem para o utilizador
                ViewBag.Mensagem = "A equação tem duas raízes complexas distintas.";
                ViewBag.x1 = x1;
                ViewBag.x2 = x1;

                // devolver controlo à View
                return View();
            }

            // se chegar aqui, alguma coisa correu muito mal...
            // devolver controlo à View
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
