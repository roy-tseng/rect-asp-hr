namespace INFOLINK.DBHelper
{
    
    public class SeedHandler : ISeedHandler
    {
        protected string entity = string.Empty;

        protected string connectString = string.Empty;

        public SeedHandler(string connectionString, string pathOFEntity)
        {
            this.entity = pathOFEntity;
            this.connectString = connectionString;
        }

        public virtual bool OpenDBConnection()
        {
            return false;
        }

        public virtual bool CloseConnection()
        {
            return false;
        }

        public virtual bool DumpDataToDB()
        {
            return false;
        }

        public virtual bool DumpDataToDB(string targetTable, bool isReset, out int effectedRow)
        {
            effectedRow = 0;
            return false;
        }
    }
}