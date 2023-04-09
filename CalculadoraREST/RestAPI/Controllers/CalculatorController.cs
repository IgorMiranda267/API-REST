using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace CalculadoraREST.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculatorController : ControllerBase
    { 
        private readonly ILogger<CalculatorController> _logger;

        public CalculatorController(ILogger<CalculatorController> logger)
        {
            _logger = logger;
        }

        [HttpGet("sum/{fristNumber}/{secondNumber}")]
        public IActionResult soma(string fristNumber, string secondNumber)
        {
            if (IsNumeric(fristNumber) && IsNumeric(secondNumber))
            {
                double sum = Double.Parse(fristNumber) + Double.Parse(secondNumber);
                return Ok(sum.ToString());
            }
           return BadRequest("Invalid Input");
        }

        [HttpGet("sub/{fristNumber}/{secondNumber}")]
        public IActionResult Subtracao(string fristNumber, string secondNumber)
        {
            if (IsNumeric(fristNumber) && IsNumeric(secondNumber))
            {
                double sum = Double.Parse(fristNumber) - Double.Parse(secondNumber);
                return Ok(sum.ToString());
            }
            return BadRequest("Invalid Input");
        }

        [HttpGet("mul/{fristNumber}/{secondNumber}")]
        public IActionResult Multiplicacao(string fristNumber, string secondNumber)
        {
            if (IsNumeric(fristNumber) && IsNumeric(secondNumber))
            {
                double sum = Double.Parse(fristNumber) * Double.Parse(secondNumber);
                return Ok(sum.ToString());
            }
            return BadRequest("Invalid Input");
        }

        [HttpGet("div/{fristNumber}/{secondNumber}")]
        public IActionResult Divisao(string fristNumber, string secondNumber)
        {
            if (IsNumeric(fristNumber) && IsNumeric(secondNumber))
            {
                double sum = Double.Parse(fristNumber) / Double.Parse(secondNumber);
                return Ok(sum.ToString());
            }
            return BadRequest("Invalid Input");
        }

        [HttpGet("med/{fristNumber}/{secondNumber}")]
        public IActionResult Media(string fristNumber, string secondNumber)
        {
            if (IsNumeric(fristNumber) && IsNumeric(secondNumber))
            {
                double sum = (Double.Parse(fristNumber) + Double.Parse(secondNumber)) / 2 ;
                return Ok(sum.ToString());
            }
            return BadRequest("Invalid Input");
        }

        [HttpGet("raiz/{fristNumber}")]
        public IActionResult Raiz(string fristNumber)
        {
            if (IsNumeric(fristNumber))
            {
                double sum = Math.Sqrt(Double.Parse(fristNumber)) ;
                return Ok(sum.ToString());
            }
            return BadRequest("Invalid Input");
        }

        private bool IsNumeric(string fristNumber)
        {
            double number;
            bool isNumber = double.TryParse(fristNumber, System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out number);
            return isNumber;
        }
    }
}
