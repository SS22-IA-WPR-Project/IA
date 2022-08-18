using System;

namespace Studyrooms
{
    public class Event
    {
        private event Action actionHere = delegate { };
        private string i = "";

        public void Invoke()
        {
            actionHere?.Invoke();
        }

        public void Invoke(string i)
        {
            this.i = i;
            actionHere?.Invoke();
        }

        public string GetId()
        {
            return i;
        }

        public string AddListener(Action data)
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
