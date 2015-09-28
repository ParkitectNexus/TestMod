using System.Collections;
using UnityEngine;

namespace TestMod
{
    class TestMod : MonoBehaviour
    {
        private bool _superSpeed;

        private void Awake()
        {
            DontDestroyOnLoad(transform.gameObject);
        }

        private void OnGUI()
        {
            GUI.Label(new Rect(475, 20, 250, 20), "The test mod has been loaded, yay!");

            if (Application.loadedLevel != 2)
                return;

            if (GUI.Button(new Rect(250, 10, 200, 20), "Spawn Guests!"))
            {
                StartCoroutine("SpawnGuests");
            }
            if (GUI.Button(new Rect(250, 30, 200, 20), "Stop spawning Guests!"))
            {
                StopCoroutine("SpawnGuests");
            }
            if (GUI.Button(new Rect(250, 50, 200, 20), "Give $1000"))
            {
                GameController.Instance.park.parkInfo.moneyTransaction(1000,
                    MonthlyTransactions.Transaction.PARK_ADMISSION);
            }
            if (GUI.Button(new Rect(250, 70, 200, 20), "Toggle superspeed (10x)"))
            {
                _superSpeed = !_superSpeed;

                Time.timeScale = _superSpeed ? 10 : 1;
            }
        }

        private IEnumerator SpawnGuests()
        {
            for (;;)
            {
                GameController.Instance.park.spawnGuest();

                yield return new WaitForSeconds(1);
            }
        }
    }
}
