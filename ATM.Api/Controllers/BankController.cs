using ATM.Application.DTOs;
using ATM.Application.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ATM.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize] 
    public class BankController : ControllerBase
    {
        private readonly IBankService _bankService;

        public BankController(IBankService bankService)
        {
            _bankService = bankService;
        }

        /// <summary>
        /// Realiza un ingreso de dinero en la cuenta.
        /// </summary>
        [HttpPost("deposit")]

        public async Task<IActionResult> Deposit([FromBody] TransactionRequestDTO request)
        {
            try
            {
                var result = await _bankService.DepositAsync(request);
                return Ok(result);
            }
            catch (Exception ex) when (ex is ArgumentException || ex is InvalidOperationException)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (InvalidOperationException ex)
            {
                return StatusCode(500, "Ocurrió un error técnico inesperado.");
            }
        }

        /// <summary>
        /// Realiza una retirada de dinero de la cuenta.
        /// </summary>
        [HttpPost("withdraw")]
      
        public async Task<IActionResult> Withdraw( TransactionRequestDTO request)
        {
            try
            {
                var result = await _bankService.WithdrawAsync(request);
                return Ok(result);
            }
            catch (Exception ex) when (ex is ArgumentException || ex is InvalidOperationException)
            {
                return BadRequest(new { message = ex.Message }); 
            }
            catch (Exception)
            {
                return StatusCode(500, "Ocurrió un error técnico inesperado.");
            }
        }
    }
}
