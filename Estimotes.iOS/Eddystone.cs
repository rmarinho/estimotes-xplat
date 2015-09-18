using System;
using Estimote;


namespace Estimotes {

    public class Eddystone : IEddystone {
        readonly Estimote.Eddystone native;

        public Eddystone(Estimote.Eddystone native) {
            this.native = native;
            this.Type = String.IsNullOrWhiteSpace(native.Url)
                ? EddystoneType.Uid
                : EddystoneType.Url;
        }


        public int Rssi => this.native.Rssi?.Int32Value ?? 0;
        public double Temperature => this.native.Telemetry?.Temperature?.FloatValue ?? 0;
        public EddystoneType Type { get; }
        public Proximity Proximity => this.native.Proximity.FromNative();
        public string Namespace => this.native.NamespaceID;
         public string Instance => this.native.InstanceID;
        public string MacAddress => this.native.MacAddress;
        public string Url => this.native.Url;
    }
}