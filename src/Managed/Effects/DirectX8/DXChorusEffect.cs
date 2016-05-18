namespace ManagedBass.DirectX8
{
    public sealed class DXChorusEffect : Effect<DXChorusParameters>
    {
        public DXChorusEffect(int Handle, int Priority = 0) : base(Handle, Priority) { }

        public DXChorusEffect(MediaPlayer player, int Priority = 0) : base(player, Priority) { }

        public DXWaveform Waveform
        {
            get { return Parameters.lWaveform; }
            set
            {
                Parameters.lWaveform = value;

                OnPropertyChanged();
            }
        }

        public double WetDryMix
        {
            get { return Parameters.fWetDryMix; }
            set
            {
                Parameters.fWetDryMix = (float)value;

                OnPropertyChanged();
            }
        }

        public double Depth
        {
            get { return Parameters.fDepth; }
            set
            {
                Parameters.fDepth = (float)value;

                OnPropertyChanged();
            }
        }

        public double Feedback
        {
            get { return Parameters.fFeedback; }
            set
            {
                Parameters.fFeedback = (float)value;

                OnPropertyChanged();
            }
        }

        public double Frequency
        {
            get { return Parameters.fFrequency; }
            set
            {
                Parameters.fFrequency = (float)value;

                OnPropertyChanged();
            }
        }

        public double Delay
        {
            get { return Parameters.fDelay; }
            set
            {
                Parameters.fDelay = (float)value;

                OnPropertyChanged();
            }
        }

        public DXPhase Phase
        {
            get { return Parameters.lPhase; }
            set
            {
                Parameters.lPhase = value;

                OnPropertyChanged();
            }
        }
    }
}