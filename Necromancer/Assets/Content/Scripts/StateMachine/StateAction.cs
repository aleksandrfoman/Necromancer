using UnityEngine;

namespace Content.Scripts.StateMachine
{
    public abstract class StateAction<T> : MonoBehaviour
    {
        
        private bool isEnded; 
        private T machine;
        
        public bool IsEnded => isEnded;

        public T Machine => machine;

        public void Init(T inputObject)
        {
            this.machine = inputObject;
        }


        public virtual void StartState()
        {
            isEnded = false;
        }

        public virtual void ProcessState(){}

        public virtual void ProcessStateFixed(){}
        public virtual void EndState()
        {
            isEnded = true;
        }
        public virtual void ResetState(){}
    }
}
