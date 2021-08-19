﻿namespace Domains.Helpers
{
    public static class CustomResponseMessage
    {
        public static class HTTP
        {
            public const string OK = "Operação realizada com sucesso!";
            public const string INTERNAL_SERVER_ERROR = "Erro interno no servidor.";
            public const string NOT_FOUND = "Recurso solicitado não encontrado.";
            public const string PRECONDITION_FAILED = "Alguma pré condição não foi atendida.";
        }

        public static class Clients
        {
            public static class ConditionValidations
            {
                public const string CLIENT_DOCUMENT_ALREADY_REGISTERED = "Documento já cadastrado.";
                public const string CLIENT_NOT_FOUND = "Cliente não encontrado.";
            }

            public static class DomainValidations {
                public const string REQUIRED_DOCUMENT = "Documento é obrigatório.";
                public const string LONG_NAME = "Nome muito longo.";
                public const string REQUIRED_NAME = "Nome é obrigatório.";
                public const string INVALID_AGE = "Idade inválida ou não informada.";
                public const string INVALID_GENDER = "Gênero inválido ou não informado.";
                public const string INVALID_PERSON = "Tipo da pessoa inválido ou não informado.";
            }
        }

        public static class Accounts
        {
            public static class ConditionValidations
            {
                public const string ACCOUNT_ALREADY_REGISTERED = "Conta já cadastrada.";
            }

            public static class DomainValidations
            {
                
                public const string INVALID_ACCOUNT_TYPE = "Tipo da conta inválido ou não informado.";
                public const string INVALID_BALANCE = "Valor inválido ou não informado.";
            }
        }
    }
}
