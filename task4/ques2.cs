using System;

namespace Question2 {
    class Version {
        double versionNo { get; set; }
        public Version(double versionNo) {
            this.versionNo = versionNo;
        }
    }
    class Feature {
        private string name { set; get; }
        private bool isEnabled { set; get; }
        private Version minimumVersion { set; get; }
        public Feature(string name ,bool isEnabled ,Version minimumVersion) {
            this.name = name;
            this.isEnabled = isEnabled;
            this.minimumVersion = minimumVersion;
        }
        public void DisplayFeature() {
            System.Console.WriteLine($"Feature Name: {name}");
            System.Console.WriteLine($"Feature is { ( isEnabled ? "Enabled" : "Disabled" ) }");
            System.Console.WriteLine($"Feature Minimum Version: {minimumVersion}");
        }
    }
    class FeatureManager {
        private List<Feature> features;
        private Version sysVersion { set; get; }
        public FeatureManager(Version sysVersion) {
            features = new List<Feature> ();
            this.sysVersion = sysVersion;
        }
        public void AddFeature(Feature feature) {
            features.Add(feature);
        }
        private Feature Search(string featureName) {
            foreach (Feature feat in features ) {
                if (featureName == feat.name) {
                    return feat;
                }
            }
            return null;
        }
        public bool CanRun(string featureName) {
            Feature feature = Search(featureName);
            return sysVersion.versionNo >= feature.minimumVersion.versionNo;
        }
    }
    internal class Program {
        static void Main() {
            FeatureManager fMng = new FeatureManager(new Version(2.0));
            fMng.AddFeature(new Feature("Login",true,new Version(1.0)));
            fMng.AddFeature(new Feature("Export",true,new Version(1.7)));
            fMng.AddFeature(new Feature("AdminPanel",true,new Version(2.5)));

            if ( fMng.CanRun("Login") ) System.Console.WriteLine("Can login");
            else System.Console.WriteLine("Can't login");
        }
    }
}