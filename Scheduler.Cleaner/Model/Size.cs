using Scheduler.Common.Enums;
using System;

namespace Scheduler.Cleaner.Model
{
    public struct Size
    {
        public Size(long lengthInBytes)
        {
            this.LengthInBytes = lengthInBytes;
        }

        public long LengthInBytes { get; private set; }

        public string GetSize(SizeUnits unit)
        {
            if (LengthInBytes == 0)
                return "0" + SizeUnits.B;

            if (unit == SizeUnits.Auto)
            {
                int place = Convert.ToInt32(Math.Floor(Math.Log(LengthInBytes, 1024)));
                double num = Math.Round(LengthInBytes / Math.Pow(1024, place), 2);
                return $"{(Math.Sign(LengthInBytes) * num)} {(SizeUnits)(place + 1)}";
            }
            else
            {
                double num = Math.Round(LengthInBytes / Math.Pow(1024, (int)unit - 1), 2);
                return $"{(Math.Sign(LengthInBytes) * num)} {unit}";
            }
        }

        public static implicit operator Size(long n)
        {
            return new Size(n);
        }
    }
}
