// ParkitectNexusClient
// Copyright 2015 Parkitect, Tim Potze

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace ParkitectModTools
{
    class ModtoolsMonoBehaviour : MonoBehaviour
    {
        public void Awake()
        {
            DontDestroyOnLoad(transform.gameObject);
        }

        private bool superSpeed = false;

        public void OnGUI()
        {
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
                superSpeed = !superSpeed;

                if (superSpeed)
                {
                    Time.timeScale = 10;
                }
                else
                {
                    Time.timeScale = 1;
                }
            }
        }

        public IEnumerator SpawnGuests()
        {
            for (;;)
            {
                GameController.Instance.park.spawnGuest();

                yield return new WaitForSeconds(1);
            }
        }
    }
}
