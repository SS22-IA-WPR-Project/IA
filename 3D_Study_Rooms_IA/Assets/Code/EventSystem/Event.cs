using System;


namespace Studyrooms
{
    public class Event
    {
        private event Action actionHere = delegate { };

        public void Invoke()
        {
            actionHere?.Invoke();
        }

        public void AddListener(Action data)
        {
            actionHere += data;
        }

        public void RemoveListener(Action data)
        {
            actionHere -= data;
        }

    }
}
