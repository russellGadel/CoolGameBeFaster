using System;
using JetBrains.Annotations;

namespace Services.InternetConnection
{
    public interface IInternetConnectionService
    {
        void CheckInternetConnection([CanBeNull] Action thenHasInternetConnection,
            [CanBeNull] Action thenHasNotInternetConnection);
    }
}