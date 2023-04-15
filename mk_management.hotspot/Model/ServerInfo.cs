namespace mk_management.hotspot.Model
{
    public class ModelBase
    {

        public string ErrorMsj = "";

        public ModelBase()
        {
            this.ErrorMsj = "Info. no recuperada";
        }

        public void SetError(string _error)
        {
            ErrorMsj = _error;
        }

        public void ClearError()
        {
            ErrorMsj = "";
        }

        public bool TieneError { get { return common.Utilerias.EsValorValido(ErrorMsj); } }
    }

    public class ServerInfo : ModelBase
    {
        internal string Id;
        internal string Nombre;
        internal string IP;
        internal int Puerto;
        internal string VersionSO;
        internal string Usuario;
        internal string Clave;

        public string getIP => IP;
        public int getPort => Puerto;
        public string getOsVersion => VersionSO;
        public string getUser => Usuario;
        public string getPwd => Clave;
    }
}
