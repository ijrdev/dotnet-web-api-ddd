namespace Domains.Helpers
{
    public static class CustomResponseMessage
    {
        public const string OK = "Operação realizada com sucesso!";
        public const string INTERNAL_SERVER_ERROR = "Erro interno no servidor.";
        public const string NOT_FOUND = "Recurso não encontrado.";
        public const string PRECONDITION_FAILED = "Alguma pré condição não foi atendida.";

        public static class Clients
        {
            public const string CLIENT_CPF_ALREADY_REGISTERED = "CPF já cadastrado.";
        }
    }
}
