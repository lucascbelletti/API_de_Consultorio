﻿using API_Consultorio.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_Consultorio.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsultaController : ControllerBase
    {
        private readonly IConsultaService _consultaService;

        public ConsultaController(IConsultaService consultaService)
        {
            _consultaService = consultaService;
        }

        [HttpGet]
        [Route("/consultas/{data}")]
        public async Task<ActionResult<List<Consulta>>> GetConsultaPorData(DateTime data)
        {
            var consultas = await _consultaService.GetConsultasByData(data);
            if (consultas == null) { return NotFound("Não foram encontradas consultas nessa data!"); }
            return Ok(consultas);
        }
        [HttpGet]
        [Route("/medicos/{id}/consultas")]
        public async Task<ActionResult<List<Consulta>>> GetConsultaPorMedico(int id)
        {
            var consultas = await _consultaService.GetConsultasByMedico(id);
            if (consultas == null) { return NotFound("Não foram encontradas consultas com esse médico!"); }
            return Ok(consultas);
        }
        [HttpGet]
        [Route("/pacientes/{id}/consultas")]
        public async Task<ActionResult<List<Consulta>>> GetConsultaPorPaciente(int id)
        {
            var consultas = await _consultaService.GetConsultasByPaciente(id);
            if (consultas == null) { return NotFound("Não foram encontradas consultas desse paciente!"); }
            return Ok(consultas);
        }

        [HttpPost]
        public async Task<ActionResult<Consulta>> AgendarConsulta(ConsultaPostDTO consulta)
        {
            var consultaR = await _consultaService.AgendarConsulta(consulta);
            return Ok(consultaR);
        }

        [HttpDelete]
        public async Task<ActionResult<Consulta>> DeletarConsulta(int id)
        {
            var consultaR = await _consultaService.DeleteConsulta(id);
            if (consultaR == null) { return NotFound("Não foram encontradas consultas nesse id!"); }
            return Ok(consultaR);
        }
    }
}
