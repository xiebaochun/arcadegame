using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WEngine
{
    public class TransitionHandler
    {
        public List<TransitionEntry> Transitions = new List<TransitionEntry>();
        public TransitionHandler()
        {

        }
        public void AddTransition(float start, float end, int time)
        {
            TransitionEntry te = new TransitionEntry();
            te.Enabled = true;

            te.StartValue = start;
            te.EndValue = end;
            te.TotalTime = time;
            te.CurrentTime = 0;
            te.CurrentValue = te.StartValue;
            te.Speed = (te.EndValue - te.StartValue) / te.TotalTime;
        }

        public void Update()
        {
            Transitions.RemoveAll(delTest);
            foreach (TransitionEntry te in Transitions)
            {
                te.CurrentValue += te.Speed;
                te.CurrentTime++;
                if (te.CurrentTime == te.TotalTime)
                {
                    te.Enabled = false;
                    te.CurrentValue = te.EndValue;
                }
            }
        }

        bool delTest(TransitionEntry te)
        {
            if (te.Enabled) return false;
            return true;
        }
    }

    public class TransitionEntry
    {
        public TransitionType Type = TransitionType.Default;

        public bool Enabled;
        public float CurrentValue;

        public float StartValue;
        public float EndValue;
        public int CurrentTime;
        public int TotalTime;
        public float Speed;
    }

    public enum TransitionType
    {
        Default,
        X,
        Y,
        Scale,
        Alpha

    }
}
