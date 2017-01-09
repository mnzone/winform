using System;

namespace DelegateLibrary
{
    public delegate void CallbackMsg(String text);

    public delegate void UpdatedCallback(String result, int status);

    public delegate void UpdatedService(ServiceStatus status);
}