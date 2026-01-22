using System.Collections.Generic;
using System.Linq;


namespace Eloi.HID
{
    [System.Serializable]
        public class GenericNewOldList<T>
        {

            public T[] m_currentList = new T[0];
            public T[] m_previousList = new T[0];
            public T[] m_newList = new T[0];
            public T[] m_lostList = new T[0];

            public void RefreshComListInfo(IEnumerable<T> newElement)
            {
                m_previousList = m_currentList.ToArray();
                m_currentList = newElement.Distinct().ToArray();
                m_newList = (m_currentList.ToArray().Except(m_previousList)).ToArray();
                m_lostList = (m_previousList.ToArray().Except(m_currentList)).ToArray();
            }


        }

    }


