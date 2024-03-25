using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SpecflowToolkit.Transformers
{
    [Binding]
    public static class ByTransformer
    {
        [StepArgumentTransformation(@"id (.*)")]
        public static By ByIdTransformer(string id) => By.Id(id);

        [StepArgumentTransformation(@"name (.*)")]
        public static By ByNameTransformer(string name) => By.Name(name);

        [StepArgumentTransformation(@"tag (.*)")]
        public static By ByTagTransformer(string tag) => By.TagName(tag);
        

        [StepArgumentTransformation(@"xpath (.*)")]
        public static By ByXpathTransformer(string xpath) => By.XPath(xpath);

        [StepArgumentTransformation(@"classe (.*)")]
        public static By ByClasseTransformer(string classe) => By.ClassName(classe);
    }
}
