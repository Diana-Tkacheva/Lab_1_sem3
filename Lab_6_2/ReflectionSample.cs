using System;


namespace Lab_6_2
{
    [AttributeUsage(AttributeTargets.Property)]
    public class CustomAttribute: Attribute
    {
        public string Description { get; set; }
        public CustomAttribute() { }
        public CustomAttribute(string description)
        {
            Description = description;
        }
    }

    public class ReflectionSample
    {
        private readonly int _round;
        [CustomAttribute("My CustomAttribute")]
        public string Description { get; private set; }
        
        public ReflectionSample() { }
        public ReflectionSample(string description)
        {
            Description = description;
        }
        public ReflectionSample(string description, int round) : this(description)
        {
            _round = round;
            IsInitialized = true;
        }

        public bool IsInitialized { private set; get; }

        public string GetDescription()
        {
            return Description;
        }

        public int GetRound()
        {
            return _round;
        }

        public override string ToString()
        {
            return $"{Description}: {_round}";
        }
    }
}
