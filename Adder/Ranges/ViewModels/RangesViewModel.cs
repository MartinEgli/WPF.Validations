using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bfa.Common.WPF.Validations.ValidationTestGui.Ranges.ViewModels
{
    using Bfa.Common.Binders;

    using PropertyChangedEventArgs = System.ComponentModel.PropertyChangedEventArgs;

    public class RangesViewModel : Bindable
    {
        public RangesViewModel()
        {
            Model = new Model();
            Model.PropertyChanged += ModelOnPropertyChanged;
            RangesModel = new RangesModel();
            RangesModel.PropertyChanged += RangesModelOnPropertyChanged;
        }

        private void RangesModelOnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            this.OnPropertyChanged(e.PropertyName);
        }

        private void ModelOnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            this.OnPropertyChanged(e.PropertyName);
        }

        public Model Model { get; }
        public RangesModel RangesModel { get; }

        public double Value
        {
            get => this.Model.Value;
            set => this.Model.Value = value;
        }

        public double Max
        {
            get => this.RangesModel.Max;
            set => this.SetProperty(v => this.RangesModel.Max = v, this.RangesModel.Max, value);
        }

        public double Min
        {
            get => this.RangesModel.Min;
            set => this.RangesModel.Min = value;
        }
    }

    public class RangesModel : Bindable
    {
        private double max;

        private double min;

        public double Max
        {
            get => this.max;
            set => this.SetProperty(ref this.max, value);
        }

        public double Min
        {
            get => this.min;
            set => this.SetProperty(ref this.min, value);
        }
    }

    public class Model : Bindable
    {
        private double value;

        public double Value
        {
            get => this.value;
            set => this.SetProperty(ref this.value, value);
        }
    }
}