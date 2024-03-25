using TechTalk.SpecFlow;

namespace SpecflowToolkit.Transformers
{

    [Binding]
    public static class CustomTransformation
    {
        [StepArgumentTransformation(@"(.*) seconds")]
        [StepArgumentTransformation(@"(.*) second")]
        public static TimeSpan TimeSpanSecondsTransformer(int seconds) => TimeSpan.FromSeconds(seconds); 

        [StepArgumentTransformation(@"(.*) minute")]
        [StepArgumentTransformation(@"(.*) minutes")]
        public static TimeSpan TimeSpanMinutesTransformer(int minutes) => TimeSpan.FromMinutes(minutes);
    }
}
