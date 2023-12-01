using NUnit.Framework;

namespace SampleProject.StepDefinitions
{
    [Binding]
    public sealed class CalculatorStepDefinitions
    {
      private int  firstNumber,secondnumber,sum,difference;

        [Given("the first number is (.*)")]
        public void GivenTheFirstNumberIs(int number)
        {
           this.firstNumber = number;

           
        }

        [Given("the second number is (.*)")]
        public void GivenTheSecondNumberIs(int number)
        {
            this.secondnumber = number;
        }

        [When("the two numbers are added")]
        public void WhenTheTwoNumbersAreAdded()
        {
            this.sum = this.firstNumber+ this.secondnumber;
        }

        [Then("the result should be (.*)")]
        public void ThenTheResultShouldBe(int result)
        {

            Assert.AreEqual(this.sum, result);
        }

        [When(@"the second number is subtract from the first number")]
        public void WhenTheSecondNumberIsSubtractFromTheFirstNumber()
        {

            this.difference = this.firstNumber - this.secondnumber;
            
        }

        [Then(@"the difference should be (.*)")]
        public void ThenTheDifferenceShouldBe(int result)
        {
            Assert.AreEqual(this.difference, result);
        }

    }
}