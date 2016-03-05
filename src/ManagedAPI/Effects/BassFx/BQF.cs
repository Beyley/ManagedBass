﻿using ManagedBass.Dynamics;
using System.Runtime.InteropServices;

namespace ManagedBass.Effects
{
    [StructLayout(LayoutKind.Sequential)]
    public class BQFParameters : IEffectParameter
    {
        public BQFType lFilter = BQFType.AllPass;
        public float fCenter = 200f;
        public float fGain = 0;
        public float fBandwidth = 1f;
        public float fQ = 0;
        public float fS = 0;
        public FXChannelFlags lChannel = FXChannelFlags.All;

        public EffectType FXType => EffectType.BQF;
    }

    /// <summary>
    /// Used with <see cref="Bass.ChannelSetFX" />, <see cref="Bass.FXSetParameters" /> and <see cref="Bass.FXGetParameters" /> to retrieve and set the parameters of the DSP effect BiQuad filter.
    /// </summary>
    /// <remarks>
    /// BiQuad filters are second-order recursive linear filters.
    /// </remarks>
    public class BQFEffect : Effect<BQFParameters>
    {
        public BQFEffect(int Handle, BQFType BQFType) : base(Handle) { Parameters.lFilter = BQFType; }

        /// <summary>
        /// Gain in dB (-15...0...+15). Default 0dB (used only for PEAKINGEQ and Shelving filters).
        /// </summary>
        public double Gain
        {
            get { return Parameters.fGain; }
            set
            {
                Parameters.fGain = (float)value;
                Update();
            }
        }

        /// <summary>
        /// Bandwidth in octaves (0.1...4...n), Q is not in use (<see cref="Bandwidth"/> has priority over <see cref="Q"/>). Default = 1 (0=not in use).
        /// The bandwidth in octaves (between -3 dB frequencies for <see cref="BQFType.BandPass"/> and <see cref="BQFType.Notch"/> or between midpoint (dBgain/2) gain frequencies for PEAKINGEQ).
        /// </summary>
        public double Bandwidth
        {
            get { return Parameters.fBandwidth; }
            set
            {
                Parameters.fBandwidth = (float)value;
                Update();
            }
        }

        /// <summary>
        /// Cut-off frequency (Center in PEAKINGEQ and Shelving filters) in Hz (1...info.freq/2). Default = 200Hz.
        /// </summary>
        public double Center
        {
            get { return Parameters.fCenter; }
            set
            {
                Parameters.fCenter = (float)value;
                Update();
            }
        }

        /// <summary>
        /// EE kinda definition of Q (0.1...1...n), if <see cref="Bandwidth"/> is not in use. Default = 0.0 (0=not in use).
        /// </summary>
        public double Q
        {
            get { return Parameters.fQ; }
            set
            {
                Parameters.fQ = (float)value;
                Update();
            }
        }

        /// <summary>
        /// A shelf slope parameter (linear, used only with Shelving filters) (0...1...n). Default = 0.0.
        /// When 1, the shelf slope is as steep as you can get it and remain monotonically increasing or decreasing gain with frequency.
        /// </summary>
        public double S
        {
            get { return Parameters.fS; }
            set
            {
                Parameters.fS = (float)value;
                Update();
            }
        }
    }
}