﻿namespace ControleMedicamentos.ConsoleApp.Compartilhado
{
    public class GeradorId
    {
        private static int IdPacientes = 0;
        private static int IdMedicamentos = 0;

        public static int GerarIdPaciente()
        {
            return ++IdPacientes;
        }

        public static int GerarIdMedicamento()
        {
            return ++IdMedicamentos;
        }


    }
}
