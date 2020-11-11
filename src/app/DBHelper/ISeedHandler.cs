
namespace INFOLINK.DBHelper
{
    using System;

    public interface ISeedHandler
    {
        bool DumpDataToDB(string pathSource);
    }
}
