using System;
using ColossalFramework;
using ColossalFramework.Plugins;

using ICities;
using UnityEngine;

namespace RemoveDead
{
    public class RemoveDead : ThreadingExtensionBase
    {
        private CitizenManager _instance;

        public override void OnCreated(IThreading threading)
        {
            _instance = Singleton<CitizenManager>.instance;
            
            base.OnCreated(threading);
        }

        public override void OnBeforeSimulationTick()
        {
            //uint count = 0;
            //for (uint i = 0; i < _instance.m_citizens.m_buffer.Length; i++){
            //    Citizen c = _instance.m_citizens.m_buffer[i];
            //    if (c.Dead)
            //    {
            //        _instance.ReleaseCitizen(i);
            //        count++;
            //    }
            //}
            base.OnBeforeSimulationTick();
        }
    }

    public class MyModInfo : IUserMod
    {
        public string Name
        {
            get { return "RemoveDead"; }
        }

        public string Description
        {
            get { return "Removes all dead from all buildings, eliminating the need for deathcare."; }
        }
        
    }
}
