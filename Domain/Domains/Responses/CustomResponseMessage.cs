﻿namespace Domain.Responses
{
    public static class CustomResponseMessage
    {
        public static class HTTP
        {
            public const string OK = "Operação realizada com sucesso!";
            public const string INTERNAL_SERVER_ERROR = "Erro interno no servidor.";
            public const string NOT_FOUND = "Recurso solicitado não encontrado.";
            public const string PRECONDITION_FAILED = "Alguma pré condição não foi atendida.";
            public const string FORBIDDEN = "Acesso negado.";
        }

        public static class Clients
        {
            public static class ConditionValidations
            {
                public const string DOCUMENT_ALREADY_REGISTERED = "Documento já cadastrado.";
                public const string CLIENT_NOT_FOUND = "Cliente não encontrado.";
                public const string INVALID_AGE = "Idade inválida.";
                public const string INVALID_GENDER = "Gênero inválido.";
                public const string INVALID_PERSON = "Tipo da pessoa inválido.";
                public const string INCORRECT_PASSWORD = "Senha incorreta.";
            }

            public static class DomainValidations {
                public const string REQUIRED_DOCUMENT = "Documento é obrigatório.";
                public const string REQUIRED_NAME = "Nome é obrigatório.";
                public const string LONG_NAME = "Nome muito longo.";
                public const string REQUIRED_AGE = "Idade é obrigatória.";
                public const string INVALID_AGE = "Idade inválida ou não informada.";
                public const string REQUIRED_GENDER = "Gênero é obrigatório.";
                public const string INVALID_GENDER = "Gênero inválido ou não informado.";
                public const string REQUIRED_PERSON = "Tipo da pessoa é obrigatório.";
                public const string INVALID_PERSON = "Tipo da pessoa inválido ou não informado.";
                public const string REQUIRED_EMAIL = "Email inválido ou não informado.";
                public const string LONG_EMAIL = "Email muito longo.";
                public const string INVALID_EMAIL = "Email invalido.";
                public const string REQUIRED_PASSWORD = "Senha inválida ou não informado.";
            }
        }

        public static class Accounts
        {
            public static class ConditionValidations
            {
                public const string ACCOUNT_ALREADY_REGISTERED = "Conta já cadastrada.";
                public const string INVALID_ACCOUNT_TYPE = "Tipo da conta inválido.";
            }

            public static class DomainValidations
            {
                
                public const string INVALID_ACCOUNT_TYPE = "Tipo da conta inválido ou não informado.";
                public const string REQUIRED_ACCOUNT_TYPE = "Tipo da conta é obrigatório.";
                public const string INVALID_BALANCE = "Valor inválido.";
                public const string REQUIRED_BALANCE = "Saldo é obrigatório.";
            }
        }

        public static class AccountsTransactions
        {
            public static class ConditionValidations
            {
                public const string ACCOUNT_NUMBER_NOT_FOUND = "Número da conta não encontrado.";
                public const string INSUFFICIENT_BALANCE = "Saldo insuficiente para realizar a operação.";
            }

            public static class DomainValidations
            {
                public const string REQUIRED_ACCOUNT_NUMBER_TO_TRANSFER = "Número da conta para transferir é obrigatório.";
                public const string REQUIRED_ACCOUNT_NUMBER_TO_RECEIVE = "Número da conta para receber é obrigatório.";
                public const string REQUIRED_VALUE = "Valor é obrigatório.";
                public const string INVALID_VALUE = "Valor inválido ou não informado.";
            }
        }
    }
}
