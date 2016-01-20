using System;
using ColossalFramework;
using ColossalFramework.Plugins;

using ICities;
using UnityEngine;

namespace RemoveDead
{
    public class RemoveDead : ThreadingExtensionBase
    {
        private CitizenManager _citizenManager;
        private BuildingManager _buildingManager;

        private float _delta = 0;

        public override void OnCreated(IThreading threading)
        {
            _citizenManager = Singleton<CitizenManager>.instance;
            _buildingManager = Singleton<BuildingManager>.instance;
            
            base.OnCreated(threading);
        }

        public override void OnUpdate(float realTimeDelta, float simulationTimeDelta)
        {
            _delta += simulationTimeDelta;
            
            if (_delta > 300) // run remover every 5 in-game minutes
            {
                _delta = 0;
                DebugOutputPanel.AddMessage(PluginManager.MessageType.Message, "iteration run");

                Citizen[] citizens = _citizenManager.m_citizens.m_buffer;
                
                int deadCount = 0;
                int citizenCount = 0;

                for (uint i = 0; i < citizens.Length; i++)
                {
                    Citizen citizen = citizens[i];

                    if (citizen.m_flags != Citizen.Flags.None) // Check if citizen struct has any flags (i.e. is the citizen initialized)
                    {
                        citizenCount++;
                        
                        if (citizen.Dead)
                        {
                            _citizenManager.ReleaseCitizen(i); // remove the citizen
                            deadCount++;
                        }
                    }
                }

                if (deadCount > 0)
                {
                    DebugOutputPanel.AddMessage(PluginManager.MessageType.Message, "Removed " + deadCount + " dead bodies out of " + citizenCount + " citizens");
                }
            }

            base.OnUpdate(realTimeDelta, simulationTimeDelta);
        }

        public override void OnReleased()
        {
            base.OnReleased();
        }
    }
}
