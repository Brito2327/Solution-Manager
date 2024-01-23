namespace ClinicNest.Domain.Util
{
    public static class RegexPatterns
    {
        public const string Email = @"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$";
        public const string Data = @"^(0{0,1}[1-9]|[12][0-9]|3[01])[\/]([0]{0,1}[1-9]|1[012])[\/](\d{4})$";
        public const string Hora = @"^([0-1]\d|2[0-3]):([0-5]\d):([0-5]\d)$";
        public const string TelefoneApenasNumero = @"^\d{8,13}$";
        public const string CpfApenasNumero = @"^\d{11}$";
        public const string CpfRgApenasNumero = @"^\d{10,11}$";
        public const string ListaDeInteirosProgress = @"^(\d+)(,\d+)*$";
        public const string ListaDeStringProgress = @"^(\w+)(,\w+)*$";
        public const string CodigoContingencia = @"^\d{8}_\d{9}$";
    }
}
