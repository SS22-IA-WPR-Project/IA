using System;


namespace Studyrooms
{
    public static class SREvents
    {

        public static readonly Event sceneLoadClass = new Event();
        public static readonly Event sceneLoadSignUpToCharUi = new Event();
        public static readonly Event sceneLoadLogInToClass = new Event();
        public static readonly Event sceneLoadClassToGUI = new Event();
        //public static readonly Event startSceneLoad = new Event();
        public static readonly Event loadAvatar = new Event();
        public static readonly Event joinTable = new Event();
        //public static readonly Event exitTable = new Event();
    }
}