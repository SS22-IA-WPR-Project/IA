using System;

namespace Studyrooms
{
    public class Event
    {
        private event Action actionHere = delegate { };
        private String i = "";

        public void Invoke()
        {
            actionHere?.Invoke();
        }

        public void Invoke(int i)
        {

            actionHere?.Invoke();
        }

        public String AddListener(Action data)
        {
            actionHere += data;
            return i;
        }


        public void RemoveListener(Action data)
        {
            actionHere -= data;
        }

    }
}
