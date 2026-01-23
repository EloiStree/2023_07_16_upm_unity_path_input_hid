
using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;


namespace Eloi.HID
{
    public class HidMono_ObserverPlugUnplugDevices : GenericNewOldListMono<InputDevice>
{
    [ContextMenu("Refresh and notify")]
    public void RefreshAndNotify() {

        base.PushAndRefreshAndNotify(InputSystem.devices.ToArray());
    }
}
    [System.Serializable]
    public class TypeClampHistory : GenericClampHistory<string>
    {
        public void PushIn(System.Type typeValue)
        {
            PushIn(typeValue.ToString());
        }
    }

        public class GenericNewOldStringListMono : GenericNewOldListMono<string>
        {



        }
        public class GenericNewOldListMono<T> : MonoBehaviour
        {
            public GenericNewOldList<T> m_tracked;
            public TEvent m_onCurrent;
            public TEvent m_onAdded;
            public TEvent m_onRemoved;



            [System.Serializable]
            public class TEvent : UnityEvent<T[]> { }
            // Start is called before the first frame update
            public void PushAndRefresh(T[] newValue, bool andNotify)
            {
                m_tracked.RefreshComListInfo(newValue);
                if (andNotify)
                    Notify();
            }
            public void PushAndRefreshAndNotify(T[] givenList)
            {

                PushAndRefresh(givenList, true);
            }
            [ContextMenu("Refresh with current")]
            public void RefreshWithCurrent(bool andNotify)
            {
                m_tracked.RefreshComListInfo(m_tracked.m_currentList);
                if (andNotify)
                    Notify();
            }


            public void Notify()
            {
                m_onCurrent.Invoke(m_tracked.m_currentList);
                if (m_tracked.m_newList.Length > 0)
                    m_onAdded.Invoke(m_tracked.m_newList);
                if (m_tracked.m_lostList.Length > 0)
                    m_onRemoved.Invoke(m_tracked.m_lostList);
            }

        }

    }
