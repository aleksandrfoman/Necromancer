using System;
using System.Collections.Generic;
using UnityEngine;

namespace Content.Scripts.StateMachine
{
    public abstract class StateMachine<T, K> : MonoBehaviour
    {

        [System.Serializable]
        public class StateHolder
        {
            [SerializeField] private K stateType;
            [SerializeField] private StateAction<T> stateAction;

            public StateAction<T> StateAction => stateAction;

            public K StateType => stateType;
        }

        [SerializeField] private List<StateHolder> statesList = new List<StateHolder>();
        [SerializeField] private K startAction;

        [SerializeField] private StateAction<T> currentAction;
        
        [field:SerializeField] 
        private K lastStateKey;
        private T machine;
        protected T Machine => machine;
        
        public K CurrentStateType => lastStateKey;
        public Action OnChangeState;

        public void Init(T target)
        {
            machine = target;
            
            foreach (var state in statesList)
            {
                state.StateAction.Init(target);
            }
            StartAction(startAction);
        }

        public void StartAction(K type)
        {
            if (currentAction != null)
            {
                currentAction.EndState();
            }

            var action = statesList.Find(x => x.StateType.Equals(type));
            action.StateAction.ResetState();
            action.StateAction.StartState();
            
            lastStateKey = type;
            
            if (currentAction != action.StateAction)
            {
                OnChangeState?.Invoke();
            }

            currentAction = action.StateAction;

            
        }

        public void Update()
        {
            if (currentAction != null)
            {
                if (currentAction.IsEnded)
                {
                    StateSwitch();
                }
                else
                {
                    currentAction.ProcessState();   
                }
            }
        }

        public void FixedUpdate()
        {
            if (currentAction != null)
            {
                if(!currentAction.IsEnded)
                    currentAction.ProcessStateFixed();   
            }
        }

        public virtual void StateSwitch()
        {
            StartAction(startAction);
        }
        

        public T GetStateByType<T>() where T : StateAction<T>
        {
            foreach (var st in statesList)
            {
                if (st.StateAction as T != null)
                {
                    return st.StateAction as T;
                }
            }

            return null;
        }
    }
}
