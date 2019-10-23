// -----------------------------------------------------------------------
// <copyright file="AdderModel.cs" company="bfa solutions ltd">
// Copyright (c) bfa solutions ltd. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Bfa.Common.WPF.Validations.ValidationTestGui
{
    using Bfa.Common.Binders;

    public class AdderModel : Bindable
    {
        private double? x;

        private double? y;

        public double? X
        {
            get => this.x;
            set => this.SetProperty(ref this.x, value);
        }

        public double? Y
        {
            get => this.y;
            set => this.SetProperty(ref this.y, value);
        }
    }
}