namespace Infrastructure.Context
{
    public class OracleOptions
    {
        public OracleOptions()
        {

        }
        public string ConnectionString { get; set; }
        public string Schema { get; set; }
    }
}
