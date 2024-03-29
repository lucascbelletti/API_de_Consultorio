﻿namespace API_Consultorio.Model
{
    public class Consulta
    {
        public int Id { get; set; }
        public DateTime Data { get; set; } = DateTime.Now;
        public string Descricao { get; set; } = string.Empty;
        public string Prescricao { get; set; } = string.Empty;

        public int MedicoID { get; set; }
        public Medico Medico { get; set; }

        public int PacienteID { get; set; }
        public Paciente Paciente { get; set; }
}
}
