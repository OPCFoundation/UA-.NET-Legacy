/* ========================================================================
 * Copyright (c) 2005-2013 The OPC Foundation, Inc. All rights reserved.
 *
 * OPC Foundation MIT License 1.00
 * 
 * Permission is hereby granted, free of charge, to any person
 * obtaining a copy of this software and associated documentation
 * files (the "Software"), to deal in the Software without
 * restriction, including without limitation the rights to use,
 * copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the
 * Software is furnished to do so, subject to the following
 * conditions:
 * 
 * The above copyright notice and this permission notice shall be
 * included in all copies or substantial portions of the Software.
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
 * EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES
 * OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
 * NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT
 * HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY,
 * WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
 * FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
 * OTHER DEALINGS IN THE SOFTWARE.
 *
 * The complete license agreement can be found here:
 * http://opcfoundation.org/License/MIT/1.00/
 * ======================================================================*/

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

using Opc.Ua.Server;

namespace Opc.Ua.Sample
{
#if INCLUDE_Sample
    /// <summary>
    /// Defines additional methods for the Boiler type.
    /// </summary>
    public partial class Boiler
    {
        #region Initialization
        /// <summary cref="NodeSource.OnAfterCreate" />
        protected override void OnAfterCreate(object configuration)
        {            
            base.OnAfterCreate(configuration);

            m_unitId = (uint)Interlocked.Increment(ref m_unitCounter);
            
            InputPipe.DisplayName = GetDisplayName("Pipe", 1);
            Drum.DisplayName = GetDisplayName("Drum", 1);
            OutputPipe.DisplayName = GetDisplayName("Pipe", 2);
            InputPipe.FlowTransmitter1.DisplayName = GetDisplayName("FT", 1);
            InputPipe.Valve.DisplayName = GetDisplayName("Valve", 1);            
            Drum.LevelIndicator.DisplayName = GetDisplayName("LI", 1);
            OutputPipe.FlowTransmitter2.DisplayName = GetDisplayName("FT", 2);
            LevelController.DisplayName = GetDisplayName("LC", 1);
            FlowController.DisplayName = GetDisplayName("FC", 1);
            CustomController.DisplayName = GetDisplayName("CC", 1);

            // set the EU ranges for the I/O devices.
            InputPipe.FlowTransmitter1.Output.EURange.Value  = new Range(1000, 0);
            InputPipe.Valve.Input.EURange.Value  = new Range(100, 0);
            Drum.LevelIndicator.Output.EURange.Value  = new Range(10, 0);

            SetGetWheelsCallback(new BoilerType.GetWheelsMethodHandler(OnGetWheels));
        }

        /// <summary>
        /// Handles the GetWheels test method.
        /// </summary>
        public Wheel[] OnGetWheels(OperationContext context, NodeSource target, Vehicle vehicle)
        {
            GenericEvent e = GenericEvent.Construct(Server, new NodeId(ObjectTypes.MaintenanceEventType, GetNamespaceIndex(Namespaces.Sample)));
            
            e.InitializeNewEvent();
            e.Message.Value = "Some unknown problem.";
            e.SetProperty(new QualifiedName(BrowseNames.MustCompleteByDate, GetNamespaceIndex(Namespaces.Sample)), new DateTime(1987,2,3));
            
            ReportEvent(e);

            return vehicle.Wheels.ToArray();
        }

        /// <summary>
        /// Returns the display name for the component.
        /// </summary>
        private LocalizedText GetDisplayName(string prefix, int componentId)
        {
            return new LocalizedText(String.Format("{0}{1}{2:D3}", prefix, m_unitId, componentId));
        }
        #endregion

        #region Method Callbacks
        /// <summary>
        /// Called when the program changes state.
        /// </summary>
        public void Simulation_TransitionInitiated(OperationContext context, StateMachine machine, StateMachineTransitionEventArgs e)
        {
            lock (DataLock)
            {
                switch (e.ToState.Name)
                {
                    case Opc.Ua.BrowseNames.Ready:
                    {
                        if (m_timer != null)
                        {
                            m_timer.Dispose();
                            m_timer = null;
                        }

                        break;
                    }

                    case Opc.Ua.BrowseNames.Suspended:
                    case Opc.Ua.BrowseNames.Halted:
                    {
                        if (m_timer != null)
                        {
                            m_timer.Dispose();
                            m_timer = null;
                        }

                        break;
                    }

                    case Opc.Ua.BrowseNames.Running:
                    {
                        OnStartSimulation();
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// Starts the simulation.
        /// </summary>
        private void OnStartSimulation()
        {
            m_levelController.SetPoint.Value = 5;
            m_outputPipe.FlowTransmitter2.Output.Value = 500;

            uint simulationInterval = 250;

            if (simulationInterval < 250)
            {
                simulationInterval = 250;
            }
                            
            m_random = new Random((int)simulationInterval);

            if (m_timer != null)
            {
                m_timer.Dispose();
                m_timer = null;
            }

            m_timer = new Timer(new TimerCallback(OnUpdateSimulation), null, simulationInterval, simulationInterval);
        }

        /// <summary>
        /// Called when the server is shutting down.
        /// </summary>
        public void ServerStopping()
        {
            lock (DataLock)
            {
                if (m_timer != null)
                {
                    m_timer.Dispose();
                    m_timer = null;
                }
            }
        }
        
        /// <summary>
        /// A delegate used to receive notifications when the method is called.
        /// </summary>
        private string OnCalibrateFlowTransmitter(
            OperationContext context,
            NodeSource       target,
            double           scanRate,
            double           duration)
        {
            lock (DataLock)
            {
                AcmeFlowTransmitter flowTransmitter  = target as AcmeFlowTransmitter;

                if (flowTransmitter != null)
                {
                    flowTransmitter.CalibrationParameters.Value = new double[] { scanRate, duration };
                }

                return String.Format("Calibration completed at {0}", DateTime.UtcNow);
            }
        }
        #endregion

        #region Simulation Methods
        /// <summary>
        /// Rounds a value to the significate digits specified and adds a random perturbation.
        /// </summary>
        private double RoundAndPerturb(double value, byte significantDigits)
        {
            double offsetToApply = 0;

            if (value != 0)
            {
                // need to move all significate digits above the decimal point.
                double offset = significantDigits - Math.Log10(Math.Abs(value));

                offsetToApply = Math.Floor(offset);

                if (offsetToApply == offset)
                {
                    offsetToApply -= 1;
                }
            }
            
            // round value to significant digits.
            double perturbedValue = Math.Round(value * Math.Pow(10.0, offsetToApply));
                        
            // apply the perturbation.
            perturbedValue += (m_random.NextDouble()-0.5)*5;

            // restore original exponent.
            perturbedValue = Math.Round(perturbedValue)*Math.Pow(10.0, -offsetToApply);

            // return value.
            return perturbedValue;
        }
                
        /// <summary>
        /// Moves the value towards the target.
        /// </summary>
        private double Adjust(double value, double target, double step, Range range)
        {
            // convert percentage step to an absolute step if range is specified.
            if (range != null)
            {
                step = step * range.Magnitude;
            }
            
            double difference = target - value;

            if (difference < 0)
            {
                value -= step;

                if (value < target)
                {
                   return target;
                }
            }
            else
            {
                value += step;

                if (value > target)
                {
                   return target;
                }
            }

            return value;
        }
        
        /// <summary>
        /// Returns the value as a percentage of the range.
        /// </summary>
        private double GetPercentage(AnalogItem<double> value)
        {
            double percentage = value.Value;
            Range range = value.EURange;

            if (range != null)
            {
                percentage /= Math.Abs(range.High - range.Low);

                if (Math.Abs(percentage) > 1.0)
                {
                    percentage = 1.0;
                }
            }

            return percentage;
        }
        
        /// <summary>
        /// Returns the value as a percentage of the range.
        /// </summary>
        private double GetValue(double value, Range range)
        {
            if (range != null)
            {
                return value * range.Magnitude;
            }

            return value;
        }

        /// <summary>
        /// Updates the simulation.
        /// </summary>
        private void OnUpdateSimulation(object state)
        {
            try
            {
                lock (DataLock)
                {   
                    m_simulationCounter++;

                    // adjust level.
                    m_drum.LevelIndicator.Output.Value = Adjust(m_drum.LevelIndicator.Output.Value, m_levelController.SetPoint.Value, 0.1, m_drum.LevelIndicator.Output.EURange);
                     
                    // calculate inputs for custom controller. 
                    m_customController.Input1.Value = m_levelController.UpdateMeasurement(m_drum.LevelIndicator.Output);
                    m_customController.Input2.Value = GetPercentage(m_inputPipe.FlowTransmitter1.Output);
                    m_customController.Input3.Value = GetPercentage(m_outputPipe.FlowTransmitter2.Output);
                                    
                    // calculate output for custom controller. 
                    m_customController.ControlOut.Value = (m_customController.Input1.Value + m_customController.Input3.Value - m_customController.Input2.Value)/2;
                    
                    // update flow controller set point.
                    m_flowController.SetPoint.Value = GetValue((m_customController.ControlOut.Value+1)/2, m_inputPipe.FlowTransmitter1.Output.EURange);
                    
                    double error = m_flowController.UpdateMeasurement(m_inputPipe.FlowTransmitter1.Output);
                    
                    // adjust the input valve.
                    m_inputPipe.Valve.Input.Value = Adjust(m_inputPipe.Valve.Input.Value, (error>0)?100:0, 10, null);
                    
                    // adjust the input flow.
                    m_inputPipe.FlowTransmitter1.Output.Value = Adjust(m_inputPipe.FlowTransmitter1.Output.Value, m_flowController.SetPoint.Value , 0.6, m_inputPipe.FlowTransmitter1.Output.EURange);
                         
                    // add pertebations.
                    m_drum.LevelIndicator.Output.Value        = RoundAndPerturb(m_drum.LevelIndicator.Output.Value, 3);
                    m_inputPipe.FlowTransmitter1.Output.Value  = RoundAndPerturb(m_inputPipe.FlowTransmitter1.Output.Value, 3);
                    m_outputPipe.FlowTransmitter2.Output.Value = RoundAndPerturb(m_outputPipe.FlowTransmitter2.Output.Value, 3);
                }
            }
            catch (Exception e)
            {
                Utils.Trace(e, "Unexpected exception in Boiler similation.");
            }
        }
        #endregion

        #region Private Methods
        private uint m_unitId;     
        private Timer m_timer;
        private Random m_random; 
        private static long m_unitCounter;
        private long m_simulationCounter;
        #endregion
    }
#endif
}
