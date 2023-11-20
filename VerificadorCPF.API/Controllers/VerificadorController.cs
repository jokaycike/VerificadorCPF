using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace VerificadorCPF.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VerificadorController : Controller
    {
        [HttpGet]
        public DadosCPF Get(string? CPF)
        {
            DadosCPF OBJ = DadosCPF.TodaVerificacao(CPF);
            return OBJ;
        }
    }
}
