using System;
using System.Collections;

namespace Services.InternetConnection
{
    public interface IInternetConnectionModel
    {
        IEnumerator CheckInternetConnection();
        void AddOnlyOneObserverToHasInternetConnectionEvent(Action observer);
        void AddOnlyOneObserverToHasNotInternetConnectionEvent(Action observer);
    }
}