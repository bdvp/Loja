namespace Loja.Service.Api.Cliente.Controllers
{
    using Loja.Application.Contracts.AppServices;
    using Loja.Application.Contracts.Requests;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    public class ClienteController : ApiController
    {
        private readonly IClienteAppService _clienteAppService;

        public ClienteController(IClienteAppService clienteAppService)
        {
            _clienteAppService = clienteAppService;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Post([FromBody]ClienteCreateRequest request)
        {
            return Response(await _clienteAppService.Create(request).ConfigureAwait(false));
        }

        [HttpPut]
        [AllowAnonymous]
        public async Task<IActionResult> Put([FromBody] ClienteUpdateRequest request)
        {
            return Response(await _clienteAppService.Update(request).ConfigureAwait(false));
        }

        [HttpDelete("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> Delete(int id)
        {
            return Response(await _clienteAppService.Delete(id).ConfigureAwait(false));
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetAll(int pageSize, int pageIndex)
        {
            return Response(await _clienteAppService.GetAll(pageSize, pageIndex).ConfigureAwait(false));
        }

        [HttpGet("{cpf}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetByCpf(string cpf)
        {
            return Response(await _clienteAppService.Get(cpf).ConfigureAwait(false));
        }
    }
}
