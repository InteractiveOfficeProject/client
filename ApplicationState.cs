using System.Threading;
using Cairo;

namespace InteractiveOfficeClient
{
    public abstract class ApplicationStateMachine
    {
        protected readonly MainWindow _context;

        public ApplicationStateMachine(MainWindow context)
        {
            _context = context;
        }

        private enum State {Paused, Working, Break};

        private State _state = State.Paused;

        public bool IsWorking()
        {
            return _state == State.Working;
        }

        public abstract void StartWorking();
        public abstract void StartNotifyBreak();
        public abstract void StartBreak();
        public abstract void StartNotifyWork();

    }
}