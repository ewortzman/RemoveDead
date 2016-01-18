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

        public override void OnCreated(IThreading threading)
        {
            _citizenManager = Singleton<CitizenManager>.instance;
            _buildingManager = Singleton<BuildingManager>.instance;

            base.OnCreated(threading);
        }

        public override void OnUpdate(float realTimeDelta, float simulationTimeDelta)
        {
            Citizen[] citizens = _citizenManager.m_citizens.m_buffer;
            //FastList<ushort> healthBuildings = _buildingManager.GetServiceBuildings(ItemClass.Service.HealthCare);

            for (uint i = 0; i < citizens.Length; i++)
            {
                Citizen citizen = citizens[i];

                if (citizen.Dead)
                {
                    _citizenManager.ReleaseCitizen(i);
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
