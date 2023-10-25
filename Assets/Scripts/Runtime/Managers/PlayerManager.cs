using Runtime.Controllers;
using Runtime.Data.UnityObjects;
using Runtime.Data.ValueObjects;
using Runtime.Signals;
using UnityEngine;

using Unity.VisualScripting;
using UnityEngine.Rendering.Universal;

namespace Runtime.Managers
{
    public class PlayerManager : MonoBehaviour
    {
        #region Self Variables

        #region Serialized Variables

        [SerializeField] private PlayerMovementController movementController;

        #endregion

        #region Peivate Variables

        private PlayerData _data;

        #endregion

        #endregion

        private void Awake()
        {
            GetPlayerData();
            SendDataToControllers();
        }

        private void GetPlayerData()
        { 
            _data = Resources.Load<CD_Player>("Data/CD_Player").Data;
        }
        
        private void SendDataToControllers()
        {
            movementController.SetMovementData(_data.MovementData);
        }

        private void OnEnable()
        {
            SubscribeEvents();
        }

        private void SubscribeEvents()
        {
            InputSignals.Instance.OnInputTaken += movementController.OnInputTaken;
        }
        
        private void UnSubscribeEvents()
        {
            InputSignals.Instance.OnInputTaken -= movementController.OnInputTaken;
        }
        
        private void OnDisable()
        {
            UnSubscribeEvents();
        }
        
    }
}