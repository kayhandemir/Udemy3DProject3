using UdemyProje3.Abstracts.States;

namespace UdemyProje3.States
{
    public class StateTransformer
    {
        public IState To { get; }
        public IState From { get; }
        public System.Func<bool> Condition { get; }
        public StateTransformer(IState from, IState to, System.Func<bool> condition)
        {
            From = from;
            To = to;
            Condition = condition;
        }
    }
}

