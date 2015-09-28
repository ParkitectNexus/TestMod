using UnityEngine;

namespace TestMod
{
    public class Main : IMod
    {
        private GameObject _gameObject;

        #region Implementation of IMod

        public void onEnabled()
        {
            _gameObject = new GameObject();
            _gameObject.AddComponent<TestMod>();
        }

        public void onDisabled()
        {
            Object.Destroy(_gameObject);
        }

        public string Name
        {
            get { return "TestMod"; }
        }

        public string Description
        {
            get { return "TestMod"; }
        }

        #endregion
    }
}
