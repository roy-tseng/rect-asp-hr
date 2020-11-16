namespace INFOLINK.LineAPP.Notify
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Collections.Specialized;

    public interface ILineAction
    {
        Task Execute(NameValueCollection dataRepo);
    }
}
