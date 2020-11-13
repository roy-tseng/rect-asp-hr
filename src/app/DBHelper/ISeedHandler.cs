
namespace INFOLINK.DBHelper
{
    using System;

    public interface ISeedHandler
    {
        bool DumpDataToDB(string targetTable, bool isReset,out int effectedRow);

        bool DumpDataToDB();

        bool OpenDBConnection();

        bool CloseConnection();
    }
}
