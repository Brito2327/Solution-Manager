namespace CooperDesp.Common
{
    public class RetornoBase
    {
        public RetornoBase()
        {
            Timeout = false;
        }

        public string Mensagem
        {
            get;
            set;
        }

        public bool Sucesso
        {
            get;
            set;
        }

        /// <summary>
        /// Indica que houve timeout na comunicação com a cip.
        /// </summary>
        public bool Timeout
        {
            get;
            set;
        }
    }
}