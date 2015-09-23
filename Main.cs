// ParkitectNexusClient
// Copyright 2015 Parkitect, Tim Potze

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace ParkitectModTools
{
    public static class Main
    {
        public static void Load()
        {
            GameObject go = new GameObject();
            go.AddComponent<ModtoolsMonoBehaviour>();
        }
    }
}
