using System;
using System.Collections.Generic;

namespace Studyrooms
{
    public class Event
    {
        private event Action actionHere = delegate { };
        private string i = "";
        private Vec3 v = new Vec3 { };
        

        public void Invoke()
        {
            actionHere?.Invoke();
        }

        public void Invoke(string i)
        {
            this.i = i;
            actionHere?.Invoke();
        }

        internal void Invoke(Vec3 v)
        {
            this.v = v;
            actionHere?.Invoke();
        }

        internal Vec3 getVec3()
        {
            return v;
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
