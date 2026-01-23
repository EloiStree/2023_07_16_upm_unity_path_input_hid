
using Eloi;
using Eloi.HID;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

public class HidMono_ObserverPlugUnplugHidPathString : GenericNewOldListMono<string>
{
    [ContextMenu("Refresh and notify")]
    public void RefreshAndNotify()
    {
        InputSystem.FlushDisconnectedDevices();
        base.PushAndRefreshAndNotify(InputSystem.devices.Select(k=>k.path).ToArray());
    }
}

